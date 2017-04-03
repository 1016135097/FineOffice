using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Letter_FrmNewLetterChannel : PageBase
{
    FineOffice.BLL.ADM_LetterChannel letterChannelBll = new FineOffice.BLL.ADM_LetterChannel();

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
            FineOffice.Modules.ADM_LetterChannel model = new FineOffice.Modules.ADM_LetterChannel();
            model.Channel = txtChannel.Text.Trim();
            letterChannelBll.Add(model);
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
        PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
    }
}
