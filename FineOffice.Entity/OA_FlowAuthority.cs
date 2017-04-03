using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.OA_FlowAuthority")]
    public partial class OA_FlowAuthority : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private System.Nullable<int> _FlowID;

        private System.Nullable<int> _DepartmentID;

        private System.Nullable<int> _PersonnelID;

        private EntityRef<HR_Department> _HR_Department;

        private EntityRef<HR_Personnel> _HR_Personnel;

        private EntityRef<OA_Flow> _OA_Flow;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnFlowIDChanging(System.Nullable<int> value);
        partial void OnFlowIDChanged();
        partial void OnDepartmentIDChanging(System.Nullable<int> value);
        partial void OnDepartmentIDChanged();
        partial void OnPersonnelIDChanging(System.Nullable<int> value);
        partial void OnPersonnelIDChanged();
        #endregion

        public OA_FlowAuthority()
        {
            this._HR_Department = default(EntityRef<HR_Department>);
            this._HR_Personnel = default(EntityRef<HR_Personnel>);
            this._OA_Flow = default(EntityRef<OA_Flow>);
            OnCreated();
        }

        [Column(Storage = "_ID",IsVersion=true, AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
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

        [Association(Name = "FK_OA_FLOW_DEPART", Storage = "_HR_Department", ThisKey = "DepartmentID", IsForeignKey = true)]
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
                        previousValue.OA_FlowAuthority.Remove(this);
                    }
                    this._HR_Department.Entity = value;
                    if ((value != null))
                    {
                        value.OA_FlowAuthority.Add(this);
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

        [Association(Name = "FK_OA_FLOW_PERSONNEL", Storage = "_HR_Personnel", ThisKey = "PersonnelID", IsForeignKey = true)]
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
                        previousValue.OA_FlowAuthority.Remove(this);
                    }
                    this._HR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.OA_FlowAuthority.Add(this);
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

        [Association(Name = "FK_OA_FLOWAUTHORITY", Storage = "_OA_Flow", ThisKey = "FlowID", IsForeignKey = true)]
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
                        previousValue.OA_FlowAuthority.Remove(this);
                    }
                    this._OA_Flow.Entity = value;
                    if ((value != null))
                    {
                        value.OA_FlowAuthority.Add(this);
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
