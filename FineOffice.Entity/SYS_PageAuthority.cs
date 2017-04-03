using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.SYS_PageAuthority")]
    public partial class SYS_PageAuthority : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _ControlID;

        private System.Nullable<int> _MenuID;

        private string _AuthorityName;

        private string _Remark;

        private System.Nullable<int> _Ordering;

        private System.Data.Linq.Binary _Version;

        private EntityRef<SYS_MenuList> _SYS_MenuList;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnControlIDChanging(string value);
        partial void OnControlIDChanged();
        partial void OnMenuIDChanging(System.Nullable<int> value);
        partial void OnMenuIDChanged();
        partial void OnAuthorityNameChanging(string value);
        partial void OnAuthorityNameChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        partial void OnOrderingChanging(System.Nullable<int> value);
        partial void OnOrderingChanged();
        partial void OnVersionChanging(System.Data.Linq.Binary value);
        partial void OnVersionChanged();
        #endregion

        public SYS_PageAuthority()
        {
            this._SYS_MenuList = default(EntityRef<SYS_MenuList>);
            OnCreated();
        }

        [Column(Storage = "_ID", DbType = "Int NOT NULL", IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
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

        [Column(Storage = "_ControlID", DbType = "VarChar(100)", UpdateCheck = UpdateCheck.Never)]
        public string ControlID
        {
            get
            {
                return this._ControlID;
            }
            set
            {
                if ((this._ControlID != value))
                {
                    this.OnControlIDChanging(value);
                    this.SendPropertyChanging();
                    this._ControlID = value;
                    this.SendPropertyChanged("ControlID");
                    this.OnControlIDChanged();
                }
            }
        }

        [Column(Storage = "_MenuID", DbType = "Int", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<int> MenuID
        {
            get
            {
                return this._MenuID;
            }
            set
            {
                if ((this._MenuID != value))
                {
                    if (this._SYS_MenuList.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnMenuIDChanging(value);
                    this.SendPropertyChanging();
                    this._MenuID = value;
                    this.SendPropertyChanged("MenuID");
                    this.OnMenuIDChanged();
                }
            }
        }

        [Column(Storage = "_AuthorityName", DbType = "VarChar(100)", UpdateCheck = UpdateCheck.Never)]
        public string AuthorityName
        {
            get
            {
                return this._AuthorityName;
            }
            set
            {
                if ((this._AuthorityName != value))
                {
                    this.OnAuthorityNameChanging(value);
                    this.SendPropertyChanging();
                    this._AuthorityName = value;
                    this.SendPropertyChanged("AuthorityName");
                    this.OnAuthorityNameChanged();
                }
            }
        }

        [Column(Storage = "_Remark", DbType = "VarChar(500)", UpdateCheck = UpdateCheck.Never)]
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

        [Column(Storage = "_Ordering", DbType = "Int", UpdateCheck = UpdateCheck.Never)]
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

        [Column(Storage = "_Version", AutoSync = AutoSync.Always, DbType = "rowversion", CanBeNull = true, IsDbGenerated = true, IsVersion = true, UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary Version
        {
            get
            {
                return this._Version;
            }
            set
            {
                if ((this._Version != value))
                {
                    this.OnVersionChanging(value);
                    this.SendPropertyChanging();
                    this._Version = value;
                    this.SendPropertyChanged("Version");
                    this.OnVersionChanged();
                }
            }
        }

        [Association(Name = "FK_SYS_PageAuthority_SYS_MenuList", Storage = "_SYS_MenuList", ThisKey = "MenuID", IsForeignKey = true)]
        public SYS_MenuList SYS_MenuList
        {
            get
            {
                return this._SYS_MenuList.Entity;
            }
            set
            {
                SYS_MenuList previousValue = this._SYS_MenuList.Entity;
                if (((previousValue != value)
                            || (this._SYS_MenuList.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._SYS_MenuList.Entity = null;
                        previousValue.SYS_PageAuthority.Remove(this);
                    }
                    this._SYS_MenuList.Entity = value;
                    if ((value != null))
                    {
                        value.SYS_PageAuthority.Add(this);
                        this._MenuID = value.ID;
                    }
                    else
                    {
                        this._MenuID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("SYS_MenuList");
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
