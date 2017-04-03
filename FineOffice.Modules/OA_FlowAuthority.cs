using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.Modules.Helper;

namespace FineOffice.Modules
{
    public class OA_FlowAuthority: BaseModule
    {
        private int _ID;
        private System.Nullable<int> _FlowID;
        private System.Nullable<int> _DepartmentID;
        private System.Nullable<int> _PersonnelID;
        private string _DepartmentName;
        private string _PersonnelName;

        public string PersonnelName
        {
            get { return _PersonnelName; }
            set { _PersonnelName = value; }
        }

        public string DepartmentName
        {
            get { return _DepartmentName; }
            set { _DepartmentName = value; }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }      

        public System.Nullable<int> FlowID
        {
            get { return _FlowID; }
            set { _FlowID = value; }
        }

        public System.Nullable<int> DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
        }       

        public System.Nullable<int> PersonnelID
        {
            get { return _PersonnelID; }
            set { _PersonnelID = value; }
        }
    }
}
