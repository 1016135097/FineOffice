using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FineOffice.Web
{
    /// <summary>
    /// author 冯胜德 2013-06-08
    /// </summary>
    public class WebPageAuthority : System.Web.UI.UserControl
    {
        /// <summary>
        /// 页面权限表
        /// </summary>
        public string PageAuthority { set; get; }

        public WebPageAuthority()
        {
        }
    }
}