using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.SYS_Parameter")]
    public partial class SYS_Parameter : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private string _ParameterName;

        private string _ParameterValue;

        private string _Sign;

        private string _TableName;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnParameterNameChanging(string value);
        partial void OnParameterNameChanged();
        partial void OnParameterValueChanging(string value);
        partial void OnParameterValueChanged();
        partial void OnSignChanging(string value);
        partial void OnSignChanged();
        partial void OnTableNameChanging(string value);
        partial void OnTableNameChanged();
        #endregion

        public SYS_Parameter()
        {
            OnCreated();
        }

        [Column(Storage = "_ID", IsVersion = true, DbType = "Int NOT NULL", IsPrimaryKey = true)]
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

        [Column(Storage = "_ParameterName", DbType = "VarChar(100)")]
        public string ParameterName
        {
            get
            {
                return this._ParameterName;
            }
            set
            {
                if ((this._ParameterName != value))
                {
                    this.OnParameterNameChanging(value);
                    this.SendPropertyChanging();
                    this._ParameterName = value;
                    this.SendPropertyChanged("ParameterName");
                    this.OnParameterNameChanged();
                }
            }
        }

        [Column(Storage = "_ParameterValue", DbType = "VarChar(50)")]
        public string ParameterValue
        {
            get
            {
                return this._ParameterValue;
            }
            set
            {
                if ((this._ParameterValue != value))
                {
                    this.OnParameterValueChanging(value);
                    this.SendPropertyChanging();
                    this._ParameterValue = value;
                    this.SendPropertyChanged("ParameterValue");
                    this.OnParameterValueChanged();
                }
            }
        }

        [Column(Storage = "_Sign", DbType = "VarChar(50)")]
        public string Sign
        {
            get
            {
                return this._Sign;
            }
            set
            {
                if ((this._Sign != value))
                {
                    this.OnSignChanging(value);
                    this.SendPropertyChanging();
                    this._Sign = value;
                    this.SendPropertyChanged("Sign");
                    this.OnSignChanged();
                }
            }
        }

        [Column(Storage = "_TableName", DbType = "VarChar(50)")]
        public string TableName
        {
            get
            {
                return this._TableName;
            }
            set
            {
                if ((this._TableName != value))
                {
                    this.OnTableNameChanging(value);
                    this.SendPropertyChanging();
                    this._TableName = value;
                    this.SendPropertyChanged("TableName");
                    this.OnTableNameChanged();
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
