using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HardDisk_FrmModifyFile : PageBase
{
    FineOffice.BLL.HD_Attachment attacthmentBll = new FineOffice.BLL.HD_Attachment();

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
        if (Request["id"] == null)
            return;
        int id = int.Parse(Request["id"].ToString());
        hiddenID.Text = id.ToString();
        FineOffice.Modules.HD_Attachment model = attacthmentBll.GetModel(d => d.ID == id);
        txtFileName.Text = model.FileName;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            FineOffice.Modules.HD_Attachment model = attacthmentBll.GetModel(d => d.ID == int.Parse(hiddenID.Text));
            model.FileName = txtFileName.Text.Trim();
            attacthmentBll.Update(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("refresh_File"));
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }
}
