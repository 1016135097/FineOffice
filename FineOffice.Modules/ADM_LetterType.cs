using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules
{
    public class ADM_LetterType
    {
        private int _ID;
        private string _Remark;
        private string _LetterType;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        } 
        public string LetterType
        {
            get { return _LetterType; }
            set { _LetterType = value; }
        }
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
    }
}
