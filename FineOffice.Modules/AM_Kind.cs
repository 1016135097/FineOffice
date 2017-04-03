using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules
{
    public class AM_Kind
    {
        private int _ID;
        private System.Nullable<int> _Serial;
        private string _SerialNO;
        private string _Name;
        private System.Nullable<int> _KindID;
        private string _KindName;
        private System.Nullable<int> _Relation;


        public string SerialNO
        {
            get { return _SerialNO; }
            set { _SerialNO = value; }
        }

        public System.Nullable<int> KindID
        {
            get { return _KindID; }
            set { _KindID = value; }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }       

        public System.Nullable<int> Serial
        {
            get { return _Serial; }
            set { _Serial = value; }
        }    

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }  

        public string KindName
        {
            get { return _KindName; }
            set { _KindName = value; }
        }     

        public System.Nullable<int> Relation
        {
            get { return _Relation; }
            set { _Relation = value; }
        }
    }
}
