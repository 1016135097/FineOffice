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

public partial class WorkRun_FrmToHandleList : PageBase
{
    FineOffice.BLL.OA_FlowRunProcess runProcessBll = new FineOffice.BLL.OA_FlowRunProcess();
    FineOffice.BLL.OA_FlowSort sortBll = new FineOffice.BLL.OA_FlowSort();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            this.workGrid.PageIndex = 0;
            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;
            GridColumn column = workGrid.FindColumn(workGrid.SortColumn);
            workGrid_Bind(changeTrackingList, column.SortField, workGrid.SortDirection);

            btnChoose.OnClientClick = frmPersonnel.GetSaveStateReference(txtCreator.ClientID, hiddenField.ClientID)
                                                    + frmPersonnel.GetShowReference("../Common/FrmMultiPersonnel.aspx?selected=" + hiddenField.Text);
        }
        //子窗体回发事件
        if (Request.Form["__EVENTARGUMENT"] == "transmitClose")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = workGrid.FindColumn(workGrid.SortColumn);
            workGrid_Bind(changeTrackingList, column.SortField, workGrid.SortDirection);
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

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = workGrid.FindColumn(workGrid.SortColumn);
        workGrid_Bind(changeTrackingList, column.SortField, workGrid.SortDirection);
    }

    /// <summary>
    /// 处理事件
    /// </summary>
    protected void workGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "handle")
        {
            try
            {
                object id = workGrid.DataKeys[workGrid.SelectedRowIndex][0];
                string tabID = "_HandleRunProcess" + id;
                object[] keys = workGrid.DataKeys[e.RowIndex];
                PageContext.RegisterStartupScript("openTab('" + tabID + "','工作办理-"
                    + workGrid.DataKeys[workGrid.SelectedRowIndex][1]
                    + "[" + workGrid.DataKeys[workGrid.SelectedRowIndex][2]
                    + "]','WorkRun/FrmHandleRunProcess.aspx?RunProcess="
                    + id + "&TabID=" + tabID + "');");
            }
            catch (Exception ex)
            {
                Alert.ShowInParent(ex.Message);
            }
        }
    }

    private void workGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string sortDirection)
    {
        ChangeTrackingList<EntitySearcher> trackingList = new ChangeTrackingList<EntitySearcher>();
        foreach (EntitySearcher s in changeTrackingList)
        {
            trackingList.Add(s);
        }

        EntitySearcher search = new EntitySearcher();
        search.Field = "State";
        search.Relation = "AND";
        search.Operator = "=";
        search.Content = "0";
        trackingList.Add(search);               

        search = new EntitySearcher();
        search.Field = "IsEnd";
        search.Relation = "AND";
        search.Operator = "=";
        search.Content = "0";
        trackingList.Add(search);

        if (this.CookiePersonnel != null)
        {
            search = new EntitySearcher();
            search.Field = "AcceptID";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = this.CookiePersonnel.ID.ToString();
            trackingList.Add(search);
        }

        workGrid.RecordCount = runProcessBll.GetCount(trackingList);
        ExtBindingList<FineOffice.Modules.OA_FlowRunProcess> list = runProcessBll.GetList(trackingList, this.workGrid.PageIndex, this.workGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, sortDirection);
        workGrid.DataSource = list;
        workGrid.DataBind();       
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void workGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        workGrid_Bind(changeTrackingList, e.SortField, e.SortDirection);
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void workGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        workGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = workGrid.FindColumn(workGrid.SortColumn);
        workGrid_Bind(changeTrackingList, column.SortField, workGrid.SortDirection);
    }

    /// <summary>
    /// 清空查找信息
    /// </summary>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtCreator.Text = "";
        hiddenField.Text = "";
        dtpBegin.Text = "";
        dtpEnd.Text = "";
        txtWorkName.Text = "";
        ddlSort.SelectedIndex = 0;
        btnFind_Click(null, null);
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

        if (hiddenField.Text.Length > 0)
        {
            string personnel = hiddenField.Text;
            search = new EntitySearcher();
            search.Field = "Creator";
            search.Relation = "AND";
            search.Operator = "in";
            search.Content = "(" + personnel.Substring(0, personnel.Length - 1) + ")";
            changeTrackingList.Add(search);
        }

        if (dtpBegin.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "WorkCreateTime";
            search.Relation = "AND";
            search.Operator = ">=";
            search.Content = dtpBegin.Text;
            changeTrackingList.Add(search);
        }

        if (dtpEnd.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "WorkCreateTime";
            search.Relation = "AND";
            search.Operator = "<=";
            search.Content = dtpEnd.Text;
            changeTrackingList.Add(search);
        }

        ViewState["sql"] = changeTrackingList;
        GridColumn column = workGrid.FindColumn(workGrid.SortColumn);
        workGrid_Bind(changeTrackingList, column.SortField, workGrid.SortDirection);
    }
}
