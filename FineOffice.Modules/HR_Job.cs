using System;
namespace FineOffice.Modules
{
    /// <summary>
    /// HR_Job:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class HR_Job : Helper.BaseModule
    {
        public HR_Job()
        { }
        #region Model
        private int _id;
        private string _jobno;
        private string _job;
        private string _pinyincode;
        private System.Nullable<bool> _stop;
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
        public string JobNO
        {
            set { _jobno = value; }
            get { return _jobno; }
        }
        /// <summary>
        /// 职位
        /// </summary>
        public string Job
        {
            set { _job = value; }
            get { return _job; }
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
        public System.Nullable<bool> Stop
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

