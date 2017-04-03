using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;

public partial class HardDisk_FrmUploadFile : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["folderid"] != null)
                hiddenFolderID.Text = Request["folderid"];

            hiddenTabID.Text = Request["tabid"];
            if (hiddenTabID.Text == "_FrmShareHardDisk")
                hiddenIsPublic.Text = "true";

            JObject ids = GetClientIDS(hiddenFolderID, hiddenTabID, pnlForm, hiddenIsPublic);

            if (!Page.IsPostBack)
            {
                string idsScriptStr = String.Format("window.Ctrls={0};", ids.ToString(Newtonsoft.Json.Formatting.None));
                PageContext.RegisterStartupScript(idsScriptStr);
            }
        }
    }
}