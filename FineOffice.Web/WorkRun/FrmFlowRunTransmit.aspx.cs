using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineOffice.Modules.Helper;
using System.Text;

public partial class WorkRun_FrmFlowRunTransmit : PageBase
{
    FineOffice.BLL.OA_FlowRunProcess runProcessBll = new FineOffice.BLL.OA_FlowRunProcess();
    FineOffice.BLL.Bussness.FlowRunHandler runHandlerBll = new FineOffice.BLL.Bussness.FlowRunHandler();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["ID"] == null)
                return;
            hiddenRunProcess.Text = Request["ID"];
            int id = int.Parse(hiddenRunProcess.Text);
            FineOffice.Modules.OA_FlowRunProcess model = runProcessBll.GetModel(d => d.ID == id);

            if (Request["Version"] != null)
            {
                hiddenVersion.Text = Request["Version"];
            }
            else
            {
                hiddenVersion.Text = this.ByteToJson(model.Version);
            }
            btnFind.OnClientClick = frmPersonnel.GetSaveStateReference(txtPersonnel.ClientID, hiddenPersonnel.ClientID)
                                                   + frmPersonnel.GetShowReference("FrmTransmitPerson.aspx?Process=" + model.ProcessID);
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int id = int.Parse(hiddenRunProcess.Text);
        FineOffice.Modules.OA_FlowRunProcess currentProcess = runProcessBll.GetModel(p => p.ID == int.Parse(hiddenRunProcess.Text));
        currentProcess.State = 2;//委托
        currentProcess.TrackingState = TrackingInfo.Updated;
        currentProcess.Version = this.JsonTobyte(hiddenVersion.Text);
        currentProcess.HandleTime = DateTime.Now;
        currentProcess.TransmitAdvice = txtTransmitAdvice.Text;

        //创建办理
        FineOffice.Modules.OA_FlowRunProcess process = new FineOffice.Modules.OA_FlowRunProcess();
        process.State = 0;
        process.RunID = currentProcess.RunID;

        //退回的操作，刚刚是反转过来
        process.Pattern = 2;
        process.SendID = currentProcess.AcceptID;
        process.IsEntrance = currentProcess.IsEntrance;
        process.AcceptID = int.Parse(hiddenPersonnel.Text);
        process.AcceptTime = currentProcess.HandleTime;
        process.ProcessID = currentProcess.ProcessID;
        process.TransmitAdvice = currentProcess.TransmitAdvice;
        process.PreviousID = currentProcess.PreviousID;
        process.TrackingState = TrackingInfo.Created;

        try
        {
            runHandlerBll.SendBackRunProcess(currentProcess, process);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("transmitClose"));
        }
        catch
        {
            Alert.ShowInParent("该流程已办理，不能操作！");
        }

    }
}
