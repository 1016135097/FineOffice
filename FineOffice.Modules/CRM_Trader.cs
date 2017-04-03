using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules
{
    /// <summary>
    /// 往来单位
    /// </summary>
    public class CRM_Trader : Modules.Helper.BaseModule
    {
        public int ID { set; get; }
        public System.Nullable<int> TypeID { set; get; }
        public System.Nullable<int> IndustryID { set; get; }
        public System.Nullable<int> AreaID { set; get; }
        public System.Nullable<int> SourceID { set; get; }
        public System.Nullable<int> GradeID { set; get; }
        public System.Nullable<int> Handler { set; get; }
        public System.Nullable<bool> IsSupplier { set; get; }
        public System.Nullable<bool> IsClient { set; get; }
        public string TraderNO { set; get; }
        public string TraderName { set; get; }
        public string ShortName { set; get; }
        public string PinyinCode { set; get; }
        public string Incorporator { set; get; }
        public System.Nullable<int> NumberOfPeople { set; get; }
        public string Tel { set; get; }
        public string Fax { set; get; }
        public string WebSite { set; get; }
        public string Email { set; get; }
        public string Post { set; get; }
        public string Address { set; get; }
        public string Linkman { set; get; }
        public string Mobile { set; get; }
        public System.Nullable<bool> Stop { set; get; }
        public string Remark { set; get; }
        public System.Nullable<DateTime> CreateTime { set; get; }

        public string Area { set; get; }
        public string Grade { set; get; }
        public string Industry { set; get; }
        public string TraderType { set; get; }
        public string HandlerName { set; get; }
        public string Source { set; get; }   
    }
}
