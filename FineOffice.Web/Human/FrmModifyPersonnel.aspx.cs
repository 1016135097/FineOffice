using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Human_FrmNewPersonnel : PageBase
{
    FineOffice.BLL.HR_Personnel personnelBll = new FineOffice.BLL.HR_Personnel();
    FineOffice.BLL.HR_Job jobBll = new FineOffice.BLL.HR_Job();
    FineOffice.BLL.HR_Department depBll = new FineOffice.BLL.HR_Department();
    FineOffice.BLL.AM_Kind kindBll = new FineOffice.BLL.AM_Kind();
    FineOffice.Common.PinyinCodeHelper pinyin = new FineOffice.Common.PinyinCodeHelper();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            LoadData();
            InitModule();
        }
    }

    private void LoadData()
    {
        List<FineOffice.Modules.HR_Department> deparmentList = depBll.GetListAll();
        ddlDepartment.Items.Clear();
        FineUI.ListItem li = new FineUI.ListItem();
        li.Text = "<请选择>";
        ddlDepartment.Items.Add(li);
        foreach (FineOffice.Modules.HR_Department department in deparmentList)
        {
            FineUI.ListItem item = new FineUI.ListItem();
            item.Text = department.DepartmentName;
            item.Value = department.ID.ToString();
            ddlDepartment.Items.Add(item);
        }

        List<FineOffice.Modules.HR_Job> jobList = jobBll.GetListAll();
        ddlJob.Items.Clear();
        FineUI.ListItem jobLi = new FineUI.ListItem();
        jobLi.Text = "<请选择>";
        ddlJob.Items.Add(jobLi);
        foreach (FineOffice.Modules.HR_Job job in jobList)
        {
            FineUI.ListItem item = new FineUI.ListItem();
            item.Text = job.Job;
            item.Value = job.ID.ToString();
            ddlJob.Items.Add(item);
        }

        List<FineOffice.Modules.AM_Kind> eduList = kindBll.GetList(d => d.KindID == 1);
        ddlEducation.Items.Clear();
        FineUI.ListItem eduLi = new FineUI.ListItem();
        eduLi.Text = "<请选择>";
        ddlEducation.Items.Add(eduLi);
        foreach (FineOffice.Modules.AM_Kind kind in eduList)
        {
            FineUI.ListItem item = new FineUI.ListItem();
            item.Text = kind.Name;
            item.Value = kind.ID.ToString();
            ddlEducation.Items.Add(item);
        }
    }

    private void InitModule()
    {
        if (Request["ID"] == null)
            return;

        int id = int.Parse(Request["ID"].ToString());
        txtID.Text = id.ToString();
        FineOffice.Modules.HR_Personnel model = personnelBll.GetModel(d => d.ID == id);
        txtAddress.Text = model.Address;
        calDateOfBirth.SelectedDate = model.DateOfBirth;
        ddlDepartment.SelectedValue = model.DepartmentID.ToString();
        ddlEducation.SelectedValue = model.EducationID.ToString();
        txtEmail.Text = model.Email;
        calEntryDate.SelectedDate = model.EntryDate;
        calExitDate.SelectedDate = model.ExitDate;
        txtHomeTelephone.Text = model.HomeTelephone;
        ddlJob.SelectedValue = model.JobID.ToString();
        txtLinkman.Text = model.Linkman;
        txtMobile.Text = model.Mobile;
        txtName.Text = model.Name;
        txtNativePlace.Text = model.NativePlace;
        txtPersonnelNO.Text = model.PersonnelNO;
        txtPinyin.Text = model.PinyinCode;
        ddlSex.SelectedValue = model.Sex.ToString();
        chkStop.Checked = model.Stop.Value;
        txtRemark.Text = model.Remark;
        chkStop.Checked = model.Stop.Value;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FineOffice.Modules.HR_Personnel model = personnelBll.GetModel(d => d.ID == int.Parse(txtID.Text));
        model.Address = txtAddress.Text.Trim();
        model.DateOfBirth = calDateOfBirth.SelectedDate;
        if (ddlDepartment.SelectedValue.Length > 0)
        {
            model.DepartmentID = int.Parse(ddlDepartment.SelectedValue);
        }
        if (ddlEducation.SelectedValue.Length > 0)
        {
            model.EducationID = int.Parse(ddlEducation.SelectedValue);
        }
        model.Email = txtEmail.Text;
        model.EntryDate = calEntryDate.SelectedDate;
        model.ExitDate = calExitDate.SelectedDate;
        model.HomeTelephone = txtHomeTelephone.Text.Trim();
        if (ddlJob.SelectedValue.Length > 0)
        {
            model.JobID = int.Parse(ddlJob.SelectedValue);
        }
        model.Linkman = txtLinkman.Text.Trim();
        model.Mobile = txtMobile.Text.Trim();
        model.Name = txtName.Text.Trim();
        model.NativePlace = txtNativePlace.Text.Trim();
        model.PersonnelNO = txtPersonnelNO.Text.Trim();
        model.PinyinCode = txtPinyin.Text.Trim();
        model.Sex = short.Parse(ddlSex.SelectedValue);
        model.Stop = chkStop.Checked;
        model.Remark = txtRemark.Text.Trim();
        try
        {
            personnelBll.Update(model);
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
        PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
    }

    protected void Pinyin_TextChanged(object sender, EventArgs e)
    {
        txtPinyin.Text = pinyin.GetFirstLetter(txtName.Text.Trim());
    }
}
