using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.Modules.Helper;

namespace FineOffice.Modules
{
    [Serializable]
    public partial class OA_Flow : Modules.Helper.BaseModule
    {
        public OA_Flow()
        {
            this._OA_FlowProcessList = new ChangeTrackingList<OA_FlowProcess>();
            this._OA_FlowAuthorityList = new ChangeTrackingList<OA_FlowAuthority>();
        }
        private int _ID;
        private string _FlowNO;
        private string _FlowName;
        private string _PinyinCode;
        private System.Nullable<int> _SortID;
        private System.Nullable<bool> _AllowAttachment;
        private System.Nullable<bool> _IsFreedom;
        private System.Nullable<bool> _Stop;
        private System.Nullable<int> _Creator;
        private string _FlowDesc;
        private string _Remark;
        private System.Nullable<System.DateTime> _CreateDate;
        private string _Version;
        private string _FlowSortName;
        private string _FlowUserName;
        private string _XML;
        private System.Nullable<bool> _AllowRecall;
        private System.Nullable<bool> _AllowRevoke;
        private System.Nullable<int> _FormID;

        public System.Nullable<int> FormID
        {
            get { return _FormID; }
            set { _FormID = value; }
        }

        public System.Nullable<bool> AllowRevoke
        {
            get { return _AllowRevoke; }
            set { _AllowRevoke = value; }
        }

        public System.Nullable<bool> AllowRecall
        {
            get { return _AllowRecall; }
            set { _AllowRecall = value; }
        }       

        private ChangeTrackingList<FineOffice.Modules.OA_FlowAuthority> _OA_FlowAuthorityList;

        public ChangeTrackingList<FineOffice.Modules.OA_FlowAuthority> OA_FlowAuthorityList
        {
            get { return _OA_FlowAuthorityList; }
            set { _OA_FlowAuthorityList = value; }
        }
        private ChangeTrackingList<FineOffice.Modules.OA_FlowProcess> _OA_FlowProcessList;


        public ChangeTrackingList<FineOffice.Modules.OA_FlowProcess> OA_FlowProcessList
        {
            get { return _OA_FlowProcessList; }
            set { _OA_FlowProcessList = value; }
        }

        public string XML
        {
            get { return _XML; }
            set { _XML = value; }
        }

        public string FlowUserName
        {
            get { return _FlowUserName; }
            set { _FlowUserName = value; }
        }

        public string Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        public string FlowSortName
        {
            get { return _FlowSortName; }
            set { _FlowSortName = value; }
        }

        public System.Nullable<System.DateTime> CreateDate
        {
            get { return _CreateDate; }
            set { _CreateDate = value; }
        }

        public string FlowDesc
        {
            get { return _FlowDesc; }
            set { _FlowDesc = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        public System.Nullable<int> Creator
        {
            get { return _Creator; }
            set { _Creator = value; }
        }

        public System.Nullable<bool> Stop
        {
            get { return _Stop; }
            set { _Stop = value; }
        }

        public System.Nullable<bool> IsFreedom
        {
            get { return _IsFreedom; }
            set { _IsFreedom = value; }
        }

        public System.Nullable<bool> AllowAttachment
        {
            get { return _AllowAttachment; }
            set { _AllowAttachment = value; }
        }

        public System.Nullable<int> SortID
        {
            get { return _SortID; }
            set { _SortID = value; }
        }

        public string PinyinCode
        {
            get { return _PinyinCode; }
            set { _PinyinCode = value; }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string FlowName
        {
            get { return _FlowName; }
            set { _FlowName = value; }
        }

        public string FlowNO
        {
            get { return _FlowNO; }
            set { _FlowNO = value; }
        }
    }
}
