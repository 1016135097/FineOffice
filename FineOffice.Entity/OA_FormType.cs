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
    [Table(Name = "dbo.OA_FormType")]
    public partial class OA_FormType : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _TypeNO;

        private string _FormTypeName;

        private string _PinyinCode;

        private System.Nullable<bool> _Stop;

        private string _Remark;

        private System.Nullable<int> _Creator;

        private EntitySet<OA_Form> _OA_Form;

        private EntityRef<HR_Personnel> _HR_Personnel;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnTypeNOChanging(string value);
        partial void OnTypeNOChanged();
        partial void OnFormTypeNameChanging(string value);
        partial void OnFormTypeNameChanged();
        partial void OnPinyinCodeChanging(string value);
        partial void OnPinyinCodeChanged();
        partial void OnStopChanging(System.Nullable<bool> value);
        partial void OnStopChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        partial void OnCreatorChanging(System.Nullable<int> value);
        partial void OnCreatorChanged();
        #endregion

        public OA_FormType()
        {
            this._OA_Form = new EntitySet<OA_Form>(new Action<OA_Form>(this.attach_OA_Form), new Action<OA_Form>(this.detach_OA_Form));
            this._HR_Personnel = default(EntityRef<HR_Personnel>);
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

        [Column(Storage = "_TypeNO", DbType = "VarChar(50)")]
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

        [Column(Storage = "_FormTypeName", DbType = "VarChar(200)")]
        public string FormTypeName
        {
            get
            {
                return this._FormTypeName;
            }
            set
            {
                if ((this._FormTypeName != value))
                {
                    this.OnFormTypeNameChanging(value);
                    this.SendPropertyChanging();
                    this._FormTypeName = value;
                    this.SendPropertyChanged("FormTypeName");
                    this.OnFormTypeNameChanged();
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

        [Column(Storage = "_Creator", DbType = "Int")]
        public System.Nullable<int> Creator
        {
            get
            {
                return this._Creator;
            }
            set
            {
                if ((this._Creator != value))
                {
                    if (this._HR_Personnel.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnCreatorChanging(value);
                    this.SendPropertyChanging();
                    this._Creator = value;
                    this.SendPropertyChanged("Creator");
                    this.OnCreatorChanged();
                }
            }
        }

        [Association(Name = "FK_OA_FORM_REFERENCE_OA_FORMT", Storage = "_OA_Form", OtherKey = "TypeID", DeleteRule = "NO ACTION")]
        public EntitySet<OA_Form> OA_Form
        {
            get
            {
                return this._OA_Form;
            }
            set
            {
                this._OA_Form.Assign(value);
            }
        }

        [Association(Name = "FK_OA_FORMTYPE_HR_PERSONNEL", Storage = "_HR_Personnel", ThisKey = "Creator", IsForeignKey = true)]
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
                        previousValue.OA_FormType.Remove(this);
                    }
                    this._HR_Personnel.Entity = value;
                    if ((value != null))
                    {
                        value.OA_FormType.Add(this);
                        this._Creator = value.ID;
                    }
                    else
                    {
                        this._Creator = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("HR_Personnel");
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

        private void attach_OA_Form(OA_Form entity)
        {
            this.SendPropertyChanging();
            entity.OA_FormType = this;
        }

        private void detach_OA_Form(OA_Form entity)
        {
            this.SendPropertyChanging();
            entity.OA_FormType = null;
        }
    }

}
