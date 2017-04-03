using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WorkFlow_FrmModifyFlowSort : PageBase
{
    FineOffice.BLL.OA_FlowSort sortBll = new FineOffice.BLL.OA_FlowSort();
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
        FineOffice.Modules.OA_FlowSort model = sortBll.GetModel(d => d.ID == id);
        txtSortNO.Text = model.SortNO;
        txtSortName.Text = model.FlowSortName;
        txtPinyinCode.Text = model.PinyinCode;
        txtRemark.Text = model.Remark;
        chkStop.Checked = model.Stop.Value;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FineOffice.Modules.OA_FlowSort model = sortBll.GetModel(d => d.ID == int.Parse(txtID.Text));
        model.SortNO = txtSortNO.Text.Trim();
        model.FlowSortName = txtSortName.Text.Trim();
        model.PinyinCode = txtPinyinCode.Text.Trim();
        model.Remark = txtRemark.Text.Trim();
        model.Stop = chkStop.Checked;
        try
        {
            sortBll.Update(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    protected void Pinyin_TextChanged(object sender, EventArgs e)
    {
        txtPinyinCode.Text = pinyin.GetFirstLetter(txtSortName.Text.Trim());
    }
}
