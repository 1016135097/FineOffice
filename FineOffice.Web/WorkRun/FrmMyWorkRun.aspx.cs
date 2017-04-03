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

public partial class WorkRun_FrmMyWorkRun : PageBase
{
    FineOffice.BLL.OA_FlowRun flowRunBll = new FineOffice.BLL.OA_FlowRun();
    FineOffice.BLL.OA_FlowSort sortBll = new FineOffice.BLL.OA_FlowSort();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            this.flowGrid.PageIndex = 0;
            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;
            GridColumn column = flowGrid.FindColumn(flowGrid.SortColumn);
            flowGrid_Bind(changeTrackingList, column.SortField, flowGrid.SortDirection);
        }
    }

    private void LoadData()
    {
        List<FineOffice.Modules.OA_FlowSort> sortList = sortBll.GetListAll();
        ddlSort.Items.Clear();
        FineUI.ListItem li = new FineUI.ListItem();
        li.Text = "<请选择>";
        ddlSort.Items.Add(li);
        foreach (FineOffice.Modules.OA_FlowSort sort in sortList)
        {
            FineUI.ListItem item = new FineUI.ListItem();
            item.Text = sort.FlowSortName;
            item.Value = sort.ID.ToString();
            ddlSort.Items.Add(item);
        }
    }

    private void flowGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string sortDirection)
    {
        ChangeTrackingList<EntitySearcher> trackingList = new ChangeTrackingList<EntitySearcher>();
        foreach (EntitySearcher s in changeTrackingList)
        {
            trackingList.Add(s);
        }
        if (this.CookiePersonnel != null)
        {
            EntitySearcher search = new EntitySearcher();
            search = new EntitySearcher();
            search.Field = "Creator";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = this.CookiePersonnel.ID.ToString();
            trackingList.Add(search);
        }

        flowGrid.RecordCount = flowRunBll.GetCount(trackingList);
        ExtBindingList<FineOffice.Modules.OA_FlowRun> list = flowRunBll.GetList(trackingList, this.flowGrid.PageIndex, this.flowGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, sortDirection);
        flowGrid.DataSource = list;
        flowGrid.DataBind();      
    }

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
        this.flowGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = flowGrid.FindColumn(flowGrid.SortColumn);
        flowGrid_Bind(changeTrackingList, column.SortField, flowGrid.SortDirection);
    }

    /// <summary>
    /// 清空查找信息
    /// </summary>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        dtpBegin.Text = "";
        dtpEnd.Text = "";
        txtWorkName.Text = "";
        ddlSort.SelectedIndex = 0;
        btnFind_Click(null, null);
    }

    /// <summary>
    /// 刷新分类
    /// </summary>
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = flowGrid.FindColumn(flowGrid.SortColumn);
        flowGrid_Bind(changeTrackingList, column.SortField, flowGrid.SortDirection);
    }

    /// <summary>
    /// 查询职员信息
    /// </summary>
    protected void btnFind_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        EntitySearcher search = new EntitySearcher();
        search.Field = "WorkName";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtWorkName.Text;
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "WorkNO";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtWorkNO.Text;
        changeTrackingList.Add(search);

        if (ddlSort.SelectedValue.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "SortID";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = ddlSort.SelectedValue;
            changeTrackingList.Add(search);
        }

        if (dtpBegin.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "CreateTime";
            search.Relation = "AND";
            search.Operator = ">=";
            search.Content = dtpBegin.Text;
            changeTrackingList.Add(search);
        }

        if (dtpEnd.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "CreateTime";
            search.Relation = "AND";
            search.Operator = "<=";
            search.Content = dtpEnd.Text;
            changeTrackingList.Add(search);
        }

        ViewState["sql"] = changeTrackingList;
        GridColumn column = flowGrid.FindColumn(flowGrid.SortColumn);
        flowGrid_Bind(changeTrackingList, column.SortField, flowGrid.SortDirection);
    }
}
