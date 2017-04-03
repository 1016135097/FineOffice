using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules
{
    [Serializable]
    public partial class OA_FormType
    {
        public OA_FormType()
        { }
        #region model
        private int _ID;

        private string _TypeNO;

        private string _FormTypeName;

        private string _PinyinCode;

        private System.Nullable<bool> _Stop;

        private string _Remark;

        private System.Nullable<int> _Creator;        

        /// <summary>
        /// GUID
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public System.Nullable<int> Creator
        {
            get { return _Creator; }
            set { _Creator = value; }
        }

        /// <summary>
        /// 表单类别编码
        /// </summary>
        public string TypeNO
        {
            get { return _TypeNO; }
            set { _TypeNO = value; }
        }

        /// <summary>
        /// 表单类别名称
        /// </summary>
        public string FormTypeName
        {
            get { return _FormTypeName; }
            set { _FormTypeName = value; }
        }

        /// <summary>
        /// 拼音码
        /// </summary>
        public string PinyinCode
        {
            get { return _PinyinCode; }
            set { _PinyinCode = value; }
        }

        /// <summary>
        /// 停用标志
        /// </summary>
        public System.Nullable<bool> Stop
        {
            get { return _Stop; }
            set { _Stop = value; }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
        #endregion
    }
}
