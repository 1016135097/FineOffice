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

public partial class WorkFlow_FrmProcessList : PageBase
{
    private FineOffice.BLL.OA_FlowProcess processBll = new FineOffice.BLL.OA_FlowProcess();
    private FineOffice.BLL.OA_FlowForm formBll = new FineOffice.BLL.OA_FlowForm();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnAdd.OnClientClick = GetOnClientClick(hiddenProcess.Text, false);
            btnAuthority.OnClientClick = processGrid.GetNoSelectionAlertReference(string.Format("请选择要操作的{0}！", processGrid.Title));

            btnDelelte.OnClientClick = formGrid.GetNoSelectionAlertReference(string.Format("请选择要删除的{0}！", formGrid.Title));
            btnDelelte.ConfirmText = string.Format("你确认要删除选中的{0}吗！", formGrid.Title);

            if (Request["ID"] != null)
            {
                int flowID = int.Parse(Request["ID"]);
                ViewState["flowID"] = flowID;
                ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
                EntitySearcher search = new EntitySearcher();
                search.Field = "FlowID";
                search.Relation = "AND";
                search.Operator = "=";
                search.Content = flowID.ToString();
                changeTrackingList.Add(search);

                this.processGrid.PageIndex = 0;
                GridColumn column = processGrid.FindColumn(processGrid.SortColumn);

                ViewState["process"] = changeTrackingList;
                processGrid_Bind(changeTrackingList, column.SortField, processGrid.SortDirection);

                ChangeTrackingList<EntitySearcher> formSearcherList = new ChangeTrackingList<EntitySearcher>();
                search = new EntitySearcher();
                search.Field = "FlowID";
                search.Relation = "AND";
                search.Operator = "=";
                search.Content = flowID.ToString();
                formSearcherList.Add(search);

                this.formGrid.PageIndex = 0;
                GridColumn formColumn = formGrid.FindColumn(formGrid.SortColumn);

                ViewState["form"] = formSearcherList;
                formGrid_Bind(formSearcherList, formColumn.SortField, formGrid.SortDirection);
            }
        }
        if (Request.Form["__EVENTARGUMENT"] == "param_from_selected")
        {
            this.UpdateFormList(hiddenForm.Text);
        }
    }

    #region processGrid_Bind

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = formGrid.SelectedRowIndexArray;
            List<int> deleteList = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                deleteList.Add(int.Parse((formGrid.DataKeys[keys[i]][0]).ToString()));
            }
            formBll.Delete(deleteList);
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["form"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = formGrid.FindColumn(formGrid.SortColumn);
            formGrid_Bind(changeTrackingList, column.SortField, formGrid.SortDirection);
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }

    private void UpdateFormList(string str)
    {
        List<string> ids = JsonToList<string>(str);
        List<string> forms = JsonToList<string>(hiddenProcess.Text.Trim());
        List<string> temp = JsonToList<string>(hiddenProcess.Text.Trim());
        string processid = processGrid.DataKeys[processGrid.SelectedRowIndex][0].ToString();
        ChangeTrackingList<FineOffice.Modules.OA_FlowForm> list = new ChangeTrackingList<FineOffice.Modules.OA_FlowForm>();
        for (int i = 0; i < ids.Count; i++)
        {
            if (ids[i].Length > 0 && !forms.Contains(ids[i]))
            {
                forms.Add(ids[i]);
                FineOffice.Modules.OA_FlowForm model = new FineOffice.Modules.OA_FlowForm();
                model.FlowID = (int)ViewState["flowID"];
                model.ProcessID = processid;
                model.FormID = int.Parse(ids[i]);
                list.Add(model);
            }
        }
        //返回值不为空重新数据绑定
        if (ids.Where(s => !temp.Contains(s)).Count() > 0)
        {
            formBll.AddAll(list);
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["form"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = formGrid.FindColumn(formGrid.SortColumn);
            formGrid_Bind(changeTrackingList, column.SortField, formGrid.SortDirection);
            hiddenProcess.Text = ListToJson(forms);
            hiddenForm.Text = "";
        }
    }

    private string GetOnClientClick(string forms, bool isEnd)
    {
        if (isEnd)
            return "return false";
        return processGrid.GetNoSelectionAlertReference("请选择要操作的节点！") + formListWin.GetSaveStateReference(hiddenForm.ClientID)
                             + formListWin.GetShowReference("../Common/FrmMultiForm.aspx?selected=" + forms);
    }

    protected void processGrid_RowSelect(object sender, FineUI.GridRowSelectEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> formSearcherList = new ChangeTrackingList<EntitySearcher>();
        EntitySearcher search = new EntitySearcher();
        search.Field = "ProcessID";
        search.Relation = "AND";
        search.Operator = "=";
        search.Content = processGrid.DataKeys[e.RowIndex][0].ToString();
        formSearcherList.Add(search);

        bool isEnd = (bool)processGrid.DataKeys[e.RowIndex][2];

        this.formGrid.PageIndex = 0;
        GridColumn formColumn = formGrid.FindColumn(formGrid.SortColumn);

        ViewState["form"] = formSearcherList;

        List<FineOffice.Modules.OA_FlowForm> formList = formBll.GetList(p => p.ProcessID == search.Content);
        List<string> sbform = (from f in formList select f.FormID.ToString()).ToList();
        hiddenProcess.Text = ListToJson(sbform);

        btnAdd.OnClientClick = GetOnClientClick(hiddenProcess.Text, isEnd);
        formGrid_Bind(formSearcherList, formColumn.SortField, formGrid.SortDirection);
    }

    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        processGrid.SelectAllRows();
    }

    private void processGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        processGrid.RecordCount = processBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.OA_FlowProcess> list = processBll.GetList(changeTrackingList, this.processGrid.PageIndex, this.processGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        processGrid.DataSource = list;
        processGrid.DataBind();
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void processGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        this.processGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["process"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = processGrid.FindColumn(processGrid.SortColumn);
        processGrid_Bind(changeTrackingList, column.SortField, processGrid.SortDirection);
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void processGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["process"] as ChangeTrackingList<EntitySearcher>;
        processGrid_Bind(changeTrackingList, e.SortField, e.SortDirection);
    }


    #region form表单管理
    private void formGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        formGrid.RecordCount = formBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.OA_FlowForm> list = formBll.GetList(changeTrackingList, this.formGrid.PageIndex, this.formGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        formGrid.DataSource = list;
        formGrid.DataBind();
    }


    /// <summary>
    /// 数据分页
    /// </summary>
    protected void formGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        this.formGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["form"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = formGrid.FindColumn(formGrid.SortColumn);
        formGrid_Bind(changeTrackingList, column.SortField, formGrid.SortDirection);
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void formGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["form"] as ChangeTrackingList<EntitySearcher>;
        formGrid_Bind(changeTrackingList, e.SortField, e.SortDirection);
    }
    #endregion

    #endregion

    protected void btnAuthority_Click(object sender, EventArgs e)
    {
        if ((bool)processGrid.DataKeys[processGrid.SelectedRowIndex][2])
        {
            return;
        }
        processAuthorityWin.IFrameUrl = string.Format("FrmProcessAuthority.aspx?id={0}",
            processGrid.DataKeys[processGrid.SelectedRowIndex][0]);
        processAuthorityWin.Hidden = false;
    }

    /// <summary>
    /// 刷新步骤
    /// </summary>
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["process"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = processGrid.FindColumn(processGrid.SortColumn);
        processGrid_Bind(changeTrackingList, column.SortField, processGrid.SortDirection);
    }

    /// <summary>
    /// 清空查询条件
    /// </summary>
    protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
    {
        ttbSearch.Text = String.Empty;
        ttbSearch.ShowTrigger1 = false;
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        ViewState["sql"] = changeTrackingList;
        GridColumn column = processGrid.FindColumn(processGrid.SortColumn);
        processGrid_Bind(changeTrackingList, column.SortField, processGrid.SortDirection);
    }

    /// <summary>
    /// 查询
    /// </summary>
    protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        EntitySearcher search = new EntitySearcher();

        search.LeftParentheses = "(";
        search.Field = "ProcessName";
        search.Relation = "or";
        search.Operator = "Like";
        search.Content = ttbSearch.Text;

        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.RightParentheses = ")";
        search.Field = "Remark";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = ttbSearch.Text;
        changeTrackingList.Add(search);

        int flowID = (int)ViewState["flowID"];
        search = new EntitySearcher();
        search.Field = "FlowID";
        search.Relation = "AND";
        search.Operator = "=";
        search.Content = flowID.ToString();
        changeTrackingList.Add(search);

        ViewState["process"] = changeTrackingList;
        GridColumn column = processGrid.FindColumn(processGrid.SortColumn);
        processGrid_Bind(changeTrackingList, column.SortField, processGrid.SortDirection);
        ttbSearch.ShowTrigger1 = true;
    }
}