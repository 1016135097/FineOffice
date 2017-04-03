using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineOffice.Common.ListHelper;
using FineOffice.Common.SerializeHelper;
using FineOffice.Common.Excel;
using FineOffice.Modules.Helper;

public partial class Contract_FrmWriteContract : PageBase
{
    FineOffice.BLL.OA_ContractType typeBll = new FineOffice.BLL.OA_ContractType();
    FineOffice.BLL.OA_Contract contractBll = new FineOffice.BLL.OA_Contract();
    FineOffice.BLL.OA_Attachment attachmentBll = new FineOffice.BLL.OA_Attachment();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            txtTrader.OnClientTriggerClick = traderWin.GetSaveStateReference(txtTrader.ClientID, hiddenTraderID.ClientID)
                + traderWin.GetShowReference("../common/FrmRadioTrader.aspx");

            txtHandler.OnClientTriggerClick = handlerWin.GetSaveStateReference(txtHandler.ClientID, hiddenHandler.ClientID)
                + handlerWin.GetShowReference("../common/FrmRadioPersonnel.aspx");

            btnModifyAttachment.OnClientClick = attachmentGrid.GetNoSelectionAlertReference(string.Format("请选择要操作的{0}！", attachmentGrid.Title));
            btnDownAttachment.OnClientClick = attachmentGrid.GetNoSelectionAlertReference(string.Format("请选择要下载的{0}！", attachmentGrid.Title));
            btnDeleteAttachment.ConfirmText = string.Format("你确认要删除选中{0}吗！", attachmentGrid.Title);
            btnDeleteAttachment.ConfirmTarget = Target.Parent;

            btnUpload.Enabled = false;
            btnDeleteAttachment.Enabled = false;
            btnTransfer.Enabled = false;
            btnDownAttachment.Enabled = false;
            btnModifyAttachment.Enabled = false;
            btnRefreshAttachment.Enabled = false;

            if (Request["Write"] == null)
            {
                hiddenWrite.Text = "new";
            }
            else
            {
                int id = int.Parse(Request["ID"]);
                hiddenTabID.Text = this._FrmWriteContract.ID + id;
                FineOffice.Modules.OA_Contract model = contractBll.GetModel(t => t.ID == id);
                InitModule(model);
            }
            btnClose.OnClientClick = string.Format("parent.closeTabWindow('{0}');", this.hiddenTabID.Text);
        }
        if (Request.Form["__EVENTARGUMENT"] == "refresh_attachment")
        {
            btnRefreshAttachment_Click(null, null);
        }
    }

    private void InitModule(FineOffice.Modules.OA_Contract model)
    {
        hiddenWrite.Text = "modify";
        btnUpload.Enabled = true;
        btnDeleteAttachment.Enabled = true;
        btnTransfer.Enabled = true;
        btnDownAttachment.Enabled = true;
        btnModifyAttachment.Enabled = true;
        btnRefreshAttachment.Enabled = true;

        hiddenID.Text = model.ID.ToString();
        txtContent.Text = model.Content;
        txtContractName.Text = model.ContractName;
        txtContractNO.Text = model.ContractNO;
        dtpEndDate.Text = string.Format("{0:yyyy-MM-dd}", model.EndDate);
        dtpSingnDate.Text = string.Format("{0:yyyy-MM-dd}", model.SingnDate);
        if (model.Handler != null)
        {
            hiddenHandler.Text = model.Handler.ToString();
            txtHandler.Text = model.HandlerName;
        }
        txtLocation.Text = model.Location;
        txtRemark.Text = model.Remark;
        if (model.TraderID != null)
        {
            hiddenTraderID.Text = model.TraderID.ToString();
            txtTrader.Text = model.TraderName;
        }
        ddlType.SelectedValue = model.TypeID.ToString();
        attachmentGrid_Bind();
    }

    private void LoadData()
    {
        #region 合同类型
        List<FineOffice.Modules.OA_ContractType> typeList = typeBll.GetListAll();
        ddlType.Items.Clear();
        foreach (FineOffice.Modules.OA_ContractType type in typeList)
        {
            ddlType.Items.Add(type.TypeName, type.ID.ToString());
        }
        #endregion
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDeleteAttachment_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = attachmentGrid.SelectedRowIndexArray;
            List<int> deleteList = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                deleteList.Add(int.Parse((attachmentGrid.DataKeys[keys[i]][0]).ToString()));
            }
            attachmentBll.Delete(deleteList);
            attachmentGrid_Bind();
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }

    protected void btnRefreshAttachment_Click(object sender, EventArgs e)
    {
        attachmentGrid_Bind();
    }

    protected void btnTransfer_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = attachmentGrid.SelectedRowIndexArray;
            List<int> ids = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                ids.Add(int.Parse((attachmentGrid.DataKeys[keys[i]][0]).ToString()));
            }
            attachmentBll.TransferToComAttachment(ids);
            Alert.ShowInParent("共 " + ids.Count + " 个文件成功转存！");
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    protected void btnDownAttachment_Click(object sender, EventArgs e)
    {
        int id = int.Parse(attachmentGrid.DataKeys[attachmentGrid.SelectedRowIndex][0].ToString());
        FineOffice.Modules.OA_Attachment model = attachmentBll.GetModel(d => d.ID == id);
        byte[] attachment = SharpZipLib.DeCompress(model.AttachmentData);

        FineOffice.Web.FileTypeHelper typeHelper = new FineOffice.Web.FileTypeHelper();
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "utf-8";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + typeHelper.ToHexString(model.FileName + "." + model.XType));
        Response.AddHeader("Content-Length", attachment.Length.ToString());
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        Response.OutputStream.Write(attachment, 0, attachment.Length);
        Response.Flush();
    }

    private void attachmentGrid_Bind()
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        EntitySearcher searcher = new EntitySearcher();
        searcher.Field = "ContractID";
        searcher.Operator = "=";
        searcher.Relation = "AND";
        searcher.Content = hiddenID.Text;
        changeTrackingList.Add(searcher);

        GridColumn column = attachmentGrid.FindColumn(attachmentGrid.SortColumn);
        attachmentGrid.RecordCount = attachmentBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.OA_Attachment> list = attachmentBll.GetList(changeTrackingList, attachmentGrid.PageIndex, attachmentGrid.PageSize).ToBindingList();
        list.Sort(column.SortField, attachmentGrid.SortDirection);
        attachmentGrid.DataSource = list;
        attachmentGrid.DataBind();
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void attachmentGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        attachmentGrid_Bind();
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void attachmentGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        attachmentGrid_Bind();
    }

    protected void btnModifyAttachment_Click(object sender, EventArgs e)
    {
        modifyAttachmentWin.IFrameUrl = string.Format("../Common/FrmModifyAttachment.aspx?ID={0}", attachmentGrid.DataKeys[attachmentGrid.SelectedRowIndex][0]);
        modifyAttachmentWin.Hidden = false;
    }

    /// <summary>
    /// 删除附件的方法
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
                attachmentGrid_Bind();
            }
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        if (hiddenWrite.Text.Equals("modify"))
        {
            int id = int.Parse(hiddenID.Text);
            FineOffice.Modules.OA_Contract model = contractBll.GetModel(t => t.ID == id);
            InitModule(model);
        }
        else
        {
            txtContent.Text = "";
            txtContractName.Text = "";
            txtContractNO.Text = "";
            dtpEndDate.Text = "";
            dtpSingnDate.Text = "";
            hiddenHandler.Text = "";
            txtHandler.Text = "";
            txtLocation.Text = "";
            txtRemark.Text = "";
            hiddenTraderID.Text = "";
            txtTrader.Text = "";
            ddlType.SelectedIndex = 0;
        }
    }

    /// <summary>
    /// 上传文件
    /// </summary>
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        uploadAttachmentWin.IFrameUrl = string.Format("../Common/FrmUploadAttachment.aspx?ContractID={0}&TabID={1}", hiddenID.Text, hiddenTabID.Text);
        uploadAttachmentWin.Hidden = false;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.CookiePersonnel == null)
        {
            Alert.ShowInParent("当前用户不存在职员信息！");
            return;
        }
        FineOffice.Modules.OA_Contract model = new FineOffice.Modules.OA_Contract();
        bool modify = false;
        if (hiddenWrite.Text.Equals("modify"))
        {
            int id = int.Parse(hiddenID.Text);
            model = contractBll.GetModel(t => t.ID == id);
            modify = true;
        }
        model.Content = txtContent.Text.Trim();
        model.ContractName = txtContractName.Text.Trim();
        model.ContractNO = txtContractNO.Text.Trim();
        model.EndDate = DateTime.Parse(dtpEndDate.Text);
        model.SingnDate = DateTime.Parse(dtpSingnDate.Text);
        if (hiddenHandler.Text.Length > 0)
        {
            model.Handler = int.Parse(hiddenHandler.Text);
        }
        model.Location = txtLocation.Text;
        model.Remark = txtRemark.Text;
        if (hiddenTraderID.Text.Length > 0)
        {
            model.TraderID = int.Parse(hiddenTraderID.Text);
        }
        model.TypeID = int.Parse(ddlType.SelectedValue);
        try
        {
            if (modify)
                model = contractBll.Update(model);
            else
                model = contractBll.Add(model);
            InitModule(model);
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }
}
