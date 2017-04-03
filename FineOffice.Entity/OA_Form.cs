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
    [Table(Name = "dbo.OA_Form")]
    public partial class OA_Form : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private System.Nullable<int> _TypeID;

        private string _FormNO;

        private string _FormName;

        private string _PinyinCode;

        private System.Data.Linq.Binary _FormData;

        private string _XType;

        private string _Remark;

        private System.Nullable<int> _Creator;

        private System.Nullable<bool> _Stop;

        private EntitySet<OA_Flow> _OA_Flow;

        private EntitySet<OA_FlowForm> _OA_FlowForm;

        private EntitySet<OA_FlowRunData> _OA_FlowRunData;

        private EntityRef<HR_Personnel> _HR_Personnel;

        private EntityRef<OA_FormType> _OA_FormType;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnTypeIDChanging(System.Nullable<int> value);
        partial void OnTypeIDChanged();
        partial void OnFormNOChanging(string value);
        partial void OnFormNOChanged();
        partial void OnFormNameChanging(string value);
        partial void OnFormNameChanged();
        partial void OnPinyinCodeChanging(string value);
        partial void OnPinyinCodeChanged();
        partial void OnFormDataChanging(System.Data.Linq.Binary value);
        partial void OnFormDataChanged();
        partial void OnXTypeChanging(string value);
        partial void OnXTypeChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        partial void OnCreatorChanging(System.Nullable<int> value);
        partial void OnCreatorChanged();
        partial void OnStopChanging(System.Nullable<bool> value);
        partial void OnStopChanged();
        #endregion

        public OA_Form()
        {
            this._OA_Flow = new EntitySet<OA_Flow>(new Action<OA_Flow>(this.attach_OA_Flow), new Action<OA_Flow>(this.detach_OA_Flow));
            this._OA_FlowForm = new EntitySet<OA_FlowForm>(new Action<OA_FlowForm>(this.attach_OA_FlowForm), new Action<OA_FlowForm>(this.detach_OA_FlowForm));
            this._OA_FlowRunData = new EntitySet<OA_FlowRunData>(new Action<OA_FlowRunData>(this.attach_OA_FlowRunData), new Action<OA_FlowRunData>(this.detach_OA_FlowRunData));
            this._HR_Personnel = default(EntityRef<HR_Personnel>);
            this._OA_FormType = default(EntityRef<OA_FormType>);
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
                    if (this._OA_FormType.HasLoadedOrAssignedValue)
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

        [Column(Storage = "_FormNO", DbType = "VarChar(50)")]
        public string FormNO
        {
            get
            {
                return this._FormNO;
            }
            set
            {
                if ((this._FormNO != value))
                {
                    this.OnFormNOChanging(value);
                    this.SendPropertyChanging();
                    this._FormNO = value;
                    this.SendPropertyChanged("FormNO");
                    this.OnFormNOChanged();
                }
            }
        }

        [Column(Storage = "_FormName", DbType = "VarChar(200)")]
        public string FormName
        {
            get
            {
                return this._FormName;
            }
            set
            {
                if ((this._FormName != value))
                {
                    this.OnFormNameChanging(value);
                    this.SendPropertyChanging();
                    this._FormName = value;
                    this.SendPropertyChanged("FormName");
                    this.OnFormNameChanged();
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

        [Column(Storage = "_FormData", DbType = "Image", CanBeNull = true, UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary FormData
        {
            get
            {
                return this._FormData;
            }
            set
            {
                if ((this._FormData != value))
                {
                    this.OnFormDataChanging(value);
                    this.SendPropertyChanging();
                    this._FormData = value;
                    this.SendPropertyChanged("FormData");
                    this.OnFormDataChanged();
                }
            }
        }

        [Column(Storage = "_XType", DbType = "VarChar(50)")]
        public string XType
        {
            get
            {
                return this._XType;
            }
            set
            {
                if ((this._XType != value))
                {
                    this.OnXTypeChanging(value);
                    this.SendPropertyChanging();
                    this._XType = value;
                    this.SendPropertyChanged("XType");
                    this.OnXTypeChanged();
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

        [Association(Name = "FK_OA_Flow_OA_Form", Storage = "_OA_Flow", OtherKey = "FormID", DeleteRule = "NO ACTION")]
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

        [Association(Name = "FK_OA_FlOWFORM_OA_FORM", Storage = "_OA_FlowForm", OtherKey = "FormID", DeleteRule = "NO ACTION")]
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

        [Association(Name = "FK_OA_FlowRunData_OA_FlowRunData", Storage = "_OA_FlowRunData", OtherKey = "FormID", DeleteRule = "NO ACTION")]
        public EntitySet<OA_FlowRunData> OA_FlowRunData
        {
            get
            {
                return this._OA_FlowRunData;
            }
            set
            {
                this._OA_FlowRunData.Assign(value);
            }
        }

        [Association(Name = "FK_OA_FORM_HR_PERSONNEL", Storage = "_HR_Personnel", ThisKey = "Creator", IsForeignKey = true)]
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
                        previousValue.OA_Form.Remove(this);
                    }
                    this._HR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.OA_Form.Add(this);
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

        [Association(Name = "FK_OA_FORM_REFERENCE_OA_FORMT", Storage = "_OA_FormType", ThisKey = "TypeID", IsForeignKey = true)]
        public OA_FormType OA_FormType
        {
            get
            {
                return this._OA_FormType.Entity;
            }
            set
            {
                OA_FormType previousValue = this._OA_FormType.Entity;
                if (((previousValue != value)
                            || (this._OA_FormType.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._OA_FormType.Entity = null;
                        previousValue.OA_Form.Remove(this);
                    }
                    this._OA_FormType.Entity = value;
                    if ((value != null))
                    {
                        value.OA_Form.Add(this);
                        this._TypeID = value.ID;
                    }
                    else
                    {
                        this._TypeID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("OA_FormType");
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

        private void attach_OA_Flow(OA_Flow entity)
        {
            this.SendPropertyChanging();
            entity.OA_Form = this;
        }

        private void detach_OA_Flow(OA_Flow entity)
        {
            this.SendPropertyChanging();
            entity.OA_Form = null;
        }

        private void attach_OA_FlowForm(OA_FlowForm entity)
        {
            this.SendPropertyChanging();
            entity.OA_Form = this;
        }

        private void detach_OA_FlowForm(OA_FlowForm entity)
        {
            this.SendPropertyChanging();
            entity.OA_Form = null;
        }

        private void attach_OA_FlowRunData(OA_FlowRunData entity)
        {
            this.SendPropertyChanging();
            entity.OA_Form = this;
        }

        private void detach_OA_FlowRunData(OA_FlowRunData entity)
        {
            this.SendPropertyChanging();
            entity.OA_Form = null;
        }
    }
}
