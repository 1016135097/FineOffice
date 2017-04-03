using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.Modules.Helper;

namespace FineOffice.Modules
{
    [Serializable]
    public partial class OA_Form : BaseModule
    {
        public OA_Form()
        { }
        #region model
        private int _ID;
        private System.Nullable<int> _TypeID;
        private string _FormName;
        private string _FormNO;
        private string _PinyinCode;
        private byte[] _FormData;
        private string _Remark;
        private string _XType;
        private string _FormTypeName;
        private System.Nullable<bool> _Stop;
        private System.Nullable<int> _Creator;

        public string XType
        {
            get { return _XType; }
            set { _XType = value; }
        }

        /// <summary>
        /// GUID
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public System.Nullable<bool> Stop
        {
            get { return _Stop; }
            set { _Stop = value; }
        }

        public System.Nullable<int> Creator
        {
            get { return _Creator; }
            set { _Creator = value; }
        }

        public string FormTypeName
        {
            get { return _FormTypeName; }
            set { _FormTypeName = value; }
        } 

        /// <summary>
        /// 表单类别ID
        /// </summary>
        public System.Nullable<int> TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }

        /// <summary>
        /// 编码
        /// </summary>
        public string FormNO
        {
            get { return _FormNO; }
            set { _FormNO = value; }
        }

        /// <summary>
        /// 表单名称
        /// </summary>
        public string FormName
        {
            get { return _FormName; }
            set { _FormName = value; }
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
        /// 表单内容
        /// </summary>
        public byte[] FormData
        {
            get { return _FormData; }
            set { _FormData = value; }
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
