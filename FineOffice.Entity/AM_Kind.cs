using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.ComponentModel;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.AM_Kind")]
    public partial class AM_Kind : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private System.Nullable<int> _Serial;

        private string _SerialNO;

        private string _Name;

        private System.Nullable<int> _KindID;

        private string _KindName;

        private System.Nullable<int> _Relation;

        private EntitySet<CNS_CensusMember> _CNS_CensusMember;

        private EntitySet<HR_Personnel> _HR_Personnel;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnSerialChanging(System.Nullable<int> value);
        partial void OnSerialChanged();
        partial void OnSerialNOChanging(string value);
        partial void OnSerialNOChanged();
        partial void OnNameChanging(string value);
        partial void OnNameChanged();
        partial void OnKindIDChanging(System.Nullable<int> value);
        partial void OnKindIDChanged();
        partial void OnKindNameChanging(string value);
        partial void OnKindNameChanged();
        partial void OnRelationChanging(System.Nullable<int> value);
        partial void OnRelationChanged();
        #endregion

        public AM_Kind()
        {
            this._CNS_CensusMember = new EntitySet<CNS_CensusMember>(new Action<CNS_CensusMember>(this.attach_CNS_CensusMember), new Action<CNS_CensusMember>(this.detach_CNS_CensusMember));
            this._HR_Personnel = new EntitySet<HR_Personnel>(new Action<HR_Personnel>(this.attach_HR_Personnel), new Action<HR_Personnel>(this.detach_HR_Personnel));
            OnCreated();
        }

        [Column(Storage = "_ID", DbType = "Int NOT NULL", IsPrimaryKey = true)]
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

        [Column(Storage = "_Serial", DbType = "Int")]
        public System.Nullable<int> Serial
        {
            get
            {
                return this._Serial;
            }
            set
            {
                if ((this._Serial != value))
                {
                    this.OnSerialChanging(value);
                    this.SendPropertyChanging();
                    this._Serial = value;
                    this.SendPropertyChanged("Serial");
                    this.OnSerialChanged();
                }
            }
        }

        [Column(Storage = "_SerialNO", DbType = "VarChar(50)")]
        public string SerialNO
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

        [Column(Storage = "_Name", DbType = "VarChar(50)")]
        public string Name
        {
            get
            {
                return this._Name;
            }
            set
            {
                if ((this._Name != value))
                {
                    this.OnNameChanging(value);
                    this.SendPropertyChanging();
                    this._Name = value;
                    this.SendPropertyChanged("Name");
                    this.OnNameChanged();
                }
            }
        }

        [Column(Storage = "_KindID", DbType = "Int")]
        public System.Nullable<int> KindID
        {
            get
            {
                return this._KindID;
            }
            set
            {
                if ((this._KindID != value))
                {
                    this.OnKindIDChanging(value);
                    this.SendPropertyChanging();
                    this._KindID = value;
                    this.SendPropertyChanged("KindID");
                    this.OnKindIDChanged();
                }
            }
        }

        [Column(Storage = "_KindName", DbType = "VarChar(50)")]
        public string KindName
        {
            get
            {
                return this._KindName;
            }
            set
            {
                if ((this._KindName != value))
                {
                    this.OnKindNameChanging(value);
                    this.SendPropertyChanging();
                    this._KindName = value;
                    this.SendPropertyChanged("KindName");
                    this.OnKindNameChanged();
                }
            }
        }

        [Column(Storage = "_Relation", DbType = "Int")]
        public System.Nullable<int> Relation
        {
            get
            {
                return this._Relation;
            }
            set
            {
                if ((this._Relation != value))
                {
                    this.OnRelationChanging(value);
                    this.SendPropertyChanging();
                    this._Relation = value;
                    this.SendPropertyChanged("Relation");
                    this.OnRelationChanged();
                }
            }
        }

        [Association(Name = "FK_CNS_CensusMember_AM_Kind", Storage = "_CNS_CensusMember", OtherKey = "EducationID", DeleteRule = "NO ACTION")]
        public EntitySet<CNS_CensusMember> CNS_CensusMember
        {
            get
            {
                return this._CNS_CensusMember;
            }
            set
            {
                this._CNS_CensusMember.Assign(value);
            }
        }

        [Association(Name = "FK_HR_PERSONNEL_AM_KIND", Storage = "_HR_Personnel", OtherKey = "EducationID", DeleteRule = "NO ACTION")]
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

        private void attach_CNS_CensusMember(CNS_CensusMember entity)
        {
            this.SendPropertyChanging();
            entity.AM_Kind = this;
        }

        private void detach_CNS_CensusMember(CNS_CensusMember entity)
        {
            this.SendPropertyChanging();
            entity.AM_Kind = null;
        }

        private void attach_HR_Personnel(HR_Personnel entity)
        {
            this.SendPropertyChanging();
            entity.AM_Kind = this;
        }

        private void detach_HR_Personnel(HR_Personnel entity)
        {
            this.SendPropertyChanging();
            entity.AM_Kind = null;
        }
    }
}
