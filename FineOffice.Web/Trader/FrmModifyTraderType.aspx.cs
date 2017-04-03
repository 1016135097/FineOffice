using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Trader_FrmModifyTraderType : PageBase
{
    FineOffice.BLL.CRM_TraderType traderTypeBll = new FineOffice.BLL.CRM_TraderType();

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
        FineOffice.Modules.CRM_TraderType model = traderTypeBll.GetModel(t => t.ID == id);

        hiddenID.Text = model.ID.ToString();
        txtTraderType.Text = model.TraderType;
        txtOrdering.Text = model.Ordering.ToString();
        txtRemark.Text = model.Remark;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int id = int.Parse(hiddenID.Text);
        FineOffice.Modules.CRM_TraderType model = traderTypeBll.GetModel(d => d.ID == id);
        model.TraderType = txtTraderType.Text.Trim();
        model.Ordering = int.Parse(txtOrdering.Text);
        model.Remark = txtRemark.Text.Trim();
        try
        {
            traderTypeBll.Update(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }
}
