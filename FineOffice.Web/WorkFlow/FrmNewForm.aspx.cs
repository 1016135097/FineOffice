using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WorkFlow_FrmNewForm : PageBase
{
    FineOffice.BLL.OA_Form formBll = new FineOffice.BLL.OA_Form();
    FineOffice.BLL.OA_FormType typeBll = new FineOffice.BLL.OA_FormType();

    FineOffice.Common.PinyinCodeHelper pinyin = new FineOffice.Common.PinyinCodeHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            LoadData();
        }
    }

    private void LoadData()
    {
        List<FineOffice.Modules.OA_FormType> typeList = typeBll.GetListAll();
        ddlType.Items.Clear();
        FineUI.ListItem li = new FineUI.ListItem();
        li.Text = "<请选择>";
        ddlType.Items.Add(li);
        foreach (FineOffice.Modules.OA_FormType type in typeList)
        {
            FineUI.ListItem item = new FineUI.ListItem();
            item.Text = type.FormTypeName;
            item.Value = type.ID.ToString();
            ddlType.Items.Add(item);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FineOffice.Modules.OA_Form model = new FineOffice.Modules.OA_Form();
        model.FormNO = txtFormNO.Text.Trim();
        model.FormName = txtFormName.Text.Trim();
        model.PinyinCode = txtPinyinCode.Text.Trim();
        if (ddlType.SelectedValue.Length > 0)
        {
            model.TypeID = int.Parse(ddlType.SelectedValue);
        }
        model.Remark = txtRemark.Text.Trim();
        model.Stop = chkStop.Checked;
        try
        {
            formBll.Add(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }

    protected void Pinyin_TextChanged(object sender, EventArgs e)
    {
        txtPinyinCode.Text = pinyin.GetFirstLetter(txtFormName.Text.Trim());
    }
}
