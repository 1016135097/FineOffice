using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.CNS_PoliticalAffiliation")]
    public partial class CNS_PoliticalAffiliation : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _Political;

        private string _Remark;

        private EntitySet<CNS_CensusMember> _CNS_CensusMember;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnPoliticalChanging(string value);
        partial void OnPoliticalChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public CNS_PoliticalAffiliation()
        {
            this._CNS_CensusMember = new EntitySet<CNS_CensusMember>(new Action<CNS_CensusMember>(this.attach_CNS_CensusMember), new Action<CNS_CensusMember>(this.detach_CNS_CensusMember));
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

        [Column(Storage = "_Political", DbType = "VarChar(50)")]
        public string Political
        {
            get
            {
                return this._Political;
            }
            set
            {
                if ((this._Political != value))
                {
                    this.OnPoliticalChanging(value);
                    this.SendPropertyChanging();
                    this._Political = value;
                    this.SendPropertyChanged("Political");
                    this.OnPoliticalChanged();
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

        [Association(Name = "FK_CNS_CensusMember_CNS_PoliticalAffiliation", Storage = "_CNS_CensusMember", OtherKey = "PoliticalID", DeleteRule = "NO ACTION")]
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
            entity.CNS_PoliticalAffiliation = this;
        }

        private void detach_CNS_CensusMember(CNS_CensusMember entity)
        {
            this.SendPropertyChanging();
            entity.CNS_PoliticalAffiliation = null;
        }
    }
}
