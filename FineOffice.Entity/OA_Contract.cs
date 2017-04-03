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
    [Table(Name = "dbo.OA_Contract")]
    public partial class OA_Contract : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _ContractNO;

        private string _ContractName;

        private System.Nullable<int> _TypeID;

        private System.Nullable<int> _TraderID;

        private System.Nullable<System.DateTime> _SingnDate;

        private System.Nullable<System.DateTime> _EndDate;

        private string _Linkman;

        private string _Moblie;

        private System.Nullable<int> _Handler;

        private string _Content;

        private string _Location;

        private string _Remark;

        private EntitySet<OA_Attachment> _OA_Attachment;

        private EntityRef<CRM_Trader> _CRM_Trader;

        private EntityRef<HR_Personnel> _HR_Personnel;

        private EntityRef<OA_ContractType> _OA_ContractType;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnContractNOChanging(string value);
        partial void OnContractNOChanged();
        partial void OnContractNameChanging(string value);
        partial void OnContractNameChanged();
        partial void OnTypeIDChanging(System.Nullable<int> value);
        partial void OnTypeIDChanged();
        partial void OnTraderIDChanging(System.Nullable<int> value);
        partial void OnTraderIDChanged();
        partial void OnSingnDateChanging(System.Nullable<System.DateTime> value);
        partial void OnSingnDateChanged();
        partial void OnEndDateChanging(System.Nullable<System.DateTime> value);
        partial void OnEndDateChanged();
        partial void OnLinkmanChanging(string value);
        partial void OnLinkmanChanged();
        partial void OnMoblieChanging(string value);
        partial void OnMoblieChanged();
        partial void OnHandlerChanging(System.Nullable<int> value);
        partial void OnHandlerChanged();
        partial void OnContentChanging(string value);
        partial void OnContentChanged();
        partial void OnLocationChanging(string value);
        partial void OnLocationChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public OA_Contract()
        {
            this._OA_Attachment = new EntitySet<OA_Attachment>(new Action<OA_Attachment>(this.attach_OA_Attachment), new Action<OA_Attachment>(this.detach_OA_Attachment));
            this._CRM_Trader = default(EntityRef<CRM_Trader>);
            this._HR_Personnel = default(EntityRef<HR_Personnel>);
            this._OA_ContractType = default(EntityRef<OA_ContractType>);
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

        [Column(Storage = "_ContractNO", DbType = "VarChar(30)")]
        public string ContractNO
        {
            get
            {
                return this._ContractNO;
            }
            set
            {
                if ((this._ContractNO != value))
                {
                    this.OnContractNOChanging(value);
                    this.SendPropertyChanging();
                    this._ContractNO = value;
                    this.SendPropertyChanged("ContractNO");
                    this.OnContractNOChanged();
                }
            }
        }

        [Column(Storage = "_ContractName", DbType = "VarChar(50)")]
        public string ContractName
        {
            get
            {
                return this._ContractName;
            }
            set
            {
                if ((this._ContractName != value))
                {
                    this.OnContractNameChanging(value);
                    this.SendPropertyChanging();
                    this._ContractName = value;
                    this.SendPropertyChanged("ContractName");
                    this.OnContractNameChanged();
                }
            }
        }

        [Column(Storage = "_TypeID", DbType = "Int")]
        public System.Nullable<int> TypeID
        {
            get
            {
                return this._TypeID;
            }
            set
            {
                if ((this._TypeID != value))
                {
                    if (this._OA_ContractType.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnTypeIDChanging(value);
                    this.SendPropertyChanging();
                    this._TypeID = value;
                    this.SendPropertyChanged("TypeID");
                    this.OnTypeIDChanged();
                }
            }
        }

        [Column(Storage = "_TraderID", DbType = "Int")]
        public System.Nullable<int> TraderID
        {
            get
            {
                return this._TraderID;
            }
            set
            {
                if ((this._TraderID != value))
                {
                    if (this._CRM_Trader.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnTraderIDChanging(value);
                    this.SendPropertyChanging();
                    this._TraderID = value;
                    this.SendPropertyChanged("TraderID");
                    this.OnTraderIDChanged();
                }
            }
        }

        [Column(Storage = "_SingnDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> SingnDate
        {
            get
            {
                return this._SingnDate;
            }
            set
            {
                if ((this._SingnDate != value))
                {
                    this.OnSingnDateChanging(value);
                    this.SendPropertyChanging();
                    this._SingnDate = value;
                    this.SendPropertyChanged("SingnDate");
                    this.OnSingnDateChanged();
                }
            }
        }

        [Column(Storage = "_EndDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> EndDate
        {
            get
            {
                return this._EndDate;
            }
            set
            {
                if ((this._EndDate != value))
                {
                    this.OnEndDateChanging(value);
                    this.SendPropertyChanging();
                    this._EndDate = value;
                    this.SendPropertyChanged("EndDate");
                    this.OnEndDateChanged();
                }
            }
        }

        [Column(Storage = "_Linkman", DbType = "VarChar(50)")]
        public string Linkman
        {
            get
            {
                return this._Linkman;
            }
            set
            {
                if ((this._Linkman != value))
                {
                    this.OnLinkmanChanging(value);
                    this.SendPropertyChanging();
                    this._Linkman = value;
                    this.SendPropertyChanged("Linkman");
                    this.OnLinkmanChanged();
                }
            }
        }

        [Column(Storage = "_Moblie", DbType = "VarChar(50)")]
        public string Moblie
        {
            get
            {
                return this._Moblie;
            }
            set
            {
                if ((this._Moblie != value))
                {
                    this.OnMoblieChanging(value);
                    this.SendPropertyChanging();
                    this._Moblie = value;
                    this.SendPropertyChanged("Moblie");
                    this.OnMoblieChanged();
                }
            }
        }

        [Column(Storage = "_Handler", DbType = "Int")]
        public System.Nullable<int> Handler
        {
            get
            {
                return this._Handler;
            }
            set
            {
                if ((this._Handler != value))
                {
                    if (this._HR_Personnel.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnHandlerChanging(value);
                    this.SendPropertyChanging();
                    this._Handler = value;
                    this.SendPropertyChanged("Handler");
                    this.OnHandlerChanged();
                }
            }
        }

        [Column(Storage = "_Content", DbType = "VarChar(500)")]
        public string Content
        {
            get
            {
                return this._Content;
            }
            set
            {
                if ((this._Content != value))
                {
                    this.OnContentChanging(value);
                    this.SendPropertyChanging();
                    this._Content = value;
                    this.SendPropertyChanged("Content");
                    this.OnContentChanged();
                }
            }
        }

        [Column(Storage = "_Location", DbType = "VarChar(50)")]
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

        [Association(Name = "FK_ATTACHME_REFERENCE_CONTRACT", Storage = "_OA_Attachment", OtherKey = "ContractID", DeleteRule = "NO ACTION")]
        public EntitySet<OA_Attachment> OA_Attachment
        {
            get
            {
                return this._OA_Attachment;
            }
            set
            {
                this._OA_Attachment.Assign(value);
            }
        }

        [Association(Name = "FK_OA_Contract_CRM_Trader", Storage = "_CRM_Trader", ThisKey = "TraderID", IsForeignKey = true)]
        public CRM_Trader CRM_Trader
        {
            get
            {
                return this._CRM_Trader.Entity;
            }
            set
            {
                CRM_Trader previousValue = this._CRM_Trader.Entity;
                if (((previousValue != value)
                            || (this._CRM_Trader.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._CRM_Trader.Entity = null;
                        previousValue.OA_Contract.Remove(this);
                    }
                    this._CRM_Trader.Entity = value;
                    if ((value != null))
                    {
                        value.OA_Contract.Add(this);
                        this._TraderID = value.ID;
                    }
                    else
                    {
                        this._TraderID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("CRM_Trader");
                }
            }
        }

        [Association(Name = "FK_OA_Contract_HR_Personnel", Storage = "_HR_Personnel", ThisKey = "Handler", IsForeignKey = true)]
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
                        previousValue.OA_Contract.Remove(this);
                    }
                    this._HR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.OA_Contract.Add(this);
                        this._Handler = value.ID;
                    }
                    else
                    {
                        this._Handler = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_Personnel");
                }
            }
        }

        [Association(Name = "FK_OA_Contract_OA_ContractType", Storage = "_OA_ContractType", ThisKey = "TypeID", IsForeignKey = true)]
        public OA_ContractType OA_ContractType
        {
            get
            {
                return this._OA_ContractType.Entity;
            }
            set
            {
                OA_ContractType previousValue = this._OA_ContractType.Entity;
                if (((previousValue != value)
                            || (this._OA_ContractType.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._OA_ContractType.Entity = null;
                        previousValue.OA_Contract.Remove(this);
                    }
                    this._OA_ContractType.Entity = value;
                    if ((value != null))
                    {
                        value.OA_Contract.Add(this);
                        this._TypeID = value.ID;
                    }
                    else
                    {
                        this._TypeID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("OA_ContractType");
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

        private void attach_OA_Attachment(OA_Attachment entity)
        {
            this.SendPropertyChanging();
            entity.OA_Contract = this;
        }

        private void detach_OA_Attachment(OA_Attachment entity)
        {
            this.SendPropertyChanging();
            entity.OA_Contract = null;
        }
    }

}
