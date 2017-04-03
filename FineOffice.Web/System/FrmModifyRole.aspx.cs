using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_FrmModifyRole : PageBase
{
    FineOffice.BLL.SYS_Role roleBll = new FineOffice.BLL.SYS_Role();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitModule();
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
        }
    }

    private void InitModule()
    {
        int id = int.Parse(Request["id"]);
        FineOffice.Modules.SYS_Role model = roleBll.GetModel(d => d.ID == id);
        hiddenID.Text = id.ToString();
        txtOrdering.Text = model.Ordering.ToString();
        txtRemark.Text = model.Remark;
        txtRoleName.Text = model.RoleName;
        chkStop.Checked = model.Stop.Value;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int id = int.Parse(hiddenID.Text);
        FineOffice.Modules.SYS_Role model = roleBll.GetModel(d => d.ID == id);
        if (!model.IsModify.Value)
        {
            Alert.ShowInParent(string.Format("系统角色：{0}，不允许修改！", model.IsModify));
            return;
        }
        model.Ordering = int.Parse(txtOrdering.Text);
        model.RoleName = txtRoleName.Text.Trim();
        model.Remark = txtRemark.Text.Trim();
        model.Stop = chkStop.Checked;
        try
        {
            roleBll.Update(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }
}
