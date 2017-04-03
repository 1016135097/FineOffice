using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HardDisk_FrmNewFolder : PageBase
{
    FineOffice.BLL.HD_Folder folderBll = new FineOffice.BLL.HD_Folder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetHideReference();
            hiddenParentID.Text = Request["parentid"];
            hiddenIsPublic.Text = Request["ispublic"] == null ? "" : Request["ispublic"];
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            FineOffice.Modules.HD_Folder model = new FineOffice.Modules.HD_Folder();
            model.ParentID = int.Parse(hiddenParentID.Text);
            model.IsPublic = false;
            if (hiddenIsPublic.Text.Length > 0)
            {               
                model.IsPublic = true;
            }
            model.PersonnelID = CookiePersonnel.ID;
            model.FolderName = txtFolder.Text.Trim();
            folderBll.Add(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("folder_close"));
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }
    }
}
