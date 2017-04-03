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
    [Table(Name = "dbo.OA_FlowRunFeedback")]
    public partial class OA_FlowRunFeedback : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private System.Nullable<int> _RunProcessID;

        private System.Nullable<int> _PersonnelID;

        private string _Feedback;

        private System.Nullable<System.DateTime> _CreateTime;

        private System.Nullable<short> _State;

        private string _Remark;

        private EntityRef<HR_Personnel> _HR_Personnel;

        private EntityRef<OA_FlowRunProcess> _OA_FlowRunProcess;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnRunProcessIDChanging(System.Nullable<int> value);
        partial void OnRunProcessIDChanged();
        partial void OnPersonnelIDChanging(System.Nullable<int> value);
        partial void OnPersonnelIDChanged();
        partial void OnFeedbackChanging(string value);
        partial void OnFeedbackChanged();
        partial void OnCreateTimeChanging(System.Nullable<System.DateTime> value);
        partial void OnCreateTimeChanged();
        partial void OnStateChanging(System.Nullable<short> value);
        partial void OnStateChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public OA_FlowRunFeedback()
        {
            this._HR_Personnel = default(EntityRef<HR_Personnel>);
            this._OA_FlowRunProcess = default(EntityRef<OA_FlowRunProcess>);
            OnCreated();
        }

        [Column(Storage = "_ID", IsVersion=true, AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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

        [Column(Storage = "_RunProcessID", DbType = "Int")]
        public System.Nullable<int> RunProcessID
        {
            get
            {
                return this._RunProcessID;
            }
            set
            {
                if ((this._RunProcessID != value))
                {
                    if (this._OA_FlowRunProcess.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnRunProcessIDChanging(value);
                    this.SendPropertyChanging();
                    this._RunProcessID = value;
                    this.SendPropertyChanged("RunProcessID");
                    this.OnRunProcessIDChanged();
                }
            }
        }

        [Column(Storage = "_PersonnelID", DbType = "Int")]
        public System.Nullable<int> PersonnelID
        {
            get
            {
                return this._PersonnelID;
            }
            set
            {
                if ((this._PersonnelID != value))
                {
                    if (this._HR_Personnel.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnPersonnelIDChanging(value);
                    this.SendPropertyChanging();
                    this._PersonnelID = value;
                    this.SendPropertyChanged("PersonnelID");
                    this.OnPersonnelIDChanged();
                }
            }
        }

        [Column(Storage = "_Feedback", DbType = "Text", UpdateCheck = UpdateCheck.Never)]
        public string Feedback
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

        [Association(Name = "FK_OA_FlowRunFeedback_HR_Personnel", Storage = "_HR_Personnel", ThisKey = "PersonnelID", IsForeignKey = true)]
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
                        previousValue.OA_FlowRunFeedback.Remove(this);
                    }
                    this._HR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.OA_FlowRunFeedback.Add(this);
                        this._PersonnelID = value.ID;
                    }
                    else
                    {
                        this._PersonnelID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_Personnel");
                }
            }
        }

        [Association(Name = "FK_OA_FlowRunFeedback_OA_FlowRunProcess", Storage = "_OA_FlowRunProcess", ThisKey = "RunProcessID", IsForeignKey = true)]
        public OA_FlowRunProcess OA_FlowRunProcess
        {
            get
            {
                return this._OA_FlowRunProcess.Entity;
            }
            set
            {
                OA_FlowRunProcess previousValue = this._OA_FlowRunProcess.Entity;
                if (((previousValue != value)
                            || (this._OA_FlowRunProcess.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._OA_FlowRunProcess.Entity = null;
                        previousValue.OA_FlowRunFeedback.Remove(this);
                    }
                    this._OA_FlowRunProcess.Entity = value;
                    if ((value != null))
                    {
                        value.OA_FlowRunFeedback.Add(this);
                        this._RunProcessID = value.ID;
                    }
                    else
                    {
                        this._RunProcessID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("OA_FlowRunProcess");
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
