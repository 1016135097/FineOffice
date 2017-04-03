using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Census_FrmNewCensusRegister : PageBase
{
    FineOffice.BLL.CNS_CensusRegister registerBll = new FineOffice.BLL.CNS_CensusRegister();
    FineOffice.BLL.CNS_CensusType typeBll = new FineOffice.BLL.CNS_CensusType();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            LoadData();
        }
    }

    public void LoadData()
    {
        List<FineOffice.Modules.CNS_CensusType> list = typeBll.GetListAll();
        foreach (FineOffice.Modules.CNS_CensusType type in list)
        {
            ddlCensusType.Items.Add(new FineUI.ListItem(type.CensusTypeName, type.ID.ToString()));
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FineOffice.Modules.CNS_CensusRegister model = new FineOffice.Modules.CNS_CensusRegister();
        try
        {
            model.CensusTypeID = int.Parse(ddlCensusType.SelectedValue);
            model.Habitation = txtHabitation.Text.Trim();
            model.HouseHolder = txtHouseHolder.Text.Trim();
            model.RegisterNO = txtRegisterNO.Text.Trim();
            model.IssuingAuthority = txtIssuingAuthority.Text.Trim();
            model.IssuingDate = DateTime.Parse(dtpIssuingDate.Text);
            registerBll.Add(model);
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
        PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("register_close"));
    }
}
