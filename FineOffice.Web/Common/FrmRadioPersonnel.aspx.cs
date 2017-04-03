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

public partial class Common_FrmRadioPersonnel : PageBase
{
    FineOffice.BLL.HR_Personnel personBll = new FineOffice.BLL.HR_Personnel();
    FineOffice.BLL.HR_Department departmentBll = new FineOffice.BLL.HR_Department();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            this.personGrid.PageIndex = 0;
            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;
            GridColumn column = personGrid.FindColumn(personGrid.SortColumn);
            personGrid_Bind(changeTrackingList, column.SortField, personGrid.SortDirection);

            btnAdd.OnClientClick = newPersonWin.GetShowReference();
            btnModify.OnClientClick = personGrid.GetNoSelectionAlertReference("请选择要编辑的" + personGrid.Title + "！");
            btnDelelte.OnClientClick = personGrid.GetNoSelectionAlertReference("请选择要删除的" + personGrid.Title + "！");
            btnDelelte.ConfirmText = "你确认要删除选中的" + personGrid.Title + "吗？";
        }
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = personGrid.FindColumn(personGrid.SortColumn);
            personGrid_Bind(changeTrackingList, column.SortField, personGrid.SortDirection);
        }
    }

    private void LoadData()
    {
        List<FineOffice.Modules.HR_Department> list = departmentBll.GetListAll();
        ddlDepartment.Items.Add("<全部>", "");
        foreach (FineOffice.Modules.HR_Department dep in list)
        {
            ddlDepartment.Items.Add(dep.DepartmentName, dep.ID.ToString());
        }
    }

    protected void btnEnter_Click(object sender, EventArgs e)
    {
        string id = "";
        string name = "";
        if (personGrid.SelectedRowIndex > -1)
        {
            List<object[]> ids = personGrid.DataKeys;
            object[] obj = ids[personGrid.SelectedRowIndex];
            id = obj == null ? "" : obj[0].ToString();
            name = obj == null ? "" : obj[1].ToString();
        }

        PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(name, id)
            + ActiveWindow.GetHidePostBackReference("param_from_selected"));
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int[] keys = personGrid.SelectedRowIndexArray;
        List<int> deleteList = new List<int>();
        for (int i = 0; i < keys.Length; i++)
        {
            deleteList.Add(int.Parse((personGrid.DataKeys[keys[i]][0]).ToString()));
        }
        try
        {
            personBll.Delete(deleteList);
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = personGrid.FindColumn(personGrid.SortColumn);
        personGrid_Bind(changeTrackingList, column.SortField, personGrid.SortDirection);

    }

    protected void personGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            try
            {
                object[] keys = personGrid.DataKeys[e.RowIndex];
                personBll.Delete(new FineOffice.Modules.HR_Personnel { ID = int.Parse(keys[0].ToString()) });
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = personGrid.FindColumn(personGrid.SortColumn);
            personGrid_Bind(changeTrackingList, column.SortField, personGrid.SortDirection);
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        modifyPersonWin.IFrameUrl = string.Format("../Human/FrmModifyPersonnel.aspx?ID={0}", personGrid.DataKeys[personGrid.SelectedRowIndex][0]);
        modifyPersonWin.Hidden = false;
    }

    private void personGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        personGrid.RecordCount = personBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.HR_Personnel> list = personBll.GetList(changeTrackingList, this.personGrid.PageIndex, this.personGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        personGrid.DataSource = list;
        personGrid.DataBind();
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void personGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        personGrid_Bind(changeTrackingList, e.SortField, e.SortDirection);
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void personGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = personGrid.FindColumn(personGrid.SortColumn);
        personGrid_Bind(changeTrackingList, column.SortField, personGrid.SortDirection);
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
        GridColumn column = personGrid.FindColumn(personGrid.SortColumn);
        personGrid_Bind(changeTrackingList, column.SortField, personGrid.SortDirection);
    }
}
