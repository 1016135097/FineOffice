using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FineOffice.Web
{
    /// <summary>
    ///服务器响模型
    /// </summary>
    public class ResponseModule
    {
        private bool _Success;
        private string _Msg;

        /// <summary>
        /// 错误信息
        /// </summary>
        public string Msg
        {
            get { return _Msg; }
            set { _Msg = value; }
        }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success
        {
            get { return _Success; }
            set { _Success = value; }
        }
    }
}