using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules
{
    public class HD_Attachment : Helper.BaseModule
    {
        private int _ID;
        private System.Nullable<int> _PersonnelID;
        private string _FileName;
        private string _XType;
        private string _XTypeName;
        private byte[] _AttachmentData;
        private string _Size;
        private System.Nullable<int> _FolderID;
        private System.Nullable<System.DateTime> _CreateTime;
        private string _Remark;
        private System.Nullable<int> _Owner;
        private System.Nullable<bool> _IsPublic;
        private System.Nullable<int> _SendID;
        private string _SendName;
        private System.Nullable<DateTime> _SendTime;

        public System.Nullable<DateTime> SendTime
        {
            get { return _SendTime; }
            set { _SendTime = value; }
        }

        public string SendName
        {
            get { return _SendName; }
            set { _SendName = value; }
        }


        public System.Nullable<int> SendID
        {
            get { return _SendID; }
            set { _SendID = value; }
        } 

        public System.Nullable<int> Owner
        {
            get { return _Owner; }
            set { _Owner = value; }
        }

        public System.Nullable<bool> IsPublic
        {
            get { return _IsPublic; }
            set { _IsPublic = value; }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
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

        public string XType
        {
            get { return _XType; }
            set { _XType = value; }
        }

        public string XTypeName
        {
            get { return _XTypeName; }
            set { _XTypeName = value; }
        }

        public byte[] AttachmentData
        {
            get { return _AttachmentData; }
            set { _AttachmentData = value; }
        }

        public string Size
        {
            get { return _Size; }
            set { _Size = value; }
        }

        public System.Nullable<int> FolderID
        {
            get { return _FolderID; }
            set { _FolderID = value; }
        }

        public System.Nullable<System.DateTime> CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }

        public string FolderName { set; get; }
        public string PersonnelName { set; get; }
    }
}
