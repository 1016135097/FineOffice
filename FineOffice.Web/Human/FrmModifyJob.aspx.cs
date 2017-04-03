using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Human_FrmNewJob : PageBase
{
    FineOffice.BLL.HR_Job jobBll = new FineOffice.BLL.HR_Job();
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
        FineOffice.Modules.HR_Job model = jobBll.GetModel(d => d.ID == id);
        txtJob.Text = model.Job;
        txtJobNO.Text = model.JobNO;
        txtPinyinCode.Text = model.PinyinCode;
        txtRemark.Text = model.Remark;
        chkStop.Checked = model.Stop.Value;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            FineOffice.Modules.HR_Job model = jobBll.GetModel(d => d.ID == int.Parse(txtID.Text));
            model.JobNO = txtJobNO.Text.Trim();
            model.Job = txtJob.Text.Trim();
            model.PinyinCode = txtPinyinCode.Text.Trim();
            model.Remark = txtRemark.Text.Trim();
            model.Stop = chkStop.Checked;
            jobBll.Update(model);
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
        PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
    }

    protected void Pinyin_TextChanged(object sender, EventArgs e)
    {
        txtPinyinCode.Text = pinyin.GetFirstLetter(txtJob.Text.Trim());
    }
}
