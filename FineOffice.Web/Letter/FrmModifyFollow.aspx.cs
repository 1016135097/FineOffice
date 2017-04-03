using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Letter_FrmModifyFollow : PageBase
{
    FineOffice.BLL.HR_Personnel personnelBll = new FineOffice.BLL.HR_Personnel();
    FineOffice.BLL.HR_Department departmentBll = new FineOffice.BLL.HR_Department();
    FineOffice.BLL.ADM_LetterFollow followBll = new FineOffice.BLL.ADM_LetterFollow();
    FineOffice.BLL.ADM_Letter letterBll = new FineOffice.BLL.ADM_Letter();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
            int id = int.Parse(Request["ID"]);
            FineOffice.Modules.ADM_LetterFollow model = followBll.GetModel(p => p.ID == id);
            DataBind(model);
        }
    }

    private void LoadData()
    {
        #region 部门员工
        List<FineOffice.Modules.HR_Department> departmentList = departmentBll.GetListAll();
        ddlHandleDepartment.Items.Clear();
        ddlHandleDepartment.Items.Add("<请选择>", "");

        foreach (FineOffice.Modules.HR_Department dep in departmentList)
        {
            ddlHandleDepartment.Items.Add(dep.DepartmentName, dep.ID.ToString());
        }
        #endregion
    }

    private void DataBind(FineOffice.Modules.ADM_LetterFollow model)
    {
        hiddenID.Text = model.ID.ToString();
        if (model.HandleDepartmentID != null)
        {
            ddlHandleDepartment.SelectedValue = model.HandleDepartmentID.ToString();
            ddlHandleDepartment_SelectedIndexChanged(null, null);
            ddlHandler.SelectedValue = model.Handler.ToString();
        }
        dtpDate.Text = string.Format("{0:yyyy-MM-dd}", model.HandleTime);
        dtpTime.Text = string.Format("{0:HH:mm}", model.HandleTime);
        txtLinkman.Text = model.Linkman;
        txtMatter.Text = model.Matter;
        txtMoblie.Text = model.Mobile;
        txtResult.Text = model.Result;
    }

    protected void ddlHandleDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlHandleDepartment.SelectedIndex == 0)
        {
            ddlHandler.Items.Clear();
            ddlHandler.Items.Add("<请选择>", "");
        }
        else
        {
            int departmentID = int.Parse(ddlHandleDepartment.SelectedValue);
            List<FineOffice.Modules.HR_Personnel> personnelList = personnelBll.GetList(p => p.DepartmentID == departmentID);
            ddlHandler.Items.Clear();
            ddlHandler.Items.Add("<请选择>", "");
            foreach (FineOffice.Modules.HR_Personnel person in personnelList)
            {
                ddlHandler.Items.Add(person.Name, person.ID.ToString());
            }
            ddlHandler.SelectedIndex = 0;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int id = int.Parse(hiddenID.Text);
        FineOffice.Modules.ADM_LetterFollow model = followBll.GetModel(p => p.ID == id);
        if (ddlHandler.SelectedIndex > 0)
        {
            model.Handler = int.Parse(ddlHandler.SelectedValue);
        }
        else
        {
            model.Handler = null;
        }
        model.HandleTime = DateTime.Parse(dtpDate.Text + " " + dtpTime.Text);
        model.Linkman = txtLinkman.Text.Trim();
        model.Matter = txtMatter.Text.Trim();
        model.Mobile = txtMoblie.Text.Trim();
        model.Result = txtResult.Text.Trim();
        try
        {
            followBll.Update(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }
}
