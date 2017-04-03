using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.CRM_Trader")]
    public partial class CRM_Trader : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private System.Nullable<int> _AreaID;

        private System.Nullable<int> _TypeID;

        private System.Nullable<int> _IndustryID;

        private System.Nullable<int> _SourceID;

        private System.Nullable<int> _GradeID;

        private System.Nullable<int> _Handler;

        private System.Nullable<bool> _IsSupplier;

        private System.Nullable<bool> _IsClient;

        private string _TraderNO;

        private string _TraderName;

        private string _ShortName;

        private string _PinyinCode;

        private string _Incorporator;

        private System.Nullable<int> _NumberOfPeople;

        private string _Tel;

        private string _Fax;

        private string _WebSite;

        private string _Email;

        private string _Post;

        private string _Address;

        private string _Linkman;

        private string _Mobile;

        private System.Nullable<bool> _Stop;

        private System.Nullable<System.DateTime> _CreateTime;

        private string _Remark;

        private EntityRef<CRM_Area> _CRM_Area;

        private EntityRef<CRM_Grade> _CRM_Grade;

        private EntityRef<CRM_Industry> _CRM_Industry;

        private EntityRef<CRM_Source> _CRM_Source;

        private EntityRef<CRM_TraderType> _CRM_TraderType;

        private EntityRef<HR_Personnel> _HR_Personnel;

        private EntitySet<OA_Contract> _OA_Contract;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnAreaIDChanging(System.Nullable<int> value);
        partial void OnAreaIDChanged();
        partial void OnTypeIDChanging(System.Nullable<int> value);
        partial void OnTypeIDChanged();
        partial void OnIndustryIDChanging(System.Nullable<int> value);
        partial void OnIndustryIDChanged();
        partial void OnSourceIDChanging(System.Nullable<int> value);
        partial void OnSourceIDChanged();
        partial void OnGradeIDChanging(System.Nullable<int> value);
        partial void OnGradeIDChanged();
        partial void OnHandlerChanging(System.Nullable<int> value);
        partial void OnHandlerChanged();
        partial void OnIsSupplierChanging(System.Nullable<bool> value);
        partial void OnIsSupplierChanged();
        partial void OnIsClientChanging(System.Nullable<bool> value);
        partial void OnIsClientChanged();
        partial void OnTraderNOChanging(string value);
        partial void OnTraderNOChanged();
        partial void OnTraderNameChanging(string value);
        partial void OnTraderNameChanged();
        partial void OnShortNameChanging(string value);
        partial void OnShortNameChanged();
        partial void OnPinyinCodeChanging(string value);
        partial void OnPinyinCodeChanged();
        partial void OnIncorporatorChanging(string value);
        partial void OnIncorporatorChanged();
        partial void OnNumberOfPeopleChanging(System.Nullable<int> value);
        partial void OnNumberOfPeopleChanged();
        partial void OnTelChanging(string value);
        partial void OnTelChanged();
        partial void OnFaxChanging(string value);
        partial void OnFaxChanged();
        partial void OnWebSiteChanging(string value);
        partial void OnWebSiteChanged();
        partial void OnEmailChanging(string value);
        partial void OnEmailChanged();
        partial void OnPostChanging(string value);
        partial void OnPostChanged();
        partial void OnAddressChanging(string value);
        partial void OnAddressChanged();
        partial void OnLinkmanChanging(string value);
        partial void OnLinkmanChanged();
        partial void OnMobileChanging(string value);
        partial void OnMobileChanged();
        partial void OnStopChanging(System.Nullable<bool> value);
        partial void OnStopChanged();
        partial void OnCreateTimeChanging(System.Nullable<System.DateTime> value);
        partial void OnCreateTimeChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public CRM_Trader()
        {
            this._CRM_Area = default(EntityRef<CRM_Area>);
            this._CRM_Grade = default(EntityRef<CRM_Grade>);
            this._CRM_Industry = default(EntityRef<CRM_Industry>);
            this._CRM_Source = default(EntityRef<CRM_Source>);
            this._CRM_TraderType = default(EntityRef<CRM_TraderType>);
            this._HR_Personnel = default(EntityRef<HR_Personnel>);
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

        [Column(Storage = "_AreaID", DbType = "Int")]
        public System.Nullable<int> AreaID
        {
            get
            {
                return this._AreaID;
            }
            set
            {
                if ((this._AreaID != value))
                {
                    if (this._CRM_Area.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnAreaIDChanging(value);
                    this.SendPropertyChanging();
                    this._AreaID = value;
                    this.SendPropertyChanged("AreaID");
                    this.OnAreaIDChanged();
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
                    if (this._CRM_TraderType.HasLoadedOrAssignedValue)
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

        [Column(Storage = "_IndustryID", DbType = "Int")]
        public System.Nullable<int> IndustryID
        {
            get
            {
                return this._IndustryID;
            }
            set
            {
                if ((this._IndustryID != value))
                {
                    if (this._CRM_Industry.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnIndustryIDChanging(value);
                    this.SendPropertyChanging();
                    this._IndustryID = value;
                    this.SendPropertyChanged("IndustryID");
                    this.OnIndustryIDChanged();
                }
            }
        }

        [Column(Storage = "_SourceID", DbType = "Int")]
        public System.Nullable<int> SourceID
        {
            get
            {
                return this._SourceID;
            }
            set
            {
                if ((this._SourceID != value))
                {
                    if (this._CRM_Source.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnSourceIDChanging(value);
                    this.SendPropertyChanging();
                    this._SourceID = value;
                    this.SendPropertyChanged("SourceID");
                    this.OnSourceIDChanged();
                }
            }
        }

        [Column(Storage = "_GradeID", DbType = "Int")]
        public System.Nullable<int> GradeID
        {
            get
            {
                return this._GradeID;
            }
            set
            {
                if ((this._GradeID != value))
                {
                    if (this._CRM_Grade.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnGradeIDChanging(value);
                    this.SendPropertyChanging();
                    this._GradeID = value;
                    this.SendPropertyChanged("GradeID");
                    this.OnGradeIDChanged();
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

        [Column(Storage = "_IsSupplier", DbType = "Bit")]
        public System.Nullable<bool> IsSupplier
        {
            get
            {
                return this._IsSupplier;
            }
            set
            {
                if ((this._IsSupplier != value))
                {
                    this.OnIsSupplierChanging(value);
                    this.SendPropertyChanging();
                    this._IsSupplier = value;
                    this.SendPropertyChanged("IsSupplier");
                    this.OnIsSupplierChanged();
                }
            }
        }

        [Column(Storage = "_IsClient", DbType = "Bit")]
        public System.Nullable<bool> IsClient
        {
            get
            {
                return this._IsClient;
            }
            set
            {
                if ((this._IsClient != value))
                {
                    this.OnIsClientChanging(value);
                    this.SendPropertyChanging();
                    this._IsClient = value;
                    this.SendPropertyChanged("IsClient");
                    this.OnIsClientChanged();
                }
            }
        }

        [Column(Storage = "_TraderNO", DbType = "VarChar(100)")]
        public string TraderNO
        {
            get
            {
                return this._TraderNO;
            }
            set
            {
                if ((this._TraderNO != value))
                {
                    this.OnTraderNOChanging(value);
                    this.SendPropertyChanging();
                    this._TraderNO = value;
                    this.SendPropertyChanged("TraderNO");
                    this.OnTraderNOChanged();
                }
            }
        }

        [Column(Storage = "_TraderName", DbType = "VarChar(100)")]
        public string TraderName
        {
            get
            {
                return this._TraderName;
            }
            set
            {
                if ((this._TraderName != value))
                {
                    this.OnTraderNameChanging(value);
                    this.SendPropertyChanging();
                    this._TraderName = value;
                    this.SendPropertyChanged("TraderName");
                    this.OnTraderNameChanged();
                }
            }
        }

        [Column(Storage = "_ShortName", DbType = "VarChar(100)")]
        public string ShortName
        {
            get
            {
                return this._ShortName;
            }
            set
            {
                if ((this._ShortName != value))
                {
                    this.OnShortNameChanging(value);
                    this.SendPropertyChanging();
                    this._ShortName = value;
                    this.SendPropertyChanged("ShortName");
                    this.OnShortNameChanged();
                }
            }
        }

        [Column(Storage = "_PinyinCode", DbType = "VarChar(50)")]
        public string PinyinCode
        {
            get
            {
                return this._PinyinCode;
            }
            set
            {
                if ((this._PinyinCode != value))
                {
                    this.OnPinyinCodeChanging(value);
                    this.SendPropertyChanging();
                    this._PinyinCode = value;
                    this.SendPropertyChanged("PinyinCode");
                    this.OnPinyinCodeChanged();
                }
            }
        }

        [Column(Storage = "_Incorporator", DbType = "VarChar(50)")]
        public string Incorporator
        {
            get
            {
                return this._Incorporator;
            }
            set
            {
                if ((this._Incorporator != value))
                {
                    this.OnIncorporatorChanging(value);
                    this.SendPropertyChanging();
                    this._Incorporator = value;
                    this.SendPropertyChanged("Incorporator");
                    this.OnIncorporatorChanged();
                }
            }
        }

        [Column(Storage = "_NumberOfPeople", DbType = "Int")]
        public System.Nullable<int> NumberOfPeople
        {
            get
            {
                return this._NumberOfPeople;
            }
            set
            {
                if ((this._NumberOfPeople != value))
                {
                    this.OnNumberOfPeopleChanging(value);
                    this.SendPropertyChanging();
                    this._NumberOfPeople = value;
                    this.SendPropertyChanged("NumberOfPeople");
                    this.OnNumberOfPeopleChanged();
                }
            }
        }

        [Column(Storage = "_Tel", DbType = "VarChar(50)")]
        public string Tel
        {
            get
            {
                return this._Tel;
            }
            set
            {
                if ((this._Tel != value))
                {
                    this.OnTelChanging(value);
                    this.SendPropertyChanging();
                    this._Tel = value;
                    this.SendPropertyChanged("Tel");
                    this.OnTelChanged();
                }
            }
        }

        [Column(Storage = "_Fax", DbType = "VarChar(50)")]
        public string Fax
        {
            get
            {
                return this._Fax;
            }
            set
            {
                if ((this._Fax != value))
                {
                    this.OnFaxChanging(value);
                    this.SendPropertyChanging();
                    this._Fax = value;
                    this.SendPropertyChanged("Fax");
                    this.OnFaxChanged();
                }
            }
        }

        [Column(Storage = "_WebSite", DbType = "VarChar(200)")]
        public string WebSite
        {
            get
            {
                return this._WebSite;
            }
            set
            {
                if ((this._WebSite != value))
                {
                    this.OnWebSiteChanging(value);
                    this.SendPropertyChanging();
                    this._WebSite = value;
                    this.SendPropertyChanged("WebSite");
                    this.OnWebSiteChanged();
                }
            }
        }

        [Column(Storage = "_Email", DbType = "VarChar(50)")]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                if ((this._Email != value))
                {
                    this.OnEmailChanging(value);
                    this.SendPropertyChanging();
                    this._Email = value;
                    this.SendPropertyChanged("Email");
                    this.OnEmailChanged();
                }
            }
        }

        [Column(Storage = "_Post", DbType = "VarChar(50)")]
        public string Post
        {
            get
            {
                return this._Post;
            }
            set
            {
                if ((this._Post != value))
                {
                    this.OnPostChanging(value);
                    this.SendPropertyChanging();
                    this._Post = value;
                    this.SendPropertyChanged("Post");
                    this.OnPostChanged();
                }
            }
        }

        [Column(Storage = "_Address", DbType = "VarChar(200)")]
        public string Address
        {
            get
            {
                return this._Address;
            }
            set
            {
                if ((this._Address != value))
                {
                    this.OnAddressChanging(value);
                    this.SendPropertyChanging();
                    this._Address = value;
                    this.SendPropertyChanged("Address");
                    this.OnAddressChanged();
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

        [Column(Storage = "_Mobile", DbType = "VarChar(50)")]
        public string Mobile
        {
            get
            {
                return this._Mobile;
            }
            set
            {
                if ((this._Mobile != value))
                {
                    this.OnMobileChanging(value);
                    this.SendPropertyChanging();
                    this._Mobile = value;
                    this.SendPropertyChanged("Mobile");
                    this.OnMobileChanged();
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

        [Column(Storage = "_CreateTime", DbType = "DateTime")]
        public System.Nullable<System.DateTime> CreateTime
        {
            get
            {
                return this._CreateTime;
            }
            set
            {
                if ((this._CreateTime != value))
                {
                    this.OnCreateTimeChanging(value);
                    this.SendPropertyChanging();
                    this._CreateTime = value;
                    this.SendPropertyChanged("CreateTime");
                    this.OnCreateTimeChanged();
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

        [Association(Name = "FK_CRM_Trader_CRM_Area", Storage = "_CRM_Area", ThisKey = "AreaID", IsForeignKey = true)]
        public CRM_Area CRM_Area
        {
            get
            {
                return this._CRM_Area.Entity;
            }
            set
            {
                CRM_Area previousValue = this._CRM_Area.Entity;
                if (((previousValue != value)
                            || (this._CRM_Area.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._CRM_Area.Entity = null;
                        previousValue.CRM_Trader.Remove(this);
                    }
                    this._CRM_Area.Entity = value;
                    if ((value != null))
                    {
                        value.CRM_Trader.Add(this);
                        this._AreaID = value.ID;
                    }
                    else
                    {
                        this._AreaID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("CRM_Area");
                }
            }
        }

        [Association(Name = "FK_CRM_Trader_CRM_Grade", Storage = "_CRM_Grade", ThisKey = "GradeID", IsForeignKey = true)]
        public CRM_Grade CRM_Grade
        {
            get
            {
                return this._CRM_Grade.Entity;
            }
            set
            {
                CRM_Grade previousValue = this._CRM_Grade.Entity;
                if (((previousValue != value)
                            || (this._CRM_Grade.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._CRM_Grade.Entity = null;
                        previousValue.CRM_Trader.Remove(this);
                    }
                    this._CRM_Grade.Entity = value;
                    if ((value != null))
                    {
                        value.CRM_Trader.Add(this);
                        this._GradeID = value.ID;
                    }
                    else
                    {
                        this._GradeID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("CRM_Grade");
                }
            }
        }

        [Association(Name = "FK_CRM_Trader_CRM_Industry", Storage = "_CRM_Industry", ThisKey = "IndustryID", IsForeignKey = true)]
        public CRM_Industry CRM_Industry
        {
            get
            {
                return this._CRM_Industry.Entity;
            }
            set
            {
                CRM_Industry previousValue = this._CRM_Industry.Entity;
                if (((previousValue != value)
                            || (this._CRM_Industry.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._CRM_Industry.Entity = null;
                        previousValue.CRM_Trader.Remove(this);
                    }
                    this._CRM_Industry.Entity = value;
                    if ((value != null))
                    {
                        value.CRM_Trader.Add(this);
                        this._IndustryID = value.ID;
                    }
                    else
                    {
                        this._IndustryID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("CRM_Industry");
                }
            }
        }

        [Association(Name = "FK_CRM_Trader_CRM_Source", Storage = "_CRM_Source", ThisKey = "SourceID", IsForeignKey = true)]
        public CRM_Source CRM_Source
        {
            get
            {
                return this._CRM_Source.Entity;
            }
            set
            {
                CRM_Source previousValue = this._CRM_Source.Entity;
                if (((previousValue != value)
                            || (this._CRM_Source.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._CRM_Source.Entity = null;
                        previousValue.CRM_Trader.Remove(this);
                    }
                    this._CRM_Source.Entity = value;
                    if ((value != null))
                    {
                        value.CRM_Trader.Add(this);
                        this._SourceID = value.ID;
                    }
                    else
                    {
                        this._SourceID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("CRM_Source");
                }
            }
        }

        [Association(Name = "FK_CRM_Trader_CRM_TraderType", Storage = "_CRM_TraderType", ThisKey = "TypeID", IsForeignKey = true)]
        public CRM_TraderType CRM_TraderType
        {
            get
            {
                return this._CRM_TraderType.Entity;
            }
            set
            {
                CRM_TraderType previousValue = this._CRM_TraderType.Entity;
                if (((previousValue != value)
                            || (this._CRM_TraderType.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._CRM_TraderType.Entity = null;
                        previousValue.CRM_Trader.Remove(this);
                    }
                    this._CRM_TraderType.Entity = value;
                    if ((value != null))
                    {
                        value.CRM_Trader.Add(this);
                        this._TypeID = value.ID;
                    }
                    else
                    {
                        this._TypeID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("CRM_TraderType");
                }
            }
        }

        [Association(Name = "FK_CRM_Trader_HR_Personnel", Storage = "_HR_Personnel", ThisKey = "Handler", IsForeignKey = true)]
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
                        previousValue.CRM_Trader.Remove(this);
                    }
                    this._HR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.CRM_Trader.Add(this);
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

        [Association(Name = "FK_OA_Contract_CRM_Trader", Storage = "_OA_Contract", OtherKey = "TraderID", DeleteRule = "NO ACTION")]
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
            entity.CRM_Trader = this;
        }

        private void detach_OA_Contract(OA_Contract entity)
        {
            this.SendPropertyChanging();
            entity.CRM_Trader = null;
        }
    }
}
