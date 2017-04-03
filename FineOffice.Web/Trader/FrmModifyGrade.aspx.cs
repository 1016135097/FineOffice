using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Trader_FrmModifyGrade : PageBase
{
    FineOffice.BLL.CRM_Grade gradeBll = new FineOffice.BLL.CRM_Grade();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitModule();
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
        }
    }

    private void InitModule()
    {
        int id = int.Parse(Request["ID"]);
        FineOffice.Modules.CRM_Grade model = gradeBll.GetModel(t => t.ID == id);

        hiddenID.Text = model.ID.ToString();
        txtGrade.Text = model.Grade;
        txtOrdering.Text = model.Ordering.ToString();
        txtRemark.Text = model.Remark;
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        int id = int.Parse(hiddenID.Text);
        FineOffice.Modules.CRM_Grade model = gradeBll.GetModel(a => a.ID == id);
        model.Grade = txtGrade.Text.Trim();
        model.Ordering = int.Parse(txtOrdering.Text);
        model.Remark = txtRemark.Text.Trim();
        try
        {
            gradeBll.Update(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.ShowInParent(ex.Message);
        }     
    }
}
