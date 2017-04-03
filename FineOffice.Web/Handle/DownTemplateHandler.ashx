<%@ WebHandler Language="C#" Class="DownTemplateHandler" %>

using System;
using System.Web;
using FineOffice.Common.SerializeHelper;
using System.Collections.Generic;
using FineOffice.Common.Excel;
using System.ComponentModel;

public class DownTemplateHandler : IHttpHandler
{
    FineOffice.Web.FileTypeHelper typeHelper = new FineOffice.Web.FileTypeHelper();
    public void ProcessRequest(HttpContext context)
    {
        string path = context.Request["path"];
        string template = context.Request["template"];
        context.Response.Clear(); //清空无关信息
        context.Response.Buffer = true; //完成整个响应后再发送
        context.Response.Charset = "utf-8";//设置输出流的字符集-中文

        FineOffice.Web.WebExcelHelper excelHelper = new FineOffice.Web.WebExcelHelper();
        string serverPath = context.Server.MapPath(path);
        FineOffice.Common.Excel.ExcelHelper toExcel = new FineOffice.Common.Excel.ExcelHelper();
        List<ExcelHeader> headerList = toExcel.GetHeaderList(serverPath);

        toExcel.ApplicationName = excelHelper.ApplicationName;
        toExcel.Author = excelHelper.Author;
        toExcel.Comments = excelHelper.Comments;
        System.IO.MemoryStream ms = toExcel.Export<FineOffice.Modules.CNS_CensusMember>(new BindingList<FineOffice.Modules.CNS_CensusMember>(), template, headerList);
        byte[] output = ms.ToArray();

        context.Response.AddHeader("Content-Disposition", "attachment; filename=" + typeHelper.ToHexString(template + ".xls"));
        context.Response.AddHeader("Content-Length", output.Length.ToString());
        context.Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");//设置输出流的字符集
        context.Response.OutputStream.Write(output, 0, output.Length); //输出 

        context.Response.Flush();
        context.Response.End();
    }
    public bool IsReusable { get { return false; } }
}