using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Xml.Linq;
using System.Xml;
using System.Text;
using FineOffice.Modules.Helper;
using FineOffice.Web;

public partial class WorkFlow_FrmFlowView : PageBase
{
    FineOffice.BLL.OA_Flow flowBll = new FineOffice.BLL.OA_Flow();
    public FineOffice.Modules.OA_Flow model = new FineOffice.Modules.OA_Flow();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request["ID"] != null)
            {
                int id = int.Parse(Request["ID"].ToString());
                txtID.Text = id.ToString();
                model = flowBll.GetModel(d => d.ID == id);
                txtXML.Text = model.XML;
            }
        }
    }   
}