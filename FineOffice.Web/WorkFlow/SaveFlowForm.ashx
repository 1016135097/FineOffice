<%@ WebHandler Language="C#" Class="SaveDocument" %>

using System;
using System.Web;
using FineOffice.Common.SerializeHelper;

public class SaveDocument : IHttpHandler
{
    public FineOffice.BLL.OA_Form formBll = new FineOffice.BLL.OA_Form();
    public void ProcessRequest(HttpContext context)
    {
        string ID = context.Request.Params["ID"];
        FineOffice.Modules.OA_Form model = formBll.GetModel(f => f.ID == int.Parse(ID));
        if (context.Request.Files.Count > 0)
        {
            HttpPostedFile upPhoto = context.Request.Files[0];
            int upPhotoLength = upPhoto.ContentLength;
            byte[] photoArray = new Byte[upPhotoLength];
            System.IO.Stream PhotoStream = upPhoto.InputStream;
            //这些编码是把文件转换成二进制的文件
            PhotoStream.Read(photoArray, 0, upPhotoLength);
            FineOffice.Web.FileTypeHelper fileHelper = new FineOffice.Web.FileTypeHelper();

            model.XType = fileHelper.GetFileType(photoArray);
            model.FormData = SharpZipLib.Compress(photoArray);
            formBll.Update(model);
            context.Response.Write("succeed");
            context.Response.End();
        }
        else
        {
            context.Response.Write("No File Upload!");
            context.Response.End();
        }
    }
    public bool IsReusable { get { return false; } }
}