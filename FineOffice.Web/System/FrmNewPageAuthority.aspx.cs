using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_FrmNewMenu : PageBase
{
    FineOffice.BLL.SYS_PageAuthority authorityBll = new FineOffice.BLL.SYS_PageAuthority();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtParent.OnClientTriggerClick = wdnSelectMenu.GetSaveStateReference(txtParent.ClientID, hiddenParentID.ClientID)
               + wdnSelectMenu.GetShowReference("../System/FrmSelectMenu.aspx?forpage=authority");
            btnClose.OnClientClick = ActiveWindow.GetHideReference();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            FineOffice.Modules.SYS_PageAuthority model = new FineOffice.Modules.SYS_PageAuthority();
            model.AuthorityName = txtAuthorityName.Text.Trim();
            model.ControlID = txtControlID.Text.Trim();
            model.Ordering = int.Parse(txtOrdering.Text);
            model.MenuID = int.Parse(hiddenParentID.Text);
            model.Remark = txtRemark.Text.Trim();
            authorityBll.Add(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }
}
