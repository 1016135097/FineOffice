using System;
using FineOffice.Modules.Helper;
namespace FineOffice.Modules
{
    /// <summary>
    /// HR_Personnel:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class HR_Personnel : BaseModule
    {
        public HR_Personnel()
        { }
        #region Model
        private int _id;
        private string _personnelno;
        private int? _jobid;
        private string _job;
        private string _sexName;
        private int? _typeid;
        private string _personnelType;
        private int? _departmentid;
        private string _departmentName;
        private string _name;
        private string _pinyincode;
        private DateTime? _dateofbirth;
        private short? _sex;
        private string _nativeplace;
        private string _education;
        private DateTime? _entrydate;
        private DateTime? _exitdate;
        private bool? _stop;
        private string _bankingaccount;
        private string _hometelephone;
        private string _linkman;
        private string _mobile;
        private string _email;
        private string _address;
        private string _post;
        private string _remark;
        private int? _EducationID;
       
        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }

        public int? EducationID
        {
            get { return _EducationID; }
            set { _EducationID = value; }
        } 

        public string Gender
        {
            get { return _sexName; }
            set { _sexName = value; }
        }

        public string Job
        {
            get { return _job; }
            set { _job = value; }
        }
        public string PersonnelType
        {
            get { return _personnelType; }
            set { _personnelType = value; }
        }
        public string DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }

        /// <summary>
        /// 编码
        /// </summary>
        public string PersonnelNO
        {
            set { _personnelno = value; }
            get { return _personnelno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? JobID
        {
            set { _jobid = value; }
            get { return _jobid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DepartmentID
        {
            set { _departmentid = value; }
            get { return _departmentid; }
        }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
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
        /// 出生日期
        /// </summary>
        public DateTime? DateOfBirth
        {
            set { _dateofbirth = value; }
            get { return _dateofbirth; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public short? Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 籍贯
        /// </summary>
        public string NativePlace
        {
            set { _nativeplace = value; }
            get { return _nativeplace; }
        }
        /// <summary>
        /// 学历
        /// </summary>
        public string Education
        {
            set { _education = value; }
            get { return _education; }
        }
        /// <summary>
        /// 入职日期
        /// </summary>
        public DateTime? EntryDate
        {
            set { _entrydate = value; }
            get { return _entrydate; }
        }
        /// <summary>
        /// 离职日期
        /// </summary>
        public DateTime? ExitDate
        {
            set { _exitdate = value; }
            get { return _exitdate; }
        }
        /// <summary>
        /// 离职标志
        /// </summary>
        public bool? Stop
        {
            set { _stop = value; }
            get { return _stop; }
        }
        /// <summary>
        /// 银行账号
        /// </summary>
        public string BankingAccount
        {
            set { _bankingaccount = value; }
            get { return _bankingaccount; }
        }
        /// <summary>
        /// 家庭电话
        /// </summary>
        public string HomeTelephone
        {
            set { _hometelephone = value; }
            get { return _hometelephone; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Linkman
        {
            set { _linkman = value; }
            get { return _linkman; }
        }
        /// <summary>
        /// 移动电话
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 邮编
        /// </summary>
        public string Post
        {
            set { _post = value; }
            get { return _post; }
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

