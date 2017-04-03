using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Trader_FrmModifyArea : PageBase
{
    FineOffice.BLL.CRM_Area areaBll = new FineOffice.BLL.CRM_Area();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            InitModule();
        }
    }

    private void InitModule()
    {
        int id = int.Parse(Request["ID"]);
        FineOffice.Modules.CRM_Area model = areaBll.GetModel(a => a.ID == id);
        txtOrdering.Text = model.Ordering.ToString();
        txtArea.Text = model.Area;
        hiddenParentID.Text = model.ParentID.ToString();
        hiddenID.Text = id.ToString();
        txtRemark.Text = model.Remark;

        if (model.ParentID != 0)
        {
            FineOffice.Modules.CRM_Area temp = areaBll.GetModel(a => a.ID == model.ParentID);
            txtParent.Text = temp.Area;
        }
        txtParent.OnClientTriggerClick = selectAreaWin.GetSaveStateReference(txtParent.ClientID, hiddenParentID.ClientID)
                  + selectAreaWin.GetShowReference("../common/FrmSelectArea.aspx?ID=" + id);
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int id = int.Parse(hiddenID.Text);
        FineOffice.Modules.CRM_Area model = areaBll.GetModel(a => a.ID == id);
        model.Area = txtArea.Text.Trim();
        model.Ordering = int.Parse(txtOrdering.Text);
        model.ParentID = hiddenParentID.Text.Length == 0 ? 0 : int.Parse(hiddenParentID.Text);
        model.Remark = txtRemark.Text.Trim();
        try
        {
            areaBll.Update(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.ShowInTop(ex.Message);
        }
    }
}
