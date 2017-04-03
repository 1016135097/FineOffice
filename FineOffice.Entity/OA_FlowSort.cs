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
    [Table(Name = "dbo.OA_FlowSort")]
    public partial class OA_FlowSort : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _SortNO;

        private string _FlowSortName;

        private string _PinyinCode;

        private System.Nullable<int> _SerialNO;

        private System.Nullable<bool> _Stop;

        private string _Remark;

        private EntitySet<OA_Flow> _OA_Flow;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnSortNOChanging(string value);
        partial void OnSortNOChanged();
        partial void OnFlowSortNameChanging(string value);
        partial void OnFlowSortNameChanged();
        partial void OnPinyinCodeChanging(string value);
        partial void OnPinyinCodeChanged();
        partial void OnSerialNOChanging(System.Nullable<int> value);
        partial void OnSerialNOChanged();
        partial void OnStopChanging(System.Nullable<bool> value);
        partial void OnStopChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public OA_FlowSort()
        {
            this._OA_Flow = new EntitySet<OA_Flow>(new Action<OA_Flow>(this.attach_OA_Flow), new Action<OA_Flow>(this.detach_OA_Flow));
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

        [Column(Storage = "_SortNO", DbType = "VarChar(10)")]
        public string SortNO
        {
            get
            {
                return this._SortNO;
            }
            set
            {
                if ((this._SortNO != value))
                {
                    this.OnSortNOChanging(value);
                    this.SendPropertyChanging();
                    this._SortNO = value;
                    this.SendPropertyChanged("SortNO");
                    this.OnSortNOChanged();
                }
            }
        }

        [Column(Storage = "_FlowSortName", DbType = "VarChar(200)")]
        public string FlowSortName
        {
            get
            {
                return this._FlowSortName;
            }
            set
            {
                if ((this._FlowSortName != value))
                {
                    this.OnFlowSortNameChanging(value);
                    this.SendPropertyChanging();
                    this._FlowSortName = value;
                    this.SendPropertyChanged("FlowSortName");
                    this.OnFlowSortNameChanged();
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

        [Column(Storage = "_SerialNO", DbType = "Int")]
        public System.Nullable<int> SerialNO
        {
            get
            {
                return this._SerialNO;
            }
            set
            {
                if ((this._SerialNO != value))
                {
                    this.OnSerialNOChanging(value);
                    this.SendPropertyChanging();
                    this._SerialNO = value;
                    this.SendPropertyChanged("SerialNO");
                    this.OnSerialNOChanged();
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

        [Association(Name = "FK_OA_FLOW_REFERENCE_OA_FLOWS", Storage = "_OA_Flow", OtherKey = "SortID", DeleteRule = "NO ACTION")]
        public EntitySet<OA_Flow> OA_Flow
        {
            get
            {
                return this._OA_Flow;
            }
            set
            {
                this._OA_Flow.Assign(value);
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

        private void attach_OA_Flow(OA_Flow entity)
        {
            this.SendPropertyChanging();
            entity.OA_FlowSort = this;
        }

        private void detach_OA_Flow(OA_Flow entity)
        {
            this.SendPropertyChanging();
            entity.OA_FlowSort = null;
        }
    }
}
