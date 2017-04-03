using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FineOffice.Common.ListHelper
{
    //对用List<T>作数据源的DataGridView的排序类 //
    [Serializable]
    public class ExtBindingList<T> : BindingList<T>
    {
        private bool isSorted;
        private string sortProperty;
        private string sortDirection;

        /// <summary>
        /// 构造函数
        /// </summary>
        public ExtBindingList()
            : base()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="list">IList类型的列表对象</param>
        public ExtBindingList(IList<T> list)
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
    }
}
