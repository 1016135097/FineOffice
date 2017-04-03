using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_FrmModifyUser : PageBase
{
    FineOffice.BLL.SYS_User userBll = new FineOffice.BLL.SYS_User();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitModule();
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            txtPersonnel.OnClientTriggerClick = selectPersonWin.GetSaveStateReference(txtPersonnel.ClientID, hiddenPersonnel.ClientID)
                 + selectPersonWin.GetShowReference("../common/FrmRadioPersonnel.aspx");
        }
    }

    private void InitModule()
    {
        int id = int.Parse(Request["id"]);
        FineOffice.Modules.SYS_User model = userBll.GetModel(d => d.ID == id);
        hiddenID.Text = id.ToString();
        txtPassword1.Text = FineOffice.Common.DEncrypt.DESEncrypt.Decrypt(model.Password);
        txtPassword2.Text = FineOffice.Common.DEncrypt.DESEncrypt.Decrypt(model.Password);
        txtRemark.Text = model.Remark;
        txtUserName.Text = model.UserName;
        txtPersonnel.Text = model.PersonnelName;
        hiddenPersonnel.Text = model.PersonnelID.ToString();
        chkStop.Checked = model.Stop.Value;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int id = int.Parse(hiddenID.Text);
        FineOffice.Modules.SYS_User model = userBll.GetModel(d => d.ID == id);
        if (!model.IsModify.Value)
        {
            Alert.ShowInParent(string.Format("用户账号：{0}，不允许修改", model.UserName));
        }
        model.IsModify = true;
        model.UserName = txtUserName.Text.Trim();
        model.Password = txtPassword1.Text.Trim();
        model.Remark = txtRemark.Text.Trim();
        model.PersonnelID = int.Parse(hiddenPersonnel.Text);
        model.Stop = chkStop.Checked;
        try
        {
            userBll.Update(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(string.Format("用户名不允许重复！\n错误信息：{0}", ex.Message));
        }
    }
}
