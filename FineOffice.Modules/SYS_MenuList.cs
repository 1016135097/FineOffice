using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules
{
    [Serializable]
    public partial class SYS_MenuList
    {
        public SYS_MenuList()
        {
            this._PageAuthorityList = new List<SYS_PageAuthority>();
        }
        public int ID { set; get; }
        public string Text { set; get; }
        public string TabID { set; get; }
        public string NavigateUrl { set; get; }
        public System.Nullable<int> ParentID { set; get; }
        public string Icon { set; get; }
        public System.Nullable<bool> IsModule { set; get; }
        public System.Nullable<bool> IsFuntion { set; get; }
        public System.Nullable<int> Ordering { set; get; }
        public string Remark { set; get; }
        public System.Nullable<int> TreeLevel { set; get; }
        private System.Nullable<bool> _Stop;
        private System.Nullable<bool> _SingleClickExpand;
        private byte[] _Version;
        private List<Modules.SYS_PageAuthority> _PageAuthorityList;

        public List<Modules.SYS_PageAuthority> PageAuthorityList 
        {
            get { return _PageAuthorityList; }
            set { _PageAuthorityList = value; }
        }

        public byte[] Version
        {
            get { return _Version; }
            set { _Version = value; }
        }

        public System.Nullable<bool> Stop
        {
            get { return _Stop; }
            set { _Stop = value; }
        }

        public System.Nullable<bool> SingleClickExpand
        {
            get { return _SingleClickExpand; }
            set { _SingleClickExpand = value; }
        }

    }
}
