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

public partial class Census_FrmCensusRegister : PageBase
{
    private FineOffice.BLL.CNS_CensusRegister registerBll = new FineOffice.BLL.CNS_CensusRegister();
    FineOffice.BLL.CNS_CensusMember memberBll = new FineOffice.BLL.CNS_CensusMember();
    FineOffice.BLL.CNS_CensusType typeBll = new FineOffice.BLL.CNS_CensusType();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            btnNewRegister.OnClientClick = frmNewCensusRegister.GetShowReference();
            btnModifyRegister.OnClientClick = registerGrid.GetNoSelectionAlertReference("请选择要操作的数据！");
            btnDeleteRegister.ConfirmText = "你确认要删除选中的户口信息吗？";
            btnDeleteMember.ConfirmText = "你确认要删除选中的人口信息吗？";

            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            this.registerGrid.PageIndex = 0;
            GridColumn column = registerGrid.FindColumn(registerGrid.SortColumn);
            ViewState["register"] = changeTrackingList;
            registerGrid_Bind(changeTrackingList, column.SortField, registerGrid.SortDirection);
            this.registerGrid.SelectedRowIndex = 0;
        }
        if (Request.Form["__EVENTARGUMENT"] == "register_close")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["register"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = registerGrid.FindColumn(registerGrid.SortColumn);
            registerGrid_Bind(changeTrackingList, column.SortField, registerGrid.SortDirection);
        }
        if (Request.Form["__EVENTARGUMENT"] == "member_close")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["member"] as ChangeTrackingList<EntitySearcher>;
            memberGrid_Bind(changeTrackingList);
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
        txtIssuingAuthority.Text = "";
        txtHouseHolder.Text = "";
        txtHabitation.Text = "";
        dtpBegin.Text = "";
        dtpEnd.Text = "";
        ddlCensusType.SelectedIndex = 0;
        btnFind_Click(null, null);
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
        search.Field = "Habitation";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtHabitation.Text.Trim();
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "Habitation";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtHabitation.Text;
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "IssuingAuthority";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtIssuingAuthority.Text;
        changeTrackingList.Add(search);

        if (dtpBegin.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "IssuingDate";
            search.Relation = "AND";
            search.Operator = ">=";
            search.Content = dtpBegin.Text;
            changeTrackingList.Add(search);
        }

        if (dtpEnd.Text.Length > 0)
        {
            search = new EntitySearcher();
            search.Field = "IssuingDate";
            search.Relation = "AND";
            search.Operator = "<=";
            search.Content = dtpEnd.Text;
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

        ViewState["register"] = changeTrackingList;
        GridColumn column = registerGrid.FindColumn(registerGrid.SortColumn);
        registerGrid_Bind(changeTrackingList, column.SortField, registerGrid.SortDirection);
    }

    #region 户口信息操作

    protected void btnModifyRegister_Click(object sender, EventArgs e)
    {
        object id = registerGrid.DataKeys[registerGrid.SelectedRowIndex][0];
        frmModifyCensusRegister.IFrameUrl = string.Format("FrmModifyCensusRegister.aspx?ID={0}", id);
        frmModifyCensusRegister.Hidden = false;
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDeleteRegister_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = registerGrid.SelectedRowIndexArray;
            List<int> ids = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                ids.Add(int.Parse((registerGrid.DataKeys[keys[i]][0]).ToString()));
            }
            registerBll.Delete(ids);
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["register"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = registerGrid.FindColumn(registerGrid.SortColumn);
            registerGrid_Bind(changeTrackingList, column.SortField, registerGrid.SortDirection);
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    protected void registerGrid_RowSelect(object sender, FineUI.GridRowSelectEventArgs e)
    {
        string registerNO = registerGrid.DataKeys[e.RowIndex][1].ToString();
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        EntitySearcher search = new EntitySearcher();
        search.Field = "RegisterNO";
        search.Relation = "AND";
        search.Operator = "=";
        search.Content = registerNO;
        changeTrackingList.Add(search);

        btnNewMember.OnClientClick = frmNewCensusMember.GetShowReference("FrmNewCensusMember.aspx?RegisterNO=" + registerNO);

        ViewState["member"] = changeTrackingList;
        memberGrid_Bind(changeTrackingList);
    }

    private void registerGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        registerGrid.RecordCount = registerBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.CNS_CensusRegister> list = registerBll.GetList(changeTrackingList, this.registerGrid.PageIndex, this.registerGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        registerGrid.DataSource = list;
        registerGrid.DataBind();
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void registerGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        this.registerGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["register"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = registerGrid.FindColumn(registerGrid.SortColumn);
        registerGrid_Bind(changeTrackingList, column.SortField, registerGrid.SortDirection);
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void registerGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["register"] as ChangeTrackingList<EntitySearcher>;
        registerGrid_Bind(changeTrackingList, e.SortField, e.SortDirection);
    }

    #endregion

    #region 常住人员登记

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDeleteMember_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = memberGrid.SelectedRowIndexArray;
            List<int> ids = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                ids.Add(int.Parse((memberGrid.DataKeys[keys[i]][0]).ToString()));
            }
            memberBll.Delete(ids);
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["member"] as ChangeTrackingList<EntitySearcher>;
            memberGrid_Bind(changeTrackingList);
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    private void memberGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList)
    {
        List<FineOffice.Modules.CNS_CensusMember> list = memberBll.GetList(changeTrackingList);
        memberGrid.DataSource = list;
        memberGrid.DataBind();
    }

    protected void btnModifyMember_Click(object sender, EventArgs e)
    {
        frmModifyCensusMember.IFrameUrl = string.Format("FrmModifyCensusMember.aspx?ID={0}", memberGrid.DataKeys[memberGrid.SelectedRowIndex][0]);
        frmModifyCensusMember.Hidden = false;
    }
    #endregion
}