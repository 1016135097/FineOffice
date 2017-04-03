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

public partial class Trader_FrmTraderList : PageBase
{
    FineOffice.BLL.CRM_Industry industryBll = new FineOffice.BLL.CRM_Industry();
    FineOffice.BLL.CRM_TraderType typeBll = new FineOffice.BLL.CRM_TraderType();
    FineOffice.BLL.CRM_Source sourceBll = new FineOffice.BLL.CRM_Source();
    FineOffice.BLL.CRM_Grade gradeBll = new FineOffice.BLL.CRM_Grade();
    FineOffice.BLL.CRM_Area areaBll = new FineOffice.BLL.CRM_Area();

    FineOffice.BLL.CRM_Trader traderBll = new FineOffice.BLL.CRM_Trader();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();

            txtArea.OnClientTriggerClick = selectAreaWin.GetSaveStateReference(txtArea.ClientID, hiddenAreaID.ClientID)
                 + selectAreaWin.GetShowReference("../common/FrmSelectArea.aspx");

            txtHandler.OnClientTriggerClick = handlerWin.GetSaveStateReference(txtHandler.ClientID, hiddenHandler.ClientID)
                + handlerWin.GetShowReference("../common/FrmMultiPersonnel.aspx");

            btnNew.OnClientClick = newTraderWin.GetShowReference();
            btnDelete.OnClientClick = traderGrid.GetNoSelectionAlertInParentReference(string.Format("请选择要删除的{0}!", traderGrid.Title));
            btnModify.OnClientClick = traderGrid.GetNoSelectionAlertInParentReference(string.Format("请选择要编辑的{0}!", traderGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中的{0}吗!", traderGrid.Title);           

            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;
            traderDataBind();
        }

        if (Request.Form["__EVENTARGUMENT"] == "param_from_selected")
        {
            txtHandler.OnClientTriggerClick = handlerWin.GetSaveStateReference(txtHandler.ClientID, hiddenHandler.ClientID)
               + handlerWin.GetShowReference("../Common/FrmMultiPersonnel.aspx?selected=" + hiddenHandler.Text);
        }
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            traderDataBind();
        }
    }

    protected void LoadData()
    {
        #region 行业
        List<FineOffice.Modules.CRM_Industry> industryList = industryBll.GetListAll();
        ddlIndustry.Items.Add("<全部>", "");
        foreach (FineOffice.Modules.CRM_Industry industry in industryList)
        {
            ddlIndustry.Items.Add(industry.Industry, industry.ID.ToString());
        }
        #endregion

        #region 企业性质
        List<FineOffice.Modules.CRM_TraderType> typeList = typeBll.GetListAll();
        ddlTraderType.Items.Add("<全部>", "");
        foreach (FineOffice.Modules.CRM_TraderType type in typeList)
        {
            ddlTraderType.Items.Add(type.TraderType, type.ID.ToString());
        }
        #endregion

        #region 企业来源
        List<FineOffice.Modules.CRM_Source> sourceList = sourceBll.GetListAll();
        ddlSource.Items.Add("<全部>", "");
        foreach (FineOffice.Modules.CRM_Source source in sourceList)
        {
            ddlSource.Items.Add(source.Source, source.ID.ToString());
        }
        #endregion

        #region 企业等级
        List<FineOffice.Modules.CRM_Grade> gradeList = gradeBll.GetListAll();
        ddlGrade.Items.Add("<全部>", "");
        foreach (FineOffice.Modules.CRM_Grade grade in gradeList)
        {
            ddlGrade.Items.Add(grade.Grade, grade.ID.ToString());
        }
        #endregion
    }

    public void traderDataBind()
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = traderGrid.FindColumn(traderGrid.SortColumn);
        traderGrid_Bind(changeTrackingList, column.SortField, traderGrid.SortDirection);
    }

    /// <summary>
    /// 条件清空
    /// </summary>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtHandler.Text = "";
        hiddenHandler.Text = "";
        txtArea.Text = "";
        hiddenAreaID.Text = "";
        txtTraderName.Text = "";
        txtTraderNO.Text = "";
        dtpBeginDate.Text = "";
        dtpEndDate.Text = "";
        ddlGrade.SelectedIndex = 0;
        ddlIndustry.SelectedIndex = 0;
        ddlSource.SelectedIndex = 0;
        ddlRule.SelectedIndex = 0;
        ddlTraderType.SelectedIndex = 0;
        btnFind_Click(null, null);
    }

    protected void btnLoadOut_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        List<FineOffice.Modules.CRM_Trader> list = traderBll.GetList(changeTrackingList);

        FineOffice.Web.WebExcelHelper excelHelper = new FineOffice.Web.WebExcelHelper();
        FineOffice.Common.Excel.ExcelHelper toExcel = new FineOffice.Common.Excel.ExcelHelper();
        string serverPath = Server.MapPath("~/Config/Template/CRM_Trader.xml");
        List<ExcelHeader> headerList = toExcel.GetHeaderList(serverPath);

        toExcel.ApplicationName = excelHelper.ApplicationName;
        toExcel.Author = excelHelper.Author;
        toExcel.Comments = excelHelper.Comments;
        System.IO.MemoryStream ms = toExcel.Export<FineOffice.Modules.CRM_Trader>(list, traderGrid.Title, headerList);
        byte[] output = ms.ToArray();

        FineOffice.Web.FileTypeHelper typeHelper = new FineOffice.Web.FileTypeHelper();
        Response.AddHeader("Content-Disposition", "attachment; filename=" + typeHelper.ToHexString(string.Format("{0}{1:yyyyMMdd}", traderGrid.Title, DateTime.Now) + ".xls"));
        Response.AddHeader("Content-Length", output.Length.ToString());
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        Response.OutputStream.Write(output, 0, output.Length);

        Response.Flush();
        Response.End();
    }

    /// <summary>
    /// 条件过滤
    /// </summary>
    protected void btnFind_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();

        EntitySearcher search = new EntitySearcher();
        search.Field = "TraderNO";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtTraderNO.Text.Trim();
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "TraderName";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtTraderName.Text.Trim();
        changeTrackingList.Add(search);

        if (dtpBeginDate.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "CreateTime";
            search.Relation = "AND";
            search.Operator = ">=";
            search.Content = dtpBeginDate.Text;
            changeTrackingList.Add(search);
        }
        if (dtpEndDate.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "CreateTime";
            search.Relation = "AND";
            search.Operator = "<=";
            search.Content = dtpEndDate.Text;
            changeTrackingList.Add(search);
        }

        if (ddlGrade.SelectedIndex != 0)
        {
            search = new EntitySearcher();
            search.Field = "GradeID";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = ddlGrade.SelectedValue;
            changeTrackingList.Add(search);
        }

        if (ddlIndustry.SelectedIndex != 0)
        {
            search = new EntitySearcher();
            search.Field = "IndustryID";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = ddlIndustry.SelectedValue;
            changeTrackingList.Add(search);
        }

        if (ddlSource.SelectedIndex != 0)
        {
            search = new EntitySearcher();
            search.Field = "Source";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = ddlSource.SelectedValue;
            changeTrackingList.Add(search);
        }

        if (ddlTraderType.SelectedIndex != 0)
        {
            search = new EntitySearcher();
            search.Field = "TypeID";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = ddlTraderType.SelectedValue;
            changeTrackingList.Add(search);
        }

        if (ddlRule.SelectedValue == "All")
        {
            search = new EntitySearcher();
            search.Field = "IsSupplier";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = "1";
            changeTrackingList.Add(search);

            search = new EntitySearcher();
            search.Field = "IsClient";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = "1";
            changeTrackingList.Add(search);
        }
        else if (ddlRule.SelectedValue == "Client")
        {
            search = new EntitySearcher();
            search.Field = "IsClient";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = "1";
            changeTrackingList.Add(search);
        }
        else if (ddlRule.SelectedValue == "Supplier")
        {
            search = new EntitySearcher();
            search.Field = "IsSupplier";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = "1";
            changeTrackingList.Add(search);
        }

        if (hiddenAreaID.Text.Length > 0)
        {
            int id = int.Parse(hiddenAreaID.Text);
            List<FineOffice.Modules.CRM_Area> tempList = areaBll.GetSubList(new FineOffice.Modules.CRM_Area { ID = id });
            StringBuilder area = new StringBuilder();
            foreach (FineOffice.Modules.CRM_Area a in tempList)
            {
                area.Append(a.ID);
                area.Append(",");
            }
            string strArea = area.ToString();
            search = new EntitySearcher();
            search.Field = "AreaID";
            search.Relation = "AND";
            search.Operator = "in";
            search.Content = "(" + strArea.Substring(0, strArea.Length - 1) + ")";
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
        GridColumn column = traderGrid.FindColumn(traderGrid.SortColumn);
        traderGrid_Bind(changeTrackingList, column.SortField, traderGrid.SortDirection);
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
    /// 数据分页
    /// </summary>
    protected void traderGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        this.traderGrid.PageIndex = e.NewPageIndex;
        traderDataBind();
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void traderGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        traderDataBind();
    }

    /// <summary>
    /// 刷新信访信息
    /// </summary>
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        traderDataBind();
    }

    /// <summary>
    /// 修改信访信息
    /// </summary>
    protected void btnModify_Click(object sender, EventArgs e)
    {
        modifyTraderWin.IFrameUrl = string.Format("FrmModifyTrader.aspx?ID={0}", traderGrid.DataKeys[traderGrid.SelectedRowIndex][0]);
        modifyTraderWin.Hidden = false;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = traderGrid.SelectedRowIndexArray;
            List<int> ids = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                ids.Add(int.Parse((traderGrid.DataKeys[keys[i]][0]).ToString()));
            }
            traderBll.Delete(ids);
            traderDataBind();
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }       
    }
}