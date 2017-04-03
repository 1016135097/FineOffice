using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineOffice.Web;
using FineUI;
using FineOffice.Modules.Helper;
using FineOffice.Common.ListHelper;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using FineOffice.Common.SerializeHelper;
using FineOffice.Common.Excel;

public partial class Contract_FrmContractList : PageBase
{
    FineOffice.BLL.OA_ContractType typeBll = new FineOffice.BLL.OA_ContractType();
    FineOffice.BLL.OA_Contract contractBll = new FineOffice.BLL.OA_Contract();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            txtTrader.OnClientTriggerClick = traderWin.GetSaveStateReference(txtTrader.ClientID, hiddenTraderID.ClientID)
             + traderWin.GetShowReference("../common/FrmRadioTrader.aspx");

            txtHandler.OnClientTriggerClick = handlerWin.GetSaveStateReference(txtHandler.ClientID, hiddenHandler.ClientID)
                + handlerWin.GetShowReference("../common/FrmMultiPersonnel.aspx");

            btnDelete.OnClientClick = contractGrid.GetNoSelectionAlertInParentReference(string.Format("请选择要删除的{0}!", contractGrid.Title));
            btnModify.OnClientClick = contractGrid.GetNoSelectionAlertInParentReference(string.Format("请选择要编辑的{0}!", contractGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中的{0}吗!", contractGrid.Title);
            btnDelete.ConfirmTarget = Target.Parent;
            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;
            Data_Bind();
        }

        if (Request.Form["__EVENTARGUMENT"] == "param_from_selected")
        {
            txtHandler.OnClientTriggerClick = handlerWin.GetSaveStateReference(txtHandler.ClientID, hiddenHandler.ClientID)
               + handlerWin.GetShowReference("../Common/FrmMultiPersonnel.aspx?selected=" + hiddenHandler.Text);
        }
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            Data_Bind();
        }
    }

    protected void LoadData()
    {
        #region 类别
        List<FineOffice.Modules.OA_ContractType> typeList = typeBll.GetListAll();
        ddlType.Items.Add("<全部>", "");
        foreach (FineOffice.Modules.OA_ContractType type in typeList)
        {
            ddlType.Items.Add(type.TypeName, type.ID.ToString());
        }
        #endregion
    }

    public void Data_Bind()
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = contractGrid.FindColumn(contractGrid.SortColumn);
        contractGrid_Bind(changeTrackingList, column.SortField, contractGrid.SortDirection);
    }

    /// <summary>
    /// 条件清空
    /// </summary>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtHandler.Text = "";
        txtTrader.Text = "";
        hiddenTraderID.Text = "";
        hiddenHandler.Text = "";
        txtContractName.Text = "";
        txtContractNO.Text = "";
        dtpBeginDate.Text = "";
        dtpEndDate.Text = "";
        btnFind_Click(null, null);
    }

    /// <summary>
    /// 条件过滤
    /// </summary>
    protected void btnFind_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();

        EntitySearcher search = new EntitySearcher();
        search.Field = "ContractNO";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtContractNO.Text.Trim();
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "ContractName";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtContractName.Text.Trim();
        changeTrackingList.Add(search);

        if (dtpBeginDate.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "SingnDate";
            search.Relation = "AND";
            search.Operator = ">=";
            search.Content = dtpBeginDate.Text;
            changeTrackingList.Add(search);
        }
        if (dtpEndDate.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "SingnDate";
            search.Relation = "AND";
            search.Operator = "<=";
            search.Content = dtpEndDate.Text;
            changeTrackingList.Add(search);
        }

        if (ddlType.SelectedIndex != 0)
        {
            search = new EntitySearcher();
            search.Field = "TypeID";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = ddlType.SelectedValue;
            changeTrackingList.Add(search);
        }

        if (hiddenTraderID.Text.Length > 0)
        {
            string handler = hiddenHandler.Text;
            search = new EntitySearcher();
            search.Field = "TraderID";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = hiddenTraderID.Text;
            changeTrackingList.Add(search);
        }

        if (hiddenHandler.Text.Length > 0)
        {
            string handler = hiddenHandler.Text;
            search = new EntitySearcher();
            search.Field = "Handler";
            search.Relation = "AND";
            search.Operator = "in";
            search.Content = "(" + handler.Substring(0, handler.Length - 1) + ")";
            changeTrackingList.Add(search);
        }

        ViewState["sql"] = changeTrackingList;
        GridColumn column = contractGrid.FindColumn(contractGrid.SortColumn);
        contractGrid_Bind(changeTrackingList, column.SortField, contractGrid.SortDirection);
    }

    private void contractGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        contractGrid.RecordCount = contractBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.OA_Contract> list = contractBll.GetList(changeTrackingList, this.contractGrid.PageIndex, this.contractGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        contractGrid.DataSource = list;
        contractGrid.DataBind();
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void contractGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        this.contractGrid.PageIndex = e.NewPageIndex;
        Data_Bind();
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void contractGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        Data_Bind();
    }

    /// <summary>
    /// 刷新合同信息
    /// </summary>
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        Data_Bind();
    }

    /// <summary>
    /// 修改合同信息
    /// </summary>
    protected void btnModify_Click(object sender, EventArgs e)
    {
        try
        {
            object[] letter = contractGrid.DataKeys[contractGrid.SelectedRowIndex];
            string tabID = "_FrmWriteContract" + letter[0];
            PageContext.RegisterStartupScript("openTab('" + tabID + "','编辑-"
                + letter[1] + "','Contract/FrmWriteContract.aspx?ID="
                + letter[0] + "&Write=modify');");
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = contractGrid.SelectedRowIndexArray;
            List<int> ids = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                ids.Add(int.Parse((contractGrid.DataKeys[keys[i]][0]).ToString()));
            }
            contractBll.Delete(ids);
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
        Data_Bind();
    }
}