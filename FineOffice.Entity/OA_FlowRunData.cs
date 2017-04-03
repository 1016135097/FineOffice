using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Data.Linq;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.OA_FlowRunData")]
    public partial class OA_FlowRunData : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _Title;

        private System.Nullable<int> _RunProcessID;

        private System.Nullable<int> _FormID;

        private System.Data.Linq.Binary _FormData;

        private string _XType;

        private System.Nullable<System.DateTime> _UpdateTime;

        private System.Nullable<System.DateTime> _CreateTime;

        private string _Remark;

        private EntityRef<OA_Form> _OA_Form;

        private EntityRef<OA_FlowRunProcess> _OA_FlowRunProcess;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnTitleChanging(string value);
        partial void OnTitleChanged();
        partial void OnRunProcessIDChanging(System.Nullable<int> value);
        partial void OnRunProcessIDChanged();
        partial void OnFormIDChanging(System.Nullable<int> value);
        partial void OnFormIDChanged();
        partial void OnFormDataChanging(System.Data.Linq.Binary value);
        partial void OnFormDataChanged();
        partial void OnXTypeChanging(string value);
        partial void OnXTypeChanged();
        partial void OnUpdateTimeChanging(System.Nullable<System.DateTime> value);
        partial void OnUpdateTimeChanged();
        partial void OnCreateTimeChanging(System.Nullable<System.DateTime> value);
        partial void OnCreateTimeChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public OA_FlowRunData()
        {
            this._OA_Form = default(EntityRef<OA_Form>);
            this._OA_FlowRunProcess = default(EntityRef<OA_FlowRunProcess>);
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

        [Column(Storage = "_UpdateTime", DbType = "DateTime")]
        public System.Nullable<System.DateTime> UpdateTime
        {
            get
            {
                return this._UpdateTime;
            }
            set
            {
                if ((this._UpdateTime != value))
                {
                    this.OnUpdateTimeChanging(value);
                    this.SendPropertyChanging();
                    this._UpdateTime = value;
                    this.SendPropertyChanged("UpdateTime");
                    this.OnUpdateTimeChanged();
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

        [Association(Name = "FK_OA_FlowRunData_OA_FlowRunData", Storage = "_OA_Form", ThisKey = "FormID", IsForeignKey = true)]
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
                        previousValue.OA_FlowRunData.Remove(this);
                    }
                    this._OA_Form.Entity = value;
                    if ((value != null))
                    {
                        value.OA_FlowRunData.Add(this);
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

        [Association(Name = "FK_OA_FlowRunData_OA_FlowRunProcess", Storage = "_OA_FlowRunProcess", ThisKey = "RunProcessID", IsForeignKey = true)]
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
                        previousValue.OA_FlowRunData.Remove(this);
                    }
                    this._OA_FlowRunProcess.Entity = value;
                    if ((value != null))
                    {
                        value.OA_FlowRunData.Add(this);
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
