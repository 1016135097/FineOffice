using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules
{
    public class HD_Folder
    {
        public int ID { set; get; }
        public string FolderName { set; get; }
        public System.Nullable<bool> IsPublic { set; get; }
        public System.Nullable<int> ParentID { set; get; }
        public string Remark { set; get; }
        public System.Nullable<int> PersonnelID { set; get; }
    }
}
