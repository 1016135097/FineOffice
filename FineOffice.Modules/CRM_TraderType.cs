using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules
{
    public class CRM_TraderType : Helper.BaseModule
    {
        public int ID { set; get; }

        public string TraderType { set; get; }

        public System.Nullable<int> Ordering { set; get; }

        public string Remark { set; get; }
    }
}
