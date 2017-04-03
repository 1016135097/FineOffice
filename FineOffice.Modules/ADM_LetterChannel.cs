using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.Modules.Helper;

namespace FineOffice.Modules
{
    public class ADM_LetterChannel : BaseModule
    {
        private int _ID;
        private string _Channel;
        private string _Remark;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string Channel
        {
            get { return _Channel; }
            set { _Channel = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
    }
}
