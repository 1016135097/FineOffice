using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Data.Linq;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.CRM_TraderType")]
    public partial class CRM_TraderType : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _TraderType;

        private System.Nullable<int> _Ordering;

        private string _Remark;

        private EntitySet<CRM_Trader> _CRM_Trader;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnTraderTypeChanging(string value);
        partial void OnTraderTypeChanged();
        partial void OnOrderingChanging(System.Nullable<int> value);
        partial void OnOrderingChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public CRM_TraderType()
        {
            this._CRM_Trader = new EntitySet<CRM_Trader>(new Action<CRM_Trader>(this.attach_CRM_Trader), new Action<CRM_Trader>(this.detach_CRM_Trader));
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

        [Column(Storage = "_TraderType", DbType = "VarChar(50)")]
        public string TraderType
        {
            get
            {
                return this._TraderType;
            }
            set
            {
                if ((this._TraderType != value))
                {
                    this.OnTraderTypeChanging(value);
                    this.SendPropertyChanging();
                    this._TraderType = value;
                    this.SendPropertyChanged("TraderType");
                    this.OnTraderTypeChanged();
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

        [Association(Name = "FK_CRM_Trader_CRM_TraderType", Storage = "_CRM_Trader", OtherKey = "TypeID", DeleteRule = "NO ACTION")]
        public EntitySet<CRM_Trader> CRM_Trader
        {
            get
            {
                return this._CRM_Trader;
            }
            set
            {
                this._CRM_Trader.Assign(value);
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

        private void attach_CRM_Trader(CRM_Trader entity)
        {
            this.SendPropertyChanging();
            entity.CRM_TraderType = this;
        }

        private void detach_CRM_Trader(CRM_Trader entity)
        {
            this.SendPropertyChanging();
            entity.CRM_TraderType = null;
        }
    }

}
