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

public partial class WorkRun_FrmHandleRunProcess : PageBase
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
            hiddenTabID.Text = Request["TabID"];
            int runProcessID = int.Parse(Request["RunProcess"]);
            FineOffice.Modules.OA_FlowRunProcess model = runProcessBll.GetModel(r => r.ID == runProcessID);

            btnReject.Visible = !model.IsStart.Value;
            tssReject.Visible = !model.IsStart.Value;
            btnSendback.Visible = !model.IsStart.Value;
            tssSendback.Visible = !model.IsStart.Value;

            hiddenVersion.Text = this.ByteToJson(model.Version);
            hiddenRunProcess.Text = model.ID.ToString();
            txtTransmitAdvice.Text = model.TransmitAdvice;

            lblRemrk.Text = model.Remark;
            lblCreateTime.Text = string.Format("{0:yyyy-MM-dd mm:ss}", model.WorkCreateTime);
            lblCreator.Text = model.CreateName;
            lblWorkName.Text = model.WorkName;
            lblWorkNO.Text = model.WorkNO;
            hiddenWork.Text = model.RunID.ToString();

            this.formGrid.PageIndex = 0;
            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["formSql"] = changeTrackingList;
            GridColumn formColumn = formGrid.FindColumn(formGrid.SortColumn);
            formGrid_Bind(changeTrackingList, formColumn.SortField, formGrid.SortDirection);

            this.attachmentGrid.PageIndex = 0;
            ViewState["attachmentSql"] = changeTrackingList;
            GridColumn attachmentColumn = attachmentGrid.FindColumn(attachmentGrid.SortColumn);
            attachmentGrid_Bind(changeTrackingList, attachmentColumn.SortField, attachmentGrid.SortDirection);

            btnNewForm.OnClientClick = frmNewFlowForm.GetShowReference("FrmNewFlowForm.aspx?ProcessID=" + model.ProcessID + "&RunProcess=" + model.ID);
            btnModifyForm.OnClientClick = formGrid.GetNoSelectionAlertReference("请选择要操作的表单！");
            btnDownForm.OnClientClick = formGrid.GetNoSelectionAlertReference("请选择要下载的表单！");
            btnPreview.OnClientClick = formGrid.GetNoSelectionAlertReference("请选择要预览的表单！");

            btnDownAttachment.OnClientClick = attachmentGrid.GetNoSelectionAlertReference("请选择要下载的附件！");
            btnModifyFileName.OnClientClick = attachmentGrid.GetNoSelectionAlertReference("请选择要操作的附件！");          
            btnReject.ConfirmText = String.Format("你确认要拒绝吗？");

            #region 加载选择下一步的数据

            btnNext.OnClientClick = this.frmNextProcess.GetShowReference();
            btnCloseNextProcess.OnClientClick = this.frmNextProcess.GetHideReference();

            if (model.Next != null)
            {
                string[] strList = model.Next.Split(',');
                List<FineOffice.Modules.OA_FlowProcess> processList = processBll.GetList(p => strList.Contains(p.ID));
                if (processList.Count > 0)
                {
                    this.processGrid.DataSource = processList;
                    this.processGrid.DataBind();
                    this.processGrid.SelectedRowIndex = 0;
                }
            }
            #endregion

            #region 加载退回的数据
            btnSendback.OnClientClick = this.frmSendBack.GetShowReference();
            btnCloseSendBack.OnClientClick = this.frmSendBack.GetHideReference();

            List<FineOffice.Modules.OA_FlowRunProcess> runProcessList = runHandlerBll.FlowRunProcessList(new FineOffice.Modules.OA_FlowRun { ID = (int)model.RunID });
            foreach (FineOffice.Modules.OA_FlowRunProcess temp in runProcessList)
            {
                if (temp.State != 0)
                {
                    radRunProcess.Items.Add(temp.ProcessName, temp.ID.ToString());
                }
            }
            radRunProcess.SelectedIndex = radRunProcess.Items.Count - 1;
            #endregion
        }
        if (Request.Form["__EVENTARGUMENT"] == "refreshRunData")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["formSql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = formGrid.FindColumn(formGrid.SortColumn);
            formGrid_Bind(changeTrackingList, column.SortField, formGrid.SortDirection);
        }
        if (Request.Form["__EVENTARGUMENT"] == "refresh_attachment")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["attachmentSql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = attachmentGrid.FindColumn(attachmentGrid.SortColumn);
            attachmentGrid_Bind(changeTrackingList, column.SortField, attachmentGrid.SortDirection);
        }
        if (Request.Form["__EVENTARGUMENT"] == "transmitClose")
        {
            PageContext.RegisterStartupScript("saveRunProcess();");
        }
    }

    #region 表单数据

    protected void formGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        try
        {
            object[] keys = formGrid.DataKeys[e.RowIndex];
            int id = int.Parse(keys[0].ToString());
            if (e.CommandName == "delete")
            {
                runDataBll.Delete(new FineOffice.Modules.OA_FlowRunData { ID = id });
                ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["formSql"] as ChangeTrackingList<EntitySearcher>;
                GridColumn column = formGrid.FindColumn(formGrid.SortColumn);
                formGrid_Bind(changeTrackingList, column.SortField, formGrid.SortDirection);
            }
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }

    protected void btnModifyForm_Click(object sender, EventArgs e)
    {
        frmModifyFlowForm.IFrameUrl = string.Format("FrmModifyFlowForm.aspx?ID={0}", formGrid.DataKeys[formGrid.SelectedRowIndex][0]);
        frmModifyFlowForm.Title = "编辑表单-" + formGrid.DataKeys[formGrid.SelectedRowIndex][1].ToString();
        frmModifyFlowForm.Hidden = false;
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

    /// <summary>
    /// 下载和删除附件的方法
    /// </summary>
    protected void attachmentGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        try
        {
            object[] keys = attachmentGrid.DataKeys[e.RowIndex];
            int id = int.Parse(keys[0].ToString());
            if (e.CommandName == "delete")
            {
                attachmentBll.Delete(new FineOffice.Modules.OA_Attachment { ID = id });
                ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["attachmentSql"] as ChangeTrackingList<EntitySearcher>;
                GridColumn column = attachmentGrid.FindColumn(attachmentGrid.SortColumn);
                attachmentGrid_Bind(changeTrackingList, column.SortField, attachmentGrid.SortDirection);
            }
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        if (CookiePersonnel == null)
        {
            FineUI.Alert.ShowInParent("当前用户不存在职员信息，不能上传文件！");
            return;
        }
        frmAttachment.IFrameUrl = string.Format("../Common/FrmUploadAttachment.aspx?RunProcess={0}&TabID={1}", hiddenRunProcess.Text, hiddenTabID.Text);
        frmAttachment.Hidden = false;
    }

    protected void btnModifyFileName_Click(object sender, EventArgs e)
    {
        frmModifyAttName.IFrameUrl = string.Format("../Common/FrmModifyAttachment.aspx?ID={0}", attachmentGrid.DataKeys[attachmentGrid.SelectedRowIndex][0]);
        frmModifyAttName.Hidden = false;
    }

    protected void btnRefreshAttach_Click(object sender, EventArgs e)
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

    protected void btnEnterNextProcess_Click(object sender, EventArgs e)
    {
        if (processGrid.SelectedRowIndexArray.Length == 0)
        {
            Alert.ShowInParent("请选择工作步骤！");
            return;
        }

        object[] process = processGrid.DataKeys[processGrid.SelectedRowIndex];
        object[] person = null;
        if (!(bool)process[3])
        {
            if (personGrid.SelectedRowIndexArray.Length == 0)
            {
                Alert.ShowInParent("请选办理人员！");
                return;
            }
            person = personGrid.DataKeys[personGrid.SelectedRowIndex];
        }

        FineOffice.Modules.OA_FlowRunProcess handle = runProcessBll.GetModel(p => p.ID == int.Parse(hiddenRunProcess.Text));
        handle.State = 1;//已办理,转入下一步
        handle.TrackingState = TrackingInfo.Updated;
        handle.Version = this.JsonTobyte(hiddenVersion.Text);
        handle.HandleTime = DateTime.Now;
        handle.TransmitAdvice = txtTransmitAdvice.Text;

        //创建新步骤
        FineOffice.Modules.OA_FlowRunProcess runProcess = new FineOffice.Modules.OA_FlowRunProcess();
        runProcess.AcceptTime = handle.HandleTime;
        runProcess.ProcessID = process[0].ToString();
        runProcess.RunID = handle.RunID;
        runProcess.State = 0;
        runProcess.Pattern = 1;//正常转入
        runProcess.SendID = handle.AcceptID;

        if (person != null)
            runProcess.AcceptID = int.Parse(person[0].ToString());
        else
            runProcess.AcceptID = handle.AcceptID;

        runProcess.PreviousID = handle.ID;
        runProcess.TrackingState = TrackingInfo.Created;

        try
        {
            runHandlerBll.HandleCreateRunProcess(handle, runProcess);
            PageContext.RegisterStartupScript("saveRunProcess();");
        }
        catch
        {
            Alert.ShowInParent("该流程已办理，不能操作！");
        }
    }

    /// <summary>
    /// 拒绝步骤
    /// </summary>
    protected void btnReject_Click(object sender, EventArgs e)
    {
        FineOffice.Modules.OA_FlowRunProcess currentProcess = runProcessBll.GetModel(p => p.ID == int.Parse(hiddenRunProcess.Text));
        currentProcess.State = 3;//拒绝
        currentProcess.TrackingState = TrackingInfo.Updated;
        currentProcess.Version = this.JsonTobyte(hiddenVersion.Text);
        currentProcess.HandleTime = DateTime.Now;
        currentProcess.TransmitAdvice = txtTransmitAdvice.Text;

        //查找上一步骤
        FineOffice.Modules.OA_FlowRunProcess previousProcess = runProcessBll.GetModel(p => p.ID == currentProcess.PreviousID);

        //创建办理
        FineOffice.Modules.OA_FlowRunProcess process = new FineOffice.Modules.OA_FlowRunProcess();
        process.State = 0;
        process.RunID = previousProcess.RunID;

        //拒绝的操作，刚刚是反转过来
        process.Pattern = 3;
        process.SendID = currentProcess.AcceptID;
        process.IsEntrance = previousProcess.IsEntrance;
        process.AcceptID = previousProcess.SendID;
        process.AcceptTime = currentProcess.HandleTime;
        process.ProcessID = previousProcess.ProcessID;
        process.TransmitAdvice = previousProcess.TransmitAdvice;
        process.PreviousID = previousProcess.PreviousID;
        process.TrackingState = TrackingInfo.Created;

        try
        {
            runHandlerBll.SendBackRunProcess(currentProcess, process);
            PageContext.RegisterStartupScript("saveRunProcess();");
        }
        catch
        {
            Alert.ShowInParent("该流程已办理，不能操作！");
        }
    }

    /// <summary>
    /// 退回步骤
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEnterSendBack_Click(object sender, EventArgs e)
    {
        FineOffice.Modules.OA_FlowRunProcess currentProcess = runProcessBll.GetModel(p => p.ID == int.Parse(hiddenRunProcess.Text));
        currentProcess.State = 4;//退回
        currentProcess.TrackingState = TrackingInfo.Updated;
        currentProcess.Version = this.JsonTobyte(hiddenVersion.Text);
        currentProcess.HandleTime = DateTime.Now;
        currentProcess.TransmitAdvice = txtTransmitAdvice.Text;

        int backID = int.Parse(radRunProcess.SelectedValue);
        //查找要退回的步骤
        FineOffice.Modules.OA_FlowRunProcess backProcess = runProcessBll.GetModel(p => p.ID == backID);

        //创建办理
        FineOffice.Modules.OA_FlowRunProcess process = new FineOffice.Modules.OA_FlowRunProcess();
        process.State = 0;
        process.RunID = backProcess.RunID;

        //退回的操作，刚刚是反转过来
        process.Pattern = 4;
        process.SendID = currentProcess.AcceptID;
        process.IsEntrance = backProcess.IsEntrance;
        process.AcceptID = backProcess.SendID;
        process.AcceptTime = currentProcess.HandleTime;
        process.ProcessID = backProcess.ProcessID;
        process.TransmitAdvice = backProcess.TransmitAdvice;
        process.PreviousID = backProcess.PreviousID;
        process.TrackingState = TrackingInfo.Created;

        try
        {
            runHandlerBll.SendBackRunProcess(currentProcess, process);
            PageContext.RegisterStartupScript("saveRunProcess();");
        }
        catch
        {
            Alert.ShowInParent("该流程已办理，不能操作！");
        }
    }

    protected void processGrid_RowSelect(object sender, FineUI.GridRowSelectEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> searcherList = new ChangeTrackingList<EntitySearcher>();

        //部门条件
        object department = processGrid.DataKeys[processGrid.SelectedRowIndex][2];
        string depCondition = department == null ? "" : department.ToString();
        EntitySearcher search = new EntitySearcher();
        search = new EntitySearcher();
        search.LeftParentheses = "(";
        search.Field = "DepartmentID";
        search.Relation = "OR";
        search.Operator = "in";
        StringBuilder dep = new StringBuilder();
        dep.Append("(");
        if (depCondition.Length > 0)
        {
            dep.Append(depCondition.Remove(depCondition.Length - 1));
        }
        else
        {
            dep.Append("0");
        }
        dep.Append(")");
        search.Content = dep.ToString();
        searcherList.Add(search);

        //员工条件
        search = new EntitySearcher();
        object person = processGrid.DataKeys[processGrid.SelectedRowIndex][1];
        string perCondition = person == null ? "" : person.ToString();
        search.RightParentheses = ")";
        search.Field = "ID";
        search.Operator = "in";
        StringBuilder str = new StringBuilder();
        str.Append("(");
        if (perCondition.Length > 0)
        {
            str.Append(perCondition.Remove(perCondition.Length - 1));
        }
        else
        {
            str.Append("0");
        }
        str.Append(")");

        search.Content = str.ToString();
        searcherList.Add(search);
        ExtBindingList<FineOffice.Modules.HR_Personnel> list = personnelBll.GetList(searcherList).ToBindingList();
        personGrid.DataSource = list;
        personGrid.DataBind();
    }

    /// <summary>
    /// 委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRunTransmit_Click(object sender, EventArgs e)
    {
        frmRunTransmit.IFrameUrl = string.Format("FrmFlowRunTransmit.aspx?ID={0}&Version={1}", hiddenRunProcess.Text, hiddenVersion.Text);
        frmRunTransmit.Hidden = false;
    }

    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int id = int.Parse(hiddenRunProcess.Text);
        FineOffice.Modules.OA_FlowRunProcess model = runProcessBll.GetModel(p => p.ID == id);
        model.TransmitAdvice = txtTransmitAdvice.Text.Trim();
        model.Version = JsonTobyte(hiddenVersion.Text);

        model = runProcessBll.Update(model);
        hiddenVersion.Text = ByteToJson(model.Version);
    }

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
