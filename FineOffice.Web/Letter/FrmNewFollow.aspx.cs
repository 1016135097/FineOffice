using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Letter_FrmNewFollow : PageBase
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
            int letterID = int.Parse(Request["LetterID"]);
            FineOffice.Modules.ADM_Letter letter = letterBll.GetModel(p => p.ID == letterID);
            txtLinkman.Text = letter.Visitor;
            txtMoblie.Text = letter.Mobile;
            hiddenLetterID.Text = letter.ID.ToString();
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

    protected void ddlHandleDepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlHandleDepartment.SelectedValue.Length == 0)
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
        FineOffice.Modules.ADM_LetterFollow model = new FineOffice.Modules.ADM_LetterFollow();          
        if (ddlHandler.SelectedIndex > 0)
        {
            model.Handler = int.Parse(ddlHandler.SelectedValue);
        }
        else
        {
            model.Handler = null;
        }
        model.HandleTime = DateTime.Parse(dtpDate.Text+" "+dtpTime.Text);
        model.LetterID = int.Parse(hiddenLetterID.Text);
        model.Linkman = txtLinkman.Text.Trim();
        model.Matter = txtMatter.Text.Trim();
        model.Mobile = txtMoblie.Text.Trim();
        model.Result = txtResult.Text.Trim();
        try
        {
            followBll.Add(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }
}
