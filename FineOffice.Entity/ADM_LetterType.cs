using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.ComponentModel;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.ADM_LetterType")]
    public partial class ADM_LetterType : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _LetterType;

        private string _Remark;

        private EntitySet<ADM_Letter> _ADM_Letter;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnLetterTypeChanging(string value);
        partial void OnLetterTypeChanged();
        partial void OnRemarkChanging(string value);
        partial void OnRemarkChanged();
        #endregion

        public ADM_LetterType()
        {
            this._ADM_Letter = new EntitySet<ADM_Letter>(new Action<ADM_Letter>(this.attach_ADM_Letter), new Action<ADM_Letter>(this.detach_ADM_Letter));
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

        [Column(Storage = "_LetterType", DbType = "VarChar(50)")]
        public string LetterType
        {
            get
            {
                return this._LetterType;
            }
            set
            {
                if ((this._LetterType != value))
                {
                    this.OnLetterTypeChanging(value);
                    this.SendPropertyChanging();
                    this._LetterType = value;
                    this.SendPropertyChanged("LetterType");
                    this.OnLetterTypeChanged();
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

        [Association(Name = "FK_ADM_Letter_ADM_LetterType", Storage = "_ADM_Letter", OtherKey = "TypeID", DeleteRule = "NO ACTION")]
        public EntitySet<ADM_Letter> ADM_Letter
        {
            get
            {
                return this._ADM_Letter;
            }
            set
            {
                this._ADM_Letter.Assign(value);
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

        private void attach_ADM_Letter(ADM_Letter entity)
        {
            this.SendPropertyChanging();
            entity.ADM_LetterType = this;
        }

        private void detach_ADM_Letter(ADM_Letter entity)
        {
            this.SendPropertyChanging();
            entity.ADM_LetterType = null;
        }
    }
}
