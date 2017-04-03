using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Trader_FrmNewArea : PageBase
{
    FineOffice.BLL.CRM_Area areaBll = new FineOffice.BLL.CRM_Area();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtParent.OnClientTriggerClick = selectAreaWin.GetSaveStateReference(txtParent.ClientID, hiddenParentID.ClientID)
                  + selectAreaWin.GetShowReference("../common/FrmSelectArea.aspx");

            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FineOffice.Modules.CRM_Area model = new FineOffice.Modules.CRM_Area();
        model.Area = txtArea.Text.Trim();
        model.Ordering = int.Parse(txtOrdering.Text);
        model.ParentID = hiddenParentID.Text.Length == 0 ? 0 : int.Parse(hiddenParentID.Text);
        model.Remark = txtRemark.Text.Trim();
        try
        {
            areaBll.Add(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.ShowInTop(ex.Message);
        }
    }
}
