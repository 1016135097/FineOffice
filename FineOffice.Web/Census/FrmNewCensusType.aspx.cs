using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Census_FrmNewCensusType : PageBase
{
    FineOffice.BLL.CNS_CensusType censusTypeBll = new FineOffice.BLL.CNS_CensusType();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetHideReference();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            FineOffice.Modules.CNS_CensusType model = new FineOffice.Modules.CNS_CensusType();
            model.CensusTypeName = txtCensusTypeName.Text.Trim();
            censusTypeBll.Add(model);
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
        PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
    }
}
