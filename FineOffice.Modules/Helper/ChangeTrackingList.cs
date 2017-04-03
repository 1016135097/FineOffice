using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Reflection;
using FineOffice.Common;
using FineOffice.Common.ListHelper;

namespace FineOffice.Modules.Helper
{
    [Serializable]
    public class ChangeTrackingList<T> : BindingList<T>
        where T : ITrackable, INotifyPropertyChanged
    {
        // Responsible for tracking changes to items in collection
        ChangeTrackingHelper<T> changeTracker = new ChangeTrackingHelper<T>();

        // Fired when an item has changed in the collection
        public event EventHandler<ItemChangedEventArgs<T>> ItemChanged
        {
            add { changeTracker.ItemChanged += value; }
            remove { changeTracker.ItemChanged -= value; }
        }

        public ChangeTrackingList(Collection<T> list)
            : base(list)
        {
            // Add items to the change tracking list
            foreach (T item in list)
            {
                changeTracker.Add(item);
            }
        }

        // Turn change tracking on and off
        public bool Tracking
        {
            get { return changeTracker.Tracking; }
            set { changeTracker.Tracking = value; }
        }

        protected override void InsertItem(int index, T item)
        {
            try
            {
                // Add item to base collection            
                base.InsertItem(index, item);
                // Add item to change tracker
                changeTracker.Add(item);
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
        }

        protected override void ClearItems()
        {
            changeTracker.Clear();
            base.ClearItems();
        }

        protected override void RemoveItem(int index)
        {
            try
            {
                T t = this[index];
                // Remove item from change tracker
                if (index < changeTracker.Count)
                    changeTracker.Remove(t);
                // Add item to base collection
                base.RemoveItem(index);
            }
            catch
            {
            }
        }
        /// <summary>
        /// 转为list
        /// </summary>
        /// <returns></returns>
        public List<T> ToList()
        {
            List<T> list = new List<T>();
            foreach (T item in this)
            {
                list.Add(item);
            }
            return list;
        }

        public void ClearChanges()
        {
            changeTracker.ClearChanges();//清空Item
            changeTracker.Tracking = false;
            foreach (T item in this)
            {
                PropertyInfo prop = item.GetType().GetProperty("TrackingState");
                prop.SetValue(item, TrackingInfo.Unchanged, null);
                changeTracker.Add(item);
            }
        }

        public ChangeTrackingList<T> GetChanges()
        {
            ChangeTrackingHelper<T> changes = changeTracker.GetChanges(); // Get just the changed items
            return new ChangeTrackingList<T>(changes);
        }


        #region 以下是排序方式
        private bool isSorted;
        private string sortProperty;
        private string sortDirection;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ChangeTrackingList()
            : base()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="list">IList类型的列表对象</param>
        public ChangeTrackingList(IList<T> list)
            : base(list)
        {
        }

        /// <summary>
        /// 自定义排序操作
        /// </summary>
        /// <param name="property"></param>
        /// <param name="direction"></param>
        public void Sort(string property, string direction)
        {
            List<T> items = this.Items as List<T>;
            if (direction == null || (!direction.Equals("ASC") && !direction.Equals("DESC")))
                throw new Exception("必须指定排序方式(ASC,DESC)");

            if (items != null)
            {
                ObjectPropertyCompare<T> pc = new ObjectPropertyCompare<T>(property, direction);
                items.Sort(pc);
                isSorted = true;
            }
            else
            {
                isSorted = false;
            }
            sortProperty = property;
            sortDirection = direction;
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        /// <summary>
        /// 获取一个值，指示列表是否已排序
        /// </summary>
        protected override bool IsSortedCore
        {
            get
            {
                return isSorted;
            }
        }

        /// <summary>
        /// 获取一个值，指示列表是否支持排序
        /// </summary>
        protected override bool SupportsSortingCore
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 移除默认实现的排序
        /// </summary>
        protected override void RemoveSortCore()
        {
            isSorted = false;
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }
        #endregion
    }
}
