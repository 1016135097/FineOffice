﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules
{
    public class CRM_Area : Helper.BaseModule
    {
        public int ID { set; get; }
        public System.Nullable<int> ParentID { set; get; }
        public string Area { set; get; }
        public System.Nullable<int> Ordering { set; get; }
        public string Remark { set; get; }
    }
}
