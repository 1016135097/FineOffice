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

public partial class Census_FrmCensusRegister : PageBase
{
    FineOffice.BLL.CNS_CensusMember memberBll = new FineOffice.BLL.CNS_CensusMember();
    FineOffice.BLL.CNS_CensusType typeBll = new FineOffice.BLL.CNS_CensusType();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            btnNewMember.OnClientClick = frmNewCensusMember.GetShowReference("FrmNewCensusMember.aspx");
            btnLoadIn.OnClientClick = frmExcelToMember.GetShowReference("FrmExcelToMember.aspx");

            btnModifyMember.OnClientClick = memberGird.GetNoSelectionAlertReference("请选择要操作的数据！");
            btnDeleteMember.ConfirmText = "你确认要删除选中的人口信息吗？";

            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;
            GridColumn column = memberGird.FindColumn(memberGird.SortColumn);
            memberGrid_Bind(changeTrackingList, column.SortField, memberGird.SortDirection);

        }
        if (Request.Form["__EVENTARGUMENT"] == "member_close")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = memberGird.FindColumn(memberGird.SortColumn);
            memberGrid_Bind(changeTrackingList, column.SortField, memberGird.SortDirection);
        }
    }

    protected void LoadData()
    {
        List<FineOffice.Modules.CNS_CensusType> list = typeBll.GetListAll();
        ddlCensusType.Items.Add(new FineUI.ListItem("<全部>", "0"));
        foreach (FineOffice.Modules.CNS_CensusType type in list)
        {
            ddlCensusType.Items.Add(new FineUI.ListItem(type.CensusTypeName, type.ID.ToString()));
        }
    }

    /// <summary>
    /// 条件清空
    /// </summary>
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtRegisterNO.Text = "";
        txtAddress.Text = "";
        txtIDCard.Text = "";
        txtName.Text = "";
        ddlCensusType.SelectedIndex = 0;
        ddlIsCanceled.SelectedIndex = 0;
        ddlSex.SelectedIndex = 0;
        txtHouseHolder.Text = "";
        dtpBrithdayBegin.Text = "";
        dtpBrithdayEnd.Text = "";
        dtpIngoingDateBegin.Text = "";
        dtpIngoingDateEnd.Text = "";
        ddlCensusType.SelectedIndex = 0;
        btnFind_Click(null, null);
    }

    protected void btnTemplates_Click(object sender, EventArgs e)
    {
        FineOffice.Web.WebExcelHelper excelHelper = new FineOffice.Web.WebExcelHelper();
        FineOffice.Common.Excel.ExcelHelper toExcel = new FineOffice.Common.Excel.ExcelHelper();
        string serverPath = Server.MapPath("~/Config/Template/CNS_CensusMember.xml");
        List<ExcelHeader> headerList = toExcel.GetHeaderList(serverPath);
        toExcel.ApplicationName = excelHelper.ApplicationName;
        toExcel.Author = excelHelper.Author;
        toExcel.Comments = excelHelper.Comments;
        System.IO.MemoryStream ms = toExcel.Export<FineOffice.Modules.CNS_CensusMember>(new List<FineOffice.Modules.CNS_CensusMember>(), memberGird.Title, headerList);
        byte[] output = ms.ToArray();

        FineOffice.Web.FileTypeHelper typeHelper = new FineOffice.Web.FileTypeHelper();
        Response.AddHeader("Content-Disposition", "attachment; filename=" + typeHelper.ToHexString(memberGird.Title + ".xls"));
        Response.AddHeader("Content-Length", output.Length.ToString());
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");//设置输出流的字符集
        Response.OutputStream.Write(output, 0, output.Length); //输出 

        Response.Flush();
        Response.End();
    }

    protected void btnLoadOut_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        List<FineOffice.Modules.CNS_CensusMember> list = memberBll.GetList(changeTrackingList);

        FineOffice.Web.WebExcelHelper excelHelper = new FineOffice.Web.WebExcelHelper();
        FineOffice.Common.Excel.ExcelHelper toExcel = new FineOffice.Common.Excel.ExcelHelper();
        string serverPath = Server.MapPath("~/Config/Template/CNS_CensusMember.xml");
        List<ExcelHeader> headerList = toExcel.GetHeaderList(serverPath);
        toExcel.ApplicationName = excelHelper.ApplicationName;
        toExcel.Author = excelHelper.Author;
        toExcel.Comments = excelHelper.Comments;
        System.IO.MemoryStream ms = toExcel.Export<FineOffice.Modules.CNS_CensusMember>(list, memberGird.Title, headerList);
        byte[] output = ms.ToArray();

        FineOffice.Web.FileTypeHelper typeHelper = new FineOffice.Web.FileTypeHelper();
        Response.AddHeader("Content-Disposition", "attachment; filename=" + typeHelper.ToHexString(string.Format("{0}{1:yyyyMMdd}", memberGird.Title, DateTime.Now) + ".xls"));
        Response.AddHeader("Content-Length", output.Length.ToString());
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");//设置输出流的字符集
        Response.OutputStream.Write(output, 0, output.Length); //输出 

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
        search.Field = "RegisterNO";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtRegisterNO.Text.Trim();
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "HouseHolder";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtHouseHolder.Text.Trim();
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "Name";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtName.Text;
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

        search = new EntitySearcher();
        search.Field = "IDCard";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtIDCard.Text;
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "Address";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtAddress.Text;
        changeTrackingList.Add(search);

        if (dtpBrithdayBegin.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "Brithday";
            search.Relation = "AND";
            search.Operator = ">=";
            search.Content = dtpBrithdayBegin.Text;
            changeTrackingList.Add(search);
        }

        if (dtpBrithdayEnd.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "Brithday";
            search.Relation = "AND";
            search.Operator = "<=";
            search.Content = dtpBrithdayEnd.Text;
            changeTrackingList.Add(search);
        }

        if (dtpIngoingDateBegin.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "IngoingDate";
            search.Relation = "AND";
            search.Operator = ">=";
            search.Content = dtpBrithdayBegin.Text;
            changeTrackingList.Add(search);
        }

        if (dtpIngoingDateEnd.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "IngoingDate";
            search.Relation = "AND";
            search.Operator = "<=";
            search.Content = dtpBrithdayEnd.Text;
            changeTrackingList.Add(search);
        }

        if (ddlCensusType.SelectedIndex != 0)
        {
            search = new EntitySearcher();
            search.Field = "CensusTypeID";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = ddlCensusType.SelectedValue;
            changeTrackingList.Add(search);
        }

        if (ddlIsCanceled.SelectedIndex != 0)
        {
            search = new EntitySearcher();
            search.Field = "IsCanceled";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = ddlIsCanceled.SelectedValue;
            changeTrackingList.Add(search);
        }

        ViewState["sql"] = changeTrackingList;
        GridColumn column = memberGird.FindColumn(memberGird.SortColumn);
        memberGrid_Bind(changeTrackingList, column.SortField, memberGird.SortDirection);
    }

    private void memberGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        memberGird.RecordCount = memberBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.CNS_CensusMember> list = memberBll.GetList(changeTrackingList, this.memberGird.PageIndex, this.memberGird.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        memberGird.DataSource = list;
        memberGird.DataBind();
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void memberGird_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        this.memberGird.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = memberGird.FindColumn(memberGird.SortColumn);
        memberGrid_Bind(changeTrackingList, column.SortField, memberGird.SortDirection);
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void memberGird_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = memberGird.FindColumn(memberGird.SortColumn);
        memberGrid_Bind(changeTrackingList, column.SortField, memberGird.SortDirection);
    }

    /// <summary>
    /// 修改事件中的方法
    /// </summary>
    protected void btnModifyMember_Click(object sender, EventArgs e)
    {
        object id = memberGird.DataKeys[memberGird.SelectedRowIndex][0];
        frmModifyCensusMember.IFrameUrl = string.Format("FrmModifyCensusMember.aspx?ID={0}", id);
        frmModifyCensusMember.Hidden = false;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDeleteMember_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = memberGird.SelectedRowIndexArray;
            List<int> ids = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                ids.Add(int.Parse((memberGird.DataKeys[keys[i]][0]).ToString()));
            }
            memberBll.Delete(ids);
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = memberGird.FindColumn(memberGird.SortColumn);
            memberGrid_Bind(changeTrackingList, column.SortField, memberGird.SortDirection);
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }
}