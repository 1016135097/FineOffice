using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Census_FrmModifyRelation : PageBase
{
    FineOffice.BLL.CNS_CensusRelation relationBll = new FineOffice.BLL.CNS_CensusRelation();

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
        FineOffice.Modules.CNS_CensusRelation model = relationBll.GetModel(d => d.ID == id);
        txtRelation.Text = model.Relation;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            FineOffice.Modules.CNS_CensusRelation model = relationBll.GetModel(d => d.ID == int.Parse(hiddenID.Text));
            model.Relation = txtRelation.Text.Trim();
            relationBll.Update(model);
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
        PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
    }
}
