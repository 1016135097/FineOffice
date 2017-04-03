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
    [Table(Name = "dbo.OA_FlowProcess")]
    public partial class OA_FlowProcess : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private string _ID;

        private System.Nullable<int> _FlowID;

        private string _ProcessName;

        private System.Nullable<int> _Serial;

        private System.Nullable<bool> _IsStart;

        private System.Nullable<bool> _IsEnd;

        private string _ProcessPersonnel;

        private string _ProcessDepartment;

        private string _ProcessRole;

        private string _Next;

        private string _MailTo;

        private string _MessageTo;

        private string _Remark;

        private System.Nullable<bool> _TopDefault;

        private System.Nullable<bool> _AllowRefuse;

        private System.Nullable<bool> _AllowGoBack;

        private System.Nullable<bool> _Feedback;

        private System.Nullable<bool> _AllowSync;

        private System.Nullable<int> _TimeLimit;

        private System.Nullable<int> _Remind;

        private System.Data.Linq.Binary _Version;

        private EntitySet<OA_FlowForm> _OA_FlowForm;

        private EntityRef<OA_Flow> _OA_Flow;

        private EntitySet<OA_FlowRunProcess> _OA_FlowRunProcess;

        private EntitySet<OA_ProcessAuthority> _OA_ProcessAuthority;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(string value);
        partial void OnIDChanged();
        partial void OnFlowIDChanging(System.Nullable<int> value);
        partial void OnFlowIDChanged();
        partial void OnProcessNameChanging(string value);
        partial void OnProcessNameChanged();
        partial void OnSerialChanging(System.Nullable<int> value);
        partial void OnSerialChanged();
        partial void OnIsStartChanging(System.Nullable<bool> value);
        partial void OnIsStartChanged();
        partial void OnIsEndChanging(System.Nullable<bool> value);
        partial void OnIsEndChanged();
        partial void OnProcessPersonnelChanging(string value);
        partial void OnProcessPersonnelChanged();
        partial void OnProcessDepartmentChanging(string value);
        partial void OnProcessDepartmentChanged();
        partial void OnProcessRoleChanging(string value);
        partial void OnProcessRoleChanged();
        partial void OnNextChanging(string value);
        partial void OnNextChanged();
        partial void OnMailToChanging(string value);
        partial void OnMailToChanged();
        partial void OnMessageToChanging(string value);
        partial void OnMessageToChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        partial void OnTopDefaultChanging(System.Nullable<bool> value);
        partial void OnTopDefaultChanged();
        partial void OnAllowRefuseChanging(System.Nullable<bool> value);
        partial void OnAllowRefuseChanged();
        partial void OnAllowGoBackChanging(System.Nullable<bool> value);
        partial void OnAllowGoBackChanged();
        partial void OnFeedbackChanging(System.Nullable<bool> value);
        partial void OnFeedbackChanged();
        partial void OnAllowSyncChanging(System.Nullable<bool> value);
        partial void OnAllowSyncChanged();
        partial void OnTimeLimitChanging(System.Nullable<int> value);
        partial void OnTimeLimitChanged();
        partial void OnRemindChanging(System.Nullable<int> value);
        partial void OnRemindChanged();
        partial void OnVersionChanging(System.Data.Linq.Binary value);
        partial void OnVersionChanged();
        #endregion

        public OA_FlowProcess()
        {
            this._OA_FlowForm = new EntitySet<OA_FlowForm>(new Action<OA_FlowForm>(this.attach_OA_FlowForm), new Action<OA_FlowForm>(this.detach_OA_FlowForm));
            this._OA_Flow = default(EntityRef<OA_Flow>);
            this._OA_FlowRunProcess = new EntitySet<OA_FlowRunProcess>(new Action<OA_FlowRunProcess>(this.attach_OA_FlowRunProcess), new Action<OA_FlowRunProcess>(this.detach_OA_FlowRunProcess));
            this._OA_ProcessAuthority = new EntitySet<OA_ProcessAuthority>(new Action<OA_ProcessAuthority>(this.attach_OA_ProcessAuthority), new Action<OA_ProcessAuthority>(this.detach_OA_ProcessAuthority));
            OnCreated();
        }

        [Column(Storage = "_ID", DbType = "VarChar(50) NOT NULL", CanBeNull = false, IsPrimaryKey = true, UpdateCheck = UpdateCheck.Never)]
        public string ID
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

        [Column(Storage = "_FlowID", DbType = "Int", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<int> FlowID
        {
            get
            {
                return this._FlowID;
            }
            set
            {
                if ((this._FlowID != value))
                {
                    if (this._OA_Flow.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnFlowIDChanging(value);
                    this.SendPropertyChanging();
                    this._FlowID = value;
                    this.SendPropertyChanged("FlowID");
                    this.OnFlowIDChanged();
                }
            }
        }

        [Column(Storage = "_ProcessName", DbType = "VarChar(200)", UpdateCheck = UpdateCheck.Never)]
        public string ProcessName
        {
            get
            {
                return this._ProcessName;
            }
            set
            {
                if ((this._ProcessName != value))
                {
                    this.OnProcessNameChanging(value);
                    this.SendPropertyChanging();
                    this._ProcessName = value;
                    this.SendPropertyChanged("ProcessName");
                    this.OnProcessNameChanged();
                }
            }
        }

        [Column(Storage = "_Serial", DbType = "Int", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<int> Serial
        {
            get
            {
                return this._Serial;
            }
            set
            {
                if ((this._Serial != value))
                {
                    this.OnSerialChanging(value);
                    this.SendPropertyChanging();
                    this._Serial = value;
                    this.SendPropertyChanged("Serial");
                    this.OnSerialChanged();
                }
            }
        }

        [Column(Storage = "_IsStart", DbType = "Bit", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<bool> IsStart
        {
            get
            {
                return this._IsStart;
            }
            set
            {
                if ((this._IsStart != value))
                {
                    this.OnIsStartChanging(value);
                    this.SendPropertyChanging();
                    this._IsStart = value;
                    this.SendPropertyChanged("IsStart");
                    this.OnIsStartChanged();
                }
            }
        }

        [Column(Storage = "_IsEnd", DbType = "Bit", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<bool> IsEnd
        {
            get
            {
                return this._IsEnd;
            }
            set
            {
                if ((this._IsEnd != value))
                {
                    this.OnIsEndChanging(value);
                    this.SendPropertyChanging();
                    this._IsEnd = value;
                    this.SendPropertyChanged("IsEnd");
                    this.OnIsEndChanged();
                }
            }
        }

        [Column(Storage = "_ProcessPersonnel", DbType = "VarChar(500)", UpdateCheck = UpdateCheck.Never)]
        public string ProcessPersonnel
        {
            get
            {
                return this._ProcessPersonnel;
            }
            set
            {
                if ((this._ProcessPersonnel != value))
                {
                    this.OnProcessPersonnelChanging(value);
                    this.SendPropertyChanging();
                    this._ProcessPersonnel = value;
                    this.SendPropertyChanged("ProcessPersonnel");
                    this.OnProcessPersonnelChanged();
                }
            }
        }

        [Column(Storage = "_ProcessDepartment", DbType = "VarChar(500)", UpdateCheck = UpdateCheck.Never)]
        public string ProcessDepartment
        {
            get
            {
                return this._ProcessDepartment;
            }
            set
            {
                if ((this._ProcessDepartment != value))
                {
                    this.OnProcessDepartmentChanging(value);
                    this.SendPropertyChanging();
                    this._ProcessDepartment = value;
                    this.SendPropertyChanged("ProcessDepartment");
                    this.OnProcessDepartmentChanged();
                }
            }
        }

        [Column(Storage = "_ProcessRole", DbType = "VarChar(500)", UpdateCheck = UpdateCheck.Never)]
        public string ProcessRole
        {
            get
            {
                return this._ProcessRole;
            }
            set
            {
                if ((this._ProcessRole != value))
                {
                    this.OnProcessRoleChanging(value);
                    this.SendPropertyChanging();
                    this._ProcessRole = value;
                    this.SendPropertyChanged("ProcessRole");
                    this.OnProcessRoleChanged();
                }
            }
        }

        [Column(Storage = "_Next", DbType = "Text", UpdateCheck = UpdateCheck.Never)]
        public string Next
        {
            get
            {
                return this._Next;
            }
            set
            {
                if ((this._Next != value))
                {
                    this.OnNextChanging(value);
                    this.SendPropertyChanging();
                    this._Next = value;
                    this.SendPropertyChanged("Next");
                    this.OnNextChanged();
                }
            }
        }

        [Column(Storage = "_MailTo", DbType = "VarChar(1000)", UpdateCheck = UpdateCheck.Never)]
        public string MailTo
        {
            get
            {
                return this._MailTo;
            }
            set
            {
                if ((this._MailTo != value))
                {
                    this.OnMailToChanging(value);
                    this.SendPropertyChanging();
                    this._MailTo = value;
                    this.SendPropertyChanged("MailTo");
                    this.OnMailToChanged();
                }
            }
        }

        [Column(Storage = "_MessageTo", DbType = "VarChar(1000)", UpdateCheck = UpdateCheck.Never)]
        public string MessageTo
        {
            get
            {
                return this._MessageTo;
            }
            set
            {
                if ((this._MessageTo != value))
                {
                    this.OnMessageToChanging(value);
                    this.SendPropertyChanging();
                    this._MessageTo = value;
                    this.SendPropertyChanged("MessageTo");
                    this.OnMessageToChanged();
                }
            }
        }

        [Column(Storage = "_Remark", DbType = "VarChar(500)", UpdateCheck = UpdateCheck.Never)]
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

        [Column(Storage = "_TopDefault", DbType = "Bit", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<bool> TopDefault
        {
            get
            {
                return this._TopDefault;
            }
            set
            {
                if ((this._TopDefault != value))
                {
                    this.OnTopDefaultChanging(value);
                    this.SendPropertyChanging();
                    this._TopDefault = value;
                    this.SendPropertyChanged("TopDefault");
                    this.OnTopDefaultChanged();
                }
            }
        }

        [Column(Storage = "_AllowRefuse", DbType = "Bit", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<bool> AllowRefuse
        {
            get
            {
                return this._AllowRefuse;
            }
            set
            {
                if ((this._AllowRefuse != value))
                {
                    this.OnAllowRefuseChanging(value);
                    this.SendPropertyChanging();
                    this._AllowRefuse = value;
                    this.SendPropertyChanged("AllowRefuse");
                    this.OnAllowRefuseChanged();
                }
            }
        }

        [Column(Storage = "_AllowGoBack", DbType = "Bit", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<bool> AllowGoBack
        {
            get
            {
                return this._AllowGoBack;
            }
            set
            {
                if ((this._AllowGoBack != value))
                {
                    this.OnAllowGoBackChanging(value);
                    this.SendPropertyChanging();
                    this._AllowGoBack = value;
                    this.SendPropertyChanged("AllowGoBack");
                    this.OnAllowGoBackChanged();
                }
            }
        }

        [Column(Storage = "_Feedback", DbType = "Bit", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<bool> Feedback
        {
            get
            {
                return this._Feedback;
            }
            set
            {
                if ((this._Feedback != value))
                {
                    this.OnFeedbackChanging(value);
                    this.SendPropertyChanging();
                    this._Feedback = value;
                    this.SendPropertyChanged("Feedback");
                    this.OnFeedbackChanged();
                }
            }
        }

        [Column(Storage = "_AllowSync", DbType = "Bit", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<bool> AllowSync
        {
            get
            {
                return this._AllowSync;
            }
            set
            {
                if ((this._AllowSync != value))
                {
                    this.OnAllowSyncChanging(value);
                    this.SendPropertyChanging();
                    this._AllowSync = value;
                    this.SendPropertyChanged("AllowSync");
                    this.OnAllowSyncChanged();
                }
            }
        }

        [Column(Storage = "_TimeLimit", DbType = "Int", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<int> TimeLimit
        {
            get
            {
                return this._TimeLimit;
            }
            set
            {
                if ((this._TimeLimit != value))
                {
                    this.OnTimeLimitChanging(value);
                    this.SendPropertyChanging();
                    this._TimeLimit = value;
                    this.SendPropertyChanged("TimeLimit");
                    this.OnTimeLimitChanged();
                }
            }
        }

        [Column(Storage = "_Remind", DbType = "Int", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<int> Remind
        {
            get
            {
                return this._Remind;
            }
            set
            {
                if ((this._Remind != value))
                {
                    this.OnRemindChanging(value);
                    this.SendPropertyChanging();
                    this._Remind = value;
                    this.SendPropertyChanged("Remind");
                    this.OnRemindChanged();
                }
            }
        }

        [Column(Storage = "_Version", AutoSync = AutoSync.Always, DbType = "rowversion", CanBeNull = true, IsDbGenerated = true, IsVersion = true, UpdateCheck = UpdateCheck.Never)]
        public System.Data.Linq.Binary Version
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

        [Association(Name = "FK_OA_FlOWFORM_OA_FlOWPROCESS", Storage = "_OA_FlowForm", OtherKey = "ProcessID", DeleteRule = "NO ACTION")]
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

        [Association(Name = "FK_OA_FLOWP_REFERENCE_OA_FLOW", Storage = "_OA_Flow", ThisKey = "FlowID", IsForeignKey = true)]
        public OA_Flow OA_Flow
        {
            get
            {
                return this._OA_Flow.Entity;
            }
            set
            {
                OA_Flow previousValue = this._OA_Flow.Entity;
                if (((previousValue != value)
                            || (this._OA_Flow.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._OA_Flow.Entity = null;
                        previousValue.OA_FlowProcess.Remove(this);
                    }
                    this._OA_Flow.Entity = value;
                    if ((value != null))
                    {
                        value.OA_FlowProcess.Add(this);
                        this._FlowID = value.ID;
                    }
                    else
                    {
                        this._FlowID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("OA_Flow");
                }
            }
        }

        [Association(Name = "FK_OA_FlowRunProcess_OA_FlowProcess", Storage = "_OA_FlowRunProcess", OtherKey = "ProcessID", DeleteRule = "NO ACTION")]
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

        [Association(Name = "FK_OA_PROCESSAUTHORITY", Storage = "_OA_ProcessAuthority", OtherKey = "PrecessID", DeleteRule = "NO ACTION")]
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

        private void attach_OA_FlowForm(OA_FlowForm entity)
        {
            this.SendPropertyChanging();
            entity.OA_FlowProcess = this;
        }

        private void detach_OA_FlowForm(OA_FlowForm entity)
        {
            this.SendPropertyChanging();
            entity.OA_FlowProcess = null;
        }

        private void attach_OA_FlowRunProcess(OA_FlowRunProcess entity)
        {
            this.SendPropertyChanging();
            entity.OA_FlowProcess = this;
        }

        private void detach_OA_FlowRunProcess(OA_FlowRunProcess entity)
        {
            this.SendPropertyChanging();
            entity.OA_FlowProcess = null;
        }

        private void attach_OA_ProcessAuthority(OA_ProcessAuthority entity)
        {
            this.SendPropertyChanging();
            entity.OA_FlowProcess = this;
        }

        private void detach_OA_ProcessAuthority(OA_ProcessAuthority entity)
        {
            this.SendPropertyChanging();
            entity.OA_FlowProcess = null;
        }
    }
}
