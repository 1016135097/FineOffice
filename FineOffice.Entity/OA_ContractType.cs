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
    [Table(Name = "dbo.OA_ContractType")]
    public partial class OA_ContractType : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _TypeName;

        private System.Nullable<int> _Ordering;

        private string _Remark;

        private EntitySet<OA_Contract> _OA_Contract;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnTypeNameChanging(string value);
        partial void OnTypeNameChanged();
        partial void OnOrderingChanging(System.Nullable<int> value);
        partial void OnOrderingChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public OA_ContractType()
        {
            this._OA_Contract = new EntitySet<OA_Contract>(new Action<OA_Contract>(this.attach_OA_Contract), new Action<OA_Contract>(this.detach_OA_Contract));
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

        [Column(Storage = "_TypeName", DbType = "VarChar(50)")]
        public string TypeName
        {
            get
            {
                return this._TypeName;
            }
            set
            {
                if ((this._TypeName != value))
                {
                    this.OnTypeNameChanging(value);
                    this.SendPropertyChanging();
                    this._TypeName = value;
                    this.SendPropertyChanged("TypeName");
                    this.OnTypeNameChanged();
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

        [Association(Name = "FK_OA_Contract_OA_ContractType", Storage = "_OA_Contract", OtherKey = "TypeID", DeleteRule = "NO ACTION")]
        public EntitySet<OA_Contract> OA_Contract
        {
            get
            {
                return this._OA_Contract;
            }
            set
            {
                this._OA_Contract.Assign(value);
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

        private void attach_OA_Contract(OA_Contract entity)
        {
            this.SendPropertyChanging();
            entity.OA_ContractType = this;
        }

        private void detach_OA_Contract(OA_Contract entity)
        {
            this.SendPropertyChanging();
            entity.OA_ContractType = null;
        }
    }
}
