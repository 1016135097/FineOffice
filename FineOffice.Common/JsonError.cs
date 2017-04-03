using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Common
{
    public class JsonError
    {
        public JsonError(string code, string msg)
        {
            ErrorCode = code;
            msg = ErrorMsg;
        }

        public string ErrorCode { get; private set; }
        public string ErrorMsg { get; private set; }
    }
}
