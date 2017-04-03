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

public partial class WorkRun_FrmAttachmentTransfer : PageBase
{
    FineOffice.BLL.OA_Attachment attBll = new FineOffice.BLL.OA_Attachment();
    FineOffice.BLL.OA_FlowSort sortBll = new FineOffice.BLL.OA_FlowSort();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;
            GridColumn column = attachmentGrid.FindColumn(attachmentGrid.SortColumn);
            attachmentGrid_Bind(changeTrackingList, column.SortField, attachmentGrid.SortDirection);

            btnTransfer.OnClientClick = attachmentGrid.GetNoSelectionAlertReference(string.Format("请至少选择一项{0}！", attachmentGrid.Title));
            btnTransfer.OnClientClick = attachmentGrid.GetNoSelectionAlertReference(string.Format("请至少选择一项{0}！", attachmentGrid.Title));

            btnChoose.OnClientClick = frmPersonnel.GetSaveStateReference(txtCreator.ClientID, hiddenField.ClientID)
                                                    + frmPersonnel.GetShowReference("../Common/FrmMultiPersonnel.aspx?selected=" + hiddenField.Text);
        }
    }

    private void LoadData()
    {
        List<FineOffice.Modules.OA_FlowSort> sortList = sortBll.GetListAll();
        ddlSort.Items.Clear();
        FineUI.ListItem li = new FineUI.ListItem();
        li.Text = "<请选择>";
        ddlSort.Items.Add(li);
        foreach (FineOffice.Modules.OA_FlowSort sort in sortList)
        {
            FineUI.ListItem item = new FineUI.ListItem();
            item.Text = sort.FlowSortName;
            item.Value = sort.ID.ToString();
            ddlSort.Items.Add(item);
        }
    }

    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = attachmentGrid.FindColumn(attachmentGrid.SortColumn);
        attachmentGrid_Bind(changeTrackingList, column.SortField, attachmentGrid.SortDirection);
    }

    protected void btnDownAttachment_Click(object sender, EventArgs e)
    {
        int id = int.Parse(attachmentGrid.DataKeys[attachmentGrid.SelectedRowIndex][0].ToString());
        FineOffice.Modules.OA_Attachment model = attBll.GetModel(d => d.ID == id);
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
            attBll.TransferToComAttachment(ids);
            Alert.ShowInParent("共 " + ids.Count + " 个文件成功转存！");
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }


    private void attachmentGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string sortDirection)
    {
        ChangeTrackingList<EntitySearcher> trackingList = new ChangeTrackingList<EntitySearcher>();
        foreach (EntitySearcher s in changeTrackingList)
        {
            trackingList.Add(s);
        }

        EntitySearcher search = new EntitySearcher();
        search.Field = "RunProcessID";
        search.Relation = "AND";
        search.Operator = "is";
        search.Content = "not null";
        trackingList.Add(search);

        attachmentGrid.RecordCount = attBll.GetCount(trackingList);
        ExtBindingList<FineOffice.Modules.OA_Attachment> list = attBll.GetList(trackingList, attachmentGrid.PageIndex, attachmentGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, sortDirection);
        attachmentGrid.DataSource = list;
        attachmentGrid.DataBind();
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void attachmentGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        attachmentGrid_Bind(changeTrackingList, e.SortField, e.SortDirection);
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void attachmentGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        attachmentGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = attachmentGrid.FindColumn(attachmentGrid.SortColumn);
        attachmentGrid_Bind(changeTrackingList, column.SortField, attachmentGrid.SortDirection);
    }

    protected void attachmentGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        try
        {
            object[] keys = attachmentGrid.DataKeys[e.RowIndex];
            int id = int.Parse(keys[0].ToString());
            if (e.CommandName == "delete")
            {
                attBll.Delete(new FineOffice.Modules.OA_Attachment { ID = id });
                ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
                GridColumn column = attachmentGrid.FindColumn(attachmentGrid.SortColumn);
                attachmentGrid_Bind(changeTrackingList, column.SortField, attachmentGrid.SortDirection);
            }
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }


    /// <summary>
    /// 清空查找信息
    /// </summary>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtCreator.Text = "";
        hiddenField.Text = "";
        dtpBegin.Text = "";
        dtpEnd.Text = "";
        txtWorkName.Text = "";
        ddlSort.SelectedIndex = 0;
        btnFind_Click(null, null);
    }

    /// <summary>
    /// 查询职员信息
    /// </summary>
    protected void btnFind_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        EntitySearcher search = new EntitySearcher();

        search = new EntitySearcher();
        search.Field = "WorkName";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtWorkName.Text;
        changeTrackingList.Add(search);

        if (ddlSort.SelectedValue.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "SortID";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = ddlSort.SelectedValue;
            changeTrackingList.Add(search);
        }

        if (hiddenField.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "Creator";
            search.Relation = "AND";
            search.Operator = "in";
            search.Content = "(" + hiddenField.Text.Substring(0, hiddenField.Text.Length - 1) + ")";
            changeTrackingList.Add(search);
        }

        if (dtpBegin.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "WorkCreateTime";
            search.Relation = "AND";
            search.Operator = ">=";
            search.Content = dtpBegin.Text;
            changeTrackingList.Add(search);
        }

        if (dtpEnd.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "WorkCreateTime";
            search.Relation = "AND";
            search.Operator = "<=";
            search.Content = dtpEnd.Text;
            changeTrackingList.Add(search);
        }

        ViewState["sql"] = changeTrackingList;
        GridColumn column = attachmentGrid.FindColumn(attachmentGrid.SortColumn);
        attachmentGrid_Bind(changeTrackingList, column.SortField, attachmentGrid.SortDirection);
    }
}
