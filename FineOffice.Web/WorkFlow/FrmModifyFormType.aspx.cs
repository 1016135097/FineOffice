using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WorkFlow_FrmModifyFormType : PageBase
{
    FineOffice.BLL.OA_FormType typeBll = new FineOffice.BLL.OA_FormType();
    FineOffice.Common.PinyinCodeHelper pinyin = new FineOffice.Common.PinyinCodeHelper();

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
        if (Request["ID"] == null)
            return;

        int id = int.Parse(Request["ID"].ToString());
        txtID.Text = id.ToString();
        FineOffice.Modules.OA_FormType model = typeBll.GetModel(d => d.ID == id);
        txtTypeNO.Text = model.TypeNO;
        txtTypeName.Text = model.FormTypeName;
        txtPinyinCode.Text = model.PinyinCode;
        txtRemark.Text = model.Remark;
        chkStop.Checked = model.Stop.Value;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FineOffice.Modules.OA_FormType model = typeBll.GetModel(d => d.ID == int.Parse(txtID.Text));
        model.TypeNO = txtTypeNO.Text.Trim();
        model.FormTypeName = txtTypeName.Text.Trim();
        model.PinyinCode = txtPinyinCode.Text.Trim();
        model.Remark = txtRemark.Text.Trim();
        model.Stop = chkStop.Checked;
        try
        {
            typeBll.Update(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    protected void Pinyin_TextChanged(object sender, EventArgs e)
    {
        txtPinyinCode.Text = pinyin.GetFirstLetter(txtTypeName.Text.Trim());
    }
}
