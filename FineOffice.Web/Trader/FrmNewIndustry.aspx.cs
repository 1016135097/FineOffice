using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Trader_FrmNewIndustry : PageBase
{
    FineOffice.BLL.CRM_Industry industryBll = new FineOffice.BLL.CRM_Industry();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FineOffice.Modules.CRM_Industry model = new FineOffice.Modules.CRM_Industry();
        model.Industry = txtIndustry.Text.Trim();
        model.Ordering = int.Parse(txtOrdering.Text);
        model.Remark = txtRemark.Text.Trim();
        try
        {
            industryBll.Add(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }     
    }
}
