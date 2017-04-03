using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.Modules.Helper;

namespace FineOffice.Modules
{
    [Serializable]
    public partial class OA_FlowProcess : BaseModule
    {
        private string _ID;
        private System.Nullable<bool> _AllowRefuse;
        private System.Nullable<bool> _AllowGoBack;
        private System.Nullable<int> _TimeLimit;
        private System.Nullable<int> _Remind;
        private System.Nullable<bool> _AllowSync;
        private string _ProcessRole;
        private System.Nullable<int> _FlowID;
        private string _ProcessName;
        private System.Nullable<int> _Serial;
        private System.Nullable<bool> _IsStart;
        private System.Nullable<bool> _IsEnd;
        private string _ProcessPersonnel;
        private string _MessageTo;
        private string _Next;
        private string _MailTo;
        private byte[] _Version;
        private System.Nullable<bool> _TopDefault;
        private string _Remark;
        private string _FlowName;
        private string _ProcessDepartment;
        private System.Nullable<bool> _Feedback;
        private ChangeTrackingList<FineOffice.Modules.OA_FlowForm> _OA_FlowFormList;

        public System.Nullable<bool> AllowRefuse
        {
            get
            {
                if (_AllowRefuse == null)
                    _AllowRefuse = true;
                return _AllowRefuse;
            }
            set { _AllowRefuse = value; }
        }

        public System.Nullable<bool> AllowGoBack
        {
            get
            {
                if (_AllowGoBack == null)
                    _AllowGoBack = true;
                return _AllowGoBack;
            }
            set { _AllowGoBack = value; }
        }

        public System.Nullable<int> TimeLimit
        {
            get
            {
                if (_TimeLimit == null)
                    _TimeLimit = 0;
                return _TimeLimit;
            }
            set { _TimeLimit = value; }
        }

        public System.Nullable<int> Remind
        {
            get
            {
                if (_Remind == null)
                    _Remind = 0;
                return _Remind;
            }
            set { _Remind = value; }
        }

        public ChangeTrackingList<FineOffice.Modules.OA_FlowForm> OA_FlowFormList
        {
            get { return _OA_FlowFormList; }
            set { _OA_FlowFormList = value; }
        }

        public OA_FlowProcess()
        {
            this._OA_FlowFormList = new ChangeTrackingList<OA_FlowForm>();
        }

        #region Model

        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string FlowName
        {
            get { return _FlowName; }
            set { _FlowName = value; }
        }

        public string ProcessDepartment
        {
            get { return _ProcessDepartment; }
            set { _ProcessDepartment = value; }
        }

        public string ProcessRole
        {
            get { return _ProcessRole; }
            set { _ProcessRole = value; }
        }

        public System.Nullable<int> FlowID
        {
            get { return _FlowID; }
            set { _FlowID = value; }
        }

        public string ProcessName
        {
            get { return _ProcessName; }
            set { _ProcessName = value; }
        }

        public System.Nullable<int> Serial
        {
            get { return _Serial; }
            set { _Serial = value; }
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

        public string ProcessPersonnel
        {
            get { return _ProcessPersonnel; }
            set { _ProcessPersonnel = value; }
        }

        public string Next
        {
            get { return _Next; }
            set { _Next = value; }
        }

        public System.Nullable<bool> Feedback
        {
            get
            {
                if (_Feedback == null)
                    _Feedback = true;
                return _Feedback;
            }
            set { _Feedback = value; }
        }

        public System.Nullable<bool> TopDefault
        {
            get { return _TopDefault; }
            set { _TopDefault = value; }
        }

        public string MailTo
        {
            get { return _MailTo; }
            set { _MailTo = value; }
        }

        public System.Nullable<bool> AllowSync
        {
            get { return _AllowSync; }
            set { _AllowSync = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        public string MessageTo
        {
            get { return _MessageTo; }
            set { _MessageTo = value; }
        }

        public byte[] Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        #endregion
    }
}
