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
    [Table(Name = "dbo.HR_Job")]
    public partial class HR_Job : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _JobNO;

        private string _Job;

        private string _PinyinCode;

        private System.Nullable<bool> _Stop;

        private string _Remark;

        private EntitySet<HR_Personnel> _HR_Personnel;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnJobNOChanging(string value);
        partial void OnJobNOChanged();
        partial void OnJobChanging(string value);
        partial void OnJobChanged();
        partial void OnPinyinCodeChanging(string value);
        partial void OnPinyinCodeChanged();
        partial void OnStopChanging(System.Nullable<bool> value);
        partial void OnStopChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public HR_Job()
        {
            this._HR_Personnel = new EntitySet<HR_Personnel>(new Action<HR_Personnel>(this.attach_HR_Personnel), new Action<HR_Personnel>(this.detach_HR_Personnel));
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

        [Column(Storage = "_JobNO", DbType = "VarChar(10) NOT NULL", CanBeNull = false)]
        public string JobNO
        {
            get
            {
                return this._JobNO;
            }
            set
            {
                if ((this._JobNO != value))
                {
                    this.OnJobNOChanging(value);
                    this.SendPropertyChanging();
                    this._JobNO = value;
                    this.SendPropertyChanged("JobNO");
                    this.OnJobNOChanged();
                }
            }
        }

        [Column(Storage = "_Job", DbType = "VarChar(50) NOT NULL", CanBeNull = false)]
        public string Job
        {
            get
            {
                return this._Job;
            }
            set
            {
                if ((this._Job != value))
                {
                    this.OnJobChanging(value);
                    this.SendPropertyChanging();
                    this._Job = value;
                    this.SendPropertyChanged("Job");
                    this.OnJobChanged();
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

        [Association(Name = "FK_HR_PERSO_REFERENCE_HR_JOB", Storage = "_HR_Personnel", OtherKey = "JobID", DeleteRule = "NO ACTION")]
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
            entity.HR_Job = this;
        }

        private void detach_HR_Personnel(HR_Personnel entity)
        {
            this.SendPropertyChanging();
            entity.HR_Job = null;
        }
    }
}
