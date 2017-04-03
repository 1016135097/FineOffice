using System;
namespace FineOffice.Modules
{
    /// <summary>
    /// 设置能查看那些分公司权限
    /// </summary>
    [Serializable]
    public partial class SYS_User
    {
        public int ID { set; get; }
        public System.Nullable<int> PersonnelID { set; get; }
        public string UserName { set; get; }
        public System.Nullable<System.DateTime> CreateDate { set; get; }
        public string Password { set; get; }
        public string RoleList { set; get; }
        public string CheckAuthority { set; get; }
        public System.Nullable<bool> Stop { set; get; }
        public System.Nullable<bool> IsModify { set; get; }
        public string Remark { set; get; }
        public string PersonnelNO { set; get; }
        public string PersonnelName { set; get; }
        public System.Nullable<int> DepartmentID { set; get; } 
        public string DepartmentName{set;get;}
    }
}

