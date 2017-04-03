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

public partial class WorkFlow_FrmFlowList : PageBase
{
    FineOffice.BLL.OA_Flow flowBll = new FineOffice.BLL.OA_Flow();
    FineOffice.BLL.OA_FlowSort sortBll = new FineOffice.BLL.OA_FlowSort();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitTreeMenu();
            ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
            ViewState["sql"] = changeTrackingList;
            GridColumn column = flowGrid.FindColumn(flowGrid.SortColumn);
            flowGrid_Bind(changeTrackingList, column.SortField, flowGrid.SortDirection);

            btnTask.OnClientClick = flowGrid.GetNoSelectionAlertReference(string.Format("请选择{0}！", flowGrid.Title));
            btnDesign.OnClientClick = flowGrid.GetNoSelectionAlertReference(string.Format("请选择{0}！", flowGrid.Title));
            btnModify.OnClientClick = flowGrid.GetNoSelectionAlertReference(string.Format("请选择要编辑的{0}！", flowGrid.Title));
            btnDelete.OnClientClick = flowGrid.GetNoSelectionAlertReference(string.Format("请选择要删除的{0}！", flowGrid.Title));
            btnDelete.ConfirmText = string.Format("你确认要删除选中{0}吗！", flowGrid.Title);
        }
        //子窗体回发事件
        if (Request.Form["__EVENTARGUMENT"] == "subwin_close")
        {
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = flowGrid.FindColumn(flowGrid.SortColumn);
            flowGrid_Bind(changeTrackingList, column.SortField, flowGrid.SortDirection);
        }
    }

    protected void btnNew_Click(object sender, EventArgs e)
    {
        newFlowWin.IFrameUrl = string.Format("FrmNewFlow.aspx?&t={0}", DateTime.Now.Ticks);
        newFlowWin.Hidden = false;
    }

    protected void btnDesign_Click(object sender, EventArgs e)
    {
        try
        {
            PageContext.RegisterStartupScript("openTab('FlowDesign','流程设计-" +
                flowGrid.DataKeys[flowGrid.SelectedRowIndex][2] + "','WorkFlow/FrmDesignFlow.aspx?ID=" +
                flowGrid.DataKeys[flowGrid.SelectedRowIndex][0] + "');");
        }
        catch (Exception ex)
        {
            FineUI.Alert.ShowInParent(ex.Message);
        }
    }

    protected void btnTask_Click(object sender, EventArgs e)
    {
        try
        {
            PageContext.RegisterStartupScript("openTab('ProcessList','节点管理-" +
                flowGrid.DataKeys[flowGrid.SelectedRowIndex][2] + "','WorkFlow/FrmProcessList.aspx?ID=" +
                flowGrid.DataKeys[flowGrid.SelectedRowIndex][0] + "');");
        }
        catch (Exception ex)
        {
            FineUI.Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 树菜单
    /// </summary>
    private void InitTreeMenu()
    {
        XDocument xdoc = CreateXml();
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
    private XDocument CreateXml()
    {
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
        List<FineOffice.Modules.OA_FlowSort> tempList = sortBll.GetListAll();
        foreach (FineOffice.Modules.OA_FlowSort temp in tempList)
        {
            XElement xe = new XElement("TreeNode", new object[] 
            { 
                new XAttribute("Text", temp.FlowSortName), 
                new XAttribute("EnablePostBack",true),
                new XAttribute("NodeID",temp.ID),                
            });
            root.Add(xe);
        }
    }

    protected void tvwSort_NodeCommand(object sender, TreeCommandEventArgs e)
    {
        btnFind_Click(null, null);
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
        GridColumn column = flowGrid.FindColumn(flowGrid.SortColumn);
        flowGrid_Bind(changeTrackingList, column.SortField, flowGrid.SortDirection);
    }

    /// <summary>
    /// 刷新分类
    /// </summary>
    protected void btnRefresh_Click(object sender, EventArgs e)
    {
        tvwSort.Items.Clear();
        InitTreeMenu();
    }

    protected void btnSelectAll_Click(object sender, EventArgs e)
    {
        flowGrid.SelectAllRows();
    }

    /// <summary>
    /// 批量删除
    /// </summary>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            int[] keys = flowGrid.SelectedRowIndexArray;
            List<int> deleteList = new List<int>();
            for (int i = 0; i < keys.Length; i++)
            {
                deleteList.Add(int.Parse((flowGrid.DataKeys[keys[i]][0]).ToString()));
            }
            flowBll.Delete(deleteList);
            ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
            GridColumn column = flowGrid.FindColumn(flowGrid.SortColumn);
            flowGrid_Bind(changeTrackingList, column.SortField, flowGrid.SortDirection);
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    /// <summary>
    /// 删除事件
    /// </summary>
    protected void flowGrid_RowCommand(object sender, GridCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "delete")
            {
                object[] keys = flowGrid.DataKeys[e.RowIndex];
                flowBll.Delete(new FineOffice.Modules.OA_Flow { ID = int.Parse(keys[0].ToString()) });
                ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
                GridColumn column = flowGrid.FindColumn(flowGrid.SortColumn);
                flowGrid_Bind(changeTrackingList, column.SortField, flowGrid.SortDirection);
            }
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    protected void btnModify_Click(object sender, EventArgs e)
    {
        modifyFlowWin.IFrameUrl = string.Format("FrmModifyFlow.aspx?id={0}", flowGrid.DataKeys[flowGrid.SelectedRowIndex][0]);
        modifyFlowWin.Hidden = false;
    }

    private void flowGrid_Bind(ChangeTrackingList<EntitySearcher> changeTrackingList, string sortColumn, string sortDirection)
    {
        flowGrid.RecordCount = flowBll.GetCount(changeTrackingList);
        ExtBindingList<FineOffice.Modules.OA_Flow> list = flowBll.GetList(changeTrackingList, this.flowGrid.PageIndex, this.flowGrid.PageSize).ToBindingList();
        list.Sort(sortColumn, sortDirection);
        flowGrid.DataSource = list;
        flowGrid.DataBind();
    }

    /// <summary>
    /// 数据排序
    /// </summary>
    protected void flowGrid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        flowGrid_Bind(changeTrackingList, e.SortField, e.SortDirection);
    }

    /// <summary>
    /// 数据分页
    /// </summary>
    protected void flowGrid_PageIndexChange(object sender, FineUI.GridPageEventArgs e)
    {
        this.flowGrid.PageIndex = e.NewPageIndex;
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        GridColumn column = flowGrid.FindColumn(flowGrid.SortColumn);
        flowGrid_Bind(changeTrackingList, column.SortField, flowGrid.SortDirection);
    }

    /// <summary>
    /// 查询职员信息
    /// </summary>
    protected void btnFind_Click(object sender, EventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = new ChangeTrackingList<EntitySearcher>();
        EntitySearcher search = new EntitySearcher();
        search.Field = "FlowName";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtFlowName.Text;
        changeTrackingList.Add(search);

        search = new EntitySearcher();
        search.Field = "FlowDesc";
        search.Relation = "AND";
        search.Operator = "Like";
        search.Content = txtFlowDesc.Text;
        changeTrackingList.Add(search);

        FineUI.TreeNode node = tvwSort.SelectedNode;
        if (node!=null&& node.NodeID != "0")
        {
            search = new EntitySearcher();
            search.Field = "SortID"; 
            search.Relation = "AND";
            search.Operator = "=";
            search.Content = tvwSort.SelectedNodeID;
            changeTrackingList.Add(search);
        }

        ViewState["sql"] = changeTrackingList;
        GridColumn column = flowGrid.FindColumn(flowGrid.SortColumn);
        flowGrid_Bind(changeTrackingList, column.SortField, flowGrid.SortDirection);
    }
}
