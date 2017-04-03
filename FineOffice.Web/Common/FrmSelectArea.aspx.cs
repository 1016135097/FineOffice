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

public partial class Common_FrmSelectArea : PageBase
{
    FineOffice.BLL.CRM_Area areaBll = new FineOffice.BLL.CRM_Area();
    List<FineOffice.Modules.CRM_Area> areaList = new List<FineOffice.Modules.CRM_Area>();

    List<FineOffice.Modules.CRM_Area> unEnabledList = new List<FineOffice.Modules.CRM_Area>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            tvwArea_Bind();
            if (Request["ID"] != null)
            {
                int id = int.Parse(Request["ID"]);
                unEnabledList = areaBll.GetSubList(new FineOffice.Modules.CRM_Area { ID = id });
                TreeExpandNodes(tvwArea.Nodes);
            }
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
        if (tvwArea.SelectedNode != null)
        {
            FineUI.TreeNode node = tvwArea.SelectedNode;
            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(node.Text, node.NodeID) + ActiveWindow.GetHideReference());
        }
    }

    /// <summary>
    /// 收起全部
    /// </summary>
    protected void btnCollapseAll_Click(object sender, EventArgs e)
    {
        tvwArea.CollapseAllNodes();
    }

    /// <summary>
    /// 展开全部
    /// </summary>
    protected void btnExpandAll_Click(object sender, EventArgs e)
    {
        tvwArea.ExpandAllNodes();
    }

    /// <summary>
    /// 取消选择
    /// </summary>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference("", "") + ActiveWindow.GetHideReference());
    }

    /// <summary>
    /// 绑定地区树控件
    /// </summary>
    private void tvwArea_Bind()
    {
        areaList = areaBll.GetListAll();
        List<FineOffice.Modules.CRM_Area> tempList = areaList.Where(a => a.ParentID == 0).OrderBy(t => t.Ordering).ToList();
        XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Tree"));

        foreach (FineOffice.Modules.CRM_Area model in tempList)
        {
            XElement xe = new XElement("TreeNode", new object[] 
            { 
                new XAttribute("Text", model.Area),
                new XAttribute("SingleClickExpand", false),
                new XAttribute("NodeID",model.ID)
            });
            xdoc.Root.Add(xe);
            CreateXElement(xe, model);
        }
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xdoc.Document.ToString());
        tvwArea.DataSource = xmlDoc;
        tvwArea.DataBind();
    }

    /// <summary>
    /// 创建地区的子节点
    /// </summary>
    private void CreateXElement(XElement root, FineOffice.Modules.CRM_Area model)
    {
        List<FineOffice.Modules.CRM_Area> tempList = areaList.Where(a => a.ParentID == model.ID).OrderBy(t => t.Ordering).ToList();
        foreach (FineOffice.Modules.CRM_Area temp in tempList)
        {
            XElement xe = new XElement("TreeNode", new object[] 
            { 
                new XAttribute("Text", temp.Area),
                new XAttribute("SingleClickExpand", false),
                new XAttribute("NodeID",temp.ID),                
            });
            root.Add(xe);
            CreateXElement(xe, temp);
        }
    }
}