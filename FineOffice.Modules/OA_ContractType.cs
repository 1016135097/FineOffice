using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules
{
    [Serializable]
    public partial class OA_ContractType
    {
        public int ID { set; get; }
        public string TypeName { set; get; }
        public System.Nullable<int> Ordering {set;get; }
        public string Remark { set; get; }
    }
}
