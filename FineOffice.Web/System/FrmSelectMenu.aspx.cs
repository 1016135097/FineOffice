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

public partial class System_FrmSelectMenu : PageBase
{
    FineOffice.BLL.SYS_MenuList menuBll = new FineOffice.BLL.SYS_MenuList();
    List<FineOffice.Modules.SYS_MenuList> authorityList = new List<FineOffice.Modules.SYS_MenuList>();
    List<FineOffice.Modules.SYS_MenuList> unEnabledList = new List<FineOffice.Modules.SYS_MenuList>();
    bool forPage = false;//是否为页面权限选择父级菜单

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnEnter.OnClientClick = tvwMenu.GetNoSelectionAlertReference("请选择菜单!");
            if (Request["forpage"] != null)
            {
                authorityList = menuBll.GetListAll();
                forPage = true;
            }
            else
            {
                authorityList = menuBll.GetList(s => s.IsModule == true);
            }
            tvwMenu_Bind();
            if (Request["id"] != null)
            {
                int id = int.Parse(Request["id"]);
                this.GetSubList(new FineOffice.Modules.SYS_MenuList { ID = id });
                TreeExpandNodes(tvwMenu.Nodes);
            }
        }
    }

    /// <summary>
    /// 取子节点
    /// </summary>
    /// <param name="authority"></param>
    private void GetSubList(FineOffice.Modules.SYS_MenuList authority)
    {
        unEnabledList.Add(authority);
        List<FineOffice.Modules.SYS_MenuList> tempList = authorityList.Where(s => s.ParentID == authority.ID).ToList();
        foreach (FineOffice.Modules.SYS_MenuList a in tempList)
        {
            GetSubList(a);
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
        FineUI.TreeNode node = tvwMenu.SelectedNode;
        PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(node.Text, node.NodeID) + ActiveWindow.GetHideReference());
    }

    /// <summary>
    /// 收起全部
    /// </summary>
    protected void btnCollapseAll_Click(object sender, EventArgs e)
    {
        tvwMenu.CollapseAllNodes();
    }

    /// <summary>
    /// 展开全部
    /// </summary>
    protected void btnExpandAll_Click(object sender, EventArgs e)
    {
        tvwMenu.ExpandAllNodes();
    }

    /// <summary>
    /// 取消选择
    /// </summary>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference("", "0") + ActiveWindow.GetHideReference());
    }

    /// <summary>
    /// 树菜单
    /// </summary>
    private void tvwMenu_Bind()
    {
        XDocument xdoc = CreateMenuXml();
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xdoc.Document.ToString());
        tvwMenu.DataSource = xmlDoc; // 绑定 XML 数据源到树控件
        tvwMenu.DataBind();
    }

    /// <summary>
    /// 创建树的XML
    /// </summary>
    private XDocument CreateMenuXml()
    {
        List<FineOffice.Modules.SYS_MenuList> tempList = authorityList.Where(d => d.ParentID == 0).OrderBy(s => s.Ordering).ToList();
        XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Tree"));
        foreach (FineOffice.Modules.SYS_MenuList temp in tempList)
        {
            XElement sub = new XElement("TreeNode", new object[] 
            { 
                new XAttribute("Text", temp.Text), 
                new XAttribute("IconUrl",temp.Icon==null?"":string.Format("~/icon/{0}.png",temp.Icon)),
                new XAttribute("NodeID",temp.ID),                
            });
            xdoc.Root.Add(sub);
            if (forPage && temp.IsModule.Value)
            {
                object[] xas = new object[] 
                { 
                    new XAttribute("Enabled", false), 
                };
                sub.Add(xas);
            }
            CreateXElement(sub, temp);
        }
        return xdoc;
    }

    /// <summary>
    /// 创建树第一级节点
    /// </summary>
    private void CreateXElement(XElement root, FineOffice.Modules.SYS_MenuList model)
    {
        List<FineOffice.Modules.SYS_MenuList> tempList = authorityList.Where(d => d.ParentID == model.ID).ToList();
        foreach (FineOffice.Modules.SYS_MenuList temp in tempList)
        {
            XElement xe = new XElement("TreeNode", new object[] 
            { 
                new XAttribute("Text", temp.Text), 
                new XAttribute("IconUrl",temp.Icon==null?"":string.Format("~/icon/{0}.png",temp.Icon)),
                new XAttribute("NodeID",temp.ID),                
            });
            if (forPage && temp.IsModule.Value)
            {
                object[] xas = new object[] 
                { 
                    new XAttribute("Enabled", false), 
                };
                xe.Add(xas);
            }
            root.Add(xe);
            CreateXElement(xe, temp);
        }
    }
}