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
using System.Xml.Linq;
using System.Xml;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;


public partial class Common_FrmMultiForm : PageBase
{
    FineOffice.BLL.OA_Form formBll = new FineOffice.BLL.OA_Form();
    FineOffice.BLL.OA_FormType typeBll = new FineOffice.BLL.OA_FormType();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitTreeMenu();
            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;
            GridColumn column = formGrid.FindColumn(formGrid.SortColumn);
            formGrid_Bind(changeTrackingList, column.SortField, formGrid.SortDirection);

            #region old code 恢复选择中行
            if (Request["selected"] != null && Request["selected"].Length > 0)
            {
                string[] str = Request["selected"].Split(',');
                List<string> ids = new List<string>();
                for (int i = 0; i < str.Length; i++)
                {
                    ids.Add(str[i]);
                }
                hfSelectedIDS.Text = new JArray(ids).ToString(Newtonsoft.Json.Formatting.None);
                UpdateSelectedRowIndexArray();
            }
            #endregion

            btnNew.OnClientClick = newFormWin.GetShowReference();
            btnDesign.OnClientClick = formGrid.GetNoSelectionAlertReference(string.Format("请选择要设计的{0}！", formGrid.Title));
            btnModify.OnClientClick = formGrid.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", formGrid.Title));
            btnDelete.OnClientClick = formGrid.GetNoSelectionAlertReference(string.Format("请选择要删除的{0}！", formGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中{0}吗！", formGrid.Title);
        }
        //子窗体回发事件
        if (Request.Form["__EVENTARGUMENT"] == "windowClose")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = formGrid.FindColumn(formGrid.SortColumn);
            formGrid_Bind(changeTrackingList, column.SortField, formGrid.SortDirection);
        }
    }

    #region 保持选中行
    private void UpdateSelectedRowIndexArray()
    {
        List<string> ids = GetSelectedRowIndexArrayFromHiddenField();
        List<int> nextSelectedRowIndexArray = new List<int>();
        for (int i = 0, count = Math.Min(formGrid.PageSize, (formGrid.RecordCount - formGrid.PageIndex * formGrid.PageSize)); i < count; i++)
        {
            string id = formGrid.DataKeys[i][0].ToString();
            if (ids.Contains(id))
            {
                nextSelectedRowIndexArray.Add(i);
            }
        }
        formGrid.SelectedRowIndexArray = nextSelectedRowIndexArray.ToArray();
    }

    private List<string> GetSelectedRowIndexArrayFromHiddenField()
    {
        JArray idsArray = new JArray();
        string currentIDS = hfSelectedIDS.Text.Trim();
        if (!String.IsNullOrEmpty(currentIDS))
        {
            idsArray = JArray.Parse(currentIDS);
        }
        else
        {
            idsArray = new JArray();
        }
        return new List<string>(idsArray.ToObject<string[]>());
    }

    private void SyncSelectedRowIndexArrayToHiddenField()
    {
        List<string> ids = GetSelectedRowIndexArrayFromHiddenField();

        List<int> selectedRows = new List<int>();
        if (formGrid.SelectedRowIndexArray != null && formGrid.SelectedRowIndexArray.Length > 0)
        {
            selectedRows = new List<int>(formGrid.SelectedRowIndexArray);
        }
        for (int i = 0, count = Math.Min(formGrid.PageSize, (formGrid.RecordCount - formGrid.PageIndex * formGrid.PageSize)); i < count; i++)
        {
            string id = formGrid.DataKeys[i][0].ToString();
            if (selectedRows.Contains(i))
            {
                if (!ids.Contains(id))
                {
                    ids.Add(id);
                }
            }
            else
            {
                if (ids.Contains(id))
                {
                    ids.Remove(id);
                }
            }
        }
        hfSelectedIDS.Text = new JArray(ids).ToString(Newtonsoft.Json.Formatting.None);
    }
    #endregion


    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        formGrid.SelectAllRows();
    }
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
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = formGrid.FindColumn(formGrid.SortColumn);
            formGrid_Bind(changeTrackingList, column.SortField, formGrid.SortDirection);
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    protected void formGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            try
            {
                object[] keys = formGrid.DataKeys[e.RowIndex];
                formBll.Delete(new FineOffice.Modules.OA_Form { ID = int.Parse(keys[0].ToString()) });
                ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
                GridColumn column = formGrid.FindColumn(formGrid.SortColumn);
                formGrid_Bind(changeTrackingList, column.SortField, formGrid.SortDirection);
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        modifyFormWin.IFrameUrl = string.Format("../WorkFlow/FrmModifyForm.aspx?ID={0}", formGrid.DataKeys[formGrid.SelectedRowIndex][0]);
        modifyFormWin.Hidden = false;
    }

    protected void btnDesign_Click(object sender, EventArgs e)
    {
        designFormWin.IFrameUrl = string.Format("../WorkFlow/FrmDesignForm.aspx?ID={0}", formGrid.DataKeys[formGrid.SelectedRowIndex][0]);
        PageContext.RegisterStartupScript(designFormWin.GetShowReference() + designFormWin.GetMaximizeReference());
    }

    private void formGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string dortDirection)
    {
        ChangeTrackingList<EntitySearcher> trackingList = new ChangeTrackingList<EntitySearcher>();
        foreach (EntitySearcher s in changeTrackingList)
        {
            trackingList.Add(s);
        }

        FineUI.TreeNode node = tvwSort.SelectedNode;
        if (node != null && node.NodeID != "0")
        {
            EntitySearcher search = new EntitySearcher();
            search.Field = "TypeID";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = tvwSort.SelectedNodeID;
            trackingList.Add(search);
        }

        formGrid.RecordCount = formBll.GetCount(trackingList);
        ExtBindingList<FineOffice.Modules.OA_Form> list = formBll.GetList(trackingList, this.formGrid.PageIndex, this.formGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, dortDirection);
        formGrid.DataSource = list;
        formGrid.DataBind();
    }

    /// <summary>
    /// 树菜单
    /// </summary>
    private void InitTreeMenu()
    {
        XDocument xdoc = CreateMenuXml();
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xdoc.Document.ToString());

        // 绑定 XML 数据源到树控件
        tvwSort.DataSource = xmlDoc;
        tvwSort.DataBind();
        tvwSort.ExpandAllNodes();
    }

    /// <summary>
    /// 创建树的XML
    /// </summary>
    private XDocument CreateMenuXml()
    {
        List<FineOffice.Modules.OA_FormType> tempList = typeBll.GetListAll();
        XDocument xdoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("Tree"));
        XElement xe = new XElement("TreeNode", new object[] 
        { 
               new XAttribute("Text", "全部分类"),             
               new XAttribute("EnablePostBack",true),
               new XAttribute("NodeID","0"),
         });
        xdoc.Root.Add(xe);
        CreateXElement(xe);
        return xdoc;
    }

    /// <summary>
    /// 创建树的子节点
    /// </summary>
    private void CreateXElement(XElement root)
    {
        List<FineOffice.Modules.OA_FormType> tempList = typeBll.GetListAll();
        foreach (FineOffice.Modules.OA_FormType temp in tempList)
        {
            XElement xe = new XElement("TreeNode", new object[] 
            { 
                new XAttribute("Text", temp.FormTypeName), 
                new XAttribute("EnablePostBack",true),
                new XAttribute("NodeID",temp.ID),                
            });
            root.Add(xe);
        }
    }

    protected void tvwSort_NodeCommand(object sender, TreeCommandEventArgs e)
    {
        ttbSearch_Trigger2Click(null, null);
    }

    /// <summary>
    /// 展开树节点
    /// </summary>
    protected void btnExpandAll_Click(object sender, EventArgs e)
    {
        tvwSort.ExpandAllNodes();
    }

    protected void btnCollapseAll_Click(object sender, EventArgs e)
    {
        tvwSort.CollapseAllNodes();
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = formGrid.FindColumn(formGrid.SortColumn);
        formGrid_Bind(changeTrackingList, column.SortField, formGrid.SortDirection);
    }

    /// <summary>
    /// 刷新分类
    /// </summary>
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        tvwSort.Items.Clear();
        InitTreeMenu();
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void formGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        formGrid_Bind(changeTrackingList, e.SortField, e.SortDirection);
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void formGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        SyncSelectedRowIndexArrayToHiddenField();

        formGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = formGrid.FindColumn(formGrid.SortColumn);
        formGrid_Bind(changeTrackingList, column.SortField, formGrid.SortDirection);

        UpdateSelectedRowIndexArray();
    }

    /// <summary>
    /// 清空查询条件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ttbSearch_Trigger1Click(object sender, EventArgs e)
    {
        ttbSearch.Text = String.Empty;
        ttbSearch.ShowTrigger1 = false;
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        ViewState["sql"] = changeTrackingList;
        GridColumn column = formGrid.FindColumn(formGrid.SortColumn);
        formGrid_Bind(changeTrackingList, column.SortField, formGrid.SortDirection);
    }

    /// <summary>
    /// 查询
    /// </summary>
    protected void ttbSearch_Trigger2Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        EntitySearcher search = new EntitySearcher();
        search.LeftParentheses = "(";
        search.Field = "FormNO";
        search.Relation = "or";
        search.Operator = "Like";
        search.Content = ttbSearch.Text;
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "FormName";
        search.Relation = "or";
        search.Operator = "Like";
        search.Content = ttbSearch.Text;
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.RightParentheses = ")";
        search.Field = "PinyinCode";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = ttbSearch.Text;
        changeTrackingList.Add(search);

        FineUI.TreeNode node = tvwSort.SelectedNode;
        if (node.NodeID != "0")
        {
            search = new EntitySearcher();
            search.Field = "TypeID";
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = tvwSort.SelectedNodeID;
            changeTrackingList.Add(search);
        }

        ViewState["sql"] = changeTrackingList;
        GridColumn column = formGrid.FindColumn(formGrid.SortColumn);
        formGrid_Bind(changeTrackingList, column.SortField, formGrid.SortDirection);
        ttbSearch.ShowTrigger1 = true;
    }

    protected void btnEnter_Click(object sender, EventArgs e)
    {
        int[] keys = formGrid.SelectedRowIndexArray;

        List<string> select = new List<string>();
        for (int i = 0; i < keys.Length; i++)
        {
            select.Add(formGrid.DataKeys[keys[i]][0].ToString());
        }
        PageContext.RegisterStartupScript(ActiveWindow.GetWriteBackValueReference(ListToJson(select))
            + ActiveWindow.GetHidePostBackReference("param_from_selected"));
    }
}
