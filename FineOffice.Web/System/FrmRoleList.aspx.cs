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

public partial class System_FrmRoleList : PageBase
{
    FineOffice.BLL.SYS_Role roleBll = new FineOffice.BLL.SYS_Role();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.rolebGrid.PageIndex = 0;
            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;

            GridColumn column = rolebGrid.FindColumn(rolebGrid.SortColumn);
            rolebGrid_Bind(changeTrackingList, column.SortField, rolebGrid.SortDirection);

            btnNew.OnClientClick = newRoleWin.GetShowReference();
            btnModify.OnClientClick = rolebGrid.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", rolebGrid.Title));
            btnDelete.OnClientClick = rolebGrid.GetNoSelectionAlertReference(string.Format("请选择要删除的{0}！", rolebGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中{0}吗！", rolebGrid.Title);
        }
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = rolebGrid.FindColumn(rolebGrid.SortColumn);
            rolebGrid_Bind(changeTrackingList, column.SortField, rolebGrid.SortDirection);
        }
    }

    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        rolebGrid.SelectAllRows();
    }
    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = rolebGrid.SelectedRowIndexArray;
            List<int> deleteList = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                bool isModify = bool.Parse(rolebGrid.DataKeys[keys[i]][2].ToString());
                if (isModify)
                    deleteList.Add(int.Parse((rolebGrid.DataKeys[keys[i]][0]).ToString()));
            }
            roleBll.Delete(deleteList);
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = rolebGrid.FindColumn(rolebGrid.SortColumn);
            rolebGrid_Bind(changeTrackingList, column.SortField, rolebGrid.SortDirection);
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    protected void rolebGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            try
            {
                object[] keys = rolebGrid.DataKeys[e.RowIndex];
                int id = int.Parse(keys[0].ToString());
                FineOffice.Modules.SYS_Role model = roleBll.GetModel(m => m.ID == id);
                if (!model.IsModify.Value)
                {
                    Alert.ShowInParent(string.Format("系统角色：{0}，不允许删除！", model.RoleName));
                    return;
                }
                roleBll.Delete(model);
                ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
                GridColumn column = rolebGrid.FindColumn(rolebGrid.SortColumn);
                rolebGrid_Bind(changeTrackingList, column.SortField, rolebGrid.SortDirection);
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        modifyRoleWin.IFrameUrl = string.Format("FrmModifyRole.aspx?id={0}", rolebGrid.DataKeys[rolebGrid.SelectedRowIndex][0]);
        modifyRoleWin.Hidden = false;
    }

    private void rolebGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        rolebGrid.RecordCount = roleBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.SYS_Role> list = roleBll.GetList(changeTrackingList, this.rolebGrid.PageIndex, this.rolebGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        rolebGrid.DataSource = list;
        rolebGrid.DataBind();
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void rolebGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        rolebGrid_Bind(changeTrackingList, e.SortField, e.SortDirection);
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void rolebGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        this.rolebGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = rolebGrid.FindColumn(rolebGrid.SortColumn);
        rolebGrid_Bind(changeTrackingList, column.SortField, rolebGrid.SortDirection);
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
        GridColumn column = rolebGrid.FindColumn(rolebGrid.SortColumn);
        rolebGrid_Bind(changeTrackingList, column.SortField, rolebGrid.SortDirection);
    }

    /// <summary>
    /// 按条件查询
    /// </summary>
    protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        EntitySearcher search = new EntitySearcher();
        search.Field = "RoleName";
        search.Relation = "or";
        search.Operator = "Like";
        search.Content = ttbSearch.Text;
        changeTrackingList.Add(search);

        ViewState["sql"] = changeTrackingList;
        GridColumn column = rolebGrid.FindColumn(rolebGrid.SortColumn);
        rolebGrid_Bind(changeTrackingList, column.SortField, rolebGrid.SortDirection);
        ttbSearch.ShowTrigger1 = true;
    }
}
