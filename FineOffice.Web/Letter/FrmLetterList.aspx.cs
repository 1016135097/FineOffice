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

public partial class Letter_FrmLetterList : PageBase
{
    FineOffice.BLL.ADM_Letter letterBll = new FineOffice.BLL.ADM_Letter();
    FineOffice.BLL.ADM_LetterChannel chanelBll = new FineOffice.BLL.ADM_LetterChannel();
    FineOffice.BLL.ADM_LetterType typeBll = new FineOffice.BLL.ADM_LetterType();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            btnHandler.OnClientClick = wndHandler.GetSaveStateReference(txtHandler.ClientID, hiddenHandler.ClientID)
                                                  + wndHandler.GetShowReference("../Common/FrmMultiPersonnel.aspx?selected=" + hiddenHandler.Text);
            btnRecorder.OnClientClick = wndRecorder.GetSaveStateReference(txtRecorder.ClientID, hiddenRecorder.ClientID)
                                                  + wndRecorder.GetShowReference("../Common/FrmMultiPersonnel.aspx?selected=" + hiddenRecorder.Text);
            btnModify.OnClientClick = letterGrid.GetNoSelectionAlertReference(string.Format("请选择要操作的{0}！", letterGrid.Title));
            btnFollow.OnClientClick = letterGrid.GetNoSelectionAlertReference(string.Format("请选择要操作的{0}！", letterGrid.Title));
            btnDelete.OnClientClick = letterGrid.GetNoSelectionAlertReference(string.Format("请选择要操作的{0}！", letterGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中{0}吗！", letterGrid.Title);
            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;
            GridColumn column = letterGrid.FindColumn(letterGrid.SortColumn);
            letterGrid_Bind(changeTrackingList, column.SortField, letterGrid.SortDirection);
        }

        if (Request.Form["__EVENTARGUMENT"] == "param_from_selected")
        {
            btnHandler.OnClientClick = wndHandler.GetSaveStateReference(txtHandler.ClientID, hiddenHandler.ClientID)
                                                 + wndHandler.GetShowReference("../Common/FrmMultiPersonnel.aspx?selected=" + hiddenHandler.Text);
            btnRecorder.OnClientClick = wndRecorder.GetSaveStateReference(txtRecorder.ClientID, hiddenRecorder.ClientID)
                                                  + wndRecorder.GetShowReference("../Common/FrmMultiPersonnel.aspx?selected=" + hiddenRecorder.Text);
        }
    }

    protected void LoadData()
    {
        #region 渠道
        List<FineOffice.Modules.ADM_LetterChannel> channelList = chanelBll.GetListAll();
        ddlChannel.Items.Add("<全部>", "");
        foreach (FineOffice.Modules.ADM_LetterChannel channel in channelList)
        {
            ddlChannel.Items.Add(channel.Channel, channel.ID.ToString());
        }
        #endregion

        #region 问题分类
        List<FineOffice.Modules.ADM_LetterType> typeList = typeBll.GetListAll();
        ddlLetterType.Items.Add("<全部>", "");
        foreach (FineOffice.Modules.ADM_LetterType type in typeList)
        {
            ddlLetterType.Items.Add(type.LetterType, type.ID.ToString());
        }
        #endregion
    }

