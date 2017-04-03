using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Data.Linq;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.CNS_CensusMember")]
    public partial class CNS_CensusMember : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _RegisterNO;

        private string _Name;

        private string _Tel;

        private string _Relation;

        private string _OtherName;

        private System.Nullable<short> _Sex;

        private string _PlaceOfBirth;

        private string _Nationalilty;

        private string _PlaceOfAncestral;

        private System.Nullable<System.DateTime> _Brithday;

        private string _Address;

        private string _Religion;

        private string _IDCard;

        private string _Height;

        private string _TypeOfBlood;

        private System.Nullable<int> _EducationID;

        private string _Marriage;

        private string _MilitaryService;

        private string _Company;

        private string _Occupation;

        private System.Nullable<int> _PoliticalID;

        private System.Nullable<System.DateTime> _IngoingDate;

        private string _PreviousAddress;

        private string _IngoingReason;

        private System.Nullable<System.DateTime> _MoveOutDate;

        private string _MoveToAddress;

        private System.Nullable<bool> _IsCanceled;

        private System.Nullable<System.DateTime> _CancelDate;

        private string _CancelReason;

        private string _Remark;

        private EntityRef<AM_Kind> _AM_Kind;

        private EntityRef<CNS_PoliticalAffiliation> _CNS_PoliticalAffiliation;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnRegisterNOChanging(string value);
        partial void OnRegisterNOChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnTelChanging(string value);
        partial void OnTelChanged();
        partial void OnRelationChanging(string value);
        partial void OnRelationChanged();
        partial void OnOtherNameChanging(string value);
        partial void OnOtherNameChanged();
        partial void OnSexChanging(System.Nullable<short> value);
        partial void OnSexChanged();
        partial void OnPlaceOfBirthChanging(string value);
        partial void OnPlaceOfBirthChanged();
        partial void OnNationaliltyChanging(string value);
        partial void OnNationaliltyChanged();
        partial void OnPlaceOfAncestralChanging(string value);
        partial void OnPlaceOfAncestralChanged();
        partial void OnBrithdayChanging(System.Nullable<System.DateTime> value);
        partial void OnBrithdayChanged();
        partial void OnAddressChanging(string value);
        partial void OnAddressChanged();
        partial void OnReligionChanging(string value);
        partial void OnReligionChanged();
        partial void OnIDCardChanging(string value);
        partial void OnIDCardChanged();
        partial void OnHeightChanging(string value);
        partial void OnHeightChanged();
        partial void OnTypeOfBloodChanging(string value);
        partial void OnTypeOfBloodChanged();
        partial void OnEducationIDChanging(System.Nullable<int> value);
        partial void OnEducationIDChanged();
        partial void OnMarriageChanging(string value);
        partial void OnMarriageChanged();
        partial void OnMilitaryServiceChanging(string value);
        partial void OnMilitaryServiceChanged();
        partial void OnCompanyChanging(string value);
        partial void OnCompanyChanged();
        partial void OnOccupationChanging(string value);
        partial void OnOccupationChanged();
        partial void OnPoliticalIDChanging(System.Nullable<int> value);
        partial void OnPoliticalIDChanged();
        partial void OnIngoingDateChanging(System.Nullable<System.DateTime> value);
        partial void OnIngoingDateChanged();
        partial void OnPreviousAddressChanging(string value);
        partial void OnPreviousAddressChanged();
        partial void OnIngoingReasonChanging(string value);
        partial void OnIngoingReasonChanged();
        partial void OnMoveOutDateChanging(System.Nullable<System.DateTime> value);
        partial void OnMoveOutDateChanged();
        partial void OnMoveToAddressChanging(string value);
        partial void OnMoveToAddressChanged();
        partial void OnIsCanceledChanging(System.Nullable<bool> value);
        partial void OnIsCanceledChanged();
        partial void OnCancelDateChanging(System.Nullable<System.DateTime> value);
        partial void OnCancelDateChanged();
        partial void OnCancelReasonChanging(string value);
        partial void OnCancelReasonChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public CNS_CensusMember()
        {
            this._AM_Kind = default(EntityRef<AM_Kind>);
            this._CNS_PoliticalAffiliation = default(EntityRef<CNS_PoliticalAffiliation>);
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

        [Column(Storage = "_Name", DbType = "VarChar(50)")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if ((this._Name != value))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._Name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
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

        [Column(Storage = "_Relation", DbType = "VarChar(50)")]
        public string Relation
        {
            get
            {
                return this._Relation;
            }
            set
            {
                if ((this._Relation != value))
                {
                    this.OnRelationChanging(value);
                    this.SendPropertyChanging();
                    this._Relation = value;
                    this.SendPropertyChanged("Relation");
                    this.OnRelationChanged();
                }
            }
        }

        [Column(Storage = "_OtherName", DbType = "VarChar(50)")]
        public string OtherName
        {
            get
            {
                return this._OtherName;
            }
            set
            {
                if ((this._OtherName != value))
                {
                    this.OnOtherNameChanging(value);
                    this.SendPropertyChanging();
                    this._OtherName = value;
                    this.SendPropertyChanged("OtherName");
                    this.OnOtherNameChanged();
                }
            }
        }

        [Column(Storage = "_Sex", DbType = "SmallInt")]
        public System.Nullable<short> Sex
        {
            get
            {
                return this._Sex;
            }
            set
            {
                if ((this._Sex != value))
                {
                    this.OnSexChanging(value);
                    this.SendPropertyChanging();
                    this._Sex = value;
                    this.SendPropertyChanged("Sex");
                    this.OnSexChanged();
                }
            }
        }

        [Column(Storage = "_PlaceOfBirth", DbType = "VarChar(500)")]
        public string PlaceOfBirth
        {
            get
            {
                return this._PlaceOfBirth;
            }
            set
            {
                if ((this._PlaceOfBirth != value))
                {
                    this.OnPlaceOfBirthChanging(value);
                    this.SendPropertyChanging();
                    this._PlaceOfBirth = value;
                    this.SendPropertyChanged("PlaceOfBirth");
                    this.OnPlaceOfBirthChanged();
                }
            }
        }

        [Column(Storage = "_Nationalilty", DbType = "VarChar(50)")]
        public string Nationalilty
        {
            get
            {
                return this._Nationalilty;
            }
            set
            {
                if ((this._Nationalilty != value))
                {
                    this.OnNationaliltyChanging(value);
                    this.SendPropertyChanging();
                    this._Nationalilty = value;
                    this.SendPropertyChanged("Nationalilty");
                    this.OnNationaliltyChanged();
                }
            }
        }

        [Column(Storage = "_PlaceOfAncestral", DbType = "VarChar(100)")]
        public string PlaceOfAncestral
        {
            get
            {
                return this._PlaceOfAncestral;
            }
            set
            {
                if ((this._PlaceOfAncestral != value))
                {
                    this.OnPlaceOfAncestralChanging(value);
                    this.SendPropertyChanging();
                    this._PlaceOfAncestral = value;
                    this.SendPropertyChanged("PlaceOfAncestral");
                    this.OnPlaceOfAncestralChanged();
                }
            }
        }

        [Column(Storage = "_Brithday", DbType = "DateTime")]
        public System.Nullable<System.DateTime> Brithday
        {
            get
            {
                return this._Brithday;
            }
            set
            {
                if ((this._Brithday != value))
                {
                    this.OnBrithdayChanging(value);
                    this.SendPropertyChanging();
                    this._Brithday = value;
                    this.SendPropertyChanged("Brithday");
                    this.OnBrithdayChanged();
                }
            }
        }

        [Column(Storage = "_Address", DbType = "VarChar(500)")]
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

        [Column(Storage = "_Religion", DbType = "VarChar(50)")]
        public string Religion
        {
            get
            {
                return this._Religion;
            }
            set
            {
                if ((this._Religion != value))
                {
                    this.OnReligionChanging(value);
                    this.SendPropertyChanging();
                    this._Religion = value;
                    this.SendPropertyChanged("Religion");
                    this.OnReligionChanged();
                }
            }
        }

        [Column(Storage = "_IDCard", DbType = "VarChar(50)")]
        public string IDCard
        {
            get
            {
                return this._IDCard;
            }
            set
            {
                if ((this._IDCard != value))
                {
                    this.OnIDCardChanging(value);
                    this.SendPropertyChanging();
                    this._IDCard = value;
                    this.SendPropertyChanged("IDCard");
                    this.OnIDCardChanged();
                }
            }
        }

        [Column(Storage = "_Height", DbType = "VarChar(50)")]
        public string Height
        {
            get
            {
                return this._Height;
            }
            set
            {
                if ((this._Height != value))
                {
                    this.OnHeightChanging(value);
                    this.SendPropertyChanging();
                    this._Height = value;
                    this.SendPropertyChanged("Height");
                    this.OnHeightChanged();
                }
            }
        }

        [Column(Storage = "_TypeOfBlood", DbType = "VarChar(50)")]
        public string TypeOfBlood
        {
            get
            {
                return this._TypeOfBlood;
            }
            set
            {
                if ((this._TypeOfBlood != value))
                {
                    this.OnTypeOfBloodChanging(value);
                    this.SendPropertyChanging();
                    this._TypeOfBlood = value;
                    this.SendPropertyChanged("TypeOfBlood");
                    this.OnTypeOfBloodChanged();
                }
            }
        }

        [Column(Storage = "_EducationID", DbType = "Int")]
        public System.Nullable<int> EducationID
        {
            get
            {
                return this._EducationID;
            }
            set
            {
                if ((this._EducationID != value))
                {
                    if (this._AM_Kind.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnEducationIDChanging(value);
                    this.SendPropertyChanging();
                    this._EducationID = value;
                    this.SendPropertyChanged("EducationID");
                    this.OnEducationIDChanged();
                }
            }
        }

        [Column(Storage = "_Marriage", DbType = "VarChar(50)")]
        public string Marriage
        {
            get
            {
                return this._Marriage;
            }
            set
            {
                if ((this._Marriage != value))
                {
                    this.OnMarriageChanging(value);
                    this.SendPropertyChanging();
                    this._Marriage = value;
                    this.SendPropertyChanged("Marriage");
                    this.OnMarriageChanged();
                }
            }
        }

        [Column(Storage = "_MilitaryService", DbType = "VarChar(50)")]
        public string MilitaryService
        {
            get
            {
                return this._MilitaryService;
            }
            set
            {
                if ((this._MilitaryService != value))
                {
                    this.OnMilitaryServiceChanging(value);
                    this.SendPropertyChanging();
                    this._MilitaryService = value;
                    this.SendPropertyChanged("MilitaryService");
                    this.OnMilitaryServiceChanged();
                }
            }
        }

        [Column(Storage = "_Company", DbType = "VarChar(50)")]
        public string Company
        {
            get
            {
                return this._Company;
            }
            set
            {
                if ((this._Company != value))
                {
                    this.OnCompanyChanging(value);
                    this.SendPropertyChanging();
                    this._Company = value;
                    this.SendPropertyChanged("Company");
                    this.OnCompanyChanged();
                }
            }
        }

        [Column(Storage = "_Occupation", DbType = "VarChar(50)")]
        public string Occupation
        {
            get
            {
                return this._Occupation;
            }
            set
            {
                if ((this._Occupation != value))
                {
                    this.OnOccupationChanging(value);
                    this.SendPropertyChanging();
                    this._Occupation = value;
                    this.SendPropertyChanged("Occupation");
                    this.OnOccupationChanged();
                }
            }
        }

        [Column(Storage = "_PoliticalID", DbType = "Int")]
        public System.Nullable<int> PoliticalID
        {
            get
            {
                return this._PoliticalID;
            }
            set
            {
                if ((this._PoliticalID != value))
                {
                    if (this._CNS_PoliticalAffiliation.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnPoliticalIDChanging(value);
                    this.SendPropertyChanging();
                    this._PoliticalID = value;
                    this.SendPropertyChanged("PoliticalID");
                    this.OnPoliticalIDChanged();
                }
            }
        }

        [Column(Storage = "_IngoingDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> IngoingDate
        {
            get
            {
                return this._IngoingDate;
            }
            set
            {
                if ((this._IngoingDate != value))
                {
                    this.OnIngoingDateChanging(value);
                    this.SendPropertyChanging();
                    this._IngoingDate = value;
                    this.SendPropertyChanged("IngoingDate");
                    this.OnIngoingDateChanged();
                }
            }
        }

        [Column(Storage = "_PreviousAddress", DbType = "VarChar(500)")]
        public string PreviousAddress
        {
            get
            {
                return this._PreviousAddress;
            }
            set
            {
                if ((this._PreviousAddress != value))
                {
                    this.OnPreviousAddressChanging(value);
                    this.SendPropertyChanging();
                    this._PreviousAddress = value;
                    this.SendPropertyChanged("PreviousAddress");
                    this.OnPreviousAddressChanged();
                }
            }
        }

        [Column(Storage = "_IngoingReason", DbType = "VarChar(500)")]
        public string IngoingReason
        {
            get
            {
                return this._IngoingReason;
            }
            set
            {
                if ((this._IngoingReason != value))
                {
                    this.OnIngoingReasonChanging(value);
                    this.SendPropertyChanging();
                    this._IngoingReason = value;
                    this.SendPropertyChanged("IngoingReason");
                    this.OnIngoingReasonChanged();
                }
            }
        }

        [Column(Storage = "_MoveOutDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> MoveOutDate
        {
            get
            {
                return this._MoveOutDate;
            }
            set
            {
                if ((this._MoveOutDate != value))
                {
                    this.OnMoveOutDateChanging(value);
                    this.SendPropertyChanging();
                    this._MoveOutDate = value;
                    this.SendPropertyChanged("MoveOutDate");
                    this.OnMoveOutDateChanged();
                }
            }
        }

        [Column(Storage = "_MoveToAddress", DbType = "VarChar(50)")]
        public string MoveToAddress
        {
            get
            {
                return this._MoveToAddress;
            }
            set
            {
                if ((this._MoveToAddress != value))
                {
                    this.OnMoveToAddressChanging(value);
                    this.SendPropertyChanging();
                    this._MoveToAddress = value;
                    this.SendPropertyChanged("MoveToAddress");
                    this.OnMoveToAddressChanged();
                }
            }
        }

        [Column(Storage = "_IsCanceled", DbType = "Bit")]
        public System.Nullable<bool> IsCanceled
        {
            get
            {
                return this._IsCanceled;
            }
            set
            {
                if ((this._IsCanceled != value))
                {
                    this.OnIsCanceledChanging(value);
                    this.SendPropertyChanging();
                    this._IsCanceled = value;
                    this.SendPropertyChanged("IsCanceled");
                    this.OnIsCanceledChanged();
                }
            }
        }

        [Column(Storage = "_CancelDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> CancelDate
        {
            get
            {
                return this._CancelDate;
            }
            set
            {
                if ((this._CancelDate != value))
                {
                    this.OnCancelDateChanging(value);
                    this.SendPropertyChanging();
                    this._CancelDate = value;
                    this.SendPropertyChanged("CancelDate");
                    this.OnCancelDateChanged();
                }
            }
        }

        [Column(Storage = "_CancelReason", DbType = "VarChar(500)")]
        public string CancelReason
        {
            get
            {
                return this._CancelReason;
            }
            set
            {
                if ((this._CancelReason != value))
                {
                    this.OnCancelReasonChanging(value);
                    this.SendPropertyChanging();
                    this._CancelReason = value;
                    this.SendPropertyChanged("CancelReason");
                    this.OnCancelReasonChanged();
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

        [Association(Name = "FK_CNS_CensusMember_AM_Kind", Storage = "_AM_Kind", ThisKey = "EducationID", IsForeignKey = true)]
        public AM_Kind AM_Kind
        {
            get
            {
                return this._AM_Kind.Entity;
            }
            set
            {
                AM_Kind previousValue = this._AM_Kind.Entity;
                if (((previousValue != value)
                            || (this._AM_Kind.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._AM_Kind.Entity = null;
                        previousValue.CNS_CensusMember.Remove(this);
                    }
                    this._AM_Kind.Entity = value;
                    if ((value != null))
                    {
                        value.CNS_CensusMember.Add(this);
                        this._EducationID = value.ID;
                    }
                    else
                    {
                        this._EducationID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("AM_Kind");
                }
            }
        }

        [Association(Name = "FK_CNS_CensusMember_CNS_PoliticalAffiliation", Storage = "_CNS_PoliticalAffiliation", ThisKey = "PoliticalID", IsForeignKey = true)]
        public CNS_PoliticalAffiliation CNS_PoliticalAffiliation
        {
            get
            {
                return this._CNS_PoliticalAffiliation.Entity;
            }
            set
            {
                CNS_PoliticalAffiliation previousValue = this._CNS_PoliticalAffiliation.Entity;
                if (((previousValue != value)
                            || (this._CNS_PoliticalAffiliation.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._CNS_PoliticalAffiliation.Entity = null;
                        previousValue.CNS_CensusMember.Remove(this);
                    }
                    this._CNS_PoliticalAffiliation.Entity = value;
                    if ((value != null))
                    {
                        value.CNS_CensusMember.Add(this);
                        this._PoliticalID = value.ID;
                    }
                    else
                    {
                        this._PoliticalID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("CNS_PoliticalAffiliation");
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
