using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Data.Linq;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.SYS_MenuList")]
    public partial class SYS_MenuList : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _Text;

        private string _TabID;

        private string _NavigateUrl;

        private System.Nullable<int> _ParentID;

        private System.Nullable<bool> _SingleClickExpand;

        private string _Icon;

        private System.Nullable<bool> _IsModule;

        private System.Nullable<bool> _IsFuntion;

        private System.Nullable<int> _Ordering;

        private System.Nullable<bool> _Stop;

        private string _Remark;

        private System.Data.Linq.Binary _Version;

        private EntitySet<SYS_PageAuthority> _SYS_PageAuthority;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnTextChanging(string value);
        partial void OnTextChanged();
        partial void OnTabIDChanging(string value);
        partial void OnTabIDChanged();
        partial void OnNavigateUrlChanging(string value);
        partial void OnNavigateUrlChanged();
        partial void OnParentIDChanging(System.Nullable<int> value);
        partial void OnParentIDChanged();
        partial void OnSingleClickExpandChanging(System.Nullable<bool> value);
        partial void OnSingleClickExpandChanged();
        partial void OnIconChanging(string value);
        partial void OnIconChanged();
        partial void OnIsModuleChanging(System.Nullable<bool> value);
        partial void OnIsModuleChanged();
        partial void OnIsFuntionChanging(System.Nullable<bool> value);
        partial void OnIsFuntionChanged();
        partial void OnOrderingChanging(System.Nullable<int> value);
        partial void OnOrderingChanged();
        partial void OnStopChanging(System.Nullable<bool> value);
        partial void OnStopChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        partial void OnVersionChanging(System.Data.Linq.Binary value);
        partial void OnVersionChanged();
        #endregion

        public SYS_MenuList()
        {
            this._SYS_PageAuthority = new EntitySet<SYS_PageAuthority>(new Action<SYS_PageAuthority>(this.attach_SYS_PageAuthority), new Action<SYS_PageAuthority>(this.detach_SYS_PageAuthority));
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

        [Column(Storage = "_Text", DbType = "VarChar(100)", UpdateCheck = UpdateCheck.Never)]
        public string Text
        {
            get
            {
                return this._Text;
            }
            set
            {
                if ((this._Text != value))
                {
                    this.OnTextChanging(value);
                    this.SendPropertyChanging();
                    this._Text = value;
                    this.SendPropertyChanged("Text");
                    this.OnTextChanged();
                }
            }
        }

        [Column(Storage = "_TabID", DbType = "VarChar(100)", UpdateCheck = UpdateCheck.Never)]
        public string TabID
        {
            get
            {
                return this._TabID;
            }
            set
            {
                if ((this._TabID != value))
                {
                    this.OnTabIDChanging(value);
                    this.SendPropertyChanging();
                    this._TabID = value;
                    this.SendPropertyChanged("TabID");
                    this.OnTabIDChanged();
                }
            }
        }

        [Column(Storage = "_NavigateUrl", DbType = "VarChar(500)", UpdateCheck = UpdateCheck.Never)]
        public string NavigateUrl
        {
            get
            {
                return this._NavigateUrl;
            }
            set
            {
                if ((this._NavigateUrl != value))
                {
                    this.OnNavigateUrlChanging(value);
                    this.SendPropertyChanging();
                    this._NavigateUrl = value;
                    this.SendPropertyChanged("NavigateUrl");
                    this.OnNavigateUrlChanged();
                }
            }
        }

        [Column(Storage = "_ParentID", DbType = "Int", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<int> ParentID
        {
            get
            {
                return this._ParentID;
            }
            set
            {
                if ((this._ParentID != value))
                {
                    this.OnParentIDChanging(value);
                    this.SendPropertyChanging();
                    this._ParentID = value;
                    this.SendPropertyChanged("ParentID");
                    this.OnParentIDChanged();
                }
            }
        }

        [Column(Storage = "_SingleClickExpand", DbType = "Bit", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<bool> SingleClickExpand
        {
            get
            {
                return this._SingleClickExpand;
            }
            set
            {
                if ((this._SingleClickExpand != value))
                {
                    this.OnSingleClickExpandChanging(value);
                    this.SendPropertyChanging();
                    this._SingleClickExpand = value;
                    this.SendPropertyChanged("SingleClickExpand");
                    this.OnSingleClickExpandChanged();
                }
            }
        }

        [Column(Storage = "_Icon", DbType = "VarChar(50)", UpdateCheck = UpdateCheck.Never)]
        public string Icon
        {
            get
            {
                return this._Icon;
            }
            set
            {
                if ((this._Icon != value))
                {
                    this.OnIconChanging(value);
                    this.SendPropertyChanging();
                    this._Icon = value;
                    this.SendPropertyChanged("Icon");
                    this.OnIconChanged();
                }
            }
        }

        [Column(Storage = "_IsModule", DbType = "Bit", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<bool> IsModule
        {
            get
            {
                return this._IsModule;
            }
            set
            {
                if ((this._IsModule != value))
                {
                    this.OnIsModuleChanging(value);
                    this.SendPropertyChanging();
                    this._IsModule = value;
                    this.SendPropertyChanged("IsModule");
                    this.OnIsModuleChanged();
                }
            }
        }

        [Column(Storage = "_IsFuntion", DbType = "Bit", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<bool> IsFuntion
        {
            get
            {
                return this._IsFuntion;
            }
            set
            {
                if ((this._IsFuntion != value))
                {
                    this.OnIsFuntionChanging(value);
                    this.SendPropertyChanging();
                    this._IsFuntion = value;
                    this.SendPropertyChanged("IsFuntion");
                    this.OnIsFuntionChanged();
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

        [Column(Storage = "_Stop", DbType = "Bit", UpdateCheck = UpdateCheck.Never)]
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

        [Association(Name = "FK_SYS_PageAuthority_SYS_MenuList", Storage = "_SYS_PageAuthority", OtherKey = "MenuID", DeleteRule = "NO ACTION")]
        public EntitySet<SYS_PageAuthority> SYS_PageAuthority
        {
            get
            {
                return this._SYS_PageAuthority;
            }
            set
            {
                this._SYS_PageAuthority.Assign(value);
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

        private void attach_SYS_PageAuthority(SYS_PageAuthority entity)
        {
            this.SendPropertyChanging();
            entity.SYS_MenuList = this;
        }

        private void detach_SYS_PageAuthority(SYS_PageAuthority entity)
        {
            this.SendPropertyChanging();
            entity.SYS_MenuList = null;
        }
    }
}
