using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules.Helper
{
    [Serializable]
    public class ItemChangedEventArgs<T> : EventArgs
    {
        public T Item { get; set; }
         
        public ItemChangedEventArgs(T item)
        {
            this.Item = item;
        }
    }
}
