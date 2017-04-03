using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineOffice.Web;
using FineUI;
using FineOffice.Modules.Helper;
using FineOffice.Common.ListHelper;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using FineOffice.Common.SerializeHelper;

public partial class System_FrmPageAuthority : PageBase
{
    FineOffice.BLL.SYS_MenuList menuBll = new FineOffice.BLL.SYS_MenuList();
    FineOffice.BLL.SYS_PageAuthority pageAuthorityBll = new FineOffice.BLL.SYS_PageAuthority();
    List<FineOffice.Modules.SYS_MenuList> authorityList = new List<FineOffice.Modules.SYS_MenuList>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            authorityList = menuBll.GetListAll();
            tvwMenu_Bind();
            authorityDataBind();

            btnModify.OnClientClick = authorityGrid.GetNoSelectionAlertReference(string.Format("请选择要复制的{0}！", authorityGrid.Title));
            btnDelete.OnClientClick = authorityGrid.GetNoSelectionAlertReference(string.Format("请选择要删除的{0}！", authorityGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中{0}吗！", authorityGrid.Title);
        }
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            authorityDataBind();
        }
    }

    /// <summary>
    /// 树菜单
    /// </summary>
    private void tvwMenu_Bind()
    {
        XDocument xdoc = CreateMenuXml();
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xdoc.Document.ToString());

        tvwMenu.DataSource = xmlDoc;// 绑定 XML 数据源到树控件
        tvwMenu.DataBind();
        tvwMenu.Nodes[0].Expanded = true;
    }

    /// <summary>
    /// 创建树的XML
    /// </summary>
    private XDocument CreateMenuXml()
    {
        List<FineOffice.Modules.SYS_MenuList> tempList = authorityList.Where(d => d.ParentID == 0).OrderBy(s => s.Ordering).ToList();
        XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Tree"));
        XElement root = new XElement("TreeNode", new object[] 
        { 
                new XAttribute("Text", "全部菜单"), 
                new XAttribute("EnablePostBack",true),
                new XAttribute("NodeID","0"),                
        });
        xdoc.Root.Add(root);
        foreach (FineOffice.Modules.SYS_MenuList temp in tempList)
        {
            XElement sub = new XElement("TreeNode", new object[] 
            { 
                new XAttribute("Text", temp.Text), 
                new XAttribute("EnablePostBack",true),
                new XAttribute("IconUrl",temp.Icon==null?"":string.Format("~/icon/{0}.png",temp.Icon)),
                new XAttribute("NodeID",temp.ID),                
            });
            root.Add(sub);
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
                new XAttribute("EnablePostBack",true),
                new XAttribute("IconUrl",temp.Icon==null?"":string.Format("~/icon/{0}.png",temp.Icon)),
                new XAttribute("NodeID",temp.ID),                
            });
            root.Add(xe);
            CreateXElement(xe, temp);
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        authorityWin.IFrameUrl = string.Format("../System/FrmModifyPageAuthority.aspx?id={0}&t=", authorityGrid.DataKeys[authorityGrid.SelectedRowIndex][0], DateTime.Now.Ticks);
        authorityWin.Title = "编辑";
        authorityWin.Hidden = false;
    }

    /// <summary>
    /// 刷新附件信息
    /// </summary>
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        authorityDataBind();
    }

    public void authorityDataBind()
    {
        GridColumn column = authorityGrid.FindColumn(authorityGrid.SortColumn);
        authority_Bind(column.SortField, authorityGrid.SortDirection);
    }

    private void authority_Bind(string sortField, string sortDirection)
    {
        ChangeTrackingList<EntitySearcher> tempList = new ChangeTrackingList<EntitySearcher>();
        FineUI.TreeNode node = tvwMenu.SelectedNode;

        if (node != null)
        {
            string nodes = GetSubNodes(node);
            nodes = nodes.Remove(nodes.Length - 1);
            EntitySearcher searcher = new EntitySearcher();
            searcher.Field = "MenuID";
            searcher.Operator = "in";
            searcher.Content = string.Format("({0})", nodes);
            tempList.Add(searcher);
        }
        ExtBindingList<FineOffice.Modules.SYS_PageAuthority> list = pageAuthorityBll.GetList(tempList).OrderByDescending(d => d.Ordering).ToBindingList();
        list.Sort(sortField, sortDirection);
        authorityGrid.DataSource = list;
        authorityGrid.DataBind();
    }

    protected void tvwMenu_NodeCommand(object sender, TreeCommandEventArgs e)
    {
        authorityDataBind();
    }

    /// <summary>
    /// 全局变量，递归取子节点ID
    /// </summary>
    StringBuilder strNodes = new StringBuilder();

    /// <summary>
    /// 取所有子节点
    /// </summary>
    private string GetSubNodes(FineUI.TreeNode node)
    {
        strNodes.Append(node.NodeID);
        strNodes.Append(",");
        foreach (FineUI.TreeNode temp in node.Nodes)
        {
            GetSubNodes(temp);
        }
        return strNodes.ToString();
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        authorityWin.IFrameUrl = "FrmNewPageAuthority.aspx?t=" + DateTime.Now.Ticks;
        authorityWin.Title = "新增";
        authorityWin.Hidden = false;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = authorityGrid.SelectedRowIndexArray;
            List<int> ids = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                ids.Add(int.Parse((authorityGrid.DataKeys[keys[i]][0]).ToString()));
            }
            pageAuthorityBll.Delete(ids);
            authorityDataBind();
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 展开树节点
    /// </summary>
    protected void btnExpandAll_Click(object sender, EventArgs e)
    {
        tvwMenu.ExpandAllNodes();
    }

    /// <summary>
    /// 收起树节点
    /// </summary>
    protected void btnCollapseAll_Click(object sender, EventArgs e)
    {
        tvwMenu.CollapseAllNodes();
    }

    /// <summary>
    /// 删除的方法
    /// </summary>
    protected void authorityGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        try
        {
            object[] keys = authorityGrid.DataKeys[e.RowIndex];
            int id = int.Parse(keys[0].ToString());
            if (e.CommandName == "delete")
            {
                pageAuthorityBll.Delete(new FineOffice.Modules.SYS_PageAuthority { ID = id });
                authorityDataBind();
            }
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }
}