using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_FrmNewUser : PageBase
{
    FineOffice.BLL.SYS_User userBll = new FineOffice.BLL.SYS_User();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            txtPersonnel.OnClientTriggerClick = selectPersonWin.GetSaveStateReference(txtPersonnel.ClientID, hiddenPersonnel.ClientID)
                 + selectPersonWin.GetShowReference("../common/FrmRadioPersonnel.aspx");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FineOffice.Modules.SYS_User model = new FineOffice.Modules.SYS_User();
        model.IsModify = true;
        model.UserName = txtUserName.Text.Trim();
        model.CreateDate = DateTime.Now;
        model.Password = txtPassword1.Text.Trim();
        model.Remark = txtRemark.Text.Trim();
        model.PersonnelID = int.Parse(hiddenPersonnel.Text);
        model.Stop = chkStop.Checked;
        try
        {
            userBll.Add(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(string.Format("用户名不允许重复！\n错误信息：{0}", ex.Message));
        }
    }
}
