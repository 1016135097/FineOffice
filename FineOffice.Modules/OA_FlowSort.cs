using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules
{
    [Serializable]
    public partial class OA_FlowSort
    {
        public OA_FlowSort()
        { }
        #region Model
        private int _ID;
        private string _SortNO;
        private string _FlowSortName;
        private string _PinyinCode;
        private System.Nullable<int> _SerialNO;
        private System.Nullable<bool> _Stop;
        private string _Remark;

        /// <summary>
        /// GUID
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        /// <summary>
        /// 流程分类编码
        /// </summary>
        public string SortNO
        {
            get { return _SortNO; }
            set { _SortNO = value; }
        }

        /// <summary>
        /// 流程分类名称
        /// </summary>
        public string FlowSortName
        {
            get { return _FlowSortName; }
            set { _FlowSortName = value; }
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
        /// 排列序号
        /// </summary>
        public System.Nullable<int> SerialNO
        {
            get { return _SerialNO; }
            set { _SerialNO = value; }
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
