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
    FineOffice.BLL.SYS_MenuList menuBll = new FineOffice.BLL.SYS_MenuList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtParent.OnClientTriggerClick = wdnSelectMenu.GetSaveStateReference(txtParent.ClientID, hiddenParentID.ClientID)
               + wdnSelectMenu.GetShowReference("../System/FrmSelectMenu.aspx");
            btnClose.OnClientClick = ActiveWindow.GetHideReference();
            txtAuthorityValue.Enabled = false;
            txtNavigateUrl.Enabled = false;
        }
    }

    protected void rdbMenuType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbMenuType.SelectedValue == "IsFunction")
        {
            txtAuthorityValue.Enabled = true;
            txtNavigateUrl.Enabled = true;
        }
        else
        {
            txtAuthorityValue.Enabled = false;
            txtNavigateUrl.Enabled = false;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            FineOffice.Modules.SYS_MenuList model = new FineOffice.Modules.SYS_MenuList();
            model.TabID = txtAuthorityValue.Text.Trim();
            model.Icon = txtIcon.Text.Trim();

            if (rdbMenuType.SelectedValue == "IsFunction")
            {
                model.IsFuntion = true;
                model.IsModule = false;
            }
            else
            {
                model.IsModule = true;
                model.IsFuntion = false;
            }
            model.NavigateUrl = txtNavigateUrl.Text.Trim();
            model.Ordering = int.Parse(txtOrdering.Text);
            model.ParentID = int.Parse(hiddenParentID.Text);
            model.SingleClickExpand = true;
            model.Text = txtText.Text.Trim();
            model.Remark = txtRemark.Text.Trim();
            model.Stop = chkStop.Checked;
            menuBll.Add(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }
}
