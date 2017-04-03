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

public partial class WorkFlow_FrmFlowSortList : PageBase
{
    FineOffice.BLL.OA_FlowSort sortBll = new FineOffice.BLL.OA_FlowSort();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            flowSortGrid.PageIndex = 0;
            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;
            GridColumn column = flowSortGrid.FindColumn(flowSortGrid.SortColumn);
            flowSortGrid_Bind(changeTrackingList, column.SortField, flowSortGrid.SortDirection);

            btnNew.OnClientClick = newFlowSortWin.GetShowReference();
            btnModify.OnClientClick = flowSortGrid.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", flowSortGrid.Title));
            btnDelete.OnClientClick = flowSortGrid.GetNoSelectionAlertReference(string.Format("请选择要删除的{0}！", flowSortGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中{0}吗！", flowSortGrid.Title);
        }
        //子窗体回发事件
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = flowSortGrid.FindColumn(flowSortGrid.SortColumn);
            flowSortGrid_Bind(changeTrackingList, column.SortField, flowSortGrid.SortDirection);
        }
    }

    #region flowSortGrid_Bind

    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        flowSortGrid.SelectAllRows();
    }
    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = flowSortGrid.SelectedRowIndexArray;
            List<int> deleteList = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                deleteList.Add(int.Parse((flowSortGrid.DataKeys[keys[i]][0]).ToString()));
            }
            sortBll.Delete(deleteList);
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = flowSortGrid.FindColumn(flowSortGrid.SortColumn);
            flowSortGrid_Bind(changeTrackingList, column.SortField, flowSortGrid.SortDirection);
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    protected void flowSortGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "delete")
            {
                object[] keys = flowSortGrid.DataKeys[e.RowIndex];
                sortBll.Delete(new FineOffice.Modules.OA_FlowSort { ID = int.Parse(keys[0].ToString()) });
                ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
                GridColumn column = flowSortGrid.FindColumn(flowSortGrid.SortColumn);
                flowSortGrid_Bind(changeTrackingList, column.SortField, flowSortGrid.SortDirection);
            }
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        modifyFlowSortWin.IFrameUrl = string.Format("FrmModifyFlowSort.aspx?id={0}", flowSortGrid.DataKeys[flowSortGrid.SelectedRowIndex][0]);
        modifyFlowSortWin.Hidden = false;
    }

    private void flowSortGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        flowSortGrid.RecordCount = sortBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.OA_FlowSort> list = sortBll.GetList(changeTrackingList, this.flowSortGrid.PageIndex, this.flowSortGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        flowSortGrid.DataSource = list;
        flowSortGrid.DataBind();
    }

    #endregion


    /// <summary>
    /// 数据排序
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void flowSortGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        flowSortGrid_Bind(changeTrackingList, e.SortField, e.SortDirection);
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void flowSortGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        flowSortGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = flowSortGrid.FindColumn(flowSortGrid.SortColumn);
        flowSortGrid_Bind(changeTrackingList, column.SortField, flowSortGrid.SortDirection);
    }

    /// <summary>
    /// 清空查询条件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
    {
        ttbSearch.Text = String.Empty;
        ttbSearch.ShowTrigger1 = false;
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        ViewState["sql"] = changeTrackingList;
        GridColumn column = flowSortGrid.FindColumn(flowSortGrid.SortColumn);
        flowSortGrid_Bind(changeTrackingList, column.SortField, flowSortGrid.SortDirection);
    }

    /// <summary>
    /// 查询
    /// </summary>
    protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        EntitySearcher search = new EntitySearcher();
        search.Field = "SortNO";
        search.Relation = "or";
        search.Operator = "Like";
        search.Content = ttbSearch.Text;
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "SortName";
        search.Relation = "or";
        search.Operator = "Like";
        search.Content = ttbSearch.Text;
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "PinyinCode";
        search.Relation = "or";
        search.Operator = "Like";
        search.Content = ttbSearch.Text;
        changeTrackingList.Add(search);

        ViewState["sql"] = changeTrackingList;
        GridColumn column = flowSortGrid.FindColumn(flowSortGrid.SortColumn);
        flowSortGrid_Bind(changeTrackingList, column.SortField, flowSortGrid.SortDirection);
        ttbSearch.ShowTrigger1 = true;
    }
}
