using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _CreateValidate : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int width = 150;
        int height = 30;
        try
        {
            width = Convert.ToInt32(Request.QueryString["w"]);
            height = Convert.ToInt32(Request.QueryString["h"]);
        }
        catch (Exception)
        {
            //nothing to do
        }
        Response.Write(FineOffice.Common.CreateImage.DrawImage("IdentifyingCode", width, height));
    }
}