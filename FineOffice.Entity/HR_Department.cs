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
    [Table(Name = "dbo.HR_Department")]
    public partial class HR_Department : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _DepartmentNO;

        private string _DepartmentName;

        private string _PinyinCode;

        private System.Nullable<bool> _Stop;

        private string _Remark;

        private EntitySet<HR_Personnel> _HR_Personnel;

        private EntitySet<OA_FlowAuthority> _OA_FlowAuthority;

        private EntitySet<OA_ProcessAuthority> _OA_ProcessAuthority;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnDepartmentNOChanging(string value);
        partial void OnDepartmentNOChanged();
        partial void OnDepartmentNameChanging(string value);
        partial void OnDepartmentNameChanged();
        partial void OnPinyinCodeChanging(string value);
        partial void OnPinyinCodeChanged();
        partial void OnStopChanging(System.Nullable<bool> value);
        partial void OnStopChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public HR_Department()
        {
            this._HR_Personnel = new EntitySet<HR_Personnel>(new Action<HR_Personnel>(this.attach_HR_Personnel), new Action<HR_Personnel>(this.detach_HR_Personnel));
            this._OA_FlowAuthority = new EntitySet<OA_FlowAuthority>(new Action<OA_FlowAuthority>(this.attach_OA_FlowAuthority), new Action<OA_FlowAuthority>(this.detach_OA_FlowAuthority));
            this._OA_ProcessAuthority = new EntitySet<OA_ProcessAuthority>(new Action<OA_ProcessAuthority>(this.attach_OA_ProcessAuthority), new Action<OA_ProcessAuthority>(this.detach_OA_ProcessAuthority));
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

        [Column(Storage = "_DepartmentNO", DbType = "VarChar(10) NOT NULL", CanBeNull = false)]
        public string DepartmentNO
        {
            get
            {
                return this._DepartmentNO;
            }
            set
            {
                if ((this._DepartmentNO != value))
                {
                    this.OnDepartmentNOChanging(value);
                    this.SendPropertyChanging();
                    this._DepartmentNO = value;
                    this.SendPropertyChanged("DepartmentNO");
                    this.OnDepartmentNOChanged();
                }
            }
        }

        [Column(Storage = "_DepartmentName", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
        public string DepartmentName
        {
            get
            {
                return this._DepartmentName;
            }
            set
            {
                if ((this._DepartmentName != value))
                {
                    this.OnDepartmentNameChanging(value);
                    this.SendPropertyChanging();
                    this._DepartmentName = value;
                    this.SendPropertyChanged("DepartmentName");
                    this.OnDepartmentNameChanged();
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

        [Association(Name = "FK_HR_PERSO_REFERENCE_HR_DEPAR", Storage = "_HR_Personnel", OtherKey = "DepartmentID", DeleteRule = "NO ACTION")]
        public EntitySet<HR_Personnel> HR_Personnel
        {
            get
            {
                return this._HR_Personnel;
            }
            set
            {
                this._HR_Personnel.Assign(value);
            }
        }

        [Association(Name = "FK_OA_FLOW_DEPART", Storage = "_OA_FlowAuthority", OtherKey = "DepartmentID", DeleteRule = "NO ACTION")]
        public EntitySet<OA_FlowAuthority> OA_FlowAuthority
        {
            get
            {
                return this._OA_FlowAuthority;
            }
            set
            {
                this._OA_FlowAuthority.Assign(value);
            }
        }

        [Association(Name = "FK_OA_PROCESS_DEPERT", Storage = "_OA_ProcessAuthority", OtherKey = "DepartmentID", DeleteRule = "NO ACTION")]
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

        private void attach_HR_Personnel(HR_Personnel entity)
        {
            this.SendPropertyChanging();
            entity.HR_Department = this;
        }

        private void detach_HR_Personnel(HR_Personnel entity)
        {
            this.SendPropertyChanging();
            entity.HR_Department = null;
        }

        private void attach_OA_FlowAuthority(OA_FlowAuthority entity)
        {
            this.SendPropertyChanging();
            entity.HR_Department = this;
        }

        private void detach_OA_FlowAuthority(OA_FlowAuthority entity)
        {
            this.SendPropertyChanging();
            entity.HR_Department = null;
        }

        private void attach_OA_ProcessAuthority(OA_ProcessAuthority entity)
        {
            this.SendPropertyChanging();
            entity.HR_Department = this;
        }

        private void detach_OA_ProcessAuthority(OA_ProcessAuthority entity)
        {
            this.SendPropertyChanging();
            entity.HR_Department = null;
        }
    }
}
