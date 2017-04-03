using System;
using FineOffice.Modules.Helper;
namespace FineOffice.Modules
{
    /// <summary>
    /// HR_Department:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class HR_Department : BaseModule
    {
        public HR_Department()
        { }
        #region Model
        private int _id;
        private string _departmentno;
        private string _departmentname;
        private string _pinyincode;
        private bool _stop;
        private string _remark;

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 编码
        /// </summary>
        public string DepartmentNO
        {
            set { _departmentno = value; }
            get { return _departmentno; }
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string DepartmentName
        {
            set { _departmentname = value; }
            get { return _departmentname; }
        }
        /// <summary>
        /// 拼音码
        /// </summary>
        public string PinyinCode
        {
            set { _pinyincode = value; }
            get { return _pinyincode; }
        }
        /// <summary>
        /// 停用标志
        /// </summary>
        public bool Stop
        {
            set { _stop = value; }
            get { return _stop; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

