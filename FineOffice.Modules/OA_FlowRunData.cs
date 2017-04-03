using System;
using System.Collections.Generic;
using System.Text;

namespace FineOffice.Modules
{
    public class OA_FlowRunData
    {
        private int _ID;
        private System.Nullable<int> _FormID;

        private System.Nullable<int> _RunProcessID;
        private byte[] _FormData;
        private string _Remark;
        private string _FormName;
        private System.Nullable<int> _RunID;
        private System.Nullable<System.DateTime> _UpdateTime;
        private System.Nullable<System.DateTime> _CreateTime;
        private string _Title;
        private string _PersonnelName;
        private string _ProcessName;
        private string _XType;

        public System.DateTime? WorkCreateTime { set; get; }
        public string WorkNO { set; get; }
        public string WorkName { set; get; }
        public string CreateName { set; get; }
        public string FlowSortName { set; get; }
        public System.Nullable<int> SortID;

        public string XType
        {
            get { return _XType; }
            set { _XType = value; }
        }

        public string ProcessName
        {
            get { return _ProcessName; }
            set { _ProcessName = value; }
        }

        public string PersonnelName
        {
            get { return _PersonnelName; }
            set { _PersonnelName = value; }
        }

        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        public System.Nullable<int> RunID
        {
            get { return _RunID; }
            set { _RunID = value; }
        }

        public System.Nullable<System.DateTime> UpdateTime
        {
            get { return _UpdateTime; }
            set { _UpdateTime = value; }
        }

        public System.Nullable<System.DateTime> CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }

        public string FormName
        {
            get { return _FormName; }
            set { _FormName = value; }
        }

        public System.Nullable<int> RunProcessID
        {
            get { return _RunProcessID; }
            set { _RunProcessID = value; }
        }

        public System.Nullable<int> FormID
        {
            get { return _FormID; }
            set { _FormID = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public byte[] FormData
        {
            get { return _FormData; }
            set { _FormData = value; }
        }
    }
}
