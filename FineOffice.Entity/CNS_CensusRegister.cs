using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.ComponentModel;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.CNS_CensusRegister")]
    public partial class CNS_CensusRegister : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private System.Nullable<int> _CensusTypeID;

        private string _HouseHolder;

        private string _RegisterNO;

        private string _Habitation;

        private System.Nullable<System.DateTime> _IssuingDate;

        private string _IssuingAuthority;

        private string _Remark;

        private EntityRef<CNS_CensusType> _CNS_CensusType;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnCensusTypeIDChanging(System.Nullable<int> value);
        partial void OnCensusTypeIDChanged();
        partial void OnHouseHolderChanging(string value);
        partial void OnHouseHolderChanged();
        partial void OnRegisterNOChanging(string value);
        partial void OnRegisterNOChanged();
        partial void OnHabitationChanging(string value);
        partial void OnHabitationChanged();
        partial void OnIssuingDateChanging(System.Nullable<System.DateTime> value);
        partial void OnIssuingDateChanged();
        partial void OnIssuingAuthorityChanging(string value);
        partial void OnIssuingAuthorityChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public CNS_CensusRegister()
        {
            this._CNS_CensusType = default(EntityRef<CNS_CensusType>);
            OnCreated();
        }

        [Column(Storage = "_ID", AutoSync = AutoSync.OnInsert,IsVersion=true, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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

        [Column(Storage = "_CensusTypeID", DbType = "Int")]
        public System.Nullable<int> CensusTypeID
        {
            get
            {
                return this._CensusTypeID;
            }
            set
            {
                if ((this._CensusTypeID != value))
                {
                    if (this._CNS_CensusType.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCensusTypeIDChanging(value);
                    this.SendPropertyChanging();
                    this._CensusTypeID = value;
                    this.SendPropertyChanged("CensusTypeID");
                    this.OnCensusTypeIDChanged();
                }
            }
        }

        [Column(Storage = "_HouseHolder", DbType = "VarChar(50)")]
        public string HouseHolder
        {
            get
            {
                return this._HouseHolder;
            }
            set
            {
                if ((this._HouseHolder != value))
                {
                    this.OnHouseHolderChanging(value);
                    this.SendPropertyChanging();
                    this._HouseHolder = value;
                    this.SendPropertyChanged("HouseHolder");
                    this.OnHouseHolderChanged();
                }
            }
        }

        [Column(Storage = "_RegisterNO", DbType = "VarChar(100)")]
        public string RegisterNO
        {
            get
            {
                return this._RegisterNO;
            }
            set
            {
                if ((this._RegisterNO != value))
                {
                    this.OnRegisterNOChanging(value);
                    this.SendPropertyChanging();
                    this._RegisterNO = value;
                    this.SendPropertyChanged("RegisterNO");
                    this.OnRegisterNOChanged();
                }
            }
        }

        [Column(Storage = "_Habitation", DbType = "VarChar(500)")]
        public string Habitation
        {
            get
            {
                return this._Habitation;
            }
            set
            {
                if ((this._Habitation != value))
                {
                    this.OnHabitationChanging(value);
                    this.SendPropertyChanging();
                    this._Habitation = value;
                    this.SendPropertyChanged("Habitation");
                    this.OnHabitationChanged();
                }
            }
        }

        [Column(Storage = "_IssuingDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> IssuingDate
        {
            get
            {
                return this._IssuingDate;
            }
            set
            {
                if ((this._IssuingDate != value))
                {
                    this.OnIssuingDateChanging(value);
                    this.SendPropertyChanging();
                    this._IssuingDate = value;
                    this.SendPropertyChanged("IssuingDate");
                    this.OnIssuingDateChanged();
                }
            }
        }

        [Column(Storage = "_IssuingAuthority", DbType = "VarChar(500)")]
        public string IssuingAuthority
        {
            get
            {
                return this._IssuingAuthority;
            }
            set
            {
                if ((this._IssuingAuthority != value))
                {
                    this.OnIssuingAuthorityChanging(value);
                    this.SendPropertyChanging();
                    this._IssuingAuthority = value;
                    this.SendPropertyChanged("IssuingAuthority");
                    this.OnIssuingAuthorityChanged();
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

        [Association(Name = "FK_CNS_CensusRegister_CNS_CensusType", Storage = "_CNS_CensusType", ThisKey = "CensusTypeID", IsForeignKey = true)]
        public CNS_CensusType CNS_CensusType
        {
            get
            {
                return this._CNS_CensusType.Entity;
            }
            set
            {
                CNS_CensusType previousValue = this._CNS_CensusType.Entity;
                if (((previousValue != value)
                            || (this._CNS_CensusType.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._CNS_CensusType.Entity = null;
                        previousValue.CNS_CensusRegister.Remove(this);
                    }
                    this._CNS_CensusType.Entity = value;
                    if ((value != null))
                    {
                        value.CNS_CensusRegister.Add(this);
                        this._CensusTypeID = value.ID;
                    }
                    else
                    {
                        this._CensusTypeID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("CNS_CensusType");
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
