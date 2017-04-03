using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WorkRun_FrmNewFlowForm : PageBase
{
    FineOffice.BLL.OA_FlowForm flowFormBll = new FineOffice.BLL.OA_FlowForm();
    FineOffice.BLL.OA_FlowRunData runDataBll = new FineOffice.BLL.OA_FlowRunData();
    FineOffice.BLL.OA_Form formBll = new FineOffice.BLL.OA_Form();
    FineOffice.BLL.OA_FormType typeBll = new FineOffice.BLL.OA_FormType();

    FineOffice.Common.PinyinCodeHelper pinyin = new FineOffice.Common.PinyinCodeHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string ProcessID = Request["ProcessID"];
            hiddenRunProcess.Text = Request["RunProcess"];
            List<FineOffice.Modules.OA_FlowForm> formList = flowFormBll.GetList(f => f.ProcessID == ProcessID);
            ddlForm.Items.Clear();
            FineUI.ListItem li = new FineUI.ListItem();
            li.Text = "<空白表单>";
            ddlForm.Items.Add(li);
            foreach (FineOffice.Modules.OA_FlowForm form in formList)
            {
                FineUI.ListItem item = new FineUI.ListItem();
                item.Text = form.FormName;
                item.Value = form.FormID.ToString();
                ddlForm.Items.Add(item);
            }
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FineOffice.Modules.OA_FlowRunData model = new FineOffice.Modules.OA_FlowRunData();
        model.Title = txtTitle.Text.Trim();
        model.Remark = txtRemark.Text.Trim();
        model.UpdateTime = DateTime.Now;
        model.CreateTime = DateTime.Now;
        model.RunProcessID = int.Parse(hiddenRunProcess.Text);
        if (ddlForm.SelectedValue.Length > 0)
        {
            FineOffice.Modules.OA_Form form = formBll.GetModel(m => m.ID == int.Parse(ddlForm.SelectedValue));
            model.FormData = form.FormData;
            model.FormID = form.ID;
            model.XType = form.XType;
        }
        try
        {
            model = runDataBll.Add(model);
            if (chkEdit.Checked)
            {
                string tabID = string.Format("{0:HHmmssffff}", DateTime.Now);
                PageContext.RegisterStartupScript("openTab('_FrmEditForm" + tabID +
                    "','表单编辑-" + model.Title + "','WorkRun/FrmEditForm.aspx?ID=" + model.ID + "');");
            }
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("refreshRunData"));
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }
}
