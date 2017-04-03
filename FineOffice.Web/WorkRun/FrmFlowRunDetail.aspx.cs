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

public partial class WorkRun_FrmFlowRunDetail : System.Web.UI.Page
{
    FineOffice.BLL.Bussness.FlowRunHandler runHandlerBll = new FineOffice.BLL.Bussness.FlowRunHandler();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ExtBindingList<FineOffice.Modules.OA_FlowRunProcess> list = runHandlerBll.FlowRunProcessList(new FineOffice.Modules.OA_FlowRun { ID = int.Parse(Request["RunID"]) }).ToBindingList();

            GridColumn column = transmitGrid.FindColumn(transmitGrid.SortColumn);
            list.Sort(column.SortField, transmitGrid.SortDirection);

            this.transmitGrid.DataSource = list;
            this.transmitGrid.DataBind();
        }
    }
}