using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Letter_FrmModifyLetterChannel : PageBase
{
    FineOffice.BLL.ADM_LetterChannel letterChannelBll = new FineOffice.BLL.ADM_LetterChannel();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetHideReference();
            LoadData();
        }
    }
    private void LoadData()
    {
        if (Request["ID"] == null)
            return;

        int id = int.Parse(Request["ID"].ToString());
        hiddenID.Text = id.ToString();
        FineOffice.Modules.ADM_LetterChannel model = letterChannelBll.GetModel(d => d.ID == id);
        txtChannel.Text = model.Channel;
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            FineOffice.Modules.ADM_LetterChannel model = letterChannelBll.GetModel(d => d.ID == int.Parse(hiddenID.Text));
            model.Channel = txtChannel.Text.Trim();
            letterChannelBll.Update(model);
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
        PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
    }
}
