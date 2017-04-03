using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Human_FrmNewDepartment : PageBase
{
    FineOffice.BLL.HR_Department departmentBll = new FineOffice.BLL.HR_Department();
    FineOffice.Common.PinyinCodeHelper pinyin = new FineOffice.Common.PinyinCodeHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FineOffice.Modules.HR_Department model = new FineOffice.Modules.HR_Department();
        model.DepartmentNO = txtDepartmentNO.Text.Trim();
        model.DepartmentName = txtDepartmentName.Text.Trim();
        model.PinyinCode = txtPinyinCode.Text.Trim();
        model.Remark = txtRemark.Text.Trim();
        model.Stop = chkStop.Checked;
        try
        {
            departmentBll.Add(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    protected void Pinyin_TextChanged(object sender, EventArgs e)
    {
        txtPinyinCode.Text = pinyin.GetFirstLetter(txtDepartmentName.Text.Trim());
    }
}
