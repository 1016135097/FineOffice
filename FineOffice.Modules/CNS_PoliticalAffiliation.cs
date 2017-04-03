using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.Modules.Helper;

namespace FineOffice.Modules
{
    public class CNS_PoliticalAffiliation : BaseModule
    {
        private int _ID;
        private string _Political;
        private string _Remark;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }       

        public string Political
        {
            get { return _Political; }
            set { _Political = value; }
        }       

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
    }
}
