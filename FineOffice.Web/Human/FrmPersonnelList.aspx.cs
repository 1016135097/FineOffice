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

public partial class Human_FrmPersonnelList : PageBase
{
    FineOffice.BLL.HR_Personnel personnelBll = new FineOffice.BLL.HR_Personnel();
    FineOffice.BLL.HR_Department departmentBll = new FineOffice.BLL.HR_Department();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;
            GridColumn column = personnelGrid.FindColumn(personnelGrid.SortColumn);
            personnelGrid_Grid(changeTrackingList, column.SortField, personnelGrid.SortDirection);

            btnNew.OnClientClick = newPersonnelWin.GetShowReference();
            btnModify.OnClientClick = personnelGrid.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", personnelGrid.Title));
            btnDelete.OnClientClick = personnelGrid.GetNoSelectionAlertReference(string.Format("请选择要删除的{0}！", personnelGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中{0}吗！", personnelGrid.Title);
        }
        //子窗体回发事件
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = personnelGrid.FindColumn(personnelGrid.SortColumn);
            personnelGrid_Grid(changeTrackingList, column.SortField, personnelGrid.SortDirection);
        }
    }

    private void LoadData()
    {
        List<FineOffice.Modules.HR_Department> list = departmentBll.GetListAll();

        ddlDepartment.Items.Clear();
        FineUI.ListItem li = new FineUI.ListItem();
        li.Value = "";
        li.Text = "<全部>";
        ddlDepartment.Items.Add(li);
        foreach (FineOffice.Modules.HR_Department department in list)
        {
            FineUI.ListItem item = new FineUI.ListItem();
            item.Text = department.DepartmentName;
            item.Value = department.ID.ToString();
            ddlDepartment.Items.Add(item);
        }
    }

    #region personnelGrid_Grid

    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        personnelGrid.SelectAllRows();
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = personnelGrid.SelectedRowIndexArray;
            List<int> deleteList = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                deleteList.Add(int.Parse((personnelGrid.DataKeys[keys[i]][0]).ToString()));
            }
            personnelBll.Delete(deleteList);
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = personnelGrid.FindColumn(personnelGrid.SortColumn);
            personnelGrid_Grid(changeTrackingList, column.SortField, personnelGrid.SortDirection);
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    protected void personnelGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            try
            {
                object[] keys = personnelGrid.DataKeys[e.RowIndex];
                personnelBll.Delete(new FineOffice.Modules.HR_Personnel { ID = int.Parse(keys[0].ToString()) });
                ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
                GridColumn column = personnelGrid.FindColumn(personnelGrid.SortColumn);
                personnelGrid_Grid(changeTrackingList, column.SortField, personnelGrid.SortDirection);
            }
            catch (Exception ex)
            {
                Alert.ShowInParent(ex.Message);
            }
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        modifyPersonnelWin.IFrameUrl = string.Format("FrmModifyPersonnel.aspx?id={0}", personnelGrid.DataKeys[personnelGrid.SelectedRowIndex][0]);
        modifyPersonnelWin.Hidden = false;
    }

    private void personnelGrid_Grid(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        personnelGrid.RecordCount = personnelBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.HR_Personnel> list = personnelBll.GetList(changeTrackingList, this.personnelGrid.PageIndex, this.personnelGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        personnelGrid.DataSource = list;
        personnelGrid.DataBind();       
    }


    #endregion


    /// <summary>
    /// 数据排序
    /// </summary>
    protected void personnelGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        personnelGrid_Grid(changeTrackingList, e.SortField, e.SortDirection);
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void personnelGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        this.personnelGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = personnelGrid.FindColumn(personnelGrid.SortColumn);
        personnelGrid_Grid(changeTrackingList, column.SortField, personnelGrid.SortDirection);
    }

    /// <summary>
    /// 查询职员信息
    /// </summary>
    protected void btnFind_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        EntitySearcher search = new EntitySearcher();
        search.Field = "PersonnelNO";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtPersonnelNO.Text;
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "Name";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtName.Text;
        changeTrackingList.Add(search);

        string department = ddlDepartment.SelectedValue;
        if (department.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "DepartmentID";
            search.Relation = "or";
            search.Operator = "=";
            search.Content = department;
            changeTrackingList.Add(search);
        }

        ViewState["sql"] = changeTrackingList;
        GridColumn column = personnelGrid.FindColumn(personnelGrid.SortColumn);
        personnelGrid_Grid(changeTrackingList, column.SortField, personnelGrid.SortDirection);
    }
}
