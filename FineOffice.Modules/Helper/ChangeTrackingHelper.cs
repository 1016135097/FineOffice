using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace FineOffice.Modules.Helper
{
    [Serializable]
    internal class ChangeTrackingHelper<T> : Collection<T>
        where T : ITrackable, INotifyPropertyChanged
    {
        Collection<T> deletedItems = new Collection<T>();

        public event EventHandler<ItemChangedEventArgs<T>> ItemChanged;

        // Constructors
        public ChangeTrackingHelper() : base() { }

        // Start and stop change tracking
        private bool tracking;
        public bool Tracking
        {
            get
            {
                return tracking;
            }
            set
            {
                //当集合中的元素发生改变的时候发出通知
                foreach (T item in this)
                {
                    if (value) item.PropertyChanged += OnItemChanged;
                    else item.PropertyChanged -= OnItemChanged;
                }
                tracking = value;
            }
        }

        // 元素发生改变时的处理事件
        void OnItemChanged(object sender, PropertyChangedEventArgs e)
        {
            if (Tracking)
            {
                ITrackable item = (ITrackable)sender;
                if (e.PropertyName != "TrackingState")
                {
                    // 标志元素被更新
                    if (item.TrackingState == TrackingInfo.Unchanged)
                    {
                        item.TrackingState = TrackingInfo.Updated;
                    }

                    // Notify interested parties
                    if (ItemChanged != null)
                    {
                        ItemChanged(this, new ItemChangedEventArgs<T>((T)sender));
                    }
                }
            }
        }

        protected override void InsertItem(int index, T item)
        {
            // Mark item as created and listen for property changes
            if (Tracking)
            {
                item.TrackingState = TrackingInfo.Created;
                item.PropertyChanged += OnItemChanged;
            }
            base.InsertItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            if (Tracking)
            {
                // 标志元素被删除，并缓存
                // but do not cache new items
                T item = this.Items[index];
                if (item.TrackingState != TrackingInfo.Created)
                {
                    item.TrackingState = TrackingInfo.Deleted;
                    item.PropertyChanged -= OnItemChanged;
                    deletedItems.Add(item);
                }
            }
            base.RemoveItem(index);
        }

        public ChangeTrackingHelper<T> GetChanges()
        {
            // 重建新的ChangeTrackingList
            ChangeTrackingHelper<T> changes = new ChangeTrackingHelper<T>();
            foreach (T existing in this)
            {
                if (existing.TrackingState != TrackingInfo.Unchanged)
                {
                    changes.Add(existing);
                }
            }

            // Append deleted items
            foreach (T deleted in deletedItems)
            {
                changes.Add(deleted);
            }
            return changes;
        }

        public void ClearChanges()
        {
            this.Clear();//清空元素
            this.deletedItems.Clear();
        }
    }
}
