using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using FineOffice.Modules.Helper;
using FineOffice.Common.ListHelper;
using System.Web.UI.WebControls;

public partial class WorkFlow_FrmNewForm : PageBase
{
    FineOffice.BLL.OA_Flow flowBll = new FineOffice.BLL.OA_Flow();
    FineOffice.BLL.OA_FlowSort sortBll = new FineOffice.BLL.OA_FlowSort();

    FineOffice.Common.PinyinCodeHelper pinyin = new FineOffice.Common.PinyinCodeHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            //默认注册选择部门事件
            btnPersonnel.OnClientClick = OnClientClick4Personnel();
            btnDepartment.OnClientClick = OnClientClick4Department();
            LoadData();
        }
        if (Request.Form["__EVENTARGUMENT"] == "param_from_selected")
        {
            btnPersonnel.OnClientClick = OnClientClick4Personnel();
            btnDepartment.OnClientClick = OnClientClick4Department();
        }
    }

    protected string OnClientClick4Personnel()
    {
        return personnelWin.GetSaveStateReference(txtPersonnel.ClientID, hiddenPersonnel.ClientID)
                                                   + personnelWin.GetShowReference("../Common/FrmMultiPersonnel.aspx?selected=" + hiddenPersonnel.Text);
    }

    protected string OnClientClick4Department()
    {
        return departmentWin.GetSaveStateReference(txtDepartment.ClientID, hiddenDepartment.ClientID)
                                                   + departmentWin.GetShowReference("../Common/FrmMultiDepartment.aspx?selected=" + hiddenDepartment.Text);
    }

    private void LoadData()
    {
        List<FineOffice.Modules.OA_FlowSort> typList = sortBll.GetListAll();
        ddlSort.Items.Clear();
        FineUI.ListItem li = new FineUI.ListItem();
        li.Text = "<请选择>";
        ddlSort.Items.Add(li);
        foreach (FineOffice.Modules.OA_FlowSort type in typList)
        {
            FineUI.ListItem item = new FineUI.ListItem();
            item.Text = type.FlowSortName;
            item.Value = type.ID.ToString();
            ddlSort.Items.Add(item);
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FineOffice.Modules.OA_Flow model = new FineOffice.Modules.OA_Flow();
        model.FlowName = txtFormName.Text.Trim();
        model.AllowAttachment = chkAllowAttachment.Checked;
        model.CreateDate = DateTime.Now;
        if (this.CookiePersonnel != null)
            model.Creator = this.CookiePersonnel.ID;

        model.FlowDesc = txtFlowDesc.Text.Trim();
        model.FlowNO = txtFormNO.Text.Trim();
        model.IsFreedom = chkIsFreedom.Checked;
        model.PinyinCode = txtPinyinCode.Text.Trim();
        model.Remark = txtRemark.Text.Trim();
        if (ddlSort.SelectedValue.Length > 0)
            model.SortID = int.Parse(ddlSort.SelectedValue);
        model.Stop = chkStop.Checked;
        model.Version = txtVersion.Text.Trim();
        model.AllowRecall = chkAllowRecall.Checked;
        model.AllowRevoke = chkAllowRevoke.Checked;

        string[] departmentList = hiddenDepartment.Text.Split(',');
        foreach (string str in departmentList)
        {
            if (str.Length > 0)
            {
                FineOffice.Modules.OA_FlowAuthority auth = new FineOffice.Modules.OA_FlowAuthority();
                auth.DepartmentID = int.Parse(str);
                auth.FlowID = model.ID;
                model.OA_FlowAuthorityList.Add(auth);
            }
        }

        string[] personnelList = hiddenPersonnel.Text.Split(',');
        foreach (string str in personnelList)
        {
            if (str.Length > 0)
            {
                FineOffice.Modules.OA_FlowAuthority auth = new FineOffice.Modules.OA_FlowAuthority();
                auth.PersonnelID = int.Parse(str);
                auth.FlowID = model.ID;
                model.OA_FlowAuthorityList.Add(auth);
            }
        }
        try
        {
            flowBll.Add(model);
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
