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

public partial class Common_FrmMultiPersonnel : PageBase
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
            ExtBindingList<FineOffice.Modules.HR_Personnel> list = personGrid_Bind(changeTrackingList, column.SortField, personGrid.SortDirection);

            #region 恢复选中
            if (Request["selected"] != null && Request["selected"].Length > 0)
            {
                List<FineOffice.Modules.HR_Personnel> tempList = new List<FineOffice.Modules.HR_Personnel>();
                string[] str = Request["selected"].Split(',');
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i].Length > 0)
                    {
                        FineOffice.Modules.HR_Personnel depart = list.Where(d => d.ID == int.Parse(str[i])).FirstOrDefault();
                        tempList.Add(depart);
                    }
                }
                rightGrid.DataSource = tempList;
                rightGrid.DataBind();
            }
            #endregion

            btnNew.OnClientClick = newPersonWin.GetShowReference();


            btnModify.OnClientClick = personGrid.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", personGrid.Title));
            btnDelete.OnClientClick = personGrid.GetNoSelectionAlertReference(string.Format("请选择要删除的{0}！", personGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中{0}吗！", personGrid.Title);
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
        List<object[]> selecteds = rightGrid.DataKeys;
        StringBuilder ids = new StringBuilder();
        StringBuilder strName = new StringBuilder();
        for (int i = 0; i < selecteds.Count; i++)
        {
            ids.Append(selecteds[i][0]);
            ids.Append(",");

            strName.Append(selecteds[i][1]);
            strName.Append(",");
        }
        PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(strName.ToString(), ids.ToString())
            + ActiveWindow.GetHidePostBackReference("param_from_selected"));
    }

    /// <summary>
    /// 右移
    /// </summary>
    protected void btnRight_Click(object sender, EventArgs e)
    {
        List<FineOffice.Modules.HR_Personnel> personnelList = new List<FineOffice.Modules.HR_Personnel>();
        int[] keys = personGrid.SelectedRowIndexArray;
        List<object[]> list = new List<object[]>();
        for (int i = 0; i < keys.Length; i++)
        {
            list.Add(personGrid.DataKeys[keys[i]]);
        }
        List<object[]> selected = rightGrid.DataKeys;
        for (int i = 0; i < selected.Count; i++)
        {
            personnelList.Add(new FineOffice.Modules.HR_Personnel
            {
                ID = int.Parse(selected[i][0].ToString()),
                Name = selected[i][1].ToString()
            });
        }

        #region 判断右边的Grid是否已含员工信息
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
                FineOffice.Modules.HR_Personnel personnel = new FineOffice.Modules.HR_Personnel
                {
                    ID = int.Parse(list[i][0].ToString()),
                    Name = list[i][1].ToString()
                };
                personnelList.Add(personnel);
            }
        }
        #endregion

        rightGrid.DataSource = personnelList;
        rightGrid.DataBind();
    }

    protected void btnLeft_Click(object sender, EventArgs e)
    {
        List<FineOffice.Modules.HR_Personnel> personnelList = new List<FineOffice.Modules.HR_Personnel>();
        List<object[]> selected = rightGrid.DataKeys;
        for (int i = 0; i < selected.Count; i++)
        {
            personnelList.Add(new FineOffice.Modules.HR_Personnel
            {
                ID = int.Parse(selected[i][0].ToString()),
                Name = selected[i][1].ToString()
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
            personnelList.Remove(personnelList.Where(d => d.ID == list[i]).FirstOrDefault());
        }
        rightGrid.DataSource = personnelList;
        rightGrid.DataBind();
    }

    /// <summary>
    /// 全选
    /// </summary>
    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        personGrid.SelectAllRows();
    }

    /// <summary>
    /// 批量删除
    /// </summary>
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

    private ExtBindingList<FineOffice.Modules.HR_Personnel> personGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        personGrid.RecordCount = personBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.HR_Personnel> list = personBll.GetList(changeTrackingList, this.personGrid.PageIndex, this.personGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        personGrid.DataSource = list;
        personGrid.DataBind();
        return list;
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
        personGrid.PageIndex = e.NewPageIndex;
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
