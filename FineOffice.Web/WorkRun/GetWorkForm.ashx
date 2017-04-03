<%@ WebHandler Language="C#" Class="GetWorkForm" %>

using System;
using System.Web;
using FineOffice.Common.SerializeHelper;

public class GetWorkForm : IHttpHandler
{
    public FineOffice.BLL.OA_FlowRunData runDataBll = new FineOffice.BLL.OA_FlowRunData();
    public void ProcessRequest(HttpContext context)
    {
        string ID = context.Request["ID"];
        FineOffice.Modules.OA_FlowRunData model = runDataBll.GetModel(f => f.ID == int.Parse(ID));
        if (model != null)
        {
            if (model.FormData != null)
            {
                byte[] formData = SharpZipLib.DeCompress(model.FormData);
                context.Response.BinaryWrite(formData);
            }
        }
        context.Response.End();
    }
    public bool IsReusable { get { return false; } }
}