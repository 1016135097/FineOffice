<%@ WebHandler Language="C#" Class="UploadFileHandler" %>

using System;
using System.Web;
using FineOffice.Common.SerializeHelper;

public class UploadFileHandler : IHttpHandler
{
    public FineOffice.BLL.HD_Attachment attachmentBll = new FineOffice.BLL.HD_Attachment();

    public void ProcessRequest(HttpContext context)
    {
        FineOffice.Web.ResponseModule responseModule = new FineOffice.Web.ResponseModule();
        try
        {
            FineOffice.Modules.HD_Attachment model = new FineOffice.Modules.HD_Attachment();

            model.PersonnelID = int.Parse(context.Request["personnelid"]);
            model.Owner = model.PersonnelID;
            if (context.Request["ispublic"] == "true")
            {
                model.IsPublic = true;
                model.Owner = null;
            }

            if (context.Request["folderid"] != null && context.Request["folderid"].Length > 0)
                model.FolderID = int.Parse(context.Request["folderid"]);

            HttpPostedFile file = context.Request.Files["filedata"];
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
            attachmentBll.Add(model);
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