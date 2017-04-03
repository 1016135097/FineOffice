using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.Modules.Helper;

namespace FineOffice.Modules
{
    public class SYS_PageAuthority : BaseModule
    {
        private int _ID;
        private string _AuthorityName;
        private string _ControlID;
        private System.Nullable<int> _AuthorityID;
        private string _Remark;
        private byte[] _Version;
        private System.Nullable<int> _Ordering;
        private string _Text;

        public System.Nullable<int> Ordering
        {
            get { return _Ordering; }
            set { _Ordering = value; }
        }

        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }

        public byte[] Version
        {
            get { return _Version; }
            set { _Version = value; }
        }
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        public System.Nullable<int> MenuID
        {
            get { return _AuthorityID; }
            set { _AuthorityID = value; }
        }

        public string ControlID
        {
            get { return _ControlID; }
            set { _ControlID = value; }
        }

        public string AuthorityName
        {
            get { return _AuthorityName; }
            set { _AuthorityName = value; }
        }
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }         
    }
}
