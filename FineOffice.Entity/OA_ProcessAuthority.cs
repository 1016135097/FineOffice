using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Data.Linq;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.OA_ProcessAuthority")]
    public partial class OA_ProcessAuthority : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private System.Nullable<int> _DepartmentID;

        private System.Nullable<int> _RoleID;

        private System.Nullable<int> _PersonnelID;

        private string _PrecessID;

        private EntityRef<HR_Department> _HR_Department;

        private EntityRef<HR_Personnel> _HR_Personnel;

        private EntityRef<OA_FlowProcess> _OA_FlowProcess;

        private EntityRef<SYS_Role> _SYS_Role;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnDepartmentIDChanging(System.Nullable<int> value);
        partial void OnDepartmentIDChanged();
        partial void OnRoleIDChanging(System.Nullable<int> value);
        partial void OnRoleIDChanged();
        partial void OnPersonnelIDChanging(System.Nullable<int> value);
        partial void OnPersonnelIDChanged();
        partial void OnPrecessIDChanging(string value);
        partial void OnPrecessIDChanged();
        #endregion

        public OA_ProcessAuthority()
        {
            this._HR_Department = default(EntityRef<HR_Department>);
            this._HR_Personnel = default(EntityRef<HR_Personnel>);
            this._OA_FlowProcess = default(EntityRef<OA_FlowProcess>);
            this._SYS_Role = default(EntityRef<SYS_Role>);
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

        [Column(Storage = "_RoleID", DbType = "Int")]
        public System.Nullable<int> RoleID
        {
            get
            {
                return this._RoleID;
            }
            set
            {
                if ((this._RoleID != value))
                {
                    if (this._SYS_Role.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnRoleIDChanging(value);
                    this.SendPropertyChanging();
                    this._RoleID = value;
                    this.SendPropertyChanged("RoleID");
                    this.OnRoleIDChanged();
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

        [Column(Storage = "_PrecessID", DbType = "VarChar(50)")]
        public string PrecessID
        {
            get
            {
                return this._PrecessID;
            }
            set
            {
                if ((this._PrecessID != value))
                {
                    if (this._OA_FlowProcess.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnPrecessIDChanging(value);
                    this.SendPropertyChanging();
                    this._PrecessID = value;
                    this.SendPropertyChanged("PrecessID");
                    this.OnPrecessIDChanged();
                }
            }
        }

        [Association(Name = "FK_OA_PROCESS_DEPERT", Storage = "_HR_Department", ThisKey = "DepartmentID", IsForeignKey = true)]
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
                        previousValue.OA_ProcessAuthority.Remove(this);
                    }
                    this._HR_Department.Entity = value;
                    if ((value != null))
                    {
                        value.OA_ProcessAuthority.Add(this);
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

        [Association(Name = "FK_OA_PROCESS_PERSONNEL", Storage = "_HR_Personnel", ThisKey = "PersonnelID", IsForeignKey = true)]
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
                        previousValue.OA_ProcessAuthority.Remove(this);
                    }
                    this._HR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.OA_ProcessAuthority.Add(this);
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

        [Association(Name = "FK_OA_PROCESSAUTHORITY", Storage = "_OA_FlowProcess", ThisKey = "PrecessID", IsForeignKey = true)]
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
                        previousValue.OA_ProcessAuthority.Remove(this);
                    }
                    this._OA_FlowProcess.Entity = value;
                    if ((value != null))
                    {
                        value.OA_ProcessAuthority.Add(this);
                        this._PrecessID = value.ID;
                    }
                    else
                    {
                        this._PrecessID = default(string);
                    }
                    this.SendPropertyChanged("OA_FlowProcess");
                }
            }
        }

        [Association(Name = "FK_OA_PROCESSS_ROLE", Storage = "_SYS_Role", ThisKey = "RoleID", IsForeignKey = true)]
        public SYS_Role SYS_Role
        {
            get
            {
                return this._SYS_Role.Entity;
            }
            set
            {
                SYS_Role previousValue = this._SYS_Role.Entity;
                if (((previousValue != value)
                            || (this._SYS_Role.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._SYS_Role.Entity = null;
                        previousValue.OA_ProcessAuthority.Remove(this);
                    }
                    this._SYS_Role.Entity = value;
                    if ((value != null))
                    {
                        value.OA_ProcessAuthority.Add(this);
                        this._RoleID = value.ID;
                    }
                    else
                    {
                        this._RoleID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("SYS_Role");
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
