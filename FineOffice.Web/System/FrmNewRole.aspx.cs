using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_FrmNewRole : PageBase
{
    FineOffice.BLL.SYS_Role roleBll = new FineOffice.BLL.SYS_Role();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FineOffice.Modules.SYS_Role model = new FineOffice.Modules.SYS_Role();
        model.Ordering = int.Parse(txtOrdering.Text);
        model.RoleName = txtRoleName.Text.Trim();
        model.IsModify = true;
        model.Remark = txtRemark.Text.Trim();
        model.Stop = chkStop.Checked;
        try
        {
            roleBll.Add(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }        
    }
}
