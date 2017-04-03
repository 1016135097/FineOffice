using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules
{
    public class OA_FlowForm : FineOffice.Modules.Helper.BaseModule
    {
        private int _ID;      
        private System.Nullable<int> _FormID;
        private string _ProcessID;

        public System.Nullable<int> FormID
        {
            get { return _FormID; }
            set { _FormID = value; }
        }       

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string ProcessID
        {
            get { return _ProcessID; }
            set { _ProcessID = value; }
        }

        private System.Nullable<int> _FlowID;

        public System.Nullable<int> FlowID
        {
            get { return _FlowID; }
            set { _FlowID = value; }
        }

        private string _FormNO;

        public string FormNO
        {
            get { return _FormNO; }
            set { _FormNO = value; }
        }

        private string _FormName;

        public string FormName
        {
            get { return _FormName; }
            set { _FormName = value; }
        }

        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        private string _ProcessName;

        public string ProcessName
        {
            get { return _ProcessName; }
            set { _ProcessName = value; }
        }
    }
}
