using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules
{
    [Serializable]
    public partial class OA_Programme
    {
        public OA_Programme()
        { }
        #region model
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Subject;

        /// <summary>
        /// 标题
        /// </summary>
        public string Subject
        {
            get { return _Subject; }
            set { _Subject = value; }
        }

        private string _Location;

        /// <summary>
        /// 地点
        /// </summary>
        public string Location
        {
            get { return _Location; }
            set { _Location = value; }
        }

        private System.Nullable<int> _MasterId;

        /// <summary>
        /// 循环主日程ID
        /// </summary>
        public System.Nullable<int> MasterId
        {
            get { return _MasterId; }
            set { _MasterId = value; }
        }

        private string _Description;

        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private int _CalendarType;

        /// <summary>
        /// 日程的类型
        /// </summary>
        public int CalendarType
        {
            get { return _CalendarType; }
            set { _CalendarType = value; }
        }

        private System.DateTime _StartTime;

        /// <summary>
        /// 开始时间
        /// </summary>
        public System.DateTime StartTime
        {
            get { return _StartTime; }
            set { _StartTime = value; }
        }

        private System.DateTime _EndTime;

        /// <summary>
        /// 结束时间
        /// </summary>
        public System.DateTime EndTime
        {
            get { return _EndTime; }
            set { _EndTime = value; }
        }

        private bool _IsAllDayEvent;

        /// <summary>
        /// 是否全天日程
        /// </summary>
        public bool IsAllDayEvent
        {
            get { return _IsAllDayEvent; }
            set { _IsAllDayEvent = value; }
        }

        private bool _HasAttachment;

        /// <summary>
        /// 是否有附件
        /// </summary>
        public bool HasAttachment
        {
            get { return _HasAttachment; }
            set { _HasAttachment = value; }
        }

        private string _Category;

        /// <summary>
        /// 类别
        /// </summary>
        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }

        private int _InstanceType;

        /// <summary>
        ///  实例类型(周期类型)
        ///0	Single（一般日程）
        ///1	Master（循环主日程）
        ///2	Instance（循环实例日程）
        ///3	Exception （错误）
        ///4	MeetingRequest（会议安排）
        /// </summary>
        public int InstanceType
        {
            get { return _InstanceType; }
            set { _InstanceType = value; }
        }

        private string _Attendees;

        /// <summary>
        /// 参与人帐号或者邮件，多个
        /// </summary>
        public string Attendees
        {
            get { return _Attendees; }
            set { _Attendees = value; }
        }

        private string _AttendeeNames;

        /// <summary>
        /// 
        /// </summary>
        public string AttendeeNames
        {
            get { return _AttendeeNames; }
            set { _AttendeeNames = value; }
        }

        private string _OtherAttendee;

        /// <summary>
        /// 参与人姓名，多个
        /// </summary>
        public string OtherAttendee
        {
            get { return _OtherAttendee; }
            set { _OtherAttendee = value; }
        }

        private string _UPAccount;

        /// <summary>
        /// 其他参与人，填入邮件
        /// </summary>
        public string UPAccount
        {
            get { return _UPAccount; }
            set { _UPAccount = value; }
        }

        private string _UPName;

        /// <summary>
        /// 最后一个修改人账号
        /// </summary>
        public string UPName
        {
            get { return _UPName; }
            set { _UPName = value; }
        }

        private System.DateTime _UPTime;

        /// <summary>
        /// 最后一次修改时间
        /// </summary>
        public System.DateTime UPTime
        {
            get { return _UPTime; }
            set { _UPTime = value; }
        }

        private string _RecurringRule;

        /// <summary>
        /// 循环规则
        /// </summary>
        public string RecurringRule
        {
            get { return _RecurringRule; }
            set { _RecurringRule = value; }
        }

        private System.Nullable<int> _PersonnelID;

        /// <summary>
        /// 职员ID
        /// </summary>
        public System.Nullable<int> PersonnelID
        {
            get { return _PersonnelID; }
            set { _PersonnelID = value; }
        }

        private string _Remark;

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
