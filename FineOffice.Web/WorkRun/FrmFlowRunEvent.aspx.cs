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

public partial class WorkRun_FrmFlowRunEvent : System.Web.UI.Page
{
    FineOffice.BLL.OA_FlowRunProcess runProcessBll = new FineOffice.BLL.OA_FlowRunProcess();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChangeTrackingList<EntitySearcher> searcherList = new ChangeTrackingList<EntitySearcher>();
            EntitySearcher searcher = new EntitySearcher();
            searcher.Field = "RunID";
            searcher.Operator = "=";
            searcher.Content = Request["RunID"];
            searcher.Relation = "AND";
            searcherList.Add(searcher);
            ViewState["sql"] = searcherList;

            ExtBindingList<FineOffice.Modules.OA_FlowRunProcess> list = runProcessBll.GetList(searcherList).ToBindingList();

            GridColumn column = transmitGrid.FindColumn(transmitGrid.SortColumn);
            list.Sort(column.SortField, transmitGrid.SortDirection);

            this.transmitGrid.DataSource = list;
            this.transmitGrid.DataBind();
        }
    }

    protected void Grid_RowDataBound(object sender, FineUI.GridRowEventArgs e)
    {
        FineOffice.Modules.OA_FlowRunProcess row = e.DataItem as FineOffice.Modules.OA_FlowRunProcess;
        if (row != null)
        {
            if (row.State == 3)
            {
                highlightRows.Text += e.RowIndex.ToString() + ",";
            }
        }
    }


    /// <summary>
    /// 数据排序
    /// </summary>
    protected void Grid_Sort(object sender, FineUI.GridSortEventArgs e)
    {
        ChangeTrackingList<EntitySearcher> changeTrackingList = ViewState["sql"] as ChangeTrackingList<EntitySearcher>;
        ExtBindingList<FineOffice.Modules.OA_FlowRunProcess> list = runProcessBll.GetList(changeTrackingList).ToBindingList();

        list.Sort(e.SortField, e.SortDirection);
        this.transmitGrid.DataSource = list;
        this.transmitGrid.DataBind();
    }
}