using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Text.RegularExpressions;
using FineOffice.Common.Tool;
using FineOffice.Common.Excel;

namespace FineOffice.Web
{
    /// <summary>
    /// author 冯胜德 2013-05-16
    /// </summary>
    public class WebExcelHelper
    {
        public string Author { set; get; }
        public string ApplicationName { set; get; }
        public string Comments { set; get; }

        public WebExcelHelper()
        {
            XmlTextReader reader = new XmlTextReader(HttpContext.Current.Server.MapPath("~/config/ProductConfig.xml"));
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                switch (node.Attributes["key"].Value)
                {
                    case "author":
                        Author = node.Attributes["name"].Value;
                        break;
                    case "applicationName":
                        ApplicationName = node.Attributes["name"].Value;
                        break;
                    case "comments":
                        Comments = node.Attributes["name"].Value;
                        break;
                }
            }
        }
    }
}