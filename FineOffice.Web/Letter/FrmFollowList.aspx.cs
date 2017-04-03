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

public partial class Letter_FrmFollowList : PageBase
{
    FineOffice.BLL.ADM_LetterFollow followBll = new FineOffice.BLL.ADM_LetterFollow();
    FineOffice.BLL.OA_Attachment attachmentBll = new FineOffice.BLL.OA_Attachment();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnHandler.OnClientClick = wndHandler.GetSaveStateReference(txtHandler.ClientID, hiddenHandler.ClientID)
                                                  + wndHandler.GetShowReference("../Common/FrmMultiPersonnel.aspx?selected=" + hiddenHandler.Text);
            string letterID = Request["LetterID"];
            hiddenTabID.Text = this._FrmFollowList.ID + letterID;
            hiddenLetterID.Text = letterID;
            btnNewFollow.OnClientClick = wndNewFollow.GetShowReference("FrmNewFollow.aspx?LetterID=" + letterID);

            btnModifyFollow.OnClientClick = grdFollow.GetNoSelectionAlertReference("请选择要操作的数据！");
            btnDelelteFollow.ConfirmText = "你确认要删除选中的数据吗？";

            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["follow"] = changeTrackingList;
            GridColumn column = grdFollow.FindColumn(grdFollow.SortColumn);
            grdFollow_Bind(changeTrackingList, column.SortField, grdFollow.SortDirection);
            this.grdFollow.SelectedRowIndex = 0;

            btnUpload.OnClientClick = grdFollow.GetNoSelectionAlertReference("请先在在跟进情况中选择要操作的数据！");
            btnModifyFileName.OnClientClick = grdAttachment.GetNoSelectionAlertReference("请选择要操作的数据！");
            btnDownAttachment.OnClientClick = grdAttachment.GetNoSelectionAlertReference("请选择要下载的数据！");
            btnDeleteAttach.ConfirmText = "你确认要删除选中的数据吗？";
        }

        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["follow"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = grdFollow.FindColumn(grdFollow.SortColumn);
            grdFollow_Bind(changeTrackingList, column.SortField, grdFollow.SortDirection);
        }
        if (Request.Form["__EVENTARGUMENT"] == "param_from_selected")
        {
            btnHandler.OnClientClick = wndHandler.GetSaveStateReference(txtHandler.ClientID, hiddenHandler.ClientID)
                                                    + wndHandler.GetShowReference("../Common/FrmMultiPersonnel.aspx?selected=" + hiddenHandler.Text);
        }
        if (Request.Form["__EVENTARGUMENT"] == "refresh_attachment")
        {
            btnRefreshAttach_Click(null, null);
        }
    }

    #region 附件
    private void grdAttachment_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string sortDirection)
    {
        grdAttachment.RecordCount = attachmentBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.OA_Attachment> list = attachmentBll.GetList(changeTrackingList, this.grdAttachment.PageIndex, this.grdAttachment.PageSize).ToBindingList();
        list.Sort(sortColumn, sortDirection);
        grdAttachment.DataSource = list;
        grdAttachment.DataBind();
    }

    protected void grdFollow_RowSelect(object sender, FineUI.GridRowSelectEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        EntitySearcher searcher = new EntitySearcher();
        searcher.Field = "LetterFollowID";
        searcher.Operator = "=";
        searcher.Relation = "AND";
        searcher.Content = grdFollow.DataKeys[e.RowIndex][0].ToString();
        changeTrackingList.Add(searcher);

        this.grdAttachment.PageIndex = 0;
        GridColumn column = grdAttachment.FindColumn(grdAttachment.SortColumn);

        ViewState["attachment"] = changeTrackingList;
        grdAttachment_Bind(changeTrackingList, column.SortField, grdAttachment.SortDirection);
        btnUpload.OnClientClick = this.GetOnClientClick(searcher.Content);
    }

    /// <summary>
    /// 删除附件的方法
    /// </summary>
    protected void grdAttachment_RowCommand(object sender, GridCommandEventArgs e)
    {
        try
        {
            object[] keys = grdAttachment.DataKeys[e.RowIndex];
            int id = int.Parse(keys[0].ToString());
            if (e.CommandName == "delete")
            {
                attachmentBll.Delete(new FineOffice.Modules.OA_Attachment { ID = id });
                ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["attachment"] as ChangeTrackingList<EntitySearcher>;
                GridColumn column = grdAttachment.FindColumn(grdAttachment.SortColumn);
                grdAttachment_Bind(changeTrackingList, column.SortField, grdAttachment.SortDirection);
            }
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void grdAttachment_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["attachment"] as ChangeTrackingList<EntitySearcher>;
        grdAttachment_Bind(changeTrackingList, e.SortField, e.SortDirection);
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void grdAttachment_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        grdAttachment.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["attachment"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = grdAttachment.FindColumn(grdAttachment.SortColumn);
        grdAttachment_Bind(changeTrackingList, column.SortField, grdAttachment.SortDirection);
    }

    private string GetOnClientClick(string followID)
    {
        return grdFollow.GetNoSelectionAlertReference("请先在在跟进情况中选择要操作的数据！")
                             + wndAttachment.GetShowReference("../Common/FrmUploadAttachment.aspx?FollowID=" + followID + "&TabID="+this.hiddenTabID.Text);
    }

    protected void btnModifyFileName_Click(object sender, EventArgs e)
    {
        wndModifyAttachName.IFrameUrl = string.Format("../Common/FrmModifyAttachment.aspx?ID={0}", grdAttachment.DataKeys[grdAttachment.SelectedRowIndex][0]);
        wndModifyAttachName.Hidden = false;
    }
     
    protected void btnRefreshAttach_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["attachment"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = grdAttachment.FindColumn(grdAttachment.SortColumn);
        grdAttachment_Bind(changeTrackingList, column.SortField, grdAttachment.SortDirection);
    }

    protected void btnDownAttach_Click(object sender, EventArgs e)
    {
        int id = int.Parse(grdAttachment.DataKeys[grdAttachment.SelectedRowIndex][0].ToString());
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

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDeleteAttach_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = grdAttachment.SelectedRowIndexArray;
            List<int> deleteList = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                deleteList.Add(int.Parse((grdAttachment.DataKeys[keys[i]][0]).ToString()));
            }
            attachmentBll.Delete(deleteList);
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["attachment"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = grdAttachment.FindColumn(grdAttachment.SortColumn);
            grdAttachment_Bind(changeTrackingList, column.SortField, grdAttachment.SortDirection);
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }

    protected void btnTransferAttach_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = grdAttachment.SelectedRowIndexArray;
            List<int> ids = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                ids.Add(int.Parse((grdAttachment.DataKeys[keys[i]][0]).ToString()));
            }
            attachmentBll.TransferToComAttachment(ids);
            Alert.ShowInParent("共 " + ids.Count + " 个文件成功转存！");
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    #endregion

    /// <summary>
    /// 条件清空
    /// </summary>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtHandler.Text = "";
        hiddenHandler.Text = "";
        txtMoblie.Text = "";
        txtMoblie.Text = "";
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
        search.Field = "Linkman";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtLinkman.Text.Trim();
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "Mobile";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtMoblie.Text.Trim();
        changeTrackingList.Add(search);

        if (dtpBeginDate.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "HandleTime";
            search.Relation = "AND";
            search.Operator = ">=";
            search.Content = dtpBeginDate.Text;
            changeTrackingList.Add(search);
        }
        if (dtpEndDate.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "HandleTime";
            search.Relation = "AND";
            search.Operator = "<=";
            search.Content = dtpEndDate.Text;
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

        ViewState["follow"] = changeTrackingList;
        GridColumn column = grdFollow.FindColumn(grdFollow.SortColumn);
        grdFollow_Bind(changeTrackingList, column.SortField, grdFollow.SortDirection);
    }

    private void grdFollow_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        EntitySearcher search = new EntitySearcher();
        search.Field = "LetterID";
        search.Relation = "AND";
        search.Operator = "=";
        search.Content = hiddenLetterID.Text;
        changeTrackingList.Add(search);

        grdFollow.RecordCount = followBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.ADM_LetterFollow> list = followBll.GetList(changeTrackingList, this.grdFollow.PageIndex, this.grdFollow.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        grdFollow.DataSource = list;
        grdFollow.DataBind();
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void grdFollow_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        this.grdFollow.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["follow"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = grdFollow.FindColumn(grdFollow.SortColumn);
        grdFollow_Bind(changeTrackingList, column.SortField, grdFollow.SortDirection);
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void grdFollow_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["follow"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = grdFollow.FindColumn(grdFollow.SortColumn);
        grdFollow_Bind(changeTrackingList, column.SortField, grdFollow.SortDirection);
    }

    /// <summary>
    /// 刷新信息
    /// </summary>
    protected void btnRefreshFollow_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["follow"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = grdFollow.FindColumn(grdFollow.SortColumn);
        grdFollow_Bind(changeTrackingList, column.SortField, grdFollow.SortDirection);
    }

    /// <summary>
    /// 修改信息
    /// </summary>
    protected void btnModifyFollow_Click(object sender, EventArgs e)
    {
        try
        {
            object[] follow = grdFollow.DataKeys[grdFollow.SelectedRowIndex];
            wndModifyFollow.IFrameUrl = string.Format("FrmModifyFollow.aspx?ID={0}", follow[0]);
            wndModifyFollow.Hidden = false;
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDeleteFollow_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = grdFollow.SelectedRowIndexArray;
            List<int> ids = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                ids.Add(int.Parse((grdFollow.DataKeys[keys[i]][0]).ToString()));
            }
            followBll.Delete(ids);
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["follow"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = grdFollow.FindColumn(grdFollow.SortColumn);
            grdFollow_Bind(changeTrackingList, column.SortField, grdFollow.SortDirection);
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }
}