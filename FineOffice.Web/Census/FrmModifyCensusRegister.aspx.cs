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
        if(Request["ID"]!=null)
        {
            int id = int.Parse(Request["ID"]);
            hiddenID.Text = Request["ID"];
            FineOffice.Modules.CNS_CensusRegister model = registerBll.GetModel(d => d.ID == id);
            txtRegisterNO.Text = model.RegisterNO;
            txtHabitation.Text = model.Habitation;
            txtHouseHolder.Text = model.HouseHolder;
            txtIssuingAuthority.Text = model.IssuingAuthority;
            ddlCensusType.SelectedValue = model.CensusTypeID.ToString();
            dtpIssuingDate.Text = string.Format("{0:yyyy-MM-dd}", model.IssuingDate);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int id = int.Parse(hiddenID.Text);
        FineOffice.Modules.CNS_CensusRegister model = registerBll.GetModel(d => d.ID == id);
        try
        {
            model.CensusTypeID = int.Parse(ddlCensusType.SelectedValue);
            model.Habitation = txtHabitation.Text.Trim();
            model.HouseHolder = txtHouseHolder.Text.Trim();
            model.RegisterNO = txtRegisterNO.Text.Trim();
            model.IssuingAuthority = txtIssuingAuthority.Text.Trim();
            model.IssuingDate = DateTime.Parse(dtpIssuingDate.Text);            
            registerBll.Update(model);
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
        PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("register_close"));
    }
}
