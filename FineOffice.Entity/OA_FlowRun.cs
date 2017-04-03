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
    [Table(Name = "dbo.OA_FlowRun")]
    public partial class OA_FlowRun : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private System.Nullable<int> _FlowID;

        private string _WorkNO;

        private string _WorkName;

        private System.Nullable<int> _Creator;

        private System.Nullable<System.DateTime> _CreateTime;

        private System.Nullable<short> _State;

        private string _Remark;

        private EntityRef<HR_Personnel> _HR_Personnel;

        private EntityRef<OA_Flow> _OA_Flow;

        private EntitySet<OA_FlowRunProcess> _OA_FlowRunProcess;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnFlowIDChanging(System.Nullable<int> value);
        partial void OnFlowIDChanged();
        partial void OnWorkNOChanging(string value);
        partial void OnWorkNOChanged();
        partial void OnWorkNameChanging(string value);
        partial void OnWorkNameChanged();
        partial void OnCreatorChanging(System.Nullable<int> value);
        partial void OnCreatorChanged();
        partial void OnCreateTimeChanging(System.Nullable<System.DateTime> value);
        partial void OnCreateTimeChanged();
        partial void OnStateChanging(System.Nullable<short> value);
        partial void OnStateChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public OA_FlowRun()
        {
            this._HR_Personnel = default(EntityRef<HR_Personnel>);
            this._OA_Flow = default(EntityRef<OA_Flow>);
            this._OA_FlowRunProcess = new EntitySet<OA_FlowRunProcess>(new Action<OA_FlowRunProcess>(this.attach_OA_FlowRunProcess), new Action<OA_FlowRunProcess>(this.detach_OA_FlowRunProcess));
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

        [Column(Storage = "_FlowID", DbType = "Int")]
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

        [Column(Storage = "_WorkNO", DbType = "VarChar(50)")]
        public string WorkNO
        {
            get
            {
                return this._WorkNO;
            }
            set
            {
                if ((this._WorkNO != value))
                {
                    this.OnWorkNOChanging(value);
                    this.SendPropertyChanging();
                    this._WorkNO = value;
                    this.SendPropertyChanged("WorkNO");
                    this.OnWorkNOChanged();
                }
            }
        }

        [Column(Storage = "_WorkName", DbType = "VarChar(200)")]
        public string WorkName
        {
            get
            {
                return this._WorkName;
            }
            set
            {
                if ((this._WorkName != value))
                {
                    this.OnWorkNameChanging(value);
                    this.SendPropertyChanging();
                    this._WorkName = value;
                    this.SendPropertyChanged("WorkName");
                    this.OnWorkNameChanged();
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

        [Association(Name = "FK_OA_FlowRun_HR_Personnel", Storage = "_HR_Personnel", ThisKey = "Creator", IsForeignKey = true)]
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
                        previousValue.OA_FlowRun.Remove(this);
                    }
                    this._HR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.OA_FlowRun.Add(this);
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

        [Association(Name = "FK_OA_FlowRun_OA_Flow", Storage = "_OA_Flow", ThisKey = "FlowID", IsForeignKey = true)]
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
                        previousValue.OA_FlowRun.Remove(this);
                    }
                    this._OA_Flow.Entity = value;
                    if ((value != null))
                    {
                        value.OA_FlowRun.Add(this);
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

        [Association(Name = "FK_OA_FlowRunProcess_OA_FlowRun", Storage = "_OA_FlowRunProcess", OtherKey = "RunID", DeleteRule = "NO ACTION")]
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

        private void attach_OA_FlowRunProcess(OA_FlowRunProcess entity)
        {
            this.SendPropertyChanging();
            entity.OA_FlowRun = this;
        }

        private void detach_OA_FlowRunProcess(OA_FlowRunProcess entity)
        {
            this.SendPropertyChanging();
            entity.OA_FlowRun = null;
        }
    }
}
