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

public partial class Human_FrmJobList : PageBase
{
    FineOffice.BLL.HR_Job jobBll = new FineOffice.BLL.HR_Job();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.jobGrid.PageIndex = 0;
            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;
            GridColumn column = jobGrid.FindColumn(jobGrid.SortColumn);
            jobGrid_Bind(changeTrackingList, column.SortField, jobGrid.SortDirection);

            btnNew.OnClientClick = newJobWin.GetShowReference();
            btnModify.OnClientClick = jobGrid.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", jobGrid.Title));
            btnDelete.OnClientClick = jobGrid.GetNoSelectionAlertReference(string.Format("请选择要删除的{0}！", jobGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中{0}吗！", jobGrid.Title);
        }
        //子窗体回发事件
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = jobGrid.FindColumn(jobGrid.SortColumn);
            jobGrid_Bind(changeTrackingList, column.SortField, jobGrid.SortDirection);
        }
    }

    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        jobGrid.SelectAllRows();
    }
    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = jobGrid.SelectedRowIndexArray;
            List<int> deleteList = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                deleteList.Add(int.Parse((jobGrid.DataKeys[keys[i]][0]).ToString()));
            }
            jobBll.Delete(deleteList);
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = jobGrid.FindColumn(jobGrid.SortColumn);
            jobGrid_Bind(changeTrackingList, column.SortField, jobGrid.SortDirection);
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    protected void jobGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            try
            {
                object[] keys = jobGrid.DataKeys[e.RowIndex];
                jobBll.Delete(new FineOffice.Modules.HR_Job { ID = int.Parse(keys[0].ToString()) });
                ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
                GridColumn column = jobGrid.FindColumn(jobGrid.SortColumn);
                jobGrid_Bind(changeTrackingList, column.SortField, jobGrid.SortDirection);
            }
            catch (Exception ex)
            {
                Alert.ShowInParent(ex.Message);
            }
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        modifyJobWin.IFrameUrl = string.Format("FrmModifyJob.aspx?id={0}", jobGrid.DataKeys[jobGrid.SelectedRowIndex][0]);
        modifyJobWin.Hidden = false;
    }

    private void jobGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        jobGrid.RecordCount = jobBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.HR_Job> list = jobBll.GetList(changeTrackingList, this.jobGrid.PageIndex, this.jobGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        jobGrid.DataSource = list;
        jobGrid.DataBind();
    }


    /// <summary>
    /// 数据排序
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void jobGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        jobGrid_Bind(changeTrackingList, e.SortField, e.SortDirection);
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void jobGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        this.jobGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = jobGrid.FindColumn(jobGrid.SortColumn);
        jobGrid_Bind(changeTrackingList, column.SortField, jobGrid.SortDirection);
    }

    /// <summary>
    /// 清空查询条件
    /// </summary>
    protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
    {
        ttbSearch.Text = String.Empty;
        ttbSearch.ShowTrigger1 = false;
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        ViewState["sql"] = changeTrackingList;
        GridColumn column = jobGrid.FindColumn(jobGrid.SortColumn);
        jobGrid_Bind(changeTrackingList, column.SortField, jobGrid.SortDirection);
    }

    /// <summary>
    /// 查询
    /// </summary>
    protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        EntitySearcher search = new EntitySearcher();
        search.Field = "JobNO";
        search.Relation = "or";
        search.Operator = "Like";
        search.Content = ttbSearch.Text;
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "Job";
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
        GridColumn column = jobGrid.FindColumn(jobGrid.SortColumn);
        jobGrid_Bind(changeTrackingList, column.SortField, jobGrid.SortDirection);
        ttbSearch.ShowTrigger1 = true;
    }
}
