using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules
{
    [Serializable]
    public partial class OA_Attachment : Helper.BaseModule
    {
        public OA_Attachment()
        { }

        private int _ID;
        private string _FileName;
        private System.Nullable<int> _PersonnelID;
        private System.Nullable<int> _ContractID;
        private string _Remark;
        private string _ContractNO;
        private System.Nullable<int> _RunProcessID;
        private System.Nullable<int> _RunID;
        private byte[] _AttachmentData;
        private string _ProcessName;
        private string _Size;
        private string _XType;
        private string _XTypeName;
        private System.Nullable<DateTime> _CreateTime;

        private string _WorkName;
        private string _PersonnelName;
        private string _ContractName;
        public System.Nullable<DateTime> WorkCreateTime { get; set; }
        public string CreateName { get; set; }
        public System.Nullable<int> SortID { set; get; }
        public string FlowSortName { set; get; }
        public string WorkNO { set; get; }
        public System.Nullable<int> LetterFollowID { set; get; }

        public string XTypeName
        {
            get { return _XTypeName; }
            set { _XTypeName = value; }
        }

        public System.Nullable<DateTime> CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }

        public string XType
        {
            get { return _XType; }
            set { _XType = value; }
        }

        public string Size
        {
            get { return _Size; }
            set { _Size = value; }
        }

        public string ProcessName
        {
            get { return _ProcessName; }
            set { _ProcessName = value; }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public System.Nullable<int> RunID
        {
            get { return _RunID; }
            set { _RunID = value; }
        }

        public string ContractName
        {
            get { return _ContractName; }
            set { _ContractName = value; }
        }

        public string PersonnelName
        {
            get { return _PersonnelName; }
            set { _PersonnelName = value; }
        }

        public string WorkName
        {
            get { return _WorkName; }
            set { _WorkName = value; }
        }

        public string ContractNO
        {
            get { return _ContractNO; }
            set { _ContractNO = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        public System.Nullable<int> ContractID
        {
            get { return _ContractID; }
            set { _ContractID = value; }
        }

        public System.Nullable<int> PersonnelID
        {
            get { return _PersonnelID; }
            set { _PersonnelID = value; }
        }

        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        public byte[] AttachmentData
        {
            get { return _AttachmentData; }
            set { _AttachmentData = value; }
        }

        public System.Nullable<int> RunProcessID
        {
            get { return _RunProcessID; }
            set { _RunProcessID = value; }
        }
    }
}
