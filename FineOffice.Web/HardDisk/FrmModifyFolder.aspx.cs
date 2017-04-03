using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HardDisk_FrmModifyFolder : PageBase
{
    FineOffice.BLL.HD_Folder folderBll = new FineOffice.BLL.HD_Folder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetHideReference();
            int id = int.Parse(Request["id"]);
            FineOffice.Modules.HD_Folder model = folderBll.GetModel(d => d.ID == id);
            hiddenID.Text = id.ToString();
            txtFolder.Text = model.FolderName;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int id = int.Parse(hiddenID.Text);
            FineOffice.Modules.HD_Folder model = folderBll.GetModel(d => d.ID == id);
            model.FolderName = txtFolder.Text.Trim();
            folderBll.Update(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("folder_close"));
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }
}