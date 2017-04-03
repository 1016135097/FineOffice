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

public partial class System_FrmUserList : PageBase
{
    FineOffice.BLL.SYS_User userBll = new FineOffice.BLL.SYS_User();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.userGrid.PageIndex = 0;
            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;

            GridColumn column = userGrid.FindColumn(userGrid.SortColumn);
            userGrid_Bind(changeTrackingList, column.SortField, userGrid.SortDirection);

            btnAdd.OnClientClick = newUserWin.GetShowReference();
            btnModify.OnClientClick = userGrid.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", userGrid.Title));
            btnAwardRole.OnClientClick = userGrid.GetNoSelectionAlertReference(string.Format("请选择要授权的{0}！", userGrid.Title));
            btnDelete.OnClientClick = userGrid.GetNoSelectionAlertReference(string.Format("请选择要删除的{0}！", userGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中{0}吗！", userGrid.Title);
        }
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = userGrid.FindColumn(userGrid.SortColumn);
            userGrid_Bind(changeTrackingList, column.SortField, userGrid.SortDirection);
        }
    }

    protected void btnAwardRole_Click(object sender, EventArgs e)
    {
        awardRoleWin.IFrameUrl = string.Format("FrmAwardRole.aspx?id={0}", userGrid.DataKeys[userGrid.SelectedRowIndex][0]);
        awardRoleWin.Hidden = false;
        awardRoleWin.Title = string.Format("授权-{0}", userGrid.DataKeys[userGrid.SelectedRowIndex][1]);
    }
    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = userGrid.SelectedRowIndexArray;
            List<int> deleteList = new List<int>();   
            for (int i = 0; i < keys.Length; i++)
            {
                bool isModify = bool.Parse(userGrid.DataKeys[keys[i]][2].ToString());
                if(isModify)
                    deleteList.Add(int.Parse((userGrid.DataKeys[keys[i]][0]).ToString()));
            }
            userBll.Delete(deleteList);
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = userGrid.FindColumn(userGrid.SortColumn);
            userGrid_Bind(changeTrackingList, column.SortField, userGrid.SortDirection);
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    protected void userGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            try
            {
                object[] keys = userGrid.DataKeys[e.RowIndex];
                int id = int.Parse(keys[0].ToString());
                FineOffice.Modules.SYS_User model = userBll.GetModel(d => d.ID == id);
                if (!model.IsModify.Value)
                {
                    Alert.ShowInParent(string.Format("用户账号：{0}，不允许删除！", model.UserName));
                    return;
                }
                userBll.Delete(model);
                ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
                GridColumn column = userGrid.FindColumn(userGrid.SortColumn);
                userGrid_Bind(changeTrackingList, column.SortField, userGrid.SortDirection);
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        modifyUserWin.IFrameUrl = string.Format("FrmModifyUser.aspx?id={0}", userGrid.DataKeys[userGrid.SelectedRowIndex][0]);
        modifyUserWin.Hidden = false;
    }

    private void userGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        userGrid.RecordCount = userBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.SYS_User> list = userBll.GetList(changeTrackingList, this.userGrid.PageIndex, this.userGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        userGrid.DataSource = list;
        userGrid.DataBind();
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void userGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        userGrid_Bind(changeTrackingList, e.SortField, e.SortDirection);
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void userGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        this.userGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = userGrid.FindColumn(userGrid.SortColumn);
        userGrid_Bind(changeTrackingList, column.SortField, userGrid.SortDirection);
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
        GridColumn column = userGrid.FindColumn(userGrid.SortColumn);
        userGrid_Bind(changeTrackingList, column.SortField, userGrid.SortDirection);
    }

    /// <summary>
    /// 按条件查询
    /// </summary>
    protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        EntitySearcher search = new EntitySearcher();
        search.Field = "UserName";
        search.Relation = "or";
        search.Operator = "Like";
        search.Content = ttbSearch.Text;
        changeTrackingList.Add(search);

        ViewState["sql"] = changeTrackingList;
        GridColumn column = userGrid.FindColumn(userGrid.SortColumn);
        userGrid_Bind(changeTrackingList, column.SortField, userGrid.SortDirection);
        ttbSearch.ShowTrigger1 = true;
    }
}
