using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.Modules.Helper;

namespace FineOffice.Modules
{
    public class ADM_Letter : BaseModule
    {
        public int ID { set; get; }
        public System.Nullable<int> Receiver { set; get; }
        public System.Nullable<int> ChannelID { set; get; }
        public System.Nullable<int> TypeID { set; get; }
        public string Visitor { set; get; }
        public System.Nullable<short> Sex { set; get; }
        public System.Nullable<int> Age { set; get; }
        public string Mobile { set; get; }
        public string Email { set; get; }
        public string Tel { set; get; }
        public string Occupation { set; get; }
        public string Address { set; get; }
        public string LetterNO { set; get; }
        public string Title { set; get; }
        public System.Nullable<int> NumberOfpeople { set; get; }
        public string Area { set; get; }
        public string Matter { set; get; }
        public System.Nullable<System.DateTime> VisitTime { set; get; }
        public System.Nullable<int> Handler { set; get; }
        public System.Nullable<int> Recorder { set; get; }
        public System.Nullable<short> State { set; get; }
        public string Remark { set; get; }
        public string Channel { set; get; }
        public string LetterType { set; get; }
        public string IDCard { set; get; }
        public System.Nullable<System.DateTime> RecordTime { set; get; }

        public string Gender { set; get; }
        public string HandlerName { set; get; }
        public string HandleDepartment { set; get; }
        public System.Nullable<int> HandleDepartmentID { set; get; }

        public string RecorderName { set; get; }
        public string ReceiverName { set; get; }
        public string ReceiveDepartment { set; get; }
        public System.Nullable<int> ReceiveDepartmentID { set; get; }
    }
}
