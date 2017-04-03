using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WorkRun_FrmModifyFlowForm : PageBase
{
    FineOffice.BLL.OA_FlowForm flowFormBll = new FineOffice.BLL.OA_FlowForm();
    FineOffice.BLL.OA_FlowRunData runDataBll = new FineOffice.BLL.OA_FlowRunData();

    FineOffice.Common.PinyinCodeHelper pinyin = new FineOffice.Common.PinyinCodeHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hiddenFlowForm.Text = Request["ID"];
            FineOffice.Modules.OA_FlowRunData model = runDataBll.GetModel(d => d.ID == int.Parse(hiddenFlowForm.Text));
            lblFormName.Text = model.FormName;
            txtRemark.Text = model.Remark;
            txtTitle.Text = model.Title;
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FineOffice.Modules.OA_FlowRunData model = runDataBll.GetModel(d => d.ID == int.Parse(hiddenFlowForm.Text));
        model.Title = txtTitle.Text.Trim();
        model.Remark = txtRemark.Text.Trim();
        model.UpdateTime = DateTime.Now;
        try
        {
            model = runDataBll.Update(model);
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
        if (chkEdit.Checked)
        {
            string tabID = string.Format("{0:HHmmssffff}", DateTime.Now);
            PageContext.RegisterStartupScript("openTab('_FrmEditForm" + tabID +
                "','编辑表单-" + model.Title + "','WorkRun/FrmEditForm.aspx?ID=" + model.ID + "');");
        }
        PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("refreshRunData"));
    }
}
