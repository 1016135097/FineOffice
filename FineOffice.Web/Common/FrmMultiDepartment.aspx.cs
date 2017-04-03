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

public partial class FrmMultiDepartment : PageBase
{
    FineOffice.BLL.HR_Department depBll = new FineOffice.BLL.HR_Department();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            EntitySearcher search = new EntitySearcher();
            search.Field = "Stop";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = "1";
            changeTrackingList.Add(search);

            ViewState["sql"] = changeTrackingList;
            GridColumn column = departmentGrid.FindColumn(departmentGrid.SortColumn);
            ExtBindingList<FineOffice.Modules.HR_Department> list = departmentGrid_Bind(changeTrackingList, column.SortField, departmentGrid.SortDirection);

            if (Request["selected"] != null && Request["selected"].Length > 0)
            {
                List<FineOffice.Modules.HR_Department> tempList = new List<FineOffice.Modules.HR_Department>();
                string[] str = Request["selected"].Split(',');
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i].Length > 0)
                    {
                        FineOffice.Modules.HR_Department depart = list.Where(d => d.ID == int.Parse(str[i])).FirstOrDefault();
                        tempList.Add(depart);
                    }
                }
                rightGrid.DataSource = tempList;
                rightGrid.DataBind();
            }

            btnNew.OnClientClick = newDepartmentWin.GetShowReference();
            btnModify.OnClientClick = departmentGrid.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", departmentGrid.Title));
            btnDelete.OnClientClick = departmentGrid.GetNoSelectionAlertReference(string.Format("请选择要删除的{0}！", departmentGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中{0}吗！", departmentGrid.Title);
        }
        //子窗体回发事件
        if (Request.Form["__EVENTARGUMENT"] == "windowClose")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = departmentGrid.FindColumn(departmentGrid.SortColumn);
            departmentGrid_Bind(changeTrackingList, column.SortField, departmentGrid.SortDirection);
        }
    }

    protected void btnEnter_Click(object sender, EventArgs e)
    {
        List<object[]> selected = rightGrid.DataKeys;
        StringBuilder strid = new StringBuilder();
        StringBuilder strName = new StringBuilder();
        for (int i = 0; i < selected.Count; i++)
        {
            strid.Append(selected[i][0]);
            strid.Append(",");

            strName.Append(selected[i][1]);
            strName.Append(",");
        }
        PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(strName.ToString(), strid.ToString())
            + ActiveWindow.GetHidePostBackReference("param_from_selected"));
    }

    /// <summary>
    /// 全选
    /// </summary>
    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        departmentGrid.SelectAllRows();
    }

    /// <summary>
    /// 右移部门信息
    /// </summary>
    protected void btnRight_Click(object sender, EventArgs e)
    {
        List<FineOffice.Modules.HR_Department> departmentList = new List<FineOffice.Modules.HR_Department>();
        int[] keys = departmentGrid.SelectedRowIndexArray;
        List<object[]> list = new List<object[]>();
        for (int i = 0; i < keys.Length; i++)
        {
            list.Add(departmentGrid.DataKeys[keys[i]]);
        }
        List<object[]> selected = rightGrid.DataKeys;
        for (int i = 0; i < selected.Count; i++)
        {
            departmentList.Add(new FineOffice.Modules.HR_Department
            {
                ID = int.Parse(selected[i][0].ToString()),
                DepartmentName = selected[i][1].ToString()
            });
        }
        for (int i = 0; i < list.Count; i++)
        {
            bool contains = false;
            for (int j = 0; j < selected.Count; j++)
            {
                if (list[i][0].Equals(selected[j][0]))
                {
                    contains = true;
                    break;
                }
            }
            if (!contains)
            {
                FineOffice.Modules.HR_Department department = new FineOffice.Modules.HR_Department
                {
                    ID = int.Parse(list[i][0].ToString()),
                    DepartmentName = list[i][1].ToString()
                };
                departmentList.Add(department);
            }
        }
        rightGrid.DataSource = departmentList;
        rightGrid.DataBind();
    }

    protected void btnLeft_Click(object sender, EventArgs e)
    {
        List<FineOffice.Modules.HR_Department> departmentList = new List<FineOffice.Modules.HR_Department>();
        List<object[]> selected = rightGrid.DataKeys;
        for (int i = 0; i < selected.Count; i++)
        {
            departmentList.Add(new FineOffice.Modules.HR_Department
            {
                ID = int.Parse(selected[i][0].ToString()),
                DepartmentName = selected[i][1].ToString()
            });
        }
        int[] keys = rightGrid.SelectedRowIndexArray;
        List<int> list = new List<int>();
        for (int i = 0; i < keys.Length; i++)
        {
            list.Add(int.Parse(rightGrid.DataKeys[keys[i]][0].ToString()));
        }
        for (int i = 0; i < list.Count; i++)
        {
            departmentList.Remove(departmentList.Where(d => d.ID == list[i]).FirstOrDefault());
        }
        rightGrid.DataSource = departmentList;
        rightGrid.DataBind();
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
            departmentGrid_Bind(changeTrackingList, column.SortField, departmentGrid.SortDirection);
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
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
                object[] keys = departmentGrid.DataKeys[e.RowIndex];
                depBll.Delete(new FineOffice.Modules.HR_Department { ID = int.Parse(keys[0].ToString()) });
                ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
                GridColumn column = departmentGrid.FindColumn(departmentGrid.SortColumn);
                departmentGrid_Bind(changeTrackingList, column.SortField, departmentGrid.SortDirection);
            }
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        modifyDepartmentWin.IFrameUrl = string.Format("../Human/FrmModifyDepartment.aspx?id={0}", departmentGrid.DataKeys[departmentGrid.SelectedRowIndex][0]);
        modifyDepartmentWin.Hidden = false;
    }

    private ExtBindingList<FineOffice.Modules.HR_Department> departmentGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        departmentGrid.RecordCount = depBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.HR_Department> list = depBll.GetList(changeTrackingList, this.departmentGrid.PageIndex, this.departmentGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        departmentGrid.DataSource = list;
        departmentGrid.DataBind();

        return list;
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void departmentGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        departmentGrid_Bind(changeTrackingList, e.SortField, e.SortDirection);
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void departmentGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        departmentGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = departmentGrid.FindColumn(departmentGrid.SortColumn);
        departmentGrid_Bind(changeTrackingList, column.SortField, departmentGrid.SortDirection);
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
        departmentGrid_Bind(changeTrackingList, column.SortField, departmentGrid.SortDirection);
    }

    /// <summary>
    /// 查询部门
    /// </summary>
    protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();

        EntitySearcher search = new EntitySearcher();
        search.Field = "Stop";
        search.Relation = "AND";
        search.Operator = "=";
        search.Content = "1";
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.LeftParentheses = "(";
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
        search.RightParentheses = ")";
        search.Field = "PinyinCode";
        search.Relation = "or";
        search.Operator = "Like";
        search.Content = ttbSearch.Text;
        changeTrackingList.Add(search);

        ViewState["sql"] = changeTrackingList;
        GridColumn column = departmentGrid.FindColumn(departmentGrid.SortColumn);
        departmentGrid_Bind(changeTrackingList, column.SortField, departmentGrid.SortDirection);
        ttbSearch.ShowTrigger1 = true;
    }
}
