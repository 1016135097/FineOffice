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
    [Table(Name = "dbo.OA_ProjectType")]
    public partial class OA_ProjectType : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _TypeNO;

        private string _TypeName;

        private string _PinyinCode;

        private System.Nullable<short> _Stop;

        private string _Remark;

        private EntitySet<OA_WorkFlow> _OA_WorkFlow;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnTypeNOChanging(string value);
        partial void OnTypeNOChanged();
        partial void OnTypeNameChanging(string value);
        partial void OnTypeNameChanged();
        partial void OnPinyinCodeChanging(string value);
        partial void OnPinyinCodeChanged();
        partial void OnStopChanging(System.Nullable<short> value);
        partial void OnStopChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public OA_ProjectType()
        {
            this._OA_WorkFlow = new EntitySet<OA_WorkFlow>(new Action<OA_WorkFlow>(this.attach_OA_WorkFlow), new Action<OA_WorkFlow>(this.detach_OA_WorkFlow));
            OnCreated();
        }

        [Column(Storage = "_ID", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true, IsVersion=true)]
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

        [Column(Storage = "_TypeNO", DbType = "VarChar(10)")]
        public string TypeNO
        {
            get
            {
                return this._TypeNO;
            }
            set
            {
                if ((this._TypeNO != value))
                {
                    this.OnTypeNOChanging(value);
                    this.SendPropertyChanging();
                    this._TypeNO = value;
                    this.SendPropertyChanged("TypeNO");
                    this.OnTypeNOChanged();
                }
            }
        }

        [Column(Storage = "_TypeName", DbType = "VarChar(50)")]
        public string TypeName
        {
            get
            {
                return this._TypeName;
            }
            set
            {
                if ((this._TypeName != value))
                {
                    this.OnTypeNameChanging(value);
                    this.SendPropertyChanging();
                    this._TypeName = value;
                    this.SendPropertyChanged("TypeName");
                    this.OnTypeNameChanged();
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

        [Column(Storage = "_Stop", DbType = "SmallInt")]
        public System.Nullable<short> Stop
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

        [Association(Name = "FK_OA_WORKF_REFERENCE_OA_PROJE", Storage = "_OA_WorkFlow", OtherKey = "ProjectTypeID", DeleteRule = "NO ACTION")]
        public EntitySet<OA_WorkFlow> OA_WorkFlow
        {
            get
            {
                return this._OA_WorkFlow;
            }
            set
            {
                this._OA_WorkFlow.Assign(value);
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

        private void attach_OA_WorkFlow(OA_WorkFlow entity)
        {
            this.SendPropertyChanging();
            entity.OA_ProjectType = this;
        }

        private void detach_OA_WorkFlow(OA_WorkFlow entity)
        {
            this.SendPropertyChanging();
            entity.OA_ProjectType = null;
        }
    }
}
