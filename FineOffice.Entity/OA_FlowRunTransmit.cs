using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.ComponentModel;
using System.Data.Linq;

namespace FineOffice.Entity
{
    [Table(Name = "dbo.OA_FlowRunTransmit")]
    public partial class OA_FlowRunTransmit : INotifyPropertyChanging, INotifyPropertyChanged
    {

        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);

        private int _ID;

        private System.Nullable<int> _RunProcessID;

        private System.Nullable<int> _TransmitTo;

        private System.Nullable<short> _Pattern;

        private EntityRef<OA_FlowRunProcess> _OA_FlowRunProcess;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnIDChanging(int value);
        partial void OnIDChanged();
        partial void OnRunProcessIDChanging(System.Nullable<int> value);
        partial void OnRunProcessIDChanged();
        partial void OnTransmitToChanging(System.Nullable<int> value);
        partial void OnTransmitToChanged();
        partial void OnPatternChanging(System.Nullable<short> value);
        partial void OnPatternChanged();
        #endregion

        public OA_FlowRunTransmit()
        {
            this._OA_FlowRunProcess = default(EntityRef<OA_FlowRunProcess>);
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

        [Column(Storage = "_RunProcessID", DbType = "Int")]
        public System.Nullable<int> RunProcessID
        {
            get
            {
                return this._RunProcessID;
            }
            set
            {
                if ((this._RunProcessID != value))
                {
                    if (this._OA_FlowRunProcess.HasLoadedOrAssignedValue)
                    {
                        throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
                    }
                    this.OnRunProcessIDChanging(value);
                    this.SendPropertyChanging();
                    this._RunProcessID = value;
                    this.SendPropertyChanged("RunProcessID");
                    this.OnRunProcessIDChanged();
                }
            }
        }

        [Column(Storage = "_TransmitTo", DbType = "Int")]
        public System.Nullable<int> TransmitTo
        {
            get
            {
                return this._TransmitTo;
            }
            set
            {
                if ((this._TransmitTo != value))
                {
                    this.OnTransmitToChanging(value);
                    this.SendPropertyChanging();
                    this._TransmitTo = value;
                    this.SendPropertyChanged("TransmitTo");
                    this.OnTransmitToChanged();
                }
            }
        }

        [Column(Storage = "_Pattern", DbType = "SmallInt")]
        public System.Nullable<short> Pattern
        {
            get
            {
                return this._Pattern;
            }
            set
            {
                if ((this._Pattern != value))
                {
                    this.OnPatternChanging(value);
                    this.SendPropertyChanging();
                    this._Pattern = value;
                    this.SendPropertyChanged("Pattern");
                    this.OnPatternChanged();
                }
            }
        }

        [Association(Name = "FK_OA_FlowRunTransmit_OA_FlowRunTransmit", Storage = "_OA_FlowRunProcess", ThisKey = "RunProcessID", IsForeignKey = true)]
        public OA_FlowRunProcess OA_FlowRunProcess
        {
            get
            {
                return this._OA_FlowRunProcess.Entity;
            }
            set
            {
                OA_FlowRunProcess previousValue = this._OA_FlowRunProcess.Entity;
                if (((previousValue != value)
                            || (this._OA_FlowRunProcess.HasLoadedOrAssignedValue == false)))
                {
                    this.SendPropertyChanging();
                    if ((previousValue != null))
                    {
                        this._OA_FlowRunProcess.Entity = null;
                        previousValue.OA_FlowRunTransmit.Remove(this);
                    }
                    this._OA_FlowRunProcess.Entity = value;
                    if ((value != null))
                    {
                        value.OA_FlowRunTransmit.Add(this);
                        this._RunProcessID = value.ID;
                    }
                    else
                    {
                        this._RunProcessID = default(Nullable<int>);
                    }
                    this.SendPropertyChanged("OA_FlowRunProcess");
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
