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
    [Table(Name = "dbo.OA_Flow")]
    public partial class OA_Flow : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _FlowNO;

        private string _FlowName;

        private string _PinyinCode;

        private string _Version;

        private System.Nullable<int> _SortID;

        private System.Nullable<bool> _AllowRecall;

        private System.Nullable<bool> _AllowRevoke;

        private System.Nullable<bool> _AllowAttachment;

        private System.Nullable<bool> _IsFreedom;

        private System.Nullable<bool> _Stop;

        private System.Nullable<int> _Creator;

        private string _FlowDesc;

        private System.Nullable<int> _FormID;

        private System.Nullable<System.DateTime> _CreateDate;

        private string _XML;

        private string _Remark;

        private EntityRef<HR_Personnel> _HR_Personnel;

        private EntityRef<OA_Form> _OA_Form;

        private EntityRef<OA_FlowSort> _OA_FlowSort;

        private EntitySet<OA_FlowAuthority> _OA_FlowAuthority;

        private EntitySet<OA_FlowForm> _OA_FlowForm;

        private EntitySet<OA_FlowProcess> _OA_FlowProcess;

        private EntitySet<OA_FlowRun> _OA_FlowRun;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnFlowNOChanging(string value);
        partial void OnFlowNOChanged();
        partial void OnFlowNameChanging(string value);
        partial void OnFlowNameChanged();
        partial void OnPinyinCodeChanging(string value);
        partial void OnPinyinCodeChanged();
        partial void OnVersionChanging(string value);
        partial void OnVersionChanged();
        partial void OnSortIDChanging(System.Nullable<int> value);
        partial void OnSortIDChanged();
        partial void OnAllowRecallChanging(System.Nullable<bool> value);
        partial void OnAllowRecallChanged();
        partial void OnAllowRevokeChanging(System.Nullable<bool> value);
        partial void OnAllowRevokeChanged();
        partial void OnAllowAttachmentChanging(System.Nullable<bool> value);
        partial void OnAllowAttachmentChanged();
        partial void OnIsFreedomChanging(System.Nullable<bool> value);
        partial void OnIsFreedomChanged();
        partial void OnStopChanging(System.Nullable<bool> value);
        partial void OnStopChanged();
        partial void OnCreatorChanging(System.Nullable<int> value);
        partial void OnCreatorChanged();
        partial void OnFlowDescChanging(string value);
        partial void OnFlowDescChanged();
        partial void OnFormIDChanging(System.Nullable<int> value);
        partial void OnFormIDChanged();
        partial void OnCreateDateChanging(System.Nullable<System.DateTime> value);
        partial void OnCreateDateChanged();
        partial void OnXMLChanging(string value);
        partial void OnXMLChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public OA_Flow()
        {
            this._HR_Personnel = default(EntityRef<HR_Personnel>);
            this._OA_Form = default(EntityRef<OA_Form>);
            this._OA_FlowSort = default(EntityRef<OA_FlowSort>);
            this._OA_FlowAuthority = new EntitySet<OA_FlowAuthority>(new Action<OA_FlowAuthority>(this.attach_OA_FlowAuthority), new Action<OA_FlowAuthority>(this.detach_OA_FlowAuthority));
            this._OA_FlowForm = new EntitySet<OA_FlowForm>(new Action<OA_FlowForm>(this.attach_OA_FlowForm), new Action<OA_FlowForm>(this.detach_OA_FlowForm));
            this._OA_FlowProcess = new EntitySet<OA_FlowProcess>(new Action<OA_FlowProcess>(this.attach_OA_FlowProcess), new Action<OA_FlowProcess>(this.detach_OA_FlowProcess));
            this._OA_FlowRun = new EntitySet<OA_FlowRun>(new Action<OA_FlowRun>(this.attach_OA_FlowRun), new Action<OA_FlowRun>(this.detach_OA_FlowRun));
            OnCreated();
        }

        [Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, IsVersion = true, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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

        [Column(Storage = "_FlowNO", DbType = "VarChar(50)")]
        public string FlowNO
        {
            get
            {
                return this._FlowNO;
            }
            set
            {
                if ((this._FlowNO != value))
                {
                    this.OnFlowNOChanging(value);
                    this.SendPropertyChanging();
                    this._FlowNO = value;
                    this.SendPropertyChanged("FlowNO");
                    this.OnFlowNOChanged();
                }
            }
        }

        [Column(Storage = "_FlowName", DbType = "VarChar(200)")]
        public string FlowName
        {
            get
            {
                return this._FlowName;
            }
            set
            {
                if ((this._FlowName != value))
                {
                    this.OnFlowNameChanging(value);
                    this.SendPropertyChanging();
                    this._FlowName = value;
                    this.SendPropertyChanged("FlowName");
                    this.OnFlowNameChanged();
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

        [Column(Storage = "_Version", DbType = "VarChar(50)")]
        public string Version
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

        [Column(Storage = "_SortID", DbType = "Int")]
        public System.Nullable<int> SortID
        {
            get
            {
                return this._SortID;
            }
            set
            {
                if ((this._SortID != value))
                {
                    if (this._OA_FlowSort.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnSortIDChanging(value);
                    this.SendPropertyChanging();
                    this._SortID = value;
                    this.SendPropertyChanged("SortID");
                    this.OnSortIDChanged();
                }
            }
        }

        [Column(Storage = "_AllowRecall", DbType = "Bit")]
        public System.Nullable<bool> AllowRecall
        {
            get
            {
                return this._AllowRecall;
            }
            set
            {
                if ((this._AllowRecall != value))
                {
                    this.OnAllowRecallChanging(value);
                    this.SendPropertyChanging();
                    this._AllowRecall = value;
                    this.SendPropertyChanged("AllowRecall");
                    this.OnAllowRecallChanged();
                }
            }
        }

        [Column(Storage = "_AllowRevoke", DbType = "Bit")]
        public System.Nullable<bool> AllowRevoke
        {
            get
            {
                return this._AllowRevoke;
            }
            set
            {
                if ((this._AllowRevoke != value))
                {
                    this.OnAllowRevokeChanging(value);
                    this.SendPropertyChanging();
                    this._AllowRevoke = value;
                    this.SendPropertyChanged("AllowRevoke");
                    this.OnAllowRevokeChanged();
                }
            }
        }

        [Column(Storage = "_AllowAttachment", DbType = "Bit")]
        public System.Nullable<bool> AllowAttachment
        {
            get
            {
                return this._AllowAttachment;
            }
            set
            {
                if ((this._AllowAttachment != value))
                {
                    this.OnAllowAttachmentChanging(value);
                    this.SendPropertyChanging();
                    this._AllowAttachment = value;
                    this.SendPropertyChanged("AllowAttachment");
                    this.OnAllowAttachmentChanged();
                }
            }
        }

        [Column(Storage = "_IsFreedom", DbType = "Bit")]
        public System.Nullable<bool> IsFreedom
        {
            get
            {
                return this._IsFreedom;
            }
            set
            {
                if ((this._IsFreedom != value))
                {
                    this.OnIsFreedomChanging(value);
                    this.SendPropertyChanging();
                    this._IsFreedom = value;
                    this.SendPropertyChanged("IsFreedom");
                    this.OnIsFreedomChanged();
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

        [Column(Storage = "_Creator", DbType = "Int")]
        public System.Nullable<int> Creator
        {
            get
            {
                return this._Creator;
            }
            set
            {
                if ((this._Creator != value))
                {
                    if (this._HR_Personnel.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCreatorChanging(value);
                    this.SendPropertyChanging();
                    this._Creator = value;
                    this.SendPropertyChanged("Creator");
                    this.OnCreatorChanged();
                }
            }
        }

        [Column(Storage = "_FlowDesc", DbType = "Text", UpdateCheck = UpdateCheck.Never)]
        public string FlowDesc
        {
            get
            {
                return this._FlowDesc;
            }
            set
            {
                if ((this._FlowDesc != value))
                {
                    this.OnFlowDescChanging(value);
                    this.SendPropertyChanging();
                    this._FlowDesc = value;
                    this.SendPropertyChanged("FlowDesc");
                    this.OnFlowDescChanged();
                }
            }
        }

        [Column(Storage = "_FormID", DbType = "Int")]
        public System.Nullable<int> FormID
        {
            get
            {
                return this._FormID;
            }
            set
            {
                if ((this._FormID != value))
                {
                    if (this._OA_Form.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnFormIDChanging(value);
                    this.SendPropertyChanging();
                    this._FormID = value;
                    this.SendPropertyChanged("FormID");
                    this.OnFormIDChanged();
                }
            }
        }

        [Column(Storage = "_CreateDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> CreateDate
        {
            get
            {
                return this._CreateDate;
            }
            set
            {
                if ((this._CreateDate != value))
                {
                    this.OnCreateDateChanging(value);
                    this.SendPropertyChanging();
                    this._CreateDate = value;
                    this.SendPropertyChanged("CreateDate");
                    this.OnCreateDateChanged();
                }
            }
        }

        [Column(Storage = "_XML", DbType = "Text", UpdateCheck = UpdateCheck.Never)]
        public string XML
        {
            get
            {
                return this._XML;
            }
            set
            {
                if ((this._XML != value))
                {
                    this.OnXMLChanging(value);
                    this.SendPropertyChanging();
                    this._XML = value;
                    this.SendPropertyChanged("XML");
                    this.OnXMLChanged();
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

        [Association(Name = "FK_OA_FLOW_HR_PERSONNEL", Storage = "_HR_Personnel", ThisKey = "Creator", IsForeignKey = true)]
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
                        previousValue.OA_Flow.Remove(this);
                    }
                    this._HR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.OA_Flow.Add(this);
                        this._Creator = value.ID;
                    }
                    else
                    {
                        this._Creator = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_Personnel");
                }
            }
        }

        [Association(Name = "FK_OA_Flow_OA_Form", Storage = "_OA_Form", ThisKey = "FormID", IsForeignKey = true)]
        public OA_Form OA_Form
        {
            get
            {
                return this._OA_Form.Entity;
            }
            set
            {
                OA_Form previousValue = this._OA_Form.Entity;
                if (((previousValue != value)
                            || (this._OA_Form.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._OA_Form.Entity = null;
                        previousValue.OA_Flow.Remove(this);
                    }
                    this._OA_Form.Entity = value;
                    if ((value != null))
                    {
                        value.OA_Flow.Add(this);
                        this._FormID = value.ID;
                    }
                    else
                    {
                        this._FormID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("OA_Form");
                }
            }
        }

        [Association(Name = "FK_OA_FLOW_REFERENCE_OA_FLOWS", Storage = "_OA_FlowSort", ThisKey = "SortID", IsForeignKey = true)]
        public OA_FlowSort OA_FlowSort
        {
            get
            {
                return this._OA_FlowSort.Entity;
            }
            set
            {
                OA_FlowSort previousValue = this._OA_FlowSort.Entity;
                if (((previousValue != value)
                            || (this._OA_FlowSort.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._OA_FlowSort.Entity = null;
                        previousValue.OA_Flow.Remove(this);
                    }
                    this._OA_FlowSort.Entity = value;
                    if ((value != null))
                    {
                        value.OA_Flow.Add(this);
                        this._SortID = value.ID;
                    }
                    else
                    {
                        this._SortID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("OA_FlowSort");
                }
            }
        }

        [Association(Name = "FK_OA_FLOWAUTHORITY", Storage = "_OA_FlowAuthority", OtherKey = "FlowID", DeleteRule = "NO ACTION")]
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

        [Association(Name = "FK_OA_FLOWFORM_OA_FLOW", Storage = "_OA_FlowForm", OtherKey = "FlowID", DeleteRule = "NO ACTION")]
        public EntitySet<OA_FlowForm> OA_FlowForm
        {
            get
            {
                return this._OA_FlowForm;
            }
            set
            {
                this._OA_FlowForm.Assign(value);
            }
        }

        [Association(Name = "FK_OA_FLOWP_REFERENCE_OA_FLOW", Storage = "_OA_FlowProcess", OtherKey = "FlowID", DeleteRule = "NO ACTION")]
        public EntitySet<OA_FlowProcess> OA_FlowProcess
        {
            get
            {
                return this._OA_FlowProcess;
            }
            set
            {
                this._OA_FlowProcess.Assign(value);
            }
        }

        [Association(Name = "FK_OA_FlowRun_OA_Flow", Storage = "_OA_FlowRun", OtherKey = "FlowID", DeleteRule = "NO ACTION")]
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

        private void attach_OA_FlowAuthority(OA_FlowAuthority entity)
        {
            this.SendPropertyChanging();
            entity.OA_Flow = this;
        }

        private void detach_OA_FlowAuthority(OA_FlowAuthority entity)
        {
            this.SendPropertyChanging();
            entity.OA_Flow = null;
        }

        private void attach_OA_FlowForm(OA_FlowForm entity)
        {
            this.SendPropertyChanging();
            entity.OA_Flow = this;
        }

        private void detach_OA_FlowForm(OA_FlowForm entity)
        {
            this.SendPropertyChanging();
            entity.OA_Flow = null;
        }

        private void attach_OA_FlowProcess(OA_FlowProcess entity)
        {
            this.SendPropertyChanging();
            entity.OA_Flow = this;
        }

        private void detach_OA_FlowProcess(OA_FlowProcess entity)
        {
            this.SendPropertyChanging();
            entity.OA_Flow = null;
        }

        private void attach_OA_FlowRun(OA_FlowRun entity)
        {
            this.SendPropertyChanging();
            entity.OA_Flow = this;
        }

        private void detach_OA_FlowRun(OA_FlowRun entity)
        {
            this.SendPropertyChanging();
            entity.OA_Flow = null;
        }
    }
}
