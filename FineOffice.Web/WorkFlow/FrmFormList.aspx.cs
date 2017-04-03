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

public partial class WorkFlow_FrmFormList : PageBase
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
            btnNew.OnClientClick = newFormWin.GetShowReference();

            btnDesign.OnClientClick = formGrid.GetNoSelectionAlertReference(string.Format("请选择要设计的{0}！", formGrid.Title));
            btnModify.OnClientClick = formGrid.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", formGrid.Title));
            btnDelete.OnClientClick = formGrid.GetNoSelectionAlertReference(string.Format("请选择要删除的{0}！", formGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中{0}吗！", formGrid.Title);
        }
        //子窗体回发事件
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = formGrid.FindColumn(formGrid.SortColumn);
            formGrid_Bind(changeTrackingList, column.SortField, formGrid.SortDirection);
        }
    }

    #region formGrid_Bind

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
        try
        {
            if (e.CommandName == "delete")
            {
                object[] keys = formGrid.DataKeys[e.RowIndex];
                formBll.Delete(new FineOffice.Modules.OA_Form { ID = int.Parse(keys[0].ToString()) });
                ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
                GridColumn column = formGrid.FindColumn(formGrid.SortColumn);
                formGrid_Bind(changeTrackingList, column.SortField, formGrid.SortDirection);
            }
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        modifyFormWin.IFrameUrl = string.Format("FrmModifyForm.aspx?id={0}", formGrid.DataKeys[formGrid.SelectedRowIndex][0]);
        modifyFormWin.Hidden = false;
    }

    protected void btnDesign_Click(object sender, EventArgs e)
    {
        try
        {
            PageContext.RegisterStartupScript("openTab('_FormDesign','表单设计-" +
                formGrid.DataKeys[formGrid.SelectedRowIndex][1] + "','WorkFlow/FrmDesignForm.aspx?id=" +
                formGrid.DataKeys[formGrid.SelectedRowIndex][0] + "');");
        }
        catch (Exception ex)
        {
            FineUI.Alert.ShowInParent(ex.Message);
        }
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

    #endregion

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
        formGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = formGrid.FindColumn(formGrid.SortColumn);
        formGrid_Bind(changeTrackingList, column.SortField, formGrid.SortDirection);
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

        ViewState["sql"] = changeTrackingList;
        GridColumn column = formGrid.FindColumn(formGrid.SortColumn);
        formGrid_Bind(changeTrackingList, column.SortField, formGrid.SortDirection);
        ttbSearch.ShowTrigger1 = true;
    }
}
