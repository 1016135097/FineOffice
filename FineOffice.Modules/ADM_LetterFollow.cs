using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.Modules.Helper;

namespace FineOffice.Modules
{
    public class ADM_LetterFollow : BaseModule
    {
        public int ID { set; get; }
        public System.Nullable<int> LetterID { set; get; }
        public string Linkman { set; get; }
        public string Mobile { set; get; }
        public string Matter { set; get; }
        public string Result { set; get; }
        public Nullable<int> Handler { set; get; }
        public Nullable<DateTime> HandleTime { set; get; }
        public string Remark { set; get; }

        public string HandlerName { set; get; }
        public string Title { set; get; }
        public string LetterNO { set; get; }
        public Nullable<int> HandleDepartmentID { set; get; }        
    }
}
