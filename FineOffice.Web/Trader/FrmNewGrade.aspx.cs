using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Trader_FrmNewGrade : PageBase
{
    FineOffice.BLL.CRM_Grade gradeBll = new FineOffice.BLL.CRM_Grade();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        FineOffice.Modules.CRM_Grade model = new FineOffice.Modules.CRM_Grade();
        model.Grade = txtGrade.Text.Trim();
        model.Ordering = int.Parse(txtOrdering.Text);
        model.Remark = txtRemark.Text.Trim();
        try
        {
            gradeBll.Add(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }     
    }
}
