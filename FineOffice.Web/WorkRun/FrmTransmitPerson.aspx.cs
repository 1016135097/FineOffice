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

public partial class WorkRun_FrmTransmitPerson : PageBase
{
    FineOffice.BLL.HR_Personnel personnelBll = new FineOffice.BLL.HR_Personnel();
    FineOffice.BLL.HR_Department departmentBll = new FineOffice.BLL.HR_Department();

    FineOffice.BLL.OA_FlowProcess processBll = new FineOffice.BLL.OA_FlowProcess();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            this.CommonGrid.PageIndex = 0;
            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;
            GridColumn column = CommonGrid.FindColumn(CommonGrid.SortColumn);
            ExtBindingList<FineOffice.Modules.HR_Personnel> list = BindGrid(changeTrackingList, column.SortField, CommonGrid.SortDirection);
        }
        //子窗体回发事件
        if (Request.Form["__EVENTARGUMENT"] == "windowClose")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = CommonGrid.FindColumn(CommonGrid.SortColumn);
            BindGrid(changeTrackingList, column.SortField, CommonGrid.SortDirection);
        }
    }

    protected void btnEnter_Click(object sender, EventArgs e)
    {
        try
        {
            if (CommonGrid.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInParent("请选中一行！");
                return;
            }
            object[] selected = CommonGrid.DataKeys[CommonGrid.SelectedRowIndex];

            PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(selected[1].ToString(), selected[0].ToString())
                + ActiveWindow.GetHidePostBackReference("param_from_selected"));
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
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
        FineOffice.Modules.OA_FlowProcess model = processBll.GetModel(p => p.ID == Request["Process"]);
        hiddenDepartment.Text = model.ProcessDepartment;
        hiddenPerson.Text = model.ProcessPersonnel;
    }

    private ExtBindingList<FineOffice.Modules.HR_Personnel> BindGrid(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        EntitySearcher search = new EntitySearcher();
        search = new EntitySearcher();
        search.LeftParentheses = "(";
        search.Field = "DepartmentID";
        search.Relation = "OR";
        search.Operator = "in";
        StringBuilder dep = new StringBuilder();
        dep.Append("(");
        if (hiddenDepartment.Text.Length > 0)
        {
            dep.Append(hiddenDepartment.Text.Remove(hiddenDepartment.Text.Length - 1));
        }
        else
        {
            dep.Append("0");
        }
        dep.Append(")");
        search.Content = dep.ToString();
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.RightParentheses = ")";
        search.Field = "ID";
        search.Operator = "in";
        StringBuilder str = new StringBuilder();
        str.Append("(");
        if (hiddenPerson.Text.Length > 0)
        {
            str.Append(hiddenPerson.Text.Remove(hiddenPerson.Text.Length - 1));
        }
        else
        {
            str.Append("0");
        }
        str.Append(")");
        search.Content = str.ToString();
        changeTrackingList.Add(search);

        CommonGrid.RecordCount = personnelBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.HR_Personnel> list = personnelBll.GetList(changeTrackingList, this.CommonGrid.PageIndex, this.CommonGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        CommonGrid.DataSource = list;
        CommonGrid.DataBind();
        return list;
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void Grid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        BindGrid(changeTrackingList, e.SortField, e.SortDirection);
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void Grid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = CommonGrid.FindColumn(CommonGrid.SortColumn);
        BindGrid(changeTrackingList, column.SortField, CommonGrid.SortDirection);
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
        GridColumn column = CommonGrid.FindColumn(CommonGrid.SortColumn);
        BindGrid(changeTrackingList, column.SortField, CommonGrid.SortDirection);
    }
}
