using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.Modules.Helper;

namespace FineOffice.Modules
{
    public class CNS_CensusRelation : BaseModule
    {
        private int _ID; 
        private string _Relation;
        private string _Remark;

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        public string Relation
        {
            get { return _Relation; }
            set { _Relation = value; }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }  
    }
}
