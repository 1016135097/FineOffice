using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.Modules.Helper;

namespace FineOffice.Modules
{
    [Serializable]
    public partial class OA_FlowRunProcess : Modules.Helper.BaseModule
    {
        private int _ID;
        private System.Nullable<int> _RunID;
        private string _ProcessID;
        private System.Nullable<int> _SendID;
        private System.Nullable<int> _AcceptID;
        private System.Nullable<System.DateTime> _AcceptTime;
        private System.Nullable<System.DateTime> _HandleTime;
        private System.Nullable<int> _PreviousID;
        private System.Nullable<short> _Pattern;
        private System.Nullable<short> _State;
        private System.Nullable<int> _TransmitFrom;
        private string _TransmitAdvice;
        private byte[] _Version;
        private string _Remark;

        private System.Nullable<bool> _IsEnd;
        private System.Nullable<bool> _IsStart;
        public string CreateName { set; get; }
        public string WorkName { set; get; }
        public string WorkNO { set; get; }
        public string Next { set; get; }
        public string ProcessName { set; get; }
        public string FlowSortName { set; get; }
        public System.Nullable<bool> IsEntrance { set; get; }
        public System.Nullable<System.DateTime> WorkCreateTime { set; get; }
        public string AcceptName { set; get; }
        public string HandleEvent { set; get; }
        public string TransmitTo { set; get; }
        public string PatternName { set; get; }

        public System.Nullable<int> TransmitFrom
        {
            get { return _TransmitFrom; }
            set { _TransmitFrom = value; }
        }

        public System.Nullable<bool> IsStart
        {
            get { return _IsStart; }
            set { _IsStart = value; }
        }

        public System.Nullable<bool> IsEnd
        {
            get { return _IsEnd; }
            set { _IsEnd = value; }
        }

        public System.Nullable<int> SendID
        {
            get { return _SendID; }
            set { _SendID = value; }
        }

        public System.Nullable<short> Pattern
        {
            get { return _Pattern; }
            set { _Pattern = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        public byte[] Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        public string TransmitAdvice
        {
            get { return _TransmitAdvice; }
            set { _TransmitAdvice = value; }
        }

        public System.Nullable<short> State
        {
            get { return _State; }
            set { _State = value; }
        }

        public System.Nullable<int> PreviousID
        {
            get { return _PreviousID; }
            set { _PreviousID = value; }
        }

        public System.Nullable<System.DateTime> HandleTime
        {
            get { return _HandleTime; }
            set { _HandleTime = value; }
        }

        public System.Nullable<System.DateTime> AcceptTime
        {
            get { return _AcceptTime; }
            set { _AcceptTime = value; }
        }

        public System.Nullable<int> AcceptID
        {
            get { return _AcceptID; }
            set { _AcceptID = value; }
        }

        public string ProcessID
        {
            get { return _ProcessID; }
            set { _ProcessID = value; }
        }

        public System.Nullable<int> RunID
        {
            get { return _RunID; }
            set { _RunID = value; }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
    }
}
