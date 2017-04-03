using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.Modules.Helper;

namespace FineOffice.Modules
{
    public class CNS_CensusType : BaseModule
    {
        private int _ID;
        private string _Remark;
        private string _CensusTypeName;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }       

        public string CensusTypeName
        {
            get { return _CensusTypeName; }
            set { _CensusTypeName = value; }
        }      

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
    }
}
