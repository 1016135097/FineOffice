using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineOffice.Modules.Helper;

public partial class WorkRun_FrmNewWorkRun : PageBase
{
    FineOffice.BLL.OA_Flow flowBll = new FineOffice.BLL.OA_Flow();
    FineOffice.BLL.OA_FlowRun runBll = new FineOffice.BLL.OA_FlowRun();
    FineOffice.BLL.OA_FlowProcess processBll = new FineOffice.BLL.OA_FlowProcess();
    FineOffice.BLL.OA_FlowRunProcess runProcessBll = new FineOffice.BLL.OA_FlowRunProcess();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            if (Request["id"] != null)
            {
                int id = int.Parse(Request["id"]);
                FineOffice.Modules.OA_Flow model = flowBll.GetModel(f => f.ID == id);
                txtFlowID.Text = model.ID.ToString();
                txtFlowName.Text = model.FlowName.ToString();

                dtpDate.Text = string.Format("{0:yyyy-MM-dd}", DateTime.Now);
                dtpTime.Text = string.Format("{0:HH:mm}", DateTime.Now);
            }
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (this.CookiePersonnel == null)
        {
            Alert.ShowInParent("当前用户不存在职员信息，不能新建工作！");
            return;
        }
        FineOffice.Modules.OA_FlowRun model = new FineOffice.Modules.OA_FlowRun();
        model.WorkNO = txtWorkNO.Text;
        model.FlowID = int.Parse(txtFlowID.Text);
        FineOffice.Modules.OA_FlowProcess process = processBll.GetModel(r => r.FlowID == model.FlowID && r.IsStart == true);
        if (process == null)
        {
            Alert.ShowInParent("工作流程没有开始步骤，不能新建工作！");
            return;
        }

        bool state = false;
        if (process.ProcessDepartment != null)
        {
            string[] deparment = process.ProcessDepartment.Split(',');
            if (deparment.Where(s => s == this.CookiePersonnel.DepartmentID.ToString()).Count() > 0)
                state = true;
        }
        if (process.ProcessPersonnel != null)
        {
            string[] personnel = process.ProcessPersonnel.Split(',');
            if (personnel.Where(s => s == this.CookiePersonnel.ID.ToString()).Count() > 0)
                state = true;
        }
        if (process.ProcessDepartment == null && process.ProcessPersonnel == null)
        {
            state = true;
        }
        if (!state)
        {
            Alert.ShowInParent("当前用户没有操作该步骤的权限，不能新建工作！");
            return;
        }
        model.WorkName = txtWorkName.Text.Trim();
        model.CreateTime = DateTime.Parse(dtpDate.Text.Trim() + " " + dtpTime.Text);
        model.Remark = txtRemark.Text;
        model.Creator = CookiePersonnel.ID;
        FineOffice.Modules.OA_FlowRunProcess runProcess = new FineOffice.Modules.OA_FlowRunProcess();
        runProcess.AcceptID = this.CookiePersonnel.ID;
        runProcess.SendID = this.CookiePersonnel.ID;
        runProcess.ProcessID = process.ID;
        runProcess.AcceptTime = model.CreateTime;
        runProcess.RunID = model.ID;
        runProcess.State = 0;
        runProcess.Pattern = 0;
        runProcess.AcceptTime = model.CreateTime;
        runProcess.State = 0;
        runProcess.IsEntrance = true;
        runProcess.AcceptID = this.CookiePersonnel.ID;
        model.OA_FlowRunProcessList.Add(runProcess);

        try
        {
            model = runBll.Add(model);
            ChangeTrackingList<EntitySearcher> searchList = new ChangeTrackingList<EntitySearcher>();
            EntitySearcher searcher = new EntitySearcher();
            searcher.Content = model.ID.ToString();
            searcher.Operator = "=";
            searcher.Field = "RunID";
            searcher.Relation = "OR";
            searchList.Add(searcher);
            FineOffice.Modules.OA_FlowRunProcess temp = runProcessBll.GetList(searchList)[0];
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("Close&" + temp.ID));
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }
}
