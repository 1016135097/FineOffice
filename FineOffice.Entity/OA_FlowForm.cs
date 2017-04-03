using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.OA_FlowForm")]
    public partial class OA_FlowForm : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private System.Nullable<int> _FormID;

        private string _ProcessID;

        private System.Nullable<int> _FlowID;

        private EntityRef<OA_Flow> _OA_Flow;

        private EntityRef<OA_FlowProcess> _OA_FlowProcess;

        private EntityRef<OA_Form> _OA_Form;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnFormIDChanging(System.Nullable<int> value);
        partial void OnFormIDChanged();
        partial void OnProcessIDChanging(string value);
        partial void OnProcessIDChanged();
        partial void OnFlowIDChanging(System.Nullable<int> value);
        partial void OnFlowIDChanged();
        #endregion

        public OA_FlowForm()
        {
            this._OA_Flow = default(EntityRef<OA_Flow>);
            this._OA_FlowProcess = default(EntityRef<OA_FlowProcess>);
            this._OA_Form = default(EntityRef<OA_Form>);
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

        [Column(Storage = "_ProcessID", DbType = "VarChar(50)")]
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

        [Association(Name = "FK_OA_FLOWFORM_OA_FLOW", Storage = "_OA_Flow", ThisKey = "FlowID", IsForeignKey = true)]
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
                        previousValue.OA_FlowForm.Remove(this);
                    }
                    this._OA_Flow.Entity = value;
                    if ((value != null))
                    {
                        value.OA_FlowForm.Add(this);
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

        [Association(Name = "FK_OA_FlOWFORM_OA_FlOWPROCESS", Storage = "_OA_FlowProcess", ThisKey = "ProcessID", IsForeignKey = true)]
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
                        previousValue.OA_FlowForm.Remove(this);
                    }
                    this._OA_FlowProcess.Entity = value;
                    if ((value != null))
                    {
                        value.OA_FlowForm.Add(this);
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

        [Association(Name = "FK_OA_FlOWFORM_OA_FORM", Storage = "_OA_Form", ThisKey = "FormID", IsForeignKey = true)]
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
                        previousValue.OA_FlowForm.Remove(this);
                    }
                    this._OA_Form.Entity = value;
                    if ((value != null))
                    {
                        value.OA_FlowForm.Add(this);
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