    /// <summary>
    /// 条件清空
    /// </summary>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtHandler.Text = "";
        hiddenHandler.Text = "";
        txtRecorder.Text = "";
        hiddenRecorder.Text = "";
        txtAddress.Text = "";
        txtIDCard.Text = "";
        txtLetterNO.Text = "";
        txtTitle.Text = "";
        txtVisitor.Text = "";
        ddlChannel.SelectedIndex = 0;
        ddlLetterType.SelectedIndex = 0;
        ddlSex.SelectedIndex = 0;
        dtpBeginDate.Text = "";
        dtpEndDate.Text = "";
        btnFind_Click(null, null);
    }

    protected void btnLoadOut_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        List<FineOffice.Modules.ADM_Letter> list = letterBll.GetList(changeTrackingList);

        FineOffice.Web.WebExcelHelper excelHelper = new FineOffice.Web.WebExcelHelper();
        FineOffice.Common.Excel.ExcelHelper toExcel = new FineOffice.Common.Excel.ExcelHelper();
        string serverPath = Server.MapPath("~/Config/Template/ADM_Letter.xml");
        List<ExcelHeader> headerList = toExcel.GetHeaderList(serverPath);

        toExcel.ApplicationName = excelHelper.ApplicationName;
        toExcel.Author = excelHelper.Author;
        toExcel.Comments = excelHelper.Comments;
        System.IO.MemoryStream ms = toExcel.Export<FineOffice.Modules.ADM_Letter>(list, letterGrid.Title, headerList);
        byte[] output = ms.ToArray();

        FineOffice.Web.FileTypeHelper typeHelper = new FineOffice.Web.FileTypeHelper();
        Response.AddHeader("Content-Disposition", "attachment; filename=" + typeHelper.ToHexString(string.Format("{0}{1:yyyyMMdd}", letterGrid.Title, DateTime.Now) + ".xls"));
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
        search.Field = "LetterNO";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtLetterNO.Text.Trim();
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "Visitor";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtVisitor.Text.Trim();
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "Title";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtTitle.Text.Trim();
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "IDCard";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtIDCard.Text.Trim();
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "Address";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtAddress.Text.Trim();
        changeTrackingList.Add(search);

        if (ddlSex.SelectedIndex != 0)
        {
            search = new EntitySearcher();
            search.Field = "Sex";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = ddlSex.SelectedValue;
            changeTrackingList.Add(search);
        }

        if (ddlChannel.SelectedIndex != 0)
        {
            search = new EntitySearcher();
            search.Field = "ChannelID";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = ddlChannel.SelectedValue;
            changeTrackingList.Add(search);
        }

        if (ddlLetterType.SelectedIndex != 0)
        {
            search = new EntitySearcher();
            search.Field = "TypeID";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = ddlLetterType.SelectedValue;
            changeTrackingList.Add(search);
        }

        if (dtpBeginDate.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "VisitTime";
            search.Relation = "AND";
            search.Operator = ">=";
            search.Content = dtpBeginDate.Text;
            changeTrackingList.Add(search);
        }
        if (dtpEndDate.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "VisitTime";
            search.Relation = "AND";
            search.Operator = "<=";
            search.Content = dtpEndDate.Text;
            changeTrackingList.Add(search);
        }

        if (hiddenRecorder.Text.Length > 0)
        {
            string recorder = hiddenRecorder.Text;
            search = new EntitySearcher();
            search.Field = "Recorder";
            search.Relation = "AND";
            search.Operator = "in";
            search.Content = "(" + recorder.Substring(0, recorder.Length - 1) + ")";
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
        GridColumn column = letterGrid.FindColumn(letterGrid.SortColumn);
        letterGrid_Bind(changeTrackingList, column.SortField, letterGrid.SortDirection);
    }

    private void letterGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        letterGrid.RecordCount = letterBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.ADM_Letter> list = letterBll.GetList(changeTrackingList, this.letterGrid.PageIndex, this.letterGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        letterGrid.DataSource = list;
        letterGrid.DataBind();
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void letterGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        this.letterGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = letterGrid.FindColumn(letterGrid.SortColumn);
        letterGrid_Bind(changeTrackingList, column.SortField, letterGrid.SortDirection);
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void letterGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = letterGrid.FindColumn(letterGrid.SortColumn);
        letterGrid_Bind(changeTrackingList, column.SortField, letterGrid.SortDirection);
    }

    /// <summary>
    /// 刷新信访信息
    /// </summary>
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = letterGrid.FindColumn(letterGrid.SortColumn);
        letterGrid_Bind(changeTrackingList, column.SortField, letterGrid.SortDirection);
    }

    /// <summary>
    /// 修改信访信息
    /// </summary>
    protected void btnModify_Click(object sender, EventArgs e)
    {
        try
        {
            object[] letter = letterGrid.DataKeys[letterGrid.SelectedRowIndex];
            string tabID = "_FrmWriteLetter" + letter[0];
            PageContext.RegisterStartupScript("openTab('" + tabID + "','编辑-"
                + letter[1] + "','Letter/FrmWriteLetter.aspx?ID="
                + letter[0] + "&Write=modify');");
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 信访跟进
    /// </summary>
    protected void btnFollow_Click(object sender, EventArgs e)
    {
        try
        {
            object[] letter = letterGrid.DataKeys[letterGrid.SelectedRowIndex];
            string tabID = "_FrmFollowList" + letter[0];
            PageContext.RegisterStartupScript("openTab('" + tabID + "','跟进-"
                + letter[1] + "','Letter/FrmFollowList.aspx?LetterID="
                + letter[0] + "');");
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
            int[] keys = letterGrid.SelectedRowIndexArray;
            List<int> ids = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                ids.Add(int.Parse((letterGrid.DataKeys[keys[i]][0]).ToString()));
            }
            letterBll.Delete(ids);
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = letterGrid.FindColumn(letterGrid.SortColumn);
            letterGrid_Bind(changeTrackingList, column.SortField, letterGrid.SortDirection);           
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }
}