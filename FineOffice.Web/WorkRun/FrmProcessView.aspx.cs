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
using System.Xml;
using System.Xml.Linq;
using FineOffice.Common.SerializeHelper;

public partial class WorkRun_FrmProcessView : PageBase
{
    FineOffice.BLL.OA_FlowRunProcess runProcessBll = new FineOffice.BLL.OA_FlowRunProcess();
    FineOffice.BLL.OA_FlowRunData runDataBll = new FineOffice.BLL.OA_FlowRunData();
    FineOffice.BLL.OA_Attachment attachmentBll = new FineOffice.BLL.OA_Attachment();
    FineOffice.BLL.HR_Personnel personnelBll = new FineOffice.BLL.HR_Personnel();
    FineOffice.BLL.OA_FlowProcess processBll = new FineOffice.BLL.OA_FlowProcess();
    FineOffice.BLL.Bussness.FlowRunHandler runHandlerBll = new FineOffice.BLL.Bussness.FlowRunHandler();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["RunProcess"] != null)
            {
                hiddenTabID.Text = Request["TabID"];
                int runProcessID = int.Parse(Request["RunProcess"]);
                FineOffice.Modules.OA_FlowRunProcess model = runProcessBll.GetModel(r => r.ID == runProcessID);

                hiddenVersion.Text = this.ByteToJson(model.Version);
                hiddenRunProcess.Text = model.ID.ToString();
                txtTransmitAdvice.Text = model.TransmitAdvice;

                lblRemrk.Text = model.Remark;
                lblCreateTime.Text = string.Format("{0:yyyy-MM-dd mm:ss}", model.WorkCreateTime);
                lblCreator.Text = model.CreateName;
                lblWorkName.Text = model.WorkName;
                lblWorkNO.Text = model.WorkNO;
                hiddenWork.Text = model.RunID.ToString();
              
                ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
                ViewState["formSql"] = changeTrackingList;
                GridColumn formColumn = formGrid.FindColumn(formGrid.SortColumn);
                formGrid_Bind(changeTrackingList, formColumn.SortField, formGrid.SortDirection);
               
                ViewState["attachmentSql"] = changeTrackingList;
                GridColumn attachmentColumn = attachmentGrid.FindColumn(attachmentGrid.SortColumn);
                attachmentGrid_Bind(changeTrackingList, attachmentColumn.SortField, attachmentGrid.SortDirection);

                btnPreview.OnClientClick = formGrid.GetNoSelectionAlertReference("请选择要预览的表单！");
                btnDownForm.OnClientClick = formGrid.GetNoSelectionAlertReference("请选择要下载的表单！");

                btnDownAttachment.OnClientClick = attachmentGrid.GetNoSelectionAlertReference("请选择要下载的附件！");
            }
        }
    }

    #region 表单数据  

    protected void btnDownForm_Click(object sender, EventArgs e)
    {
        int id = int.Parse(formGrid.DataKeys[formGrid.SelectedRowIndex][0].ToString());
        FineOffice.Modules.OA_FlowRunData model = runDataBll.GetModel(d => d.ID == id);
        byte[] formData = SharpZipLib.DeCompress(model.FormData);

        this.Response.Clear();
        this.Response.Buffer = true;
        this.Response.Charset = "utf-8";
        this.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(model.Title + "." + model.XType));
        this.Response.AddHeader("Content-Length", formData.Length.ToString());
        this.Response.ContentType = "application/msword";
        this.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        this.Response.OutputStream.Write(formData, 0, formData.Length);
        this.Response.Flush();
    }

    protected void btnPreview_Click(object sender, EventArgs e)
    {
        string tabID = string.Format("{0:HHmmssffff}", DateTime.Now);
        PageContext.RegisterStartupScript("openTab('_FrmPreviewForm" + tabID +
            "','表单预览-" + formGrid.DataKeys[formGrid.SelectedRowIndex][1] + "','WorkRun/FrmPreviewForm.aspx?ID=" + formGrid.DataKeys[formGrid.SelectedRowIndex][0] + "');");
    }

    protected void btnRefreshForm_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["formSql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = formGrid.FindColumn(formGrid.SortColumn);
        formGrid_Bind(changeTrackingList, column.SortField, formGrid.SortDirection);
    }

    private void formGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string sortDirection)
    {
        ChangeTrackingList<EntitySearcher> trackingList = new ChangeTrackingList<EntitySearcher>();
        foreach (EntitySearcher es in changeTrackingList)
        {
            trackingList.Add(es);
        }

        EntitySearcher searcher = new EntitySearcher();
        searcher.Content = hiddenWork.Text;
        searcher.Field = "RunID";
        searcher.Operator = "=";
        searcher.Relation = "AND";
        trackingList.Add(searcher);

        formGrid.RecordCount = runDataBll.GetCount(trackingList);
        ExtBindingList<FineOffice.Modules.OA_FlowRunData> list = runDataBll.GetList(trackingList, this.formGrid.PageIndex, this.formGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, sortDirection);
        formGrid.DataSource = list;
        formGrid.DataBind();
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void formGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["formSql"] as ChangeTrackingList<EntitySearcher>;
        formGrid_Bind(changeTrackingList, e.SortField, e.SortDirection);
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void formGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        this.formGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["formSql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = formGrid.FindColumn(formGrid.SortColumn);
        formGrid_Bind(changeTrackingList, column.SortField, formGrid.SortDirection);
    }
    #endregion

    #region 附件数据
    /// <summary>
    /// 数据分页
    /// </summary>
    protected void attachmentGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        this.attachmentGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["attachmentSql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = attachmentGrid.FindColumn(attachmentGrid.SortColumn);
        attachmentGrid_Bind(changeTrackingList, column.SortField, attachmentGrid.SortDirection);
    }

    protected void btnDownAttachment_Click(object sender, EventArgs e)
    {
        int id = int.Parse(attachmentGrid.DataKeys[attachmentGrid.SelectedRowIndex][0].ToString());
        FineOffice.Modules.OA_Attachment model = attachmentBll.GetModel(d => d.ID == id);
        byte[] attachmentData = SharpZipLib.DeCompress(model.AttachmentData);

        FineOffice.Web.FileTypeHelper typeHelper = new FineOffice.Web.FileTypeHelper();
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "utf-8";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + typeHelper.ToHexString(model.FileName + "." + model.XType));
        Response.AddHeader("Content-Length", attachmentData.Length.ToString());
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        Response.OutputStream.Write(attachmentData, 0, attachmentData.Length);
        Response.Flush();
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void attachmentGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["attachmentSql"] as ChangeTrackingList<EntitySearcher>;
        attachmentGrid_Bind(changeTrackingList, e.SortField, e.SortDirection);
    }

    protected void btnRefreshAtt_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["attachmentSql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = attachmentGrid.FindColumn(attachmentGrid.SortColumn);
        attachmentGrid_Bind(changeTrackingList, column.SortField, attachmentGrid.SortDirection);
    }

    private void attachmentGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string sortDirection)
    {
        ChangeTrackingList<EntitySearcher> trackingList = new ChangeTrackingList<EntitySearcher>();
        foreach (EntitySearcher es in changeTrackingList)
        {
            trackingList.Add(es);
        }
        EntitySearcher searcher = new EntitySearcher();
        searcher.Content = hiddenWork.Text;
        searcher.Field = "RunID";
        searcher.Operator = "=";
        searcher.Relation = "AND";
        trackingList.Add(searcher);

        attachmentGrid.RecordCount = attachmentBll.GetCount(trackingList);
        ExtBindingList<FineOffice.Modules.OA_Attachment> list = attachmentBll.GetList(trackingList, this.attachmentGrid.PageIndex, this.attachmentGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, sortDirection);
        attachmentGrid.DataSource = list;
        attachmentGrid.DataBind();
    }
    #endregion

    #region 步骤处方法

    /// <summary>
    /// 流程步骤
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRunDetail_Click(object sender, EventArgs e)
    {
        frmFlowRunDetail.IFrameUrl = string.Format("FrmFlowRunDetail.aspx?RunID={0}", hiddenWork.Text);
        frmFlowRunDetail.Hidden = false;
    }

    /// <summary>
    /// 流程事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRunEvent_Click(object sender, EventArgs e)
    {
        frmFlowRunEvent.IFrameUrl = string.Format("FrmFlowRunEvent.aspx?RunID={0}", hiddenWork.Text);
        frmFlowRunEvent.Hidden = false;
    }
    #endregion
}
