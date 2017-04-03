using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Data.Linq;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.CNS_CensusType")]
    public partial class CNS_CensusType : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _CensusTypeName;

        private string _Remark;

        private EntitySet<CNS_CensusRegister> _CNS_CensusRegister;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnCensusTypeNameChanging(string value);
        partial void OnCensusTypeNameChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public CNS_CensusType()
        {
            this._CNS_CensusRegister = new EntitySet<CNS_CensusRegister>(new Action<CNS_CensusRegister>(this.attach_CNS_CensusRegister), new Action<CNS_CensusRegister>(this.detach_CNS_CensusRegister));
            OnCreated();
        }

        [Column(Storage = "_ID",IsVersion=true, AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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

        [Column(Storage = "_CensusTypeName", DbType = "VarChar(50)")]
        public string CensusTypeName
        {
            get
            {
                return this._CensusTypeName;
            }
            set
            {
                if ((this._CensusTypeName != value))
                {
                    this.OnCensusTypeNameChanging(value);
                    this.SendPropertyChanging();
                    this._CensusTypeName = value;
                    this.SendPropertyChanged("CensusTypeName");
                    this.OnCensusTypeNameChanged();
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

        [Association(Name = "FK_CNS_CensusRegister_CNS_CensusType", Storage = "_CNS_CensusRegister", OtherKey = "CensusTypeID", DeleteRule = "NO ACTION")]
        public EntitySet<CNS_CensusRegister> CNS_CensusRegister
        {
            get
            {
                return this._CNS_CensusRegister;
            }
            set
            {
                this._CNS_CensusRegister.Assign(value);
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

        private void attach_CNS_CensusRegister(CNS_CensusRegister entity)
        {
            this.SendPropertyChanging();
            entity.CNS_CensusType = this;
        }

        private void detach_CNS_CensusRegister(CNS_CensusRegister entity)
        {
            this.SendPropertyChanging();
            entity.CNS_CensusType = null;
        }
    }
}
