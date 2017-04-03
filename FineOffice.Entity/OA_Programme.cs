using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.OA_Programme")]
    public partial class OA_Programme : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _Subject;

        private string _Location;

        private System.Nullable<int> _MasterID;

        private string _Description;

        private int _CalendarType;

        private System.DateTime _StartTime;

        private System.DateTime _EndTime;

        private bool _IsAllDayEvent;

        private bool _HasAttachment;

        private string _Category;

        private int _InstanceType;

        private string _Attendees;

        private string _AttendeeNames;

        private string _OtherAttendee;

        private string _UPAccount;

        private string _UPName;

        private System.DateTime _UPTime;

        private string _RecurringRule;

        private System.Nullable<int> _PersonnelID;

        private string _Remark;

        private EntityRef<HR_Personnel> _HR_Personnel;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnSubjectChanging(string value);
        partial void OnSubjectChanged();
        partial void OnLocationChanging(string value);
        partial void OnLocationChanged();
        partial void OnMasterIDChanging(System.Nullable<int> value);
        partial void OnMasterIDChanged();
        partial void OnDescriptionChanging(string value);
        partial void OnDescriptionChanged();
        partial void OnCalendarTypeChanging(int value);
        partial void OnCalendarTypeChanged();
        partial void OnStartTimeChanging(System.DateTime value);
        partial void OnStartTimeChanged();
        partial void OnEndTimeChanging(System.DateTime value);
        partial void OnEndTimeChanged();
        partial void OnIsAllDayEventChanging(bool value);
        partial void OnIsAllDayEventChanged();
        partial void OnHasAttachmentChanging(bool value);
        partial void OnHasAttachmentChanged();
        partial void OnCategoryChanging(string value);
        partial void OnCategoryChanged();
        partial void OnInstanceTypeChanging(int value);
        partial void OnInstanceTypeChanged();
        partial void OnAttendeesChanging(string value);
        partial void OnAttendeesChanged();
        partial void OnAttendeeNamesChanging(string value);
        partial void OnAttendeeNamesChanged();
        partial void OnOtherAttendeeChanging(string value);
        partial void OnOtherAttendeeChanged();
        partial void OnUPAccountChanging(string value);
        partial void OnUPAccountChanged();
        partial void OnUPNameChanging(string value);
        partial void OnUPNameChanged();
        partial void OnUPTimeChanging(System.DateTime value);
        partial void OnUPTimeChanged();
        partial void OnRecurringRuleChanging(string value);
        partial void OnRecurringRuleChanged();
        partial void OnPersonnelIDChanging(System.Nullable<int> value);
        partial void OnPersonnelIDChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public OA_Programme()
        {
            this._HR_Personnel = default(EntityRef<HR_Personnel>);
            OnCreated();
        }

        [Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID
        {
            get
            {
                return this._ID;
            }
            set
            {
                if ((this._ID != value))
                {
                    this.OnIDChanging(value);
                    this.SendPropertyChanging();
                    this._ID = value;
                    this.SendPropertyChanged("ID");
                    this.OnIDChanged();
                }
            }
        }

        [Column(Storage = "_Subject", DbType = "NVarChar(1000)")]
        public string Subject
        {
            get
            {
                return this._Subject;
            }
            set
            {
                if ((this._Subject != value))
                {
                    this.OnSubjectChanging(value);
                    this.SendPropertyChanging();
                    this._Subject = value;
                    this.SendPropertyChanged("Subject");
                    this.OnSubjectChanged();
                }
            }
        }

        [Column(Storage = "_Location", DbType = "NVarChar(200)")]
        public string Location
        {
            get
            {
                return this._Location;
            }
            set
            {
                if ((this._Location != value))
                {
                    this.OnLocationChanging(value);
                    this.SendPropertyChanging();
                    this._Location = value;
                    this.SendPropertyChanged("Location");
                    this.OnLocationChanged();
                }
            }
        }

        [Column(Storage = "_MasterID", DbType = "Int")]
        public System.Nullable<int> MasterID
        {
            get
            {
                return this._MasterID;
            }
            set
            {
                if ((this._MasterID != value))
                {
                    this.OnMasterIDChanging(value);
                    this.SendPropertyChanging();
                    this._MasterID = value;
                    this.SendPropertyChanged("MasterID");
                    this.OnMasterIDChanged();
                }
            }
        }

        [Column(Storage = "_Description", DbType = "NVarChar(255)")]
        public string Description
        {
            get
            {
                return this._Description;
            }
            set
            {
                if ((this._Description != value))
                {
                    this.OnDescriptionChanging(value);
                    this.SendPropertyChanging();
                    this._Description = value;
                    this.SendPropertyChanged("Description");
                    this.OnDescriptionChanged();
                }
            }
        }

        [Column(Storage = "_CalendarType", DbType = "Int NOT NULL")]
        public int CalendarType
        {
            get
            {
                return this._CalendarType;
            }
            set
            {
                if ((this._CalendarType != value))
                {
                    this.OnCalendarTypeChanging(value);
                    this.SendPropertyChanging();
                    this._CalendarType = value;
                    this.SendPropertyChanged("CalendarType");
                    this.OnCalendarTypeChanged();
                }
            }
        }

        [Column(Storage = "_StartTime", DbType = "DateTime NOT NULL")]
        public System.DateTime StartTime
        {
            get
            {
                return this._StartTime;
            }
            set
            {
                if ((this._StartTime != value))
                {
                    this.OnStartTimeChanging(value);
                    this.SendPropertyChanging();
                    this._StartTime = value;
                    this.SendPropertyChanged("StartTime");
                    this.OnStartTimeChanged();
                }
            }
        }

        [Column(Storage = "_EndTime", DbType = "DateTime NOT NULL")]
        public System.DateTime EndTime
        {
            get
            {
                return this._EndTime;
            }
            set
            {
                if ((this._EndTime != value))
                {
                    this.OnEndTimeChanging(value);
                    this.SendPropertyChanging();
                    this._EndTime = value;
                    this.SendPropertyChanged("EndTime");
                    this.OnEndTimeChanged();
                }
            }
        }

        [Column(Storage = "_IsAllDayEvent", DbType = "Bit NOT NULL")]
        public bool IsAllDayEvent
        {
            get
            {
                return this._IsAllDayEvent;
            }
            set
            {
                if ((this._IsAllDayEvent != value))
                {
                    this.OnIsAllDayEventChanging(value);
                    this.SendPropertyChanging();
                    this._IsAllDayEvent = value;
                    this.SendPropertyChanged("IsAllDayEvent");
                    this.OnIsAllDayEventChanged();
                }
            }
        }

        [Column(Storage = "_HasAttachment", DbType = "Bit NOT NULL")]
        public bool HasAttachment
        {
            get
            {
                return this._HasAttachment;
            }
            set
            {
                if ((this._HasAttachment != value))
                {
                    this.OnHasAttachmentChanging(value);
                    this.SendPropertyChanging();
                    this._HasAttachment = value;
                    this.SendPropertyChanged("HasAttachment");
                    this.OnHasAttachmentChanged();
                }
            }
        }

        [Column(Storage = "_Category", DbType = "NVarChar(200)")]
        public string Category
        {
            get
            {
                return this._Category;
            }
            set
            {
                if ((this._Category != value))
                {
                    this.OnCategoryChanging(value);
                    this.SendPropertyChanging();
                    this._Category = value;
                    this.SendPropertyChanged("Category");
                    this.OnCategoryChanged();
                }
            }
        }

        [Column(Storage = "_InstanceType", DbType = "Int NOT NULL")]
        public int InstanceType
        {
            get
            {
                return this._InstanceType;
            }
            set
            {
                if ((this._InstanceType != value))
                {
                    this.OnInstanceTypeChanging(value);
                    this.SendPropertyChanging();
                    this._InstanceType = value;
                    this.SendPropertyChanged("InstanceType");
                    this.OnInstanceTypeChanged();
                }
            }
        }

        [Column(Storage = "_Attendees", DbType = "NVarChar(255)")]
        public string Attendees
        {
            get
            {
                return this._Attendees;
            }
            set
            {
                if ((this._Attendees != value))
                {
                    this.OnAttendeesChanging(value);
                    this.SendPropertyChanging();
                    this._Attendees = value;
                    this.SendPropertyChanged("Attendees");
                    this.OnAttendeesChanged();
                }
            }
        }

        [Column(Storage = "_AttendeeNames", DbType = "NVarChar(255)")]
        public string AttendeeNames
        {
            get
            {
                return this._AttendeeNames;
            }
            set
            {
                if ((this._AttendeeNames != value))
                {
                    this.OnAttendeeNamesChanging(value);
                    this.SendPropertyChanging();
                    this._AttendeeNames = value;
                    this.SendPropertyChanged("AttendeeNames");
                    this.OnAttendeeNamesChanged();
                }
            }
        }

        [Column(Storage = "_OtherAttendee", DbType = "NVarChar(255)")]
        public string OtherAttendee
        {
            get
            {
                return this._OtherAttendee;
            }
            set
            {
                if ((this._OtherAttendee != value))
                {
                    this.OnOtherAttendeeChanging(value);
                    this.SendPropertyChanging();
                    this._OtherAttendee = value;
                    this.SendPropertyChanged("OtherAttendee");
                    this.OnOtherAttendeeChanged();
                }
            }
        }

        [Column(Storage = "_UPAccount", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string UPAccount
        {
            get
            {
                return this._UPAccount;
            }
            set
            {
                if ((this._UPAccount != value))
                {
                    this.OnUPAccountChanging(value);
                    this.SendPropertyChanging();
                    this._UPAccount = value;
                    this.SendPropertyChanged("UPAccount");
                    this.OnUPAccountChanged();
                }
            }
        }

        [Column(Storage = "_UPName", DbType = "NVarChar(50) NOT NULL", CanBeNull = false)]
        public string UPName
        {
            get
            {
                return this._UPName;
            }
            set
            {
                if ((this._UPName != value))
                {
                    this.OnUPNameChanging(value);
                    this.SendPropertyChanging();
                    this._UPName = value;
                    this.SendPropertyChanged("UPName");
                    this.OnUPNameChanged();
                }
            }
        }

        [Column(Storage = "_UPTime", DbType = "DateTime NOT NULL")]
        public System.DateTime UPTime
        {
            get
            {
                return this._UPTime;
            }
            set
            {
                if ((this._UPTime != value))
                {
                    this.OnUPTimeChanging(value);
                    this.SendPropertyChanging();
                    this._UPTime = value;
                    this.SendPropertyChanged("UPTime");
                    this.OnUPTimeChanged();
                }
            }
        }

        [Column(Storage = "_RecurringRule", DbType = "NVarChar(500)")]
        public string RecurringRule
        {
            get
            {
                return this._RecurringRule;
            }
            set
            {
                if ((this._RecurringRule != value))
                {
                    this.OnRecurringRuleChanging(value);
                    this.SendPropertyChanging();
                    this._RecurringRule = value;
                    this.SendPropertyChanged("RecurringRule");
                    this.OnRecurringRuleChanged();
                }
            }
        }

        [Column(Storage = "_PersonnelID", DbType = "Int")]
        public System.Nullable<int> PersonnelID
        {
            get
            {
                return this._PersonnelID;
            }
            set
            {
                if ((this._PersonnelID != value))
                {
                    if (this._HR_Personnel.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnPersonnelIDChanging(value);
                    this.SendPropertyChanging();
                    this._PersonnelID = value;
                    this.SendPropertyChanged("PersonnelID");
                    this.OnPersonnelIDChanged();
                }
            }
        }

        [Column(Storage = "_Remark", DbType = "NVarChar(500)")]
        public string Remark
        {
            get
            {
                return this._Remark;
            }
            set
            {
                if ((this._Remark != value))
                {
                    this.OnRemarkChanging(value);
                    this.SendPropertyChanging();
                    this._Remark = value;
                    this.SendPropertyChanged("Remark");
                    this.OnRemarkChanged();
                }
            }
        }

        [Association(Name = "FK_OA_PROGRAMME_HR_PERSONNEL", Storage = "_HR_Personnel", ThisKey = "PersonnelID", IsForeignKey = true)]
        public HR_Personnel HR_Personnel
        {
            get
            {
                return this._HR_Personnel.Entity;
            }
            set
            {
                HR_Personnel previousValue = this._HR_Personnel.Entity;
                if (((previousValue != value)
                            || (this._HR_Personnel.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HR_Personnel.Entity = null;
                        previousValue.OA_Programme.Remove(this);
                    }
                    this._HR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.OA_Programme.Add(this);
                        this._PersonnelID = value.ID;
                    }
                    else
                    {
                        this._PersonnelID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_Personnel");
                }
            }
        }

        public event PropertyChangingEventHandler PropertyChanging;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void SendPropertyChanging()
        {
            if ((this.PropertyChanging != null))
            {
                this.PropertyChanging(this, emptyChangingEventArgs);
            }
        }

        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
