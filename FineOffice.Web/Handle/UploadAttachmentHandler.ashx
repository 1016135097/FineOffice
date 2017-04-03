<%@ WebHandler Language="C#" Class="UploadAttachmentHandler" %>

using System;
using System.Web;
using FineOffice.Common.SerializeHelper;

public class UploadAttachmentHandler : IHttpHandler
{
    public FineOffice.BLL.OA_Attachment attBll = new FineOffice.BLL.OA_Attachment();

    public void ProcessRequest(HttpContext context)
    {
        FineOffice.Modules.OA_Attachment model = new FineOffice.Modules.OA_Attachment();

        model.PersonnelID = int.Parse(context.Request["PersonnelID"]);
        if (context.Request["followid"] != null)
            model.LetterFollowID = int.Parse(context.Request["FollowID"]);
        if (context.Request["runprocessid"] != null)
            model.RunProcessID = int.Parse(context.Request["runprocessid"]);
        if (context.Request["ContractID"] != null)
            model.ContractID = int.Parse(context.Request["ContractID"]);

        FineOffice.Web.ResponseModule responseModule = new FineOffice.Web.ResponseModule();
        try
        {
            HttpPostedFile file = context.Request.Files["FileData"];
            Byte[] fileData = new Byte[file.ContentLength];
            System.IO.Stream sr = file.InputStream;
            sr.Read(fileData, 0, file.ContentLength);
            model.AttachmentData = SharpZipLib.Compress(fileData);

            model.XType = file.FileName.Substring(file.FileName.LastIndexOf(".") + 1, (file.FileName.Length - 1) - file.FileName.LastIndexOf("."));
            model.FileName = file.FileName.Substring(0, file.FileName.LastIndexOf("."));
            FineOffice.Web.FileTypeHelper xmlHepler = new FineOffice.Web.FileTypeHelper("~/config/FileType.xml");
            model.Size = xmlHepler.ReturnFileSize(file.ContentLength);
            model.XTypeName = xmlHepler.GetFileType(model.XType);
            model.CreateTime = DateTime.Now;
            attBll.Add(model);
            responseModule.Success = true;
        }
        catch (Exception ex)
        {
            responseModule.Success = false;
            responseModule.Msg = ex.Message;
        }
        string upMessage = Newtonsoft.Json.JsonConvert.SerializeObject(responseModule);
        context.Response.Write(upMessage);
        context.Response.End();
    }
    public bool IsReusable { get { return false; } }
}