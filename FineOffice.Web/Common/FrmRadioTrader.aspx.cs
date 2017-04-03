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

public partial class Common_FrmRadioTrader : PageBase
{
    FineOffice.BLL.CRM_Trader traderBll = new FineOffice.BLL.CRM_Trader();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.traderGrid.PageIndex = 0;
            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;
            GridColumn column = traderGrid.FindColumn(traderGrid.SortColumn);
            traderGrid_Bind(changeTrackingList, column.SortField, traderGrid.SortDirection);

            btnAdd.OnClientClick = newTraderWin.GetShowReference();
            btnModify.OnClientClick = traderGrid.GetNoSelectionAlertReference("请选择要编辑的" + traderGrid.Title + "！");
            btnDelelte.OnClientClick = traderGrid.GetNoSelectionAlertReference("请选择要删除的" + traderGrid.Title + "！");
            btnDelelte.ConfirmText = "你确认要删除选中的" + traderGrid.Title + "吗？";
        }
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = traderGrid.FindColumn(traderGrid.SortColumn);
            traderGrid_Bind(changeTrackingList, column.SortField, traderGrid.SortDirection);
        }
    }

    protected void btnEnter_Click(object sender, EventArgs e)
    {
        string id = "";
        string name = "";
        if (traderGrid.SelectedRowIndex > -1)
        {
            List<object[]> ids = traderGrid.DataKeys;
            object[] obj = ids[traderGrid.SelectedRowIndex];
            id = obj == null ? "" : obj[0].ToString();
            name = obj == null ? "" : obj[1].ToString();
        }

        PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(name, id)
            + ActiveWindow.GetHidePostBackReference("param_from_selected"));
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        int[] keys = traderGrid.SelectedRowIndexArray;
        List<int> deleteList = new List<int>();
        for (int i = 0; i < keys.Length; i++)
        {
            deleteList.Add(int.Parse((traderGrid.DataKeys[keys[i]][0]).ToString()));
        }
        try
        {
            traderBll.Delete(deleteList);
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = traderGrid.FindColumn(traderGrid.SortColumn);
        traderGrid_Bind(changeTrackingList, column.SortField, traderGrid.SortDirection);

    }

    protected void traderGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            try
            {
                object[] keys = traderGrid.DataKeys[e.RowIndex];
                traderBll.Delete(new FineOffice.Modules.CRM_Trader { ID = int.Parse(keys[0].ToString()) });
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = traderGrid.FindColumn(traderGrid.SortColumn);
            traderGrid_Bind(changeTrackingList, column.SortField, traderGrid.SortDirection);
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        modifyTraderWin.IFrameUrl = string.Format("../Trader/FrmModifyTrader.aspx?ID={0}", traderGrid.DataKeys[traderGrid.SelectedRowIndex][0]);
        modifyTraderWin.Hidden = false;
    }

    private void traderGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        traderGrid.RecordCount = traderBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.CRM_Trader> list = traderBll.GetList(changeTrackingList, this.traderGrid.PageIndex, this.traderGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        traderGrid.DataSource = list;
        traderGrid.DataBind();
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void traderGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        traderGrid_Bind(changeTrackingList, e.SortField, e.SortDirection);
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void traderGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = traderGrid.FindColumn(traderGrid.SortColumn);
        traderGrid_Bind(changeTrackingList, column.SortField, traderGrid.SortDirection);
    }

    /// <summary>
    /// 查询职员信息
    /// </summary>
    protected void btnFind_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        EntitySearcher search = new EntitySearcher();
        search.Field = "TraderNO";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtTraderNO.Text;
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "TraderName";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtTraderName.Text;
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "PinyinCode";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtPingyinCode.Text;
        changeTrackingList.Add(search);

        ViewState["sql"] = changeTrackingList;
        GridColumn column = traderGrid.FindColumn(traderGrid.SortColumn);
        traderGrid_Bind(changeTrackingList, column.SortField, traderGrid.SortDirection);
    }
}
