using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using FineUI;
using FineOffice.Web;

public partial class HardDisk_FrmMoveFolder : PageBase
{
    FineOffice.BLL.HD_Folder folderBll = new FineOffice.BLL.HD_Folder();

    List<FineOffice.Modules.HD_Folder> folderList = new List<FineOffice.Modules.HD_Folder>();
    List<FineOffice.Modules.HD_Folder> unEnabledList = new List<FineOffice.Modules.HD_Folder> { };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int id = int.Parse(Request["id"]);
            hiddenID.Text = id.ToString();
            string rootName = "我的硬盘";

            if (Request["ispublic"] == "true")
            {
                folderList = folderBll.GetList(i => i.IsPublic == true);
                rootName = "公共硬盘";
            }
            else
            {
                folderList = folderBll.GetList(i => i.PersonnelID == CookiePersonnel.ID);
            }

            tvwFolder_Bind(rootName);
            btnClose.OnClientClick = ActiveWindow.GetHideReference();

            unEnabledList = folderBll.GetSubList(new FineOffice.Modules.HD_Folder { ID = id });
            TreeExpandNodes(tvwFolder.Nodes);
            btnEnter.OnClientClick = tvwFolder.GetNoSelectionAlertReference(string.Format("请选择要目标{0}！", tvwFolder.Title));
        }
    }

    /// <summary>
    /// 递归设置节点
    /// </summary>
    private void TreeExpandNodes(FineUI.TreeNodeCollection treeNodes)
    {
        foreach (FineUI.TreeNode node in treeNodes)
        {
            int id = int.Parse(node.NodeID);
            if (unEnabledList.Where(d => d.ID == id).Count() > 0)
            {
                node.Enabled = false;
            }
            TreeExpandNodes(node.Nodes);
        }
    }

    protected void btnEnter_Click(object sender, EventArgs e)
    {
        if (tvwFolder.SelectedNode != null)
        {
            try
            {
                int id = int.Parse(hiddenID.Text);
                FineOffice.Modules.HD_Folder model = folderBll.GetModel(d => d.ID == id);
                model.ParentID = int.Parse(tvwFolder.SelectedNodeID);
                folderBll.Update(model);
                PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("folder_close"));
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }
    }

    /// <summary>
    /// 收起全部
    /// </summary>
    protected void btnCollapseAll_Click(object sender, EventArgs e)
    {
        tvwFolder.CollapseAllNodes();
    }

    /// <summary>
    /// 展开全部
    /// </summary>
    protected void btnExpandAll_Click(object sender, EventArgs e)
    {
        tvwFolder.ExpandAllNodes();
    }

    /// <summary>
    /// 树菜单
    /// </summary>
    private void tvwFolder_Bind(string rootName)
    {
        XDocument xdoc = CreateMenuXml(rootName);
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xdoc.Document.ToString());

        // 绑定 XML 数据源到树控件
        tvwFolder.DataSource = xmlDoc;
        tvwFolder.DataBind();
        tvwFolder.Nodes[0].Expanded = true;
    }

    /// <summary>
    /// 创建树的XML
    /// </summary>
    private XDocument CreateMenuXml(string rootName)
    {

        XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Tree"));
        XElement xe = new XElement("TreeNode", new object[] 
        { 
               new XAttribute("Text", rootName),             
               new XAttribute("EnablePostBack",false),
               new XAttribute("NodeID","0"),
         });
        xdoc.Root.Add(xe);
        List<FineOffice.Modules.HD_Folder> tempList = folderList.Where(d => d.ParentID == 0).ToList();
        foreach (FineOffice.Modules.HD_Folder temp in tempList)
        {
            XElement sub = new XElement("TreeNode", new object[] 
            { 
                new XAttribute("Text", temp.FolderName), 
                new XAttribute("EnablePostBack",false),
                new XAttribute("NodeID",temp.ID),                
            });
            xe.Add(sub);
            CreateXElement(sub, temp);
        }
        return xdoc;
    }

    /// <summary>
    /// 创建树第一级节点
    /// </summary>
    private void CreateXElement(XElement root, FineOffice.Modules.HD_Folder model)
    {
        List<FineOffice.Modules.HD_Folder> tempList = folderList.Where(d => d.ParentID == model.ID).ToList();
        foreach (FineOffice.Modules.HD_Folder temp in tempList)
        {
            XElement xe = new XElement("TreeNode", new object[] 
            { 
                new XAttribute("Text", temp.FolderName), 
                new XAttribute("EnablePostBack",false),
                new XAttribute("NodeID",temp.ID),                
            });
            root.Add(xe);
            CreateXElement(xe, temp);
        }
    }
}