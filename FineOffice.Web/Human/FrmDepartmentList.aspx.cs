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

public partial class Human_FrmDepartmentList : PageBase
{
    FineOffice.BLL.HR_Department depBll = new FineOffice.BLL.HR_Department();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {           
            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;
            GridColumn column = departmentGrid.FindColumn(departmentGrid.SortColumn);
            departmentGrid_Grid(changeTrackingList, column.SortField, departmentGrid.SortDirection);

            btnNew.OnClientClick = newDepartmentWin.GetShowReference();
            btnModify.OnClientClick = departmentGrid.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", departmentGrid.Title));
            btnDelete.OnClientClick = departmentGrid.GetNoSelectionAlertReference(string.Format("请选择要删除的{0}！", departmentGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中{0}吗！", departmentGrid.Title);
        }
        //子窗体回发事件
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = departmentGrid.FindColumn(departmentGrid.SortColumn);
            departmentGrid_Grid(changeTrackingList, column.SortField, departmentGrid.SortDirection);
        }
    }

    #region departmentGrid_Grid

    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        departmentGrid.SelectAllRows();
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = departmentGrid.SelectedRowIndexArray;
            List<int> deleteList = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                deleteList.Add(int.Parse((departmentGrid.DataKeys[keys[i]][0]).ToString()));
            }
            depBll.Delete(deleteList);
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = departmentGrid.FindColumn(departmentGrid.SortColumn);
            departmentGrid_Grid(changeTrackingList, column.SortField, departmentGrid.SortDirection);
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    protected void departmentGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "delete")
            {
                Grid dd = new Grid();
                object[] keys = departmentGrid.DataKeys[e.RowIndex];
                depBll.Delete(new FineOffice.Modules.HR_Department { ID = int.Parse(keys[0].ToString()) });
                ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
                GridColumn column = departmentGrid.FindColumn(departmentGrid.SortColumn);
                departmentGrid_Grid(changeTrackingList, column.SortField, departmentGrid.SortDirection);
            }
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        modifyDepartmentWin.IFrameUrl = string.Format("FrmModifyDepartment.aspx?id={0}", departmentGrid.DataKeys[departmentGrid.SelectedRowIndex][0]);
        modifyDepartmentWin.Hidden = false;
    }

    private void departmentGrid_Grid(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        departmentGrid.RecordCount = depBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.HR_Department> list = depBll.GetList(changeTrackingList, this.departmentGrid.PageIndex, this.departmentGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        departmentGrid.DataSource = list;
        departmentGrid.DataBind();
    }
    #endregion


    /// <summary>
    /// 数据排序
    /// </summary>
    protected void departmentGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        departmentGrid_Grid(changeTrackingList, e.SortField, e.SortDirection);
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void departmentGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        this.departmentGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = departmentGrid.FindColumn(departmentGrid.SortColumn);
        departmentGrid_Grid(changeTrackingList, column.SortField, departmentGrid.SortDirection);
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
        GridColumn column = departmentGrid.FindColumn(departmentGrid.SortColumn);
        departmentGrid_Grid(changeTrackingList, column.SortField, departmentGrid.SortDirection);
    }

    /// <summary>
    /// 查询部门
    /// </summary>
    protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        EntitySearcher search = new EntitySearcher();
        search.Field = "DepartmentNO";
        search.Relation = "or";
        search.Operator = "Like";
        search.Content = ttbSearch.Text;
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "DepartmentName";
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
        GridColumn column = departmentGrid.FindColumn(departmentGrid.SortColumn);
        departmentGrid_Grid(changeTrackingList, column.SortField, departmentGrid.SortDirection);
        ttbSearch.ShowTrigger1 = true;
    }
}
