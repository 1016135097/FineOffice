using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineOffice.Web;
using FineUI;
using System.Data;
using System.Text;
using FineOffice.Modules.Helper;
using FineOffice.Common.ListHelper;
using System.Xml;
using System.Xml.Linq;

public partial class WorkRun_FrmChooseFlow : PageBase
{
    FineOffice.BLL.OA_FlowAuthority flowBll = new FineOffice.BLL.OA_FlowAuthority();
    FineOffice.BLL.OA_FlowSort sortBll = new FineOffice.BLL.OA_FlowSort();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitTreeMenu();
            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;
            GridColumn column = flowGrid.FindColumn(flowGrid.SortColumn);
            flowGrid_Bind(changeTrackingList, column.SortField, flowGrid.SortDirection);
            btnTask.OnClientClick = flowGrid.GetNoSelectionAlertReference(string.Format("请选择请选择要操作的{0}！", flowGrid.Title));
            btnFlowProcess.OnClientClick = flowGrid.GetNoSelectionAlertReference(string.Format("请选择请选择要操作的{0}！", flowGrid.Title));
        }
        if (Request.Form["__EVENTARGUMENT"] != null && Request.Form["__EVENTARGUMENT"].Contains('&'))
        {
            string runProcess = Request.Form["__EVENTARGUMENT"].Split('&')[1];
            string tabID = "_HandleRunProcess" + runProcess;
            PageContext.RegisterStartupScript("openTab('" + tabID + "','流程办理-" +
               flowGrid.DataKeys[flowGrid.SelectedRowIndex][2] + "','WorkRun/FrmHandleRunProcess.aspx?TabID=" + tabID + "&RunProcess=" + runProcess + "');");
            PageContext.RegisterStartupScript("parent.refreshRunProcess();");
        }
    }

    protected void btnFlowProcess_Click(object sender, EventArgs e)
    {
        try
        {
            PageContext.RegisterStartupScript("openTab('FlowView','查看流程-" +
                flowGrid.DataKeys[flowGrid.SelectedRowIndex][2] + "','WorkFlow/FrmFlowView.aspx?ID=" +
                flowGrid.DataKeys[flowGrid.SelectedRowIndex][0] + "');");
        }
        catch (Exception ex)
        {
            FineUI.Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 新建流程
    /// </summary>
    protected void btnTask_Click(object sender, EventArgs e)
    {
        try
        {
            newWorkWin.IFrameUrl = string.Format("FrmNewWorkRun.aspx?ID={0}", flowGrid.DataKeys[flowGrid.SelectedRowIndex][0]);
            newWorkWin.Hidden = false;
        }
        catch (Exception ex)
        {
            FineUI.Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 树菜单
    /// </summary>
    private void InitTreeMenu()
    {
        XDocument xdoc = CreateMenuXml();
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xdoc.Document.ToString());

        // 绑定 XML 数据源到树控件
        tvwSort.DataSource = xmlDoc;
        tvwSort.DataBind();
        tvwSort.ExpandAllNodes();
    }

    /// <summary>
    /// 创建树的XML
    /// </summary>
    private XDocument CreateMenuXml()
    {
        List<FineOffice.Modules.OA_FlowSort> tempList = sortBll.GetListAll();
        XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Tree"));
        XElement xe = new XElement("TreeNode", new object[] 
        { 
               new XAttribute("Text", "全部分类"),             
               new XAttribute("EnablePostBack",true),
               new XAttribute("NodeID","0"),
         });
        xdoc.Root.Add(xe);
        CreateXElement(xe);
        return xdoc;
    }

    /// <summary>
    /// 创建树的子节点
    /// </summary>
    private void CreateXElement(XElement root)
    {
        List<FineOffice.Modules.OA_FlowSort> tempList = sortBll.GetListAll();
        foreach (FineOffice.Modules.OA_FlowSort temp in tempList)
        {
            XElement xe = new XElement("TreeNode", new object[] 
            { 
                new XAttribute("Text", temp.FlowSortName), 
                new XAttribute("EnablePostBack",true),
                new XAttribute("NodeID",temp.ID),                
            });
            root.Add(xe);
        }
    }

    protected void tvwSort_NodeCommand(object sender, TreeCommandEventArgs e)
    {
        btnFind_Click(null, null);
    }

    /// <summary>
    /// 展开树节点
    /// </summary>
    protected void btnExpandAll_Click(object sender, EventArgs e)
    {
        tvwSort.ExpandAllNodes();
    }

    protected void btnCollapseAll_Click(object sender, EventArgs e)
    {
        tvwSort.CollapseAllNodes();
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = flowGrid.FindColumn(flowGrid.SortColumn);
        flowGrid_Bind(changeTrackingList, column.SortField, flowGrid.SortDirection);
    }

    /// <summary>
    /// 刷新分类
    /// </summary>
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        tvwSort.Items.Clear();
        InitTreeMenu();
    }

    /// <summary>
    /// 刷新流程
    /// </summary>
    protected void btnRefreshFlow_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = flowGrid.FindColumn(flowGrid.SortColumn);
        flowGrid_Bind(changeTrackingList, column.SortField, flowGrid.SortDirection);
    }

    #region flowGrid_Bind

    private void flowGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string sortDirection)
    {
        ChangeTrackingList<EntitySearcher> trackingList = new ChangeTrackingList<EntitySearcher>();
        foreach (EntitySearcher s in changeTrackingList)
        {
            trackingList.Add(s);
        }

        EntitySearcher search = new EntitySearcher();
        search.Field = "Stop";
        search.Relation = "AND";
        search.Operator = "=";
        search.Content = "1";
        trackingList.Add(search);

        if (this.CookiePersonnel != null)
        {
            search = new EntitySearcher();
            search.Field = "PersonnelID";
            search.LeftParentheses = "(";
            search.Relation = "OR";
            search.Operator = "=";
            search.Content = this.CookiePersonnel.ID.ToString();
            trackingList.Add(search);

            search = new EntitySearcher();
            search.Field = "DepartmentID";
            search.RightParentheses = ")";
            search.Relation = "OR";
            search.Operator = "=";
            search.Content = this.CookiePersonnel.DepartmentID.ToString();
            trackingList.Add(search);
        }

        flowGrid.RecordCount = flowBll.GetCount(trackingList);
        ExtBindingList<FineOffice.Modules.OA_Flow> list = flowBll.GetList(trackingList, this.flowGrid.PageIndex, this.flowGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, sortDirection);
        flowGrid.DataSource = list;
        flowGrid.DataBind();
    }

    #endregion

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void flowGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        flowGrid_Bind(changeTrackingList, e.SortField, e.SortDirection);
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void flowGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        flowGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = flowGrid.FindColumn(flowGrid.SortColumn);
        flowGrid_Bind(changeTrackingList, column.SortField, flowGrid.SortDirection);
    }

    protected void btnFind_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        EntitySearcher search = new EntitySearcher();
        search.Field = "FlowName";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtFlowName.Text;
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "FlowDesc";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtFlowDesc.Text;
        changeTrackingList.Add(search);

        FineUI.TreeNode node = tvwSort.SelectedNode;
        if (node.NodeID != "0")
        {
            search = new EntitySearcher();
            search.Field = "SortID";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = tvwSort.SelectedNodeID;
            changeTrackingList.Add(search);
        }

        ViewState["sql"] = changeTrackingList;
        GridColumn column = flowGrid.FindColumn(flowGrid.SortColumn);
        flowGrid_Bind(changeTrackingList, column.SortField, flowGrid.SortDirection);
    }
}
