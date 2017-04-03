using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contract_FrmContractType : PageBase
{
    FineOffice.BLL.OA_ContractType typeBll = new FineOffice.BLL.OA_ContractType();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            btnClose.OnClientClick = ActiveWindow.GetConfirmHidePostBackReference();
            InitModule();
        }
    }

    protected void InitModule()
    {
        int id = int.Parse(Request["ID"]);
        hiddenID.Text = id.ToString();
        FineOffice.Modules.OA_ContractType model = typeBll.GetModel(d => d.ID == id);
        txtRemark.Text = model.Remark;
        txtTypeName.Text = model.TypeName;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int id = int.Parse(hiddenID.Text);
        FineOffice.Modules.OA_ContractType model = typeBll.GetModel(d => d.ID == id);
        model.TypeName = txtTypeName.Text.Trim();
        model.Ordering = int.Parse(txtOrdering.Text);
        model.Remark = txtRemark.Text.Trim();
        try
        {
            typeBll.Update(model);
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference("subwin_close"));
        }
        catch (Exception ex)
        {
            Alert.ShowInTop(ex.Message);
        }
    }
}
