<%@ WebHandler Language="C#" Class="GetDocument" %>

using System;
using System.Web;
using FineOffice.Common.SerializeHelper;

public class GetDocument : IHttpHandler
{
    public FineOffice.BLL.OA_Form formBll = new FineOffice.BLL.OA_Form();
    public void ProcessRequest(HttpContext context)
    {
        string ID = context.Request["id"];
        FineOffice.Modules.OA_Form model = formBll.GetModel(f => f.ID == int.Parse(ID));
        if (model != null)
        {
            if (model.FormData != null && model.FormData.Length > 0)
            {
                byte[] formData = SharpZipLib.DeCompress(model.FormData);
                context.Response.BinaryWrite(formData);
            }
        }
        context.Response.End();
    }
    public bool IsReusable { get { return false; } }
}