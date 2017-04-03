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

public partial class System_FrmRoleAuthority : PageBase
{
    FineOffice.BLL.SYS_MenuList menuBll = new FineOffice.BLL.SYS_MenuList();
    FineOffice.BLL.SYS_PageAuthority pageAuthorityBll = new FineOffice.BLL.SYS_PageAuthority();
    FineOffice.BLL.SYS_Role roleBll = new FineOffice.BLL.SYS_Role();

    List<FineOffice.Modules.SYS_MenuList> authorityList = new List<FineOffice.Modules.SYS_MenuList>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnAward.OnClientClick = roleGrid.GetNoSelectionAlertReference(string.Format("请选择要操作的{0}！", this.roleGrid.Title));
            authorityList = menuBll.GetListAll();
            tvwMenu_Bind();
            authorityDataBind();
            roleGrid_Bind();
        }
    }

    private void roleGrid_Bind()
    {
        List<FineOffice.Modules.SYS_Role> list = roleBll.GetListAll();
        roleGrid.DataSource = list;
        roleGrid.DataBind();
    }

    private void tvwMenu_Bind()
    {
        XDocument xdoc = CreateMenuXml();
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xdoc.Document.ToString());
        tvwMenu.DataSource = xmlDoc;// 绑定 XML 数据源到树控件
        tvwMenu.DataBind();
        tvwMenu.Nodes[0].Expanded = true;
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

    protected void twvMenu_NodeCheck(object sender, FineUI.TreeCheckEventArgs e)
    {
        if (!e.Node.Leaf)
            CheckTreeNode(e.Node.Nodes, e.Checked);

        if (e.Checked)
            CheckParentNode(e.Node);

        #region  些代码需要和authorityGrid_RowSelect一起使用，但其效率过低
        //List<int> ids = GetCheckedNodeIDs();
        //List<int> selectedRowIndexArray = authorityGrid.SelectedRowIndexArray.ToList();
        //List<int> newSelectedRowIndexArray = new List<int>();

        //for (int i = 0; i < authorityGrid.Rows.Count; i++)
        //{
        //    if (selectedRowIndexArray.Contains(i))
        //    {
        //        int menuID = int.Parse(authorityGrid.DataKeys[i][1].ToString());
        //        if (ids.Contains(menuID))
        //        {
        //            newSelectedRowIndexArray.Add(i);
        //        }
        //    }
        //}
        //authorityGrid.SelectedRowIndexArray = newSelectedRowIndexArray.ToArray();
        #endregion
    }

    #region 效率过低没有使用的代码
    /// <summary>
    /// 根据authorityGrid选中树
    /// </summary>
    //protected void authorityGrid_RowSelect(object sender, FineUI.GridRowSelectEventArgs e)
    //{
    //    string menuID = authorityGrid.DataKeys[e.RowIndex][1].ToString();
    //    FineUI.TreeNode node = GetMenuNode(tvwMenu.Nodes, menuID);
    //    node.Checked = true;
    //    CheckParentNode(node);
    //}

    /// <summary>
    /// 取出父菜单
    /// </summary>
    //protected FineUI.TreeNode GetMenuNode(FineUI.TreeNodeCollection nodes, string nodeid)
    //{
    //    FineUI.TreeNode node = nodes.Where(n => n.NodeID == nodeid).FirstOrDefault();
    //    if (node == null)
    //    {
    //        foreach (FineUI.TreeNode n in nodes)
    //        {
    //            node = GetMenuNode(n.Nodes, nodeid);
    //            if (node != null)
    //                break;
    //        }
    //    }
    //    return node;
    //}
    #endregion

    private void CheckParentNode(FineUI.TreeNode node)
    {
        if (node.ParentNode != null)
        {
            if (node.ParentNode.Checked)
                return;
            node.ParentNode.Checked = true;
            CheckParentNode(node.ParentNode);
        }
    }

    private void CheckTreeNode(FineUI.TreeNodeCollection nodes, bool isChecked)
    {
        foreach (FineUI.TreeNode node in nodes)
        {
            node.Checked = isChecked;
            if (!node.Leaf)
            {
                CheckTreeNode(node.Nodes, isChecked);
            }
        }
    }

    protected void tvwMenu_NodeCommand(object sender, TreeCommandEventArgs e)
    {
        authorityGrid.EnableRowSelect = false;
        SyncSelectedRowIndexArrayToHiddenField();
        authorityDataBind();
        UpdateSelectedRowIndexArray();
    }

    #region 保存authorityGrid选中的值

    /// <summary>
    /// 取出隐藏表单中的数据
    /// </summary>
    /// <returns></returns>
    private List<string> GetSelectedRowIndexArrayFromHiddenField()
    {
        string currentIDS = hiddenSelectedIDs.Text.Trim();
        return this.JsonToList<string>(currentIDS);
    }

    /// <summary>
    /// 保存数据到隐藏表单域
    /// </summary>
    private void SyncSelectedRowIndexArrayToHiddenField()
    {
        List<string> ids = GetSelectedRowIndexArrayFromHiddenField();

        List<int> selectedRows = new List<int>();
        if (authorityGrid.SelectedRowIndexArray != null && authorityGrid.SelectedRowIndexArray.Length > 0)
        {
            selectedRows = new List<int>(authorityGrid.SelectedRowIndexArray);
        }
        for (int i = 0; i < authorityGrid.Rows.Count; i++)
        {
            string id = authorityGrid.DataKeys[i][0].ToString();
            if (selectedRows.Contains(i))
            {
                if (!ids.Contains(id))
                    ids.Add(id);
            }
            else
            {
                if (ids.Contains(id))
                    ids.Remove(id);
            }
        }
        hiddenSelectedIDs.Text =ListToJson(ids);;
    }

    /// <summary>
    /// authorityGrid数据更换时，设置选中的值
    /// </summary>
    private void UpdateSelectedRowIndexArray()
    {
        List<string> ids = GetSelectedRowIndexArrayFromHiddenField();
        List<int> nextSelectedRowIndexArray = new List<int>();

        for (int i = 0; i < authorityGrid.Rows.Count; i++)
        {
            string id = authorityGrid.DataKeys[i][0].ToString();
            if (ids.Contains(id))
            {
                nextSelectedRowIndexArray.Add(i);
            }
        }
        authorityGrid.SelectedRowIndexArray = nextSelectedRowIndexArray.ToArray();
    }
    #endregion

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
                new XAttribute("EnableCheckBox", true),
                new XAttribute("EnablePostBack",true),
                new XAttribute("AutoPostBack",true),
                new XAttribute("NodeID","0"),                
        });
        xdoc.Root.Add(root);
        foreach (FineOffice.Modules.SYS_MenuList temp in tempList)
        {
            XElement sub = new XElement("TreeNode", new object[] 
            { 
                new XAttribute("Text", temp.Text), 
                new XAttribute("EnableCheckBox", true),
                new XAttribute("AutoPostBack",true),
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
                new XAttribute("EnableCheckBox", true),
                new XAttribute("AutoPostBack",true),
                new XAttribute("EnablePostBack",true),
                new XAttribute("IconUrl",temp.Icon==null?"":string.Format("~/icon/{0}.png",temp.Icon)),
                new XAttribute("NodeID",temp.ID),                
            });
            root.Add(xe);
            CreateXElement(xe, temp);
        }
    }

    //==========================以下为按钮方法======================//
    /// <summary>
    /// 刷新附件信息
    /// </summary>
    protected void btnRefresh_Click(object sender, EventArgs e)
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
    /// 全选Grid
    /// </summary>
    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        authorityGrid.SelectAllRows();
    }

    /// <summary>
    /// 返选Grid
    /// </summary>
    protected void btnInverse_Click(object sender, EventArgs e)
    {
        List<int> ids = authorityGrid.SelectedRowIndexArray.ToList();
        List<int> newSelectedRowIndexArray = new List<int>();

        for (int i = 0; i < authorityGrid.Rows.Count; i++)
        {
            if (!ids.Contains(i))
                newSelectedRowIndexArray.Add(i);
        }
        authorityGrid.SelectedRowIndexArray = newSelectedRowIndexArray.ToArray();
    }

    protected List<int> GetCheckedNodeIDs()
    {
        FineUI.TreeNode[] nodes = tvwMenu.GetCheckedNodes();
        List<int> ids = new List<int>();

        foreach (FineUI.TreeNode node in nodes)
        {
            ids.Add(int.Parse(node.NodeID));
        }
        return ids;
    }

    protected void roleGrid_RowSelect(object sender, FineUI.GridRowSelectEventArgs e)
    {
        int roleID = int.Parse(roleGrid.DataKeys[e.RowIndex][0].ToString());
        FineOffice.Modules.SYS_Role model = roleBll.GetModel(r => r.ID == roleID);
        hiddenSelectedIDs.Text = model.AuthorityList;
        hiddenSelectedNodes.Text = model.MenuList;
        List<int> selectNodes = this.JsonToList<int>(model.MenuList);
        SelectRoleCheckTreeNode(tvwMenu.Nodes, selectNodes);

        this.UpdateSelectedRowIndexArray();
    }

    private void SelectRoleCheckTreeNode(FineUI.TreeNodeCollection nodes, List<int> selectNodes)
    {
        foreach (FineUI.TreeNode node in nodes)
        {
            if (selectNodes.Contains(int.Parse(node.NodeID)))
                node.Checked = true;
            else
                node.Checked = false;
            SelectRoleCheckTreeNode(node.Nodes, selectNodes);
        }
    }

    protected void btnAwardRole_Click(object sender, EventArgs e)
    {
        int roleID = int.Parse(roleGrid.DataKeys[roleGrid.SelectedRowIndex][0].ToString());
        string roleName = roleGrid.DataKeys[roleGrid.SelectedRowIndex][1].ToString();
        FineOffice.Modules.SYS_Role model = roleBll.GetModel(r => r.ID == roleID);
        List<int> menus = GetCheckedNodeIDs();
        model.MenuList = JsonSerialize.Serialize(menus);

        List<int> authoritys = new List<int>();
        int[] selectArray = authorityGrid.SelectedRowIndexArray;
        for (int i = 0; i < selectArray.Length; i++)
        {
            authoritys.Add(int.Parse(authorityGrid.DataKeys[selectArray[i]][0].ToString()));
        }
        model.AuthorityList = JsonSerialize.Serialize(authoritys);
        roleBll.Update(model);
        Alert.Show(string.Format("角色-{0}，授权成功！", roleName));
    }
}