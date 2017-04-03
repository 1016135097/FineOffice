using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Data.Linq;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.ADM_Letter")]
    public partial class ADM_Letter : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private System.Nullable<int> _Receiver;

        private System.Nullable<int> _ChannelID;

        private System.Nullable<int> _TypeID;

        private string _Visitor;

        private System.Nullable<short> _Sex;

        private System.Nullable<int> _Age;

        private string _Mobile;

        private string _Email;

        private string _Tel;

        private string _IDCard;

        private string _Occupation;

        private string _Address;

        private string _LetterNO;

        private string _Title;

        private System.Nullable<int> _NumberOfpeople;

        private string _Area;

        private string _Matter;

        private System.Nullable<System.DateTime> _VisitTime;

        private System.Nullable<int> _Handler;

        private System.Nullable<int> _Recorder;

        private System.Nullable<System.DateTime> _RecordTime;

        private System.Nullable<short> _State;

        private string _Remark;

        private EntityRef<ADM_LetterChannel> _ADM_LetterChannel;

        private EntityRef<ADM_LetterType> _ADM_LetterType;

        private EntityRef<HR_Personnel> _HR_Personnel;

        private EntityRef<HR_Personnel> _RecorderHR_Personnel;

        private EntityRef<HR_Personnel> _ReceiverHR_Personnel;

        private EntitySet<ADM_LetterFollow> _ADM_LetterFollow;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnReceiverChanging(System.Nullable<int> value);
        partial void OnReceiverChanged();
        partial void OnChannelIDChanging(System.Nullable<int> value);
        partial void OnChannelIDChanged();
        partial void OnTypeIDChanging(System.Nullable<int> value);
        partial void OnTypeIDChanged();
        partial void OnVisitorChanging(string value);
        partial void OnVisitorChanged();
        partial void OnSexChanging(System.Nullable<short> value);
        partial void OnSexChanged();
        partial void OnAgeChanging(System.Nullable<int> value);
        partial void OnAgeChanged();
        partial void OnMobileChanging(string value);
        partial void OnMobileChanged();
        partial void OnEmailChanging(string value);
        partial void OnEmailChanged();
        partial void OnTelChanging(string value);
        partial void OnTelChanged();
        partial void OnIDCardChanging(string value);
        partial void OnIDCardChanged();
        partial void OnOccupationChanging(string value);
        partial void OnOccupationChanged();
        partial void OnAddressChanging(string value);
        partial void OnAddressChanged();
        partial void OnLetterNOChanging(string value);
        partial void OnLetterNOChanged();
        partial void OnTitleChanging(string value);
        partial void OnTitleChanged();
        partial void OnNumberOfpeopleChanging(System.Nullable<int> value);
        partial void OnNumberOfpeopleChanged();
        partial void OnAreaChanging(string value);
        partial void OnAreaChanged();
        partial void OnMatterChanging(string value);
        partial void OnMatterChanged();
        partial void OnVisitTimeChanging(System.Nullable<System.DateTime> value);
        partial void OnVisitTimeChanged();
        partial void OnHandlerChanging(System.Nullable<int> value);
        partial void OnHandlerChanged();
        partial void OnRecorderChanging(System.Nullable<int> value);
        partial void OnRecorderChanged();
        partial void OnRecordTimeChanging(System.Nullable<System.DateTime> value);
        partial void OnRecordTimeChanged();
        partial void OnStateChanging(System.Nullable<short> value);
        partial void OnStateChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public ADM_Letter()
        {
            this._ADM_LetterChannel = default(EntityRef<ADM_LetterChannel>);
            this._ADM_LetterType = default(EntityRef<ADM_LetterType>);
            this._HR_Personnel = default(EntityRef<HR_Personnel>);
            this._RecorderHR_Personnel = default(EntityRef<HR_Personnel>);
            this._ReceiverHR_Personnel = default(EntityRef<HR_Personnel>);
            this._ADM_LetterFollow = new EntitySet<ADM_LetterFollow>(new Action<ADM_LetterFollow>(this.attach_ADM_LetterFollow), new Action<ADM_LetterFollow>(this.detach_ADM_LetterFollow));
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

        [Column(Storage = "_Receiver", DbType = "Int")]
        public System.Nullable<int> Receiver
        {
            get
            {
                return this._Receiver;
            }
            set
            {
                if ((this._Receiver != value))
                {
                    if (this._ReceiverHR_Personnel.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnReceiverChanging(value);
                    this.SendPropertyChanging();
                    this._Receiver = value;
                    this.SendPropertyChanged("Receiver");
                    this.OnReceiverChanged();
                }
            }
        }

        [Column(Storage = "_ChannelID", DbType = "Int")]
        public System.Nullable<int> ChannelID
        {
            get
            {
                return this._ChannelID;
            }
            set
            {
                if ((this._ChannelID != value))
                {
                    if (this._ADM_LetterChannel.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnChannelIDChanging(value);
                    this.SendPropertyChanging();
                    this._ChannelID = value;
                    this.SendPropertyChanged("ChannelID");
                    this.OnChannelIDChanged();
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
                    if (this._ADM_LetterType.HasLoadedOrAssignedValue)
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

        [Column(Storage = "_Visitor", DbType = "VarChar(50)")]
        public string Visitor
        {
            get
            {
                return this._Visitor;
            }
            set
            {
                if ((this._Visitor != value))
                {
                    this.OnVisitorChanging(value);
                    this.SendPropertyChanging();
                    this._Visitor = value;
                    this.SendPropertyChanged("Visitor");
                    this.OnVisitorChanged();
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

        [Column(Storage = "_Age", DbType = "Int")]
        public System.Nullable<int> Age
        {
            get
            {
                return this._Age;
            }
            set
            {
                if ((this._Age != value))
                {
                    this.OnAgeChanging(value);
                    this.SendPropertyChanging();
                    this._Age = value;
                    this.SendPropertyChanged("Age");
                    this.OnAgeChanged();
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

        [Column(Storage = "_Email", DbType = "VarChar(100)")]
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

        [Column(Storage = "_LetterNO", DbType = "VarChar(30)")]
        public string LetterNO
        {
            get
            {
                return this._LetterNO;
            }
            set
            {
                if ((this._LetterNO != value))
                {
                    this.OnLetterNOChanging(value);
                    this.SendPropertyChanging();
                    this._LetterNO = value;
                    this.SendPropertyChanged("LetterNO");
                    this.OnLetterNOChanged();
                }
            }
        }

        [Column(Storage = "_Title", DbType = "VarChar(50)")]
        public string Title
        {
            get
            {
                return this._Title;
            }
            set
            {
                if ((this._Title != value))
                {
                    this.OnTitleChanging(value);
                    this.SendPropertyChanging();
                    this._Title = value;
                    this.SendPropertyChanged("Title");
                    this.OnTitleChanged();
                }
            }
        }

        [Column(Storage = "_NumberOfpeople", DbType = "Int")]
        public System.Nullable<int> NumberOfpeople
        {
            get
            {
                return this._NumberOfpeople;
            }
            set
            {
                if ((this._NumberOfpeople != value))
                {
                    this.OnNumberOfpeopleChanging(value);
                    this.SendPropertyChanging();
                    this._NumberOfpeople = value;
                    this.SendPropertyChanged("NumberOfpeople");
                    this.OnNumberOfpeopleChanged();
                }
            }
        }

        [Column(Storage = "_Area", DbType = "VarChar(500)")]
        public string Area
        {
            get
            {
                return this._Area;
            }
            set
            {
                if ((this._Area != value))
                {
                    this.OnAreaChanging(value);
                    this.SendPropertyChanging();
                    this._Area = value;
                    this.SendPropertyChanged("Area");
                    this.OnAreaChanged();
                }
            }
        }

        [Column(Storage = "_Matter", DbType = "VarChar(5000)")]
        public string Matter
        {
            get
            {
                return this._Matter;
            }
            set
            {
                if ((this._Matter != value))
                {
                    this.OnMatterChanging(value);
                    this.SendPropertyChanging();
                    this._Matter = value;
                    this.SendPropertyChanged("Matter");
                    this.OnMatterChanged();
                }
            }
        }

        [Column(Storage = "_VisitTime", DbType = "DateTime")]
        public System.Nullable<System.DateTime> VisitTime
        {
            get
            {
                return this._VisitTime;
            }
            set
            {
                if ((this._VisitTime != value))
                {
                    this.OnVisitTimeChanging(value);
                    this.SendPropertyChanging();
                    this._VisitTime = value;
                    this.SendPropertyChanged("VisitTime");
                    this.OnVisitTimeChanged();
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

        [Column(Storage = "_Recorder", DbType = "Int")]
        public System.Nullable<int> Recorder
        {
            get
            {
                return this._Recorder;
            }
            set
            {
                if ((this._Recorder != value))
                {
                    if (this._RecorderHR_Personnel.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnRecorderChanging(value);
                    this.SendPropertyChanging();
                    this._Recorder = value;
                    this.SendPropertyChanged("Recorder");
                    this.OnRecorderChanged();
                }
            }
        }

        [Column(Storage = "_RecordTime", DbType = "DateTime")]
        public System.Nullable<System.DateTime> RecordTime
        {
            get
            {
                return this._RecordTime;
            }
            set
            {
                if ((this._RecordTime != value))
                {
                    this.OnRecordTimeChanging(value);
                    this.SendPropertyChanging();
                    this._RecordTime = value;
                    this.SendPropertyChanged("RecordTime");
                    this.OnRecordTimeChanged();
                }
            }
        }

        [Column(Storage = "_State", DbType = "SmallInt")]
        public System.Nullable<short> State
        {
            get
            {
                return this._State;
            }
            set
            {
                if ((this._State != value))
                {
                    this.OnStateChanging(value);
                    this.SendPropertyChanging();
                    this._State = value;
                    this.SendPropertyChanged("State");
                    this.OnStateChanged();
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

        [Association(Name = "FK_ADM_Letter_ADM_LetterChannel", Storage = "_ADM_LetterChannel", ThisKey = "ChannelID", IsForeignKey = true)]
        public ADM_LetterChannel ADM_LetterChannel
        {
            get
            {
                return this._ADM_LetterChannel.Entity;
            }
            set
            {
                ADM_LetterChannel previousValue = this._ADM_LetterChannel.Entity;
                if (((previousValue != value)
                            || (this._ADM_LetterChannel.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._ADM_LetterChannel.Entity = null;
                        previousValue.ADM_Letter.Remove(this);
                    }
                    this._ADM_LetterChannel.Entity = value;
                    if ((value != null))
                    {
                        value.ADM_Letter.Add(this);
                        this._ChannelID = value.ID;
                    }
                    else
                    {
                        this._ChannelID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("ADM_LetterChannel");
                }
            }
        }

        [Association(Name = "FK_ADM_Letter_ADM_LetterType", Storage = "_ADM_LetterType", ThisKey = "TypeID", IsForeignKey = true)]
        public ADM_LetterType ADM_LetterType
        {
            get
            {
                return this._ADM_LetterType.Entity;
            }
            set
            {
                ADM_LetterType previousValue = this._ADM_LetterType.Entity;
                if (((previousValue != value)
                            || (this._ADM_LetterType.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._ADM_LetterType.Entity = null;
                        previousValue.ADM_Letter.Remove(this);
                    }
                    this._ADM_LetterType.Entity = value;
                    if ((value != null))
                    {
                        value.ADM_Letter.Add(this);
                        this._TypeID = value.ID;
                    }
                    else
                    {
                        this._TypeID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("ADM_LetterType");
                }
            }
        }

        [Association(Name = "FK_ADM_Letter_Handler", Storage = "_HR_Personnel", ThisKey = "Handler", IsForeignKey = true)]
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
                        previousValue.ADM_Letter.Remove(this);
                    }
                    this._HR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.ADM_Letter.Add(this);
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

        [Association(Name = "FK_ADM_Letter_HR_Recorder", Storage = "_RecorderHR_Personnel", ThisKey = "Recorder", IsForeignKey = true)]
        public HR_Personnel RecorderHR_Personnel
        {
            get
            {
                return this._RecorderHR_Personnel.Entity;
            }
            set
            {
                HR_Personnel previousValue = this._RecorderHR_Personnel.Entity;
                if (((previousValue != value)
                            || (this._RecorderHR_Personnel.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._RecorderHR_Personnel.Entity = null;
                        previousValue.ADM_Letter_HR_Recorder.Remove(this);
                    }
                    this._RecorderHR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.ADM_Letter_HR_Recorder.Add(this);
                        this._Recorder = value.ID;
                    }
                    else
                    {
                        this._Recorder = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("RecorderHR_Personnel");
                }
            }
        }

        [Association(Name = "FK_ADM_Letter_Recipient", Storage = "_ReceiverHR_Personnel", ThisKey = "Receiver", IsForeignKey = true)]
        public HR_Personnel ReceiverHR_Personnel
        {
            get
            {
                return this._ReceiverHR_Personnel.Entity;
            }
            set
            {
                HR_Personnel previousValue = this._ReceiverHR_Personnel.Entity;
                if (((previousValue != value)
                            || (this._ReceiverHR_Personnel.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._ReceiverHR_Personnel.Entity = null;
                        previousValue.ADM_Letter_Recipient.Remove(this);
                    }
                    this._ReceiverHR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.ADM_Letter_Recipient.Add(this);
                        this._Receiver = value.ID;
                    }
                    else
                    {
                        this._Receiver = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("ReceiverHR_Personnel");
                }
            }
        }

        [Association(Name = "FK_ADM_LetterFollow_ADM_Letter", Storage = "_ADM_LetterFollow", OtherKey = "LetterID", DeleteRule = "NO ACTION")]
        public EntitySet<ADM_LetterFollow> ADM_LetterFollow
        {
            get
            {
                return this._ADM_LetterFollow;
            }
            set
            {
                this._ADM_LetterFollow.Assign(value);
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

        private void attach_ADM_LetterFollow(ADM_LetterFollow entity)
        {
            this.SendPropertyChanging();
            entity.ADM_Letter = this;
        }

        private void detach_ADM_LetterFollow(ADM_LetterFollow entity)
        {
            this.SendPropertyChanging();
            entity.ADM_Letter = null;
        }
    }
}
