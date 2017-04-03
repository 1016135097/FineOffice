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
    [Table(Name = "dbo.HR_Personnel")]
    public partial class HR_Personnel : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _PersonnelNO;

        private System.Nullable<int> _JobID;

        private System.Nullable<int> _DepartmentID;

        private string _Name;

        private string _PinyinCode;

        private System.Nullable<System.DateTime> _DateOfBirth;

        private System.Nullable<short> _Sex;

        private string _NativePlace;

        private System.Nullable<int> _EducationID;

        private System.Nullable<System.DateTime> _EntryDate;

        private System.Nullable<System.DateTime> _ExitDate;

        private System.Nullable<bool> _Stop;

        private string _BankingAccount;

        private string _HomeTelephone;

        private string _Linkman;

        private string _Mobile;

        private string _Email;

        private string _Address;

        private string _Post;

        private string _Remark;

        private EntitySet<ADM_Letter> _ADM_Letter;

        private EntitySet<ADM_Letter> _ADM_Letter_HR_Recorder;

        private EntitySet<ADM_Letter> _ADM_Letter_Recipient;

        private EntitySet<ADM_LetterFollow> _ADM_LetterFollow;

        private EntitySet<OA_Attachment> _OA_Attachment;

        private EntitySet<CRM_Trader> _CRM_Trader;

        private EntitySet<HD_Folder> _HD_Folder;

        private EntityRef<HR_Department> _HR_Department;

        private EntityRef<HR_Job> _HR_Job;

        private EntityRef<AM_Kind> _AM_Kind;

        private EntitySet<HD_Attachment> _HD_Attachment;

        private EntitySet<OA_Contract> _OA_Contract;

        private EntitySet<OA_Flow> _OA_Flow;

        private EntitySet<OA_FlowAuthority> _OA_FlowAuthority;

        private EntitySet<OA_FlowRun> _OA_FlowRun;

        private EntitySet<OA_FlowRunFeedback> _OA_FlowRunFeedback;

        private EntitySet<OA_FlowRunProcess> _OA_FlowRunProcess;

        private EntitySet<OA_FlowRunProcess> _OA_FlowRunProcess_HR_Personnel;

        private EntitySet<OA_Form> _OA_Form;

        private EntitySet<OA_FormType> _OA_FormType;

        private EntitySet<OA_ProcessAuthority> _OA_ProcessAuthority;

        private EntitySet<OA_Programme> _OA_Programme;

        private EntitySet<SYS_User> _SYS_User;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnPersonnelNOChanging(string value);
        partial void OnPersonnelNOChanged();
        partial void OnJobIDChanging(System.Nullable<int> value);
        partial void OnJobIDChanged();
        partial void OnDepartmentIDChanging(System.Nullable<int> value);
        partial void OnDepartmentIDChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnPinyinCodeChanging(string value);
        partial void OnPinyinCodeChanged();
        partial void OnDateOfBirthChanging(System.Nullable<System.DateTime> value);
        partial void OnDateOfBirthChanged();
        partial void OnSexChanging(System.Nullable<short> value);
        partial void OnSexChanged();
        partial void OnNativePlaceChanging(string value);
        partial void OnNativePlaceChanged();
        partial void OnEducationIDChanging(System.Nullable<int> value);
        partial void OnEducationIDChanged();
        partial void OnEntryDateChanging(System.Nullable<System.DateTime> value);
        partial void OnEntryDateChanged();
        partial void OnExitDateChanging(System.Nullable<System.DateTime> value);
        partial void OnExitDateChanged();
        partial void OnStopChanging(System.Nullable<bool> value);
        partial void OnStopChanged();
        partial void OnBankingAccountChanging(string value);
        partial void OnBankingAccountChanged();
        partial void OnHomeTelephoneChanging(string value);
        partial void OnHomeTelephoneChanged();
        partial void OnLinkmanChanging(string value);
        partial void OnLinkmanChanged();
        partial void OnMobileChanging(string value);
        partial void OnMobileChanged();
        partial void OnEmailChanging(string value);
        partial void OnEmailChanged();
        partial void OnAddressChanging(string value);
        partial void OnAddressChanged();
        partial void OnPostChanging(string value);
        partial void OnPostChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public HR_Personnel()
        {
            this._ADM_Letter = new EntitySet<ADM_Letter>(new Action<ADM_Letter>(this.attach_ADM_Letter), new Action<ADM_Letter>(this.detach_ADM_Letter));
            this._ADM_Letter_HR_Recorder = new EntitySet<ADM_Letter>(new Action<ADM_Letter>(this.attach_ADM_Letter_HR_Recorder), new Action<ADM_Letter>(this.detach_ADM_Letter_HR_Recorder));
            this._ADM_Letter_Recipient = new EntitySet<ADM_Letter>(new Action<ADM_Letter>(this.attach_ADM_Letter_Recipient), new Action<ADM_Letter>(this.detach_ADM_Letter_Recipient));
            this._ADM_LetterFollow = new EntitySet<ADM_LetterFollow>(new Action<ADM_LetterFollow>(this.attach_ADM_LetterFollow), new Action<ADM_LetterFollow>(this.detach_ADM_LetterFollow));
            this._OA_Attachment = new EntitySet<OA_Attachment>(new Action<OA_Attachment>(this.attach_OA_Attachment), new Action<OA_Attachment>(this.detach_OA_Attachment));
            this._CRM_Trader = new EntitySet<CRM_Trader>(new Action<CRM_Trader>(this.attach_CRM_Trader), new Action<CRM_Trader>(this.detach_CRM_Trader));
            this._HD_Folder = new EntitySet<HD_Folder>(new Action<HD_Folder>(this.attach_HD_Folder), new Action<HD_Folder>(this.detach_HD_Folder));
            this._HR_Department = default(EntityRef<HR_Department>);
            this._HR_Job = default(EntityRef<HR_Job>);
            this._AM_Kind = default(EntityRef<AM_Kind>);
            this._HD_Attachment = new EntitySet<HD_Attachment>(new Action<HD_Attachment>(this.attach_HD_Attachment), new Action<HD_Attachment>(this.detach_HD_Attachment));
            this._OA_Contract = new EntitySet<OA_Contract>(new Action<OA_Contract>(this.attach_OA_Contract), new Action<OA_Contract>(this.detach_OA_Contract));
            this._OA_Flow = new EntitySet<OA_Flow>(new Action<OA_Flow>(this.attach_OA_Flow), new Action<OA_Flow>(this.detach_OA_Flow));
            this._OA_FlowAuthority = new EntitySet<OA_FlowAuthority>(new Action<OA_FlowAuthority>(this.attach_OA_FlowAuthority), new Action<OA_FlowAuthority>(this.detach_OA_FlowAuthority));
            this._OA_FlowRun = new EntitySet<OA_FlowRun>(new Action<OA_FlowRun>(this.attach_OA_FlowRun), new Action<OA_FlowRun>(this.detach_OA_FlowRun));
            this._OA_FlowRunFeedback = new EntitySet<OA_FlowRunFeedback>(new Action<OA_FlowRunFeedback>(this.attach_OA_FlowRunFeedback), new Action<OA_FlowRunFeedback>(this.detach_OA_FlowRunFeedback));
            this._OA_FlowRunProcess = new EntitySet<OA_FlowRunProcess>(new Action<OA_FlowRunProcess>(this.attach_OA_FlowRunProcess), new Action<OA_FlowRunProcess>(this.detach_OA_FlowRunProcess));
            this._OA_FlowRunProcess_HR_Personnel = new EntitySet<OA_FlowRunProcess>(new Action<OA_FlowRunProcess>(this.attach_OA_FlowRunProcess_HR_Personnel), new Action<OA_FlowRunProcess>(this.detach_OA_FlowRunProcess_HR_Personnel));
            this._OA_Form = new EntitySet<OA_Form>(new Action<OA_Form>(this.attach_OA_Form), new Action<OA_Form>(this.detach_OA_Form));
            this._OA_FormType = new EntitySet<OA_FormType>(new Action<OA_FormType>(this.attach_OA_FormType), new Action<OA_FormType>(this.detach_OA_FormType));
            this._OA_ProcessAuthority = new EntitySet<OA_ProcessAuthority>(new Action<OA_ProcessAuthority>(this.attach_OA_ProcessAuthority), new Action<OA_ProcessAuthority>(this.detach_OA_ProcessAuthority));
            this._OA_Programme = new EntitySet<OA_Programme>(new Action<OA_Programme>(this.attach_OA_Programme), new Action<OA_Programme>(this.detach_OA_Programme));
            this._SYS_User = new EntitySet<SYS_User>(new Action<SYS_User>(this.attach_SYS_User), new Action<SYS_User>(this.detach_SYS_User));
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

        [Column(Storage = "_PersonnelNO", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
        public string PersonnelNO
        {
            get
            {
                return this._PersonnelNO;
            }
            set
            {
                if ((this._PersonnelNO != value))
                {
                    this.OnPersonnelNOChanging(value);
                    this.SendPropertyChanging();
                    this._PersonnelNO = value;
                    this.SendPropertyChanged("PersonnelNO");
                    this.OnPersonnelNOChanged();
                }
            }
        }

        [Column(Storage = "_JobID", DbType = "Int")]
        public System.Nullable<int> JobID
        {
            get
            {
                return this._JobID;
            }
            set
            {
                if ((this._JobID != value))
                {
                    if (this._HR_Job.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnJobIDChanging(value);
                    this.SendPropertyChanging();
                    this._JobID = value;
                    this.SendPropertyChanged("JobID");
                    this.OnJobIDChanged();
                }
            }
        }

        [Column(Storage = "_DepartmentID", DbType = "Int")]
        public System.Nullable<int> DepartmentID
        {
            get
            {
                return this._DepartmentID;
            }
            set
            {
                if ((this._DepartmentID != value))
                {
                    if (this._HR_Department.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnDepartmentIDChanging(value);
                    this.SendPropertyChanging();
                    this._DepartmentID = value;
                    this.SendPropertyChanged("DepartmentID");
                    this.OnDepartmentIDChanged();
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

        [Column(Storage = "_PinyinCode", DbType = "VarChar(30)")]
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

        [Column(Storage = "_DateOfBirth", DbType = "DateTime")]
        public System.Nullable<System.DateTime> DateOfBirth
        {
            get
            {
                return this._DateOfBirth;
            }
            set
            {
                if ((this._DateOfBirth != value))
                {
                    this.OnDateOfBirthChanging(value);
                    this.SendPropertyChanging();
                    this._DateOfBirth = value;
                    this.SendPropertyChanged("DateOfBirth");
                    this.OnDateOfBirthChanged();
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

        [Column(Storage = "_NativePlace", DbType = "VarChar(12)")]
        public string NativePlace
        {
            get
            {
                return this._NativePlace;
            }
            set
            {
                if ((this._NativePlace != value))
                {
                    this.OnNativePlaceChanging(value);
                    this.SendPropertyChanging();
                    this._NativePlace = value;
                    this.SendPropertyChanged("NativePlace");
                    this.OnNativePlaceChanged();
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

        [Column(Storage = "_EntryDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> EntryDate
        {
            get
            {
                return this._EntryDate;
            }
            set
            {
                if ((this._EntryDate != value))
                {
                    this.OnEntryDateChanging(value);
                    this.SendPropertyChanging();
                    this._EntryDate = value;
                    this.SendPropertyChanged("EntryDate");
                    this.OnEntryDateChanged();
                }
            }
        }

        [Column(Storage = "_ExitDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> ExitDate
        {
            get
            {
                return this._ExitDate;
            }
            set
            {
                if ((this._ExitDate != value))
                {
                    this.OnExitDateChanging(value);
                    this.SendPropertyChanging();
                    this._ExitDate = value;
                    this.SendPropertyChanged("ExitDate");
                    this.OnExitDateChanged();
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

        [Column(Storage = "_BankingAccount", DbType = "VarChar(50)")]
        public string BankingAccount
        {
            get
            {
                return this._BankingAccount;
            }
            set
            {
                if ((this._BankingAccount != value))
                {
                    this.OnBankingAccountChanging(value);
                    this.SendPropertyChanging();
                    this._BankingAccount = value;
                    this.SendPropertyChanged("BankingAccount");
                    this.OnBankingAccountChanged();
                }
            }
        }

        [Column(Storage = "_HomeTelephone", DbType = "VarChar(50)")]
        public string HomeTelephone
        {
            get
            {
                return this._HomeTelephone;
            }
            set
            {
                if ((this._HomeTelephone != value))
                {
                    this.OnHomeTelephoneChanging(value);
                    this.SendPropertyChanging();
                    this._HomeTelephone = value;
                    this.SendPropertyChanged("HomeTelephone");
                    this.OnHomeTelephoneChanged();
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

        [Column(Storage = "_Address", DbType = "VarChar(50)")]
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

        [Column(Storage = "_Post", DbType = "VarChar(10)")]
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

        [Association(Name = "FK_ADM_Letter_Handler", Storage = "_ADM_Letter", OtherKey = "Handler", DeleteRule = "NO ACTION")]
        public EntitySet<ADM_Letter> ADM_Letter
        {
            get
            {
                return this._ADM_Letter;
            }
            set
            {
                this._ADM_Letter.Assign(value);
            }
        }

        [Association(Name = "FK_ADM_Letter_HR_Recorder", Storage = "_ADM_Letter_HR_Recorder", OtherKey = "Recorder", DeleteRule = "NO ACTION")]
        public EntitySet<ADM_Letter> ADM_Letter_HR_Recorder
        {
            get
            {
                return this._ADM_Letter_HR_Recorder;
            }
            set
            {
                this._ADM_Letter_HR_Recorder.Assign(value);
            }
        }

        [Association(Name = "FK_ADM_Letter_Recipient", Storage = "_ADM_Letter_Recipient", OtherKey = "Receiver", DeleteRule = "NO ACTION")]
        public EntitySet<ADM_Letter> ADM_Letter_Recipient
        {
            get
            {
                return this._ADM_Letter_Recipient;
            }
            set
            {
                this._ADM_Letter_Recipient.Assign(value);
            }
        }

        [Association(Name = "FK_ADM_LetterFollow_Handler", Storage = "_ADM_LetterFollow", OtherKey = "Handler", DeleteRule = "NO ACTION")]
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

        [Association(Name = "FK_BNS_ATT_HR_PERSONNEL", Storage = "_OA_Attachment", OtherKey = "PersonnelID", DeleteRule = "NO ACTION")]
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

        [Association(Name = "FK_CRM_Trader_HR_Personnel", Storage = "_CRM_Trader", OtherKey = "Handler", DeleteRule = "NO ACTION")]
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

        [Association(Name = "FK_HD_Folder_HR_Personnel", Storage = "_HD_Folder", OtherKey = "PersonnelID", DeleteRule = "NO ACTION")]
        public EntitySet<HD_Folder> HD_Folder
        {
            get
            {
                return this._HD_Folder;
            }
            set
            {
                this._HD_Folder.Assign(value);
            }
        }

        [Association(Name = "FK_HR_PERSO_REFERENCE_HR_DEPAR", Storage = "_HR_Department", ThisKey = "DepartmentID", IsForeignKey = true)]
        public HR_Department HR_Department
        {
            get
            {
                return this._HR_Department.Entity;
            }
            set
            {
                HR_Department previousValue = this._HR_Department.Entity;
                if (((previousValue != value)
                            || (this._HR_Department.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HR_Department.Entity = null;
                        previousValue.HR_Personnel.Remove(this);
                    }
                    this._HR_Department.Entity = value;
                    if ((value != null))
                    {
                        value.HR_Personnel.Add(this);
                        this._DepartmentID = value.ID;
                    }
                    else
                    {
                        this._DepartmentID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_Department");
                }
            }
        }

        [Association(Name = "FK_HR_PERSO_REFERENCE_HR_JOB", Storage = "_HR_Job", ThisKey = "JobID", IsForeignKey = true)]
        public HR_Job HR_Job
        {
            get
            {
                return this._HR_Job.Entity;
            }
            set
            {
                HR_Job previousValue = this._HR_Job.Entity;
                if (((previousValue != value)
                            || (this._HR_Job.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._HR_Job.Entity = null;
                        previousValue.HR_Personnel.Remove(this);
                    }
                    this._HR_Job.Entity = value;
                    if ((value != null))
                    {
                        value.HR_Personnel.Add(this);
                        this._JobID = value.ID;
                    }
                    else
                    {
                        this._JobID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_Job");
                }
            }
        }

        [Association(Name = "FK_HR_PERSONNEL_AM_KIND", Storage = "_AM_Kind", ThisKey = "EducationID", IsForeignKey = true)]
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
                        previousValue.HR_Personnel.Remove(this);
                    }
                    this._AM_Kind.Entity = value;
                    if ((value != null))
                    {
                        value.HR_Personnel.Add(this);
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

        [Association(Name = "FK_OA_Com_Attachment_HR_Personnel", Storage = "_HD_Attachment", OtherKey = "PersonnelID", DeleteRule = "NO ACTION")]
        public EntitySet<HD_Attachment> HD_Attachment
        {
            get
            {
                return this._HD_Attachment;
            }
            set
            {
                this._HD_Attachment.Assign(value);
            }
        }

        [Association(Name = "FK_OA_Contract_HR_Personnel", Storage = "_OA_Contract", OtherKey = "Handler", DeleteRule = "NO ACTION")]
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

        [Association(Name = "FK_OA_FLOW_HR_PERSONNEL", Storage = "_OA_Flow", OtherKey = "Creator", DeleteRule = "NO ACTION")]
        public EntitySet<OA_Flow> OA_Flow
        {
            get
            {
                return this._OA_Flow;
            }
            set
            {
                this._OA_Flow.Assign(value);
            }
        }

        [Association(Name = "FK_OA_FLOW_PERSONNEL", Storage = "_OA_FlowAuthority", OtherKey = "PersonnelID", DeleteRule = "NO ACTION")]
        public EntitySet<OA_FlowAuthority> OA_FlowAuthority
        {
            get
            {
                return this._OA_FlowAuthority;
            }
            set
            {
                this._OA_FlowAuthority.Assign(value);
            }
        }

        [Association(Name = "FK_OA_FlowRun_HR_Personnel", Storage = "_OA_FlowRun", OtherKey = "Creator", DeleteRule = "NO ACTION")]
        public EntitySet<OA_FlowRun> OA_FlowRun
        {
            get
            {
                return this._OA_FlowRun;
            }
            set
            {
                this._OA_FlowRun.Assign(value);
            }
        }

        [Association(Name = "FK_OA_FlowRunFeedback_HR_Personnel", Storage = "_OA_FlowRunFeedback", OtherKey = "PersonnelID", DeleteRule = "NO ACTION")]
        public EntitySet<OA_FlowRunFeedback> OA_FlowRunFeedback
        {
            get
            {
                return this._OA_FlowRunFeedback;
            }
            set
            {
                this._OA_FlowRunFeedback.Assign(value);
            }
        }

        [Association(Name = "FK_OA_FlowRunProcess_HR_AcceptPerson", Storage = "_OA_FlowRunProcess", OtherKey = "AcceptID", DeleteRule = "NO ACTION")]
        public EntitySet<OA_FlowRunProcess> OA_FlowRunProcess
        {
            get
            {
                return this._OA_FlowRunProcess;
            }
            set
            {
                this._OA_FlowRunProcess.Assign(value);
            }
        }

        [Association(Name = "FK_OA_FlowRunProcess_HR_Personnel", Storage = "_OA_FlowRunProcess_HR_Personnel", OtherKey = "SendID", DeleteRule = "NO ACTION")]
        public EntitySet<OA_FlowRunProcess> OA_FlowRunProcess_HR_Personnel
        {
            get
            {
                return this._OA_FlowRunProcess_HR_Personnel;
            }
            set
            {
                this._OA_FlowRunProcess_HR_Personnel.Assign(value);
            }
        }

        [Association(Name = "FK_OA_FORM_HR_PERSONNEL", Storage = "_OA_Form", OtherKey = "Creator", DeleteRule = "NO ACTION")]
        public EntitySet<OA_Form> OA_Form
        {
            get
            {
                return this._OA_Form;
            }
            set
            {
                this._OA_Form.Assign(value);
            }
        }

        [Association(Name = "FK_OA_FORMTYPE_HR_PERSONNEL", Storage = "_OA_FormType", OtherKey = "Creator", DeleteRule = "NO ACTION")]
        public EntitySet<OA_FormType> OA_FormType
        {
            get
            {
                return this._OA_FormType;
            }
            set
            {
                this._OA_FormType.Assign(value);
            }
        }

        [Association(Name = "FK_OA_PROCESS_PERSONNEL", Storage = "_OA_ProcessAuthority", OtherKey = "PersonnelID", DeleteRule = "NO ACTION")]
        public EntitySet<OA_ProcessAuthority> OA_ProcessAuthority
        {
            get
            {
                return this._OA_ProcessAuthority;
            }
            set
            {
                this._OA_ProcessAuthority.Assign(value);
            }
        }

        [Association(Name = "FK_OA_PROGRAMME_HR_PERSONNEL", Storage = "_OA_Programme", OtherKey = "PersonnelID", DeleteRule = "NO ACTION")]
        public EntitySet<OA_Programme> OA_Programme
        {
            get
            {
                return this._OA_Programme;
            }
            set
            {
                this._OA_Programme.Assign(value);
            }
        }

        [Association(Name = "FK_SYS_USER_REFERENCE_HR_PERSO", Storage = "_SYS_User", OtherKey = "PersonnelID", DeleteRule = "NO ACTION")]
        public EntitySet<SYS_User> SYS_User
        {
            get
            {
                return this._SYS_User;
            }
            set
            {
                this._SYS_User.Assign(value);
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

        private void attach_ADM_Letter(ADM_Letter entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = this;
        }

        private void detach_ADM_Letter(ADM_Letter entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = null;
        }

        private void attach_ADM_Letter_HR_Recorder(ADM_Letter entity)
        {
            this.SendPropertyChanging();
            entity.RecorderHR_Personnel = this;
        }

        private void detach_ADM_Letter_HR_Recorder(ADM_Letter entity)
        {
            this.SendPropertyChanging();
            entity.RecorderHR_Personnel = null;
        }

        private void attach_ADM_Letter_Recipient(ADM_Letter entity)
        {
            this.SendPropertyChanging();
            entity.ReceiverHR_Personnel = this;
        }

        private void detach_ADM_Letter_Recipient(ADM_Letter entity)
        {
            this.SendPropertyChanging();
            entity.ReceiverHR_Personnel = null;
        }

        private void attach_ADM_LetterFollow(ADM_LetterFollow entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = this;
        }

        private void detach_ADM_LetterFollow(ADM_LetterFollow entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = null;
        }

        private void attach_OA_Attachment(OA_Attachment entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = this;
        }

        private void detach_OA_Attachment(OA_Attachment entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = null;
        }

        private void attach_CRM_Trader(CRM_Trader entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = this;
        }

        private void detach_CRM_Trader(CRM_Trader entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = null;
        }

        private void attach_HD_Folder(HD_Folder entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = this;
        }

        private void detach_HD_Folder(HD_Folder entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = null;
        }

        private void attach_HD_Attachment(HD_Attachment entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = this;
        }

        private void detach_HD_Attachment(HD_Attachment entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = null;
        }

        private void attach_OA_Contract(OA_Contract entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = this;
        }

        private void detach_OA_Contract(OA_Contract entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = null;
        }

        private void attach_OA_Flow(OA_Flow entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = this;
        }

        private void detach_OA_Flow(OA_Flow entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = null;
        }

        private void attach_OA_FlowAuthority(OA_FlowAuthority entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = this;
        }

        private void detach_OA_FlowAuthority(OA_FlowAuthority entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = null;
        }

        private void attach_OA_FlowRun(OA_FlowRun entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = this;
        }

        private void detach_OA_FlowRun(OA_FlowRun entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = null;
        }

        private void attach_OA_FlowRunFeedback(OA_FlowRunFeedback entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = this;
        }

        private void detach_OA_FlowRunFeedback(OA_FlowRunFeedback entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = null;
        }

        private void attach_OA_FlowRunProcess(OA_FlowRunProcess entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = this;
        }

        private void detach_OA_FlowRunProcess(OA_FlowRunProcess entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = null;
        }

        private void attach_OA_FlowRunProcess_HR_Personnel(OA_FlowRunProcess entity)
        {
            this.SendPropertyChanging();
            entity.Send = this;
        }

        private void detach_OA_FlowRunProcess_HR_Personnel(OA_FlowRunProcess entity)
        {
            this.SendPropertyChanging();
            entity.Send = null;
        }

        private void attach_OA_Form(OA_Form entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = this;
        }

        private void detach_OA_Form(OA_Form entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = null;
        }

        private void attach_OA_FormType(OA_FormType entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = this;
        }

        private void detach_OA_FormType(OA_FormType entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = null;
        }

        private void attach_OA_ProcessAuthority(OA_ProcessAuthority entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = this;
        }

        private void detach_OA_ProcessAuthority(OA_ProcessAuthority entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = null;
        }

        private void attach_OA_Programme(OA_Programme entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = this;
        }

        private void detach_OA_Programme(OA_Programme entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = null;
        }

        private void attach_SYS_User(SYS_User entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = this;
        }

        private void detach_SYS_User(SYS_User entity)
        {
            this.SendPropertyChanging();
            entity.HR_Personnel = null;
        }
    }
}
