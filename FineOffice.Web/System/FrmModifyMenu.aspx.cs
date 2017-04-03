using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class System_FrmModifyMenu : PageBase
{
    FineOffice.BLL.SYS_MenuList menuBll = new FineOffice.BLL.SYS_MenuList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitModule();
            btnClose.OnClientClick = ActiveWindow.GetHideReference();
        }
    }

    protected void InitModule()
    {
        int id = int.Parse(Request["id"]);
        FineOffice.Modules.SYS_MenuList model = menuBll.GetModel(d => d.ID == id);
        hiddenID.Text = model.ID.ToString();
        txtAuthorityValue.Text = model.TabID;
        txtIcon.Text = model.Icon;
        if (model.IsModule != null && model.IsModule.Value)
        {
            txtAuthorityValue.Enabled = false;
            txtNavigateUrl.Enabled = false;
            rdbMenuType.SelectedIndex = 0;
        }
        else
        {
            txtAuthorityValue.Enabled = true;
            txtNavigateUrl.Enabled = true;
            rdbMenuType.SelectedIndex = 1;
        }
        txtNavigateUrl.Text = model.NavigateUrl;
        txtOrdering.Text = model.Ordering.ToString();
        hiddenParentID.Text = model.ParentID.ToString();
        if (model.ParentID != 0)
        {
            FineOffice.Modules.SYS_MenuList temp = menuBll.GetModel(a => a.ID == model.ParentID);
            txtParent.Text = temp.Text;
        }
        txtText.Text = model.Text;
        txtRemark.Text = model.Remark;
        if (model.Stop != null)
            chkStop.Checked = model.Stop.Value;
        txtParent.OnClientTriggerClick = wdnSelectMenu.GetSaveStateReference(txtParent.ClientID, hiddenParentID.ClientID)
              + wdnSelectMenu.GetShowReference("../System/FrmSelectMenu.aspx?id=" + id);
    }

    protected void rdbMenuType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rdbMenuType.SelectedIndex == 1)
        {
            txtAuthorityValue.Enabled = true;
            txtNavigateUrl.Enabled = true;
        }
        else
        {
            txtAuthorityValue.Enabled = false;
            txtNavigateUrl.Enabled = false;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int id = int.Parse(hiddenID.Text);
            FineOffice.Modules.SYS_MenuList model = menuBll.GetModel(a => a.ID == id);
            model.TabID = txtAuthorityValue.Text.Trim();
            model.Icon = txtIcon.Text.Trim();

            if (rdbMenuType.SelectedIndex == 0)
            {
                model.IsModule = true;
                model.IsFuntion = false;
            }
            else
            {
                model.IsFuntion = true;
                model.IsModule = false;
            }

            model.NavigateUrl = txtNavigateUrl.Text.Trim();
            model.Ordering = int.Parse(txtOrdering.Text);

            if (hiddenParentID.Text.Length > 0)
                model.ParentID = int.Parse(hiddenParentID.Text);
            else
                model.ParentID = 0;

            model.SingleClickExpand = true;
            model.Text = txtText.Text.Trim();
            model.Remark = txtRemark.Text.Trim();
            model.Stop = chkStop.Checked;
            menuBll.Update(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.Show(ex.Message);
        }
    }
}
