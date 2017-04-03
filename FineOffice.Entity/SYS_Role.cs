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
    [Table(Name = "dbo.SYS_Role")]
    public partial class SYS_Role : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _RoleName;

        private System.Nullable<bool> _Stop;

        private System.Nullable<int> _Ordering;

        private string _MenuList;

        private string _AuthorityList;

        private System.Nullable<bool> _IsModify;

        private string _Remark;

        private EntitySet<OA_ProcessAuthority> _OA_ProcessAuthority;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnRoleNameChanging(string value);
        partial void OnRoleNameChanged();
        partial void OnStopChanging(System.Nullable<bool> value);
        partial void OnStopChanged();
        partial void OnOrderingChanging(System.Nullable<int> value);
        partial void OnOrderingChanged();
        partial void OnMenuListChanging(string value);
        partial void OnMenuListChanged();
        partial void OnAuthorityListChanging(string value);
        partial void OnAuthorityListChanged();
        partial void OnIsModifyChanging(System.Nullable<bool> value);
        partial void OnIsModifyChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public SYS_Role()
        {
            this._OA_ProcessAuthority = new EntitySet<OA_ProcessAuthority>(new Action<OA_ProcessAuthority>(this.attach_OA_ProcessAuthority), new Action<OA_ProcessAuthority>(this.detach_OA_ProcessAuthority));
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

        [Column(Storage = "_RoleName", DbType = "VarChar(50)")]
        public string RoleName
        {
            get
            {
                return this._RoleName;
            }
            set
            {
                if ((this._RoleName != value))
                {
                    this.OnRoleNameChanging(value);
                    this.SendPropertyChanging();
                    this._RoleName = value;
                    this.SendPropertyChanged("RoleName");
                    this.OnRoleNameChanged();
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

        [Column(Storage = "_Ordering", DbType = "Int")]
        public System.Nullable<int> Ordering
        {
            get
            {
                return this._Ordering;
            }
            set
            {
                if ((this._Ordering != value))
                {
                    this.OnOrderingChanging(value);
                    this.SendPropertyChanging();
                    this._Ordering = value;
                    this.SendPropertyChanged("Ordering");
                    this.OnOrderingChanged();
                }
            }
        }

        [Column(Storage = "_MenuList", DbType = "VarChar(5000)")]
        public string MenuList
        {
            get
            {
                return this._MenuList;
            }
            set
            {
                if ((this._MenuList != value))
                {
                    this.OnMenuListChanging(value);
                    this.SendPropertyChanging();
                    this._MenuList = value;
                    this.SendPropertyChanged("MenuList");
                    this.OnMenuListChanged();
                }
            }
        }

        [Column(Storage = "_AuthorityList", DbType = "VarChar(5000)")]
        public string AuthorityList
        {
            get
            {
                return this._AuthorityList;
            }
            set
            {
                if ((this._AuthorityList != value))
                {
                    this.OnAuthorityListChanging(value);
                    this.SendPropertyChanging();
                    this._AuthorityList = value;
                    this.SendPropertyChanged("AuthorityList");
                    this.OnAuthorityListChanged();
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

        [Association(Name = "FK_OA_PROCESSS_ROLE", Storage = "_OA_ProcessAuthority", OtherKey = "RoleID", DeleteRule = "NO ACTION")]
        public EntitySet<OA_ProcessAuthority> OA_ProcessAuthority
        {
            get
            {
                return this._OA_ProcessAuthority;
            }
            set
            {
                this._OA_ProcessAuthority.Assign(value);
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

        private void attach_OA_ProcessAuthority(OA_ProcessAuthority entity)
        {
            this.SendPropertyChanging();
            entity.SYS_Role = this;
        }

        private void detach_OA_ProcessAuthority(OA_ProcessAuthority entity)
        {
            this.SendPropertyChanging();
            entity.SYS_Role = null;
        }
    }
}
