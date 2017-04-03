using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Common_FrmModifyAttachment : PageBase
{
    FineOffice.BLL.OA_Attachment attachmentBll = new FineOffice.BLL.OA_Attachment();

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
        if (Request["ID"] == null)
            return;
        int id = int.Parse(Request["ID"].ToString());
        hiddenID.Text = id.ToString();
        FineOffice.Modules.OA_Attachment model = attachmentBll.GetModel(d => d.ID == id);
        txtFileName.Text = model.FileName;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            FineOffice.Modules.OA_Attachment model = attachmentBll.GetModel(d => d.ID == int.Parse(hiddenID.Text));
            model.FileName = txtFileName.Text.Trim();
            attachmentBll.Update(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("refresh_attachment"));
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }
}
