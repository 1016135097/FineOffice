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
    [Table(Name = "dbo.SYS_User")]
    public partial class SYS_User : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private System.Nullable<int> _PersonnelID;

        private string _UserName;

        private System.Nullable<System.DateTime> _CreateDate;

        private string _Password;

        private string _RoleList;

        private string _CheckAuthority;

        private System.Nullable<bool> _Stop;

        private System.Nullable<bool> _IsModify;

        private string _Remark;

        private EntityRef<HR_Personnel> _HR_Personnel;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnPersonnelIDChanging(System.Nullable<int> value);
        partial void OnPersonnelIDChanged();
        partial void OnUserNameChanging(string value);
        partial void OnUserNameChanged();
        partial void OnCreateDateChanging(System.Nullable<System.DateTime> value);
        partial void OnCreateDateChanged();
        partial void OnPasswordChanging(string value);
        partial void OnPasswordChanged();
        partial void OnRoleListChanging(string value);
        partial void OnRoleListChanged();
        partial void OnCheckAuthorityChanging(string value);
        partial void OnCheckAuthorityChanged();
        partial void OnStopChanging(System.Nullable<bool> value);
        partial void OnStopChanged();
        partial void OnIsModifyChanging(System.Nullable<bool> value);
        partial void OnIsModifyChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public SYS_User()
        {
            this._HR_Personnel = default(EntityRef<HR_Personnel>);
            OnCreated();
        }

        [Column(Storage = "_ID", IsVersion = true, AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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

        [Column(Storage = "_UserName", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                if ((this._UserName != value))
                {
                    this.OnUserNameChanging(value);
                    this.SendPropertyChanging();
                    this._UserName = value;
                    this.SendPropertyChanged("UserName");
                    this.OnUserNameChanged();
                }
            }
        }

        [Column(Storage = "_CreateDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> CreateDate
        {
            get
            {
                return this._CreateDate;
            }
            set
            {
                if ((this._CreateDate != value))
                {
                    this.OnCreateDateChanging(value);
                    this.SendPropertyChanging();
                    this._CreateDate = value;
                    this.SendPropertyChanged("CreateDate");
                    this.OnCreateDateChanged();
                }
            }
        }

        [Column(Storage = "_Password", DbType = "VarChar(100)")]
        public string Password
        {
            get
            {
                return this._Password;
            }
            set
            {
                if ((this._Password != value))
                {
                    this.OnPasswordChanging(value);
                    this.SendPropertyChanging();
                    this._Password = value;
                    this.SendPropertyChanged("Password");
                    this.OnPasswordChanged();
                }
            }
        }

        [Column(Storage = "_RoleList", DbType = "VarChar(500)")]
        public string RoleList
        {
            get
            {
                return this._RoleList;
            }
            set
            {
                if ((this._RoleList != value))
                {
                    this.OnRoleListChanging(value);
                    this.SendPropertyChanging();
                    this._RoleList = value;
                    this.SendPropertyChanged("RoleList");
                    this.OnRoleListChanged();
                }
            }
        }

        [Column(Storage = "_CheckAuthority", DbType = "VarChar(1000)")]
        public string CheckAuthority
        {
            get
            {
                return this._CheckAuthority;
            }
            set
            {
                if ((this._CheckAuthority != value))
                {
                    this.OnCheckAuthorityChanging(value);
                    this.SendPropertyChanging();
                    this._CheckAuthority = value;
                    this.SendPropertyChanged("CheckAuthority");
                    this.OnCheckAuthorityChanged();
                }
            }
        }

        [Column(Storage = "_Stop", DbType = "Bit")]
        public System.Nullable<bool> Stop
        {
            get
            {
                return this._Stop;
            }
            set
            {
                if ((this._Stop != value))
                {
                    this.OnStopChanging(value);
                    this.SendPropertyChanging();
                    this._Stop = value;
                    this.SendPropertyChanged("Stop");
                    this.OnStopChanged();
                }
            }
        }

        [Column(Storage = "_IsModify", DbType = "Bit")]
        public System.Nullable<bool> IsModify
        {
            get
            {
                return this._IsModify;
            }
            set
            {
                if ((this._IsModify != value))
                {
                    this.OnIsModifyChanging(value);
                    this.SendPropertyChanging();
                    this._IsModify = value;
                    this.SendPropertyChanged("IsModify");
                    this.OnIsModifyChanged();
                }
            }
        }

        [Column(Storage = "_Remark", DbType = "VarChar(500)")]
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

        [Association(Name = "FK_SYS_USER_REFERENCE_HR_PERSO", Storage = "_HR_Personnel", ThisKey = "PersonnelID", IsForeignKey = true)]
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
                        previousValue.SYS_User.Remove(this);
                    }
                    this._HR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.SYS_User.Add(this);
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
