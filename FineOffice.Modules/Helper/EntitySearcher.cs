using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules.Helper
{
    /// <summary>
    /// 搜寻器传输对象，每一个实例保存一个条件
    /// </summary>
    [Serializable]
    public class EntitySearcher : System.ComponentModel.INotifyPropertyChanged, ITrackable
    {
        private string _Relation;
        private string _Field;
        private string _Operator;
        private string _Content;
        private string _LeftParentheses;
        private string _RightParentheses;
        TrackingInfo _TrackingState;
       
        /// <summary>
        /// 运算符
        /// </summary>
        public string Operator
        {
            get { return _Operator; }
            set { _Operator = value; }
        }

        /// <summary>
        /// 左括号
        /// </summary>
        public string LeftParentheses
        {
            get { return _LeftParentheses; }
            set { _LeftParentheses = value; }
        }

        /// <summary>
        /// 右括号
        /// </summary>
        public string RightParentheses
        {
            get { return _RightParentheses; }
            set { _RightParentheses = value; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        /// <summary>
        /// 字段
        /// </summary>
        public string Field
        {
            get { return _Field; }
            set { _Field = value; }
        }

        /// <summary>
        /// 关系 如AND,OR,LIKE,NOT LIKE 注意大写
        /// </summary>
        public string Relation
        {
            get { return _Relation; }
            set { _Relation = value; }
        }

        public TrackingInfo TrackingState
        {
            get
            {
                return this._TrackingState;
            }
            set
            {
                if ((this._TrackingState.Equals(value) != true))
                {
                    this._TrackingState = value;
                    this.SendPropertyChanged("TrackingState");
                }
            }
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
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
