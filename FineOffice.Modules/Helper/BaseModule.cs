using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FineOffice.Modules.Helper
{
    [Serializable]
    public class BaseModule : System.ComponentModel.INotifyPropertyChanged, ITrackable
    {
        private bool _Changes = false;
        private TrackingInfo _TrackingState;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 记录是否改变
        /// </summary>
        public bool Changes
        {
            get { return _Changes; }
            set { _Changes = value; }
        }

        public TrackingInfo TrackingState
        {
            get { return this._TrackingState; }
            set
            {
                if ((this._TrackingState.Equals(value) != true))
                {
                    this._TrackingState = value;
                    this.SendPropertyChanged("TrackingState");
                }
            }           
        }

        protected void SendPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
