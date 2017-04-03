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

public partial class WorkFlow_FrmFormTypeList : PageBase
{
    FineOffice.BLL.OA_FormType typeBll = new FineOffice.BLL.OA_FormType();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.formTypeGrid.PageIndex = 0;
            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;
            GridColumn column = formTypeGrid.FindColumn(formTypeGrid.SortColumn);
            formTypeGrid_Bind(changeTrackingList, column.SortField, formTypeGrid.SortDirection);

            btnNew.OnClientClick = newFormTypeWin.GetShowReference();
            btnModify.OnClientClick = formTypeGrid.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", formTypeGrid.Title));
            btnDelete.OnClientClick = formTypeGrid.GetNoSelectionAlertReference(string.Format("请选择要删除的{0}！", formTypeGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中{0}吗！", formTypeGrid.Title);
        }
        //子窗体回发事件
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = formTypeGrid.FindColumn(formTypeGrid.SortColumn);
            formTypeGrid_Bind(changeTrackingList, column.SortField, formTypeGrid.SortDirection);
        }
    }

    #region formTypeGrid_Bind

    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        formTypeGrid.SelectAllRows();
    }
    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = formTypeGrid.SelectedRowIndexArray;
            List<int> deleteList = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                deleteList.Add(int.Parse((formTypeGrid.DataKeys[keys[i]][0]).ToString()));
            }
            typeBll.Delete(deleteList);
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = formTypeGrid.FindColumn(formTypeGrid.SortColumn);
            formTypeGrid_Bind(changeTrackingList, column.SortField, formTypeGrid.SortDirection);
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    protected void formTypeGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            try
            {
                object[] keys = formTypeGrid.DataKeys[e.RowIndex];
                typeBll.Delete(new FineOffice.Modules.OA_FormType { ID = int.Parse(keys[0].ToString()) });
                ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
                GridColumn column = formTypeGrid.FindColumn(formTypeGrid.SortColumn);
                formTypeGrid_Bind(changeTrackingList, column.SortField, formTypeGrid.SortDirection);
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        modifyFormTypeWin.IFrameUrl = string.Format("FrmModifyFormType.aspx?id={0}", formTypeGrid.DataKeys[formTypeGrid.SelectedRowIndex][0]);
        modifyFormTypeWin.Hidden = false;
    }

    private void formTypeGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        formTypeGrid.RecordCount = typeBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.OA_FormType> list = typeBll.GetList(changeTrackingList, this.formTypeGrid.PageIndex, this.formTypeGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        formTypeGrid.DataSource = list;
        formTypeGrid.DataBind();
    }


    #endregion


    /// <summary>
    /// 数据排序
    /// </summary>
    protected void formTypeGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        formTypeGrid_Bind(changeTrackingList, e.SortField, e.SortDirection);
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void formTypeGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        this.formTypeGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = formTypeGrid.FindColumn(formTypeGrid.SortColumn);
        formTypeGrid_Bind(changeTrackingList, column.SortField, formTypeGrid.SortDirection);
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
        GridColumn column = formTypeGrid.FindColumn(formTypeGrid.SortColumn);
        formTypeGrid_Bind(changeTrackingList, column.SortField, formTypeGrid.SortDirection);
    }

    /// <summary>
    /// 查询
    /// </summary>
    protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        EntitySearcher search = new EntitySearcher();
        search.Field = "TypeNO";
        search.Relation = "or";
        search.Operator = "Like";
        search.Content = ttbSearch.Text;
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "FormTypeName";
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
        GridColumn column = formTypeGrid.FindColumn(formTypeGrid.SortColumn);
        formTypeGrid_Bind(changeTrackingList, column.SortField, formTypeGrid.SortDirection);
        ttbSearch.ShowTrigger1 = true;
    }
}
