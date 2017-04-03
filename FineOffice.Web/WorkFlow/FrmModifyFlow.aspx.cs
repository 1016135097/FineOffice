using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class WorkFlow_FrmNewForm : PageBase
{
    FineOffice.BLL.OA_Flow flowBll = new FineOffice.BLL.OA_Flow();
    FineOffice.BLL.OA_FlowSort sortBll = new FineOffice.BLL.OA_FlowSort();
    FineOffice.BLL.HR_Personnel personnelBll = new FineOffice.BLL.HR_Personnel();
    FineOffice.BLL.HR_Department departmentBll = new FineOffice.BLL.HR_Department();
    FineOffice.Common.PinyinCodeHelper pinyin = new FineOffice.Common.PinyinCodeHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            LoadData();
            InitModule();
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

    private void InitModule()
    {
        if (Request["ID"] == null)
            return;

        int id = int.Parse(Request["ID"].ToString());
        txtID.Text = id.ToString();
        FineOffice.Modules.OA_Flow model = flowBll.GetModel(d => d.ID == id);
        chkAllowAttachment.Checked = model.AllowAttachment.Value;

        txtFormName.Text = model.FlowName;
        txtFlowDesc.Text = model.FlowDesc;
        txtFormNO.Text = model.FlowNO;
        chkIsFreedom.Checked = model.IsFreedom.Value;
        chkAllowRecall.Checked = model.AllowRecall.Value;
        chkAllowRevoke.Checked = model.AllowRevoke.Value;

        txtPinyinCode.Text = model.PinyinCode;
        txtRemark.Text = model.Remark;
        if (model.SortID != null)
            ddlSort.SelectedValue = model.SortID.ToString();
        chkStop.Checked = model.Stop.Value;

        StringBuilder departmentName = new StringBuilder();
        StringBuilder departmentID = new StringBuilder();

        StringBuilder personnelName = new StringBuilder();
        StringBuilder personnelID = new StringBuilder();

        foreach (FineOffice.Modules.OA_FlowAuthority authority in model.OA_FlowAuthorityList)
        {
            if (authority.PersonnelID != null)
            {
                personnelID.Append(authority.PersonnelID);
                personnelID.Append(",");

                personnelName.Append(authority.PersonnelName);
                personnelName.Append(",");
            }
            if (authority.DepartmentID != null)
            {
                departmentID.Append(authority.DepartmentID);
                departmentID.Append(",");

                departmentName.Append(authority.DepartmentName);
                departmentName.Append(",");
            }
        }

        txtDepartment.Text = departmentName.ToString();
        hiddenDepartment.Text = departmentID.ToString();

        txtPersonnel.Text = personnelName.ToString();
        hiddenPersonnel.Text = personnelID.ToString();

        btnPersonnel.OnClientClick = OnClientClick4Personnel();
        btnDepartment.OnClientClick = OnClientClick4Department();

        txtVersion.Text = model.Version;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FineOffice.Modules.OA_Flow model = flowBll.GetModel(d => d.ID == int.Parse(txtID.Text));
        model.FlowName = txtFormName.Text.Trim();
        model.AllowAttachment = chkAllowAttachment.Checked;
        model.CreateDate = DateTime.Now;
        if (this.CookiePersonnel != null)
            model.Creator = this.CookiePersonnel.ID;

        model.FlowDesc = txtFlowDesc.Text.Trim();
        model.FlowNO = txtFormNO.Text.Trim();
        model.IsFreedom = chkIsFreedom.Checked;
        model.AllowRecall = chkAllowRecall.Checked;
        model.AllowRevoke = chkAllowRevoke.Checked;

        model.PinyinCode = txtPinyinCode.Text.Trim();
        model.Remark = txtRemark.Text.Trim();
        if (ddlSort.SelectedValue.Length > 0)
            model.SortID = int.Parse(ddlSort.SelectedValue);
        model.Stop = chkStop.Checked;
        model.Version = txtVersion.Text.Trim();

        model.OA_FlowAuthorityList.Clear();
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
            flowBll.Update(model);
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
