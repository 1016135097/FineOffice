using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules
{
    [Serializable]
    public partial class OA_Contract
    {
        public int ID { set; get; }
        public string ContractNO { set; get; }
        public string ContractName { set; get; }
        public System.Nullable<int> TraderID { set; get; }
        public System.Nullable<int> TypeID { set; get; }
        public System.Nullable<System.DateTime> SingnDate { set; get; }
        public System.Nullable<System.DateTime> EndDate { set; get; }
        public System.Nullable<int> Handler { set; get; }
        public string Content { set; get; }
        public string Location { set; get; }
        public string Remark { set; get; }

        public string TypeName { set; get; }
        public string TraderName { set; get; }
        public string TraderNO { set; get; }
        public string HandlerName { set; get; }

        public System.Nullable<int> Expire { set; get; }
    }
}
