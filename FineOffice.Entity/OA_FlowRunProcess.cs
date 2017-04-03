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
    [Table(Name = "dbo.OA_FlowRunProcess")]
    public partial class OA_FlowRunProcess : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private System.Nullable<int> _RunID;

        private string _ProcessID;

        private System.Nullable<int> _SendID;

        private System.Nullable<int> _AcceptID;

        private System.Nullable<System.DateTime> _AcceptTime;

        private System.Nullable<System.DateTime> _HandleTime;

        private System.Nullable<int> _PreviousID;

        private System.Nullable<short> _State;

        private string _TransmitAdvice;

        private System.Nullable<short> _Pattern;

        private string _Remark;

        private System.Nullable<int> _TransmitFrom;

        private System.Nullable<bool> _IsEntrance;

        private System.Data.Linq.Binary _Version;

        private EntitySet<OA_Attachment> _OA_Attachment;

        private EntitySet<OA_FlowRunData> _OA_FlowRunData;

        private EntitySet<OA_FlowRunFeedback> _OA_FlowRunFeedback;

        private EntityRef<HR_Personnel> _HR_Personnel;

        private EntityRef<HR_Personnel> _Send;

        private EntityRef<OA_FlowProcess> _OA_FlowProcess;

        private EntityRef<OA_FlowRun> _OA_FlowRun;

        private EntitySet<OA_FlowRunTransmit> _OA_FlowRunTransmit;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnRunIDChanging(System.Nullable<int> value);
        partial void OnRunIDChanged();
        partial void OnProcessIDChanging(string value);
        partial void OnProcessIDChanged();
        partial void OnSendIDChanging(System.Nullable<int> value);
        partial void OnSendIDChanged();
        partial void OnAcceptIDChanging(System.Nullable<int> value);
        partial void OnAcceptIDChanged();
        partial void OnAcceptTimeChanging(System.Nullable<System.DateTime> value);
        partial void OnAcceptTimeChanged();
        partial void OnHandleTimeChanging(System.Nullable<System.DateTime> value);
        partial void OnHandleTimeChanged();
        partial void OnPreviousIDChanging(System.Nullable<int> value);
        partial void OnPreviousIDChanged();
        partial void OnStateChanging(System.Nullable<short> value);
        partial void OnStateChanged();
        partial void OnTransmitAdviceChanging(string value);
        partial void OnTransmitAdviceChanged();
        partial void OnPatternChanging(System.Nullable<short> value);
        partial void OnPatternChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        partial void OnTransmitFromChanging(System.Nullable<int> value);
        partial void OnTransmitFromChanged();
        partial void OnIsEntranceChanging(System.Nullable<bool> value);
        partial void OnIsEntranceChanged();
        partial void OnVersionChanging(System.Data.Linq.Binary value);
        partial void OnVersionChanged();
        #endregion

        public OA_FlowRunProcess()
        {
            this._OA_Attachment = new EntitySet<OA_Attachment>(new Action<OA_Attachment>(this.attach_OA_Attachment), new Action<OA_Attachment>(this.detach_OA_Attachment));
            this._OA_FlowRunData = new EntitySet<OA_FlowRunData>(new Action<OA_FlowRunData>(this.attach_OA_FlowRunData), new Action<OA_FlowRunData>(this.detach_OA_FlowRunData));
            this._OA_FlowRunFeedback = new EntitySet<OA_FlowRunFeedback>(new Action<OA_FlowRunFeedback>(this.attach_OA_FlowRunFeedback), new Action<OA_FlowRunFeedback>(this.detach_OA_FlowRunFeedback));
            this._HR_Personnel = default(EntityRef<HR_Personnel>);
            this._Send = default(EntityRef<HR_Personnel>);
            this._OA_FlowProcess = default(EntityRef<OA_FlowProcess>);
            this._OA_FlowRun = default(EntityRef<OA_FlowRun>);
            this._OA_FlowRunTransmit = new EntitySet<OA_FlowRunTransmit>(new Action<OA_FlowRunTransmit>(this.attach_OA_FlowRunTransmit), new Action<OA_FlowRunTransmit>(this.detach_OA_FlowRunTransmit));
            OnCreated();
        }

        [Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, UpdateCheck = UpdateCheck.Never)]
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

        [Column(Storage = "_RunID", DbType = "Int", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<int> RunID
        {
            get
            {
                return this._RunID;
            }
            set
            {
                if ((this._RunID != value))
                {
                    if (this._OA_FlowRun.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnRunIDChanging(value);
                    this.SendPropertyChanging();
                    this._RunID = value;
                    this.SendPropertyChanged("RunID");
                    this.OnRunIDChanged();
                }
            }
        }

        [Column(Storage = "_ProcessID", DbType = "VarChar(50)", UpdateCheck = UpdateCheck.Never)]
        public string ProcessID
        {
            get
            {
                return this._ProcessID;
            }
            set
            {
                if ((this._ProcessID != value))
                {
                    if (this._OA_FlowProcess.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnProcessIDChanging(value);
                    this.SendPropertyChanging();
                    this._ProcessID = value;
                    this.SendPropertyChanged("ProcessID");
                    this.OnProcessIDChanged();
                }
            }
        }

        [Column(Storage = "_SendID", DbType = "Int", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<int> SendID
        {
            get
            {
                return this._SendID;
            }
            set
            {
                if ((this._SendID != value))
                {
                    if (this._Send.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnSendIDChanging(value);
                    this.SendPropertyChanging();
                    this._SendID = value;
                    this.SendPropertyChanged("SendID");
                    this.OnSendIDChanged();
                }
            }
        }

        [Column(Storage = "_AcceptID", DbType = "Int", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<int> AcceptID
        {
            get
            {
                return this._AcceptID;
            }
            set
            {
                if ((this._AcceptID != value))
                {
                    if (this._HR_Personnel.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnAcceptIDChanging(value);
                    this.SendPropertyChanging();
                    this._AcceptID = value;
                    this.SendPropertyChanged("AcceptID");
                    this.OnAcceptIDChanged();
                }
            }
        }

        [Column(Storage = "_AcceptTime", DbType = "DateTime", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<System.DateTime> AcceptTime
        {
            get
            {
                return this._AcceptTime;
            }
            set
            {
                if ((this._AcceptTime != value))
                {
                    this.OnAcceptTimeChanging(value);
                    this.SendPropertyChanging();
                    this._AcceptTime = value;
                    this.SendPropertyChanged("AcceptTime");
                    this.OnAcceptTimeChanged();
                }
            }
        }

        [Column(Storage = "_HandleTime", DbType = "DateTime", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<System.DateTime> HandleTime
        {
            get
            {
                return this._HandleTime;
            }
            set
            {
                if ((this._HandleTime != value))
                {
                    this.OnHandleTimeChanging(value);
                    this.SendPropertyChanging();
                    this._HandleTime = value;
                    this.SendPropertyChanged("HandleTime");
                    this.OnHandleTimeChanged();
                }
            }
        }

        [Column(Storage = "_PreviousID", DbType = "Int", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<int> PreviousID
        {
            get
            {
                return this._PreviousID;
            }
            set
            {
                if ((this._PreviousID != value))
                {
                    this.OnPreviousIDChanging(value);
                    this.SendPropertyChanging();
                    this._PreviousID = value;
                    this.SendPropertyChanged("PreviousID");
                    this.OnPreviousIDChanged();
                }
            }
        }

        [Column(Storage = "_State", DbType = "SmallInt", UpdateCheck = UpdateCheck.Never)]
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

        [Column(Storage = "_TransmitAdvice", DbType = "VarChar(5000)", UpdateCheck = UpdateCheck.Never)]
        public string TransmitAdvice
        {
            get
            {
                return this._TransmitAdvice;
            }
            set
            {
                if ((this._TransmitAdvice != value))
                {
                    this.OnTransmitAdviceChanging(value);
                    this.SendPropertyChanging();
                    this._TransmitAdvice = value;
                    this.SendPropertyChanged("TransmitAdvice");
                    this.OnTransmitAdviceChanged();
                }
            }
        }

        [Column(Storage = "_Pattern", DbType = "SmallInt", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<short> Pattern
        {
            get
            {
                return this._Pattern;
            }
            set
            {
                if ((this._Pattern != value))
                {
                    this.OnPatternChanging(value);
                    this.SendPropertyChanging();
                    this._Pattern = value;
                    this.SendPropertyChanged("Pattern");
                    this.OnPatternChanged();
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

        [Column(Storage = "_TransmitFrom", DbType = "Int", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<int> TransmitFrom
        {
            get
            {
                return this._TransmitFrom;
            }
            set
            {
                if ((this._TransmitFrom != value))
                {
                    this.OnTransmitFromChanging(value);
                    this.SendPropertyChanging();
                    this._TransmitFrom = value;
                    this.SendPropertyChanged("TransmitFrom");
                    this.OnTransmitFromChanged();
                }
            }
        }

        [Column(Storage = "_IsEntrance", DbType = "Bit", UpdateCheck = UpdateCheck.Never)]
        public System.Nullable<bool> IsEntrance
        {
            get
            {
                return this._IsEntrance;
            }
            set
            {
                if ((this._IsEntrance != value))
                {
                    this.OnIsEntranceChanging(value);
                    this.SendPropertyChanging();
                    this._IsEntrance = value;
                    this.SendPropertyChanged("IsEntrance");
                    this.OnIsEntranceChanged();
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

        [Association(Name = "FK_OA_Attachment_OA_FlowRunProcess", Storage = "_OA_Attachment", OtherKey = "RunProcessID", DeleteRule = "NO ACTION")]
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

        [Association(Name = "FK_OA_FlowRunData_OA_FlowRunProcess", Storage = "_OA_FlowRunData", OtherKey = "RunProcessID", DeleteRule = "NO ACTION")]
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

        [Association(Name = "FK_OA_FlowRunFeedback_OA_FlowRunProcess", Storage = "_OA_FlowRunFeedback", OtherKey = "RunProcessID", DeleteRule = "NO ACTION")]
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

        [Association(Name = "FK_OA_FlowRunProcess_HR_AcceptPerson", Storage = "_HR_Personnel", ThisKey = "AcceptID", IsForeignKey = true)]
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
                        previousValue.OA_FlowRunProcess.Remove(this);
                    }
                    this._HR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.OA_FlowRunProcess.Add(this);
                        this._AcceptID = value.ID;
                    }
                    else
                    {
                        this._AcceptID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_Personnel");
                }
            }
        }

        [Association(Name = "FK_OA_FlowRunProcess_HR_Personnel", Storage = "_Send", ThisKey = "SendID", IsForeignKey = true)]
        public HR_Personnel Send
        {
            get
            {
                return this._Send.Entity;
            }
            set
            {
                HR_Personnel previousValue = this._Send.Entity;
                if (((previousValue != value)
                            || (this._Send.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._Send.Entity = null;
                        previousValue.OA_FlowRunProcess_HR_Personnel.Remove(this);
                    }
                    this._Send.Entity = value;
                    if ((value != null))
                    {
                        value.OA_FlowRunProcess_HR_Personnel.Add(this);
                        this._SendID = value.ID;
                    }
                    else
                    {
                        this._SendID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("Send");
                }
            }
        }

        [Association(Name = "FK_OA_FlowRunProcess_OA_FlowProcess", Storage = "_OA_FlowProcess", ThisKey = "ProcessID", IsForeignKey = true)]
        public OA_FlowProcess OA_FlowProcess
        {
            get
            {
                return this._OA_FlowProcess.Entity;
            }
            set
            {
                OA_FlowProcess previousValue = this._OA_FlowProcess.Entity;
                if (((previousValue != value)
                            || (this._OA_FlowProcess.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._OA_FlowProcess.Entity = null;
                        previousValue.OA_FlowRunProcess.Remove(this);
                    }
                    this._OA_FlowProcess.Entity = value;
                    if ((value != null))
                    {
                        value.OA_FlowRunProcess.Add(this);
                        this._ProcessID = value.ID;
                    }
                    else
                    {
                        this._ProcessID = default(string);
                    }
                    this.SendPropertyChanged("OA_FlowProcess");
                }
            }
        }

        [Association(Name = "FK_OA_FlowRunProcess_OA_FlowRun", Storage = "_OA_FlowRun", ThisKey = "RunID", IsForeignKey = true)]
        public OA_FlowRun OA_FlowRun
        {
            get
            {
                return this._OA_FlowRun.Entity;
            }
            set
            {
                OA_FlowRun previousValue = this._OA_FlowRun.Entity;
                if (((previousValue != value)
                            || (this._OA_FlowRun.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._OA_FlowRun.Entity = null;
                        previousValue.OA_FlowRunProcess.Remove(this);
                    }
                    this._OA_FlowRun.Entity = value;
                    if ((value != null))
                    {
                        value.OA_FlowRunProcess.Add(this);
                        this._RunID = value.ID;
                    }
                    else
                    {
                        this._RunID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("OA_FlowRun");
                }
            }
        }

        [Association(Name = "FK_OA_FlowRunTransmit_OA_FlowRunTransmit", Storage = "_OA_FlowRunTransmit", OtherKey = "RunProcessID", DeleteRule = "NO ACTION")]
        public EntitySet<OA_FlowRunTransmit> OA_FlowRunTransmit
        {
            get
            {
                return this._OA_FlowRunTransmit;
            }
            set
            {
                this._OA_FlowRunTransmit.Assign(value);
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
            entity.OA_FlowRunProcess = this;
        }

        private void detach_OA_Attachment(OA_Attachment entity)
        {
            this.SendPropertyChanging();
            entity.OA_FlowRunProcess = null;
        }

        private void attach_OA_FlowRunData(OA_FlowRunData entity)
        {
            this.SendPropertyChanging();
            entity.OA_FlowRunProcess = this;
        }

        private void detach_OA_FlowRunData(OA_FlowRunData entity)
        {
            this.SendPropertyChanging();
            entity.OA_FlowRunProcess = null;
        }

        private void attach_OA_FlowRunFeedback(OA_FlowRunFeedback entity)
        {
            this.SendPropertyChanging();
            entity.OA_FlowRunProcess = this;
        }

        private void detach_OA_FlowRunFeedback(OA_FlowRunFeedback entity)
        {
            this.SendPropertyChanging();
            entity.OA_FlowRunProcess = null;
        }

        private void attach_OA_FlowRunTransmit(OA_FlowRunTransmit entity)
        {
            this.SendPropertyChanging();
            entity.OA_FlowRunProcess = this;
        }

        private void detach_OA_FlowRunTransmit(OA_FlowRunTransmit entity)
        {
            this.SendPropertyChanging();
            entity.OA_FlowRunProcess = null;
        }
    }
}
