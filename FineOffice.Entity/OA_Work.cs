using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;


namespace BX.Entity
{
    [Table(Name = "dbo.OA_Work")]
    public partial class OA_Work : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _WorkName;

        private System.Nullable<int> _WorkFlowID;

        private System.Nullable<int> _Maker;

        private System.Nullable<System.DateTime> _MakeDate;

        private string _FromContent;

        private string _VerifyList;

        private System.Nullable<int> _WorkState;

        private string _Remark;

        private EntityRef<HR_Personnel> _HR_Personnel;

        private EntityRef<OA_WorkFlow> _OA_WorkFlow;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnWorkNameChanging(string value);
        partial void OnWorkNameChanged();
        partial void OnWorkFlowIDChanging(System.Nullable<int> value);
        partial void OnWorkFlowIDChanged();
        partial void OnMakerChanging(System.Nullable<int> value);
        partial void OnMakerChanged();
        partial void OnMakeDateChanging(System.Nullable<System.DateTime> value);
        partial void OnMakeDateChanged();
        partial void OnFromContentChanging(string value);
        partial void OnFromContentChanged();
        partial void OnVerifyListChanging(string value);
        partial void OnVerifyListChanged();
        partial void OnWorkStateChanging(System.Nullable<int> value);
        partial void OnWorkStateChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public OA_Work()
        {
            this._HR_Personnel = default(EntityRef<HR_Personnel>);
            this._OA_WorkFlow = default(EntityRef<OA_WorkFlow>);
            OnCreated();
        }

        [Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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

        [Column(Storage = "_WorkName", DbType = "VarChar(100)")]
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

        [Column(Storage = "_WorkFlowID", DbType = "Int")]
        public System.Nullable<int> WorkFlowID
        {
            get
            {
                return this._WorkFlowID;
            }
            set
            {
                if ((this._WorkFlowID != value))
                {
                    if (this._OA_WorkFlow.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnWorkFlowIDChanging(value);
                    this.SendPropertyChanging();
                    this._WorkFlowID = value;
                    this.SendPropertyChanged("WorkFlowID");
                    this.OnWorkFlowIDChanged();
                }
            }
        }

        [Column(Storage = "_Maker", DbType = "Int")]
        public System.Nullable<int> Maker
        {
            get
            {
                return this._Maker;
            }
            set
            {
                if ((this._Maker != value))
                {
                    if (this._HR_Personnel.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnMakerChanging(value);
                    this.SendPropertyChanging();
                    this._Maker = value;
                    this.SendPropertyChanged("Maker");
                    this.OnMakerChanged();
                }
            }
        }

        [Column(Storage = "_MakeDate", DbType = "DateTime")]
        public System.Nullable<System.DateTime> MakeDate
        {
            get
            {
                return this._MakeDate;
            }
            set
            {
                if ((this._MakeDate != value))
                {
                    this.OnMakeDateChanging(value);
                    this.SendPropertyChanging();
                    this._MakeDate = value;
                    this.SendPropertyChanged("MakeDate");
                    this.OnMakeDateChanged();
                }
            }
        }

        [Column(Storage = "_FromContent", DbType = "Text", UpdateCheck = UpdateCheck.Never)]
        public string FromContent
        {
            get
            {
                return this._FromContent;
            }
            set
            {
                if ((this._FromContent != value))
                {
                    this.OnFromContentChanging(value);
                    this.SendPropertyChanging();
                    this._FromContent = value;
                    this.SendPropertyChanged("FromContent");
                    this.OnFromContentChanged();
                }
            }
        }

        [Column(Storage = "_VerifyList", DbType = "VarChar(1000)")]
        public string VerifyList
        {
            get
            {
                return this._VerifyList;
            }
            set
            {
                if ((this._VerifyList != value))
                {
                    this.OnVerifyListChanging(value);
                    this.SendPropertyChanging();
                    this._VerifyList = value;
                    this.SendPropertyChanged("VerifyList");
                    this.OnVerifyListChanged();
                }
            }
        }

        [Column(Storage = "_WorkState", DbType = "Int")]
        public System.Nullable<int> WorkState
        {
            get
            {
                return this._WorkState;
            }
            set
            {
                if ((this._WorkState != value))
                {
                    this.OnWorkStateChanging(value);
                    this.SendPropertyChanging();
                    this._WorkState = value;
                    this.SendPropertyChanged("WorkState");
                    this.OnWorkStateChanged();
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

        [Association(Name = "FK_OA_WORK_REFERENCE_HR_PERSO", Storage = "_HR_Personnel", ThisKey = "Maker", IsForeignKey = true)]
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
                        previousValue.OA_Work.Remove(this);
                    }
                    this._HR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.OA_Work.Add(this);
                        this._Maker = value.ID;
                    }
                    else
                    {
                        this._Maker = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_Personnel");
                }
            }
        }

        [Association(Name = "FK_OA_WORK_REFERENCE_OA_WORKF", Storage = "_OA_WorkFlow", ThisKey = "WorkFlowID", IsForeignKey = true)]
        public OA_WorkFlow OA_WorkFlow
        {
            get
            {
                return this._OA_WorkFlow.Entity;
            }
            set
            {
                OA_WorkFlow previousValue = this._OA_WorkFlow.Entity;
                if (((previousValue != value)
                            || (this._OA_WorkFlow.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._OA_WorkFlow.Entity = null;
                        previousValue.OA_Work.Remove(this);
                    }
                    this._OA_WorkFlow.Entity = value;
                    if ((value != null))
                    {
                        value.OA_Work.Add(this);
                        this._WorkFlowID = value.ID;
                    }
                    else
                    {
                        this._WorkFlowID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("OA_WorkFlow");
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
