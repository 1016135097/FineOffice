using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class WorkFlow_FrmProcessAuthority : PageBase
{
    FineOffice.BLL.OA_FlowProcess processBll = new FineOffice.BLL.OA_FlowProcess();
    FineOffice.BLL.HR_Personnel personnelBll = new FineOffice.BLL.HR_Personnel();
    FineOffice.BLL.HR_Department departmentBll = new FineOffice.BLL.HR_Department();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["ID"] != null)
            {
                btnClose.OnClientClick = ActiveWindow.GetConfirmHideReference();
                FineOffice.Modules.OA_FlowProcess model = processBll.GetModel(p => p.ID == Request["ID"]);
                txtID.Text = model.ID;
                txtProcessName.Text = model.ProcessName;
                hiddenDepartment.Text = model.ProcessDepartment;
                hiddenPersonnel.Text = model.ProcessPersonnel;

                List<string> list = new List<string>();
                if (model.AllowRefuse.Value)
                {
                    list.Add("AllowRefuse");
                }
                if (model.AllowGoBack.Value)
                {
                    list.Add("AllowGoBack");
                }
                if (model.Feedback.Value)
                {
                    list.Add("Feedback");
                }
                chkOprate.SelectedValueArray = list.ToArray();
                txtTimeLimit.Text = model.TimeLimit.ToString();
                txtRemind.Text = model.Remind.ToString();

                model.TimeLimit = int.Parse(txtTimeLimit.Text);
                model.Remind = int.Parse(txtRemind.Text);

                #region 职员信息绑定
                List<int> personnel = new List<int>();
                if (model.ProcessPersonnel != null)
                {
                    string[] str = model.ProcessPersonnel.Split(',');
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i].Length > 0)
                        {
                            personnel.Add(int.Parse(str[i]));
                        }
                    }
                }

                List<FineOffice.Modules.HR_Personnel> personnelList = personnelBll.GetList(d => personnel.Contains(d.ID)).ToList();
                StringBuilder sbPersonnel = new StringBuilder();

                for (int i = 0; i < personnelList.Count; i++)
                {
                    sbPersonnel.Append(personnelList[i].Name);
                    sbPersonnel.Append(",");
                }
                txtPersonnel.Text = sbPersonnel.ToString();
                #endregion

                #region 部门信息绑定
                List<int> department = new List<int>();
                if (model.ProcessDepartment != null)
                {
                    string[] str = model.ProcessDepartment.Split(',');
                    for (int i = 0; i < str.Length; i++)
                    {
                        if (str[i].Length > 0)
                        {
                            department.Add(int.Parse(str[i]));
                        }
                    }
                }
                List<FineOffice.Modules.HR_Department> departmentList = departmentBll.GetList(d => department.Contains(d.ID)).ToList();

                StringBuilder sbDepartment = new StringBuilder();
                for (int i = 0; i < departmentList.Count; i++)
                {
                    sbDepartment.Append(departmentList[i].DepartmentName);
                    sbDepartment.Append(",");
                }
                txtDepartment.Text = sbDepartment.ToString();
                #endregion

                OnClientClick();
            }
        }
        if (Request.Form["__EVENTARGUMENT"] == "param_from_selected")
        {
            OnClientClick();
        }
    }

    protected void OnClientClick()
    {
        btnPersonnel.OnClientClick = personnelWin.GetSaveStateReference(txtPersonnel.ClientID, hiddenPersonnel.ClientID)
                                       + personnelWin.GetShowReference("../Common/FrmMultiPersonnel.aspx?selected=" + hiddenPersonnel.Text);

        btnDepartment.OnClientClick = departmentWin.GetSaveStateReference(txtDepartment.ClientID, hiddenDepartment.ClientID)
                               + departmentWin.GetShowReference("../Common/FrmMultiDepartment.aspx?selected=" + hiddenDepartment.Text);

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            FineOffice.Modules.OA_FlowProcess model = processBll.GetModel(p => p.ID == txtID.Text);
            model.ProcessPersonnel = hiddenPersonnel.Text;
            model.ProcessDepartment = hiddenDepartment.Text;
            string[] oprate = chkOprate.SelectedValueArray;

            if (oprate.Contains("AllowRefuse"))
                model.AllowRefuse = true;
            else
                model.AllowRefuse = false;

            if (oprate.Contains("AllowGoBack"))
                model.AllowGoBack = true;
            else
                model.AllowGoBack = false;

            if (oprate.Contains("Feedback"))
                model.Feedback = true;
            else
                model.Feedback = false;

            model.TimeLimit = int.Parse(txtTimeLimit.Text);
            model.Remind = int.Parse(txtRemind.Text);
            processBll.Update(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHideReference());
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }
}
