using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Trader_FrmModifyIndustry : PageBase
{
    FineOffice.BLL.CRM_Industry industryBll = new FineOffice.BLL.CRM_Industry();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            InitModule();
        }
    }

    private void InitModule()
    {
        int id = int.Parse(Request["ID"]);
        FineOffice.Modules.CRM_Industry model = industryBll.GetModel(t => t.ID == id);

        hiddenID.Text = model.ID.ToString();
        txtIndustry.Text = model.Industry;
        txtOrdering.Text = model.Ordering.ToString();
        txtRemark.Text = model.Remark;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int id = int.Parse(hiddenID.Text);
        FineOffice.Modules.CRM_Industry model = industryBll.GetModel(d => d.ID == id);
        model.Industry = txtIndustry.Text.Trim();
        model.Ordering = int.Parse(txtOrdering.Text);
        model.Remark = txtRemark.Text.Trim();
        try
        {
            industryBll.Update(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }
}
