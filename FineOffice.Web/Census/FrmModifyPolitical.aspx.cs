using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Census_FrmModifyPolitical : PageBase
{
    FineOffice.BLL.CNS_PoliticalAffiliation politicalBll = new FineOffice.BLL.CNS_PoliticalAffiliation();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            LoadData();
        }
    }

    private void LoadData()
    {
        if (Request["ID"] == null)
            return;
        int id = int.Parse(Request["ID"].ToString());
        hiddenID.Text = id.ToString();
        FineOffice.Modules.CNS_PoliticalAffiliation model = politicalBll.GetModel(d => d.ID == id);
        txtPolitical.Text = model.Political;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            FineOffice.Modules.CNS_PoliticalAffiliation model = politicalBll.GetModel(d => d.ID == int.Parse(hiddenID.Text));
            model.Political = txtPolitical.Text.Trim();
            politicalBll.Update(model);
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
        PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
    }
}
