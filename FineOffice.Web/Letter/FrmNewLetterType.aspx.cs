using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Letter_FrmNewLetterType : PageBase
{
    FineOffice.BLL.ADM_LetterType letterTypeBll = new FineOffice.BLL.ADM_LetterType();

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
            FineOffice.Modules.ADM_LetterType model = new FineOffice.Modules.ADM_LetterType();
            model.LetterType = txtLetterType.Text.Trim();
            letterTypeBll.Add(model);
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
        PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
    }
}
