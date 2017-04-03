using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules
{
    [Serializable]
    public partial class SYS_Role
    {
        public SYS_Role()
        { }
        #region model
        private int _ID;
        private string _RoleName;
        private System.Nullable<bool> _Stop;
        private string _AuthorityList;
        private string _Remark;
        private string _MenuList;
        private System.Nullable<int> _Ordering;
        private System.Nullable<bool> _IsModify;

        public System.Nullable<bool> IsModify
        {
            get { return _IsModify; }
            set { _IsModify = value; }
        }

        public System.Nullable<int> Ordering
        {
            get { return _Ordering; }
            set { _Ordering = value; }
        }

        public string AuthorityList
        {
            get { return _AuthorityList; }
            set { _AuthorityList = value; }
        }

        public string MenuList
        {
            get { return _MenuList; }
            set { _MenuList = value; }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string RoleName
        {
            get { return _RoleName; }
            set { _RoleName = value; }
        }

        public System.Nullable<bool> Stop
        {
            get { return _Stop; }
            set { _Stop = value; }
        }

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        #endregion
    }
}
