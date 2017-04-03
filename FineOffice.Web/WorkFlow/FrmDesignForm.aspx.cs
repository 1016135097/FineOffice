using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FineOffice.Web;
using FineUI;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WorkFlow_FrmDesignForm : PageBase
{
    public FineOffice.Modules.OA_Form model = new FineOffice.Modules.OA_Form();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {     
            FineOffice.BLL.OA_Form bll=new FineOffice.BLL.OA_Form();
            model=bll.GetModel(i=>i.ID==int.Parse(Request["ID"]));            
        }
    }
}
