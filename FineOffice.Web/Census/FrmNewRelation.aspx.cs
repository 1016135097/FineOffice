using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Census_FrmNewRelation : PageBase
{
    FineOffice.BLL.CNS_CensusRelation relationBll = new FineOffice.BLL.CNS_CensusRelation();

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
            FineOffice.Modules.CNS_CensusRelation model = new FineOffice.Modules.CNS_CensusRelation();
            model.Relation = txtRelation.Text.Trim();
            relationBll.Add(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }        
    }
}
