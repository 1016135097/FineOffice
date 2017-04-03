using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WorkRun_FrmPreviewForm : PageBase
{
    public FineOffice.BLL.OA_FlowRunData runDataBll = new FineOffice.BLL.OA_FlowRunData();
    public FineOffice.Modules.OA_FlowRunData model = new FineOffice.Modules.OA_FlowRunData();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string ID = Request["ID"];
            model = runDataBll.GetModel(f => f.ID == int.Parse(ID));
        }
    }
}
