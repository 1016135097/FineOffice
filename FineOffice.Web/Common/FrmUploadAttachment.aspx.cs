using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

public partial class Common_FrmUploadAttachment : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hiddenTabID.Text = Request["TabID"];

            if (Request["FollowID"]!=null)
                hiddenFollowID.Text = Request["FollowID"];
            
            if(Request["ContractID"]!=null)
                hiddenContractID.Text = Request["ContractID"];

            if(Request["RunProcess"]!=null)
                hiddenRunProcess.Text = Request["RunProcess"];

            JObject ids = GetClientIDS(hiddenTabID, hiddenContractID, hiddenRunProcess, hiddenFollowID, pnlMain);
           
            if (!Page.IsPostBack)
            {              
                string idsScriptStr = String.Format("window.Ctrls={0};", ids.ToString(Newtonsoft.Json.Formatting.None));
                PageContext.RegisterStartupScript(idsScriptStr);
            }
        }
    }
}