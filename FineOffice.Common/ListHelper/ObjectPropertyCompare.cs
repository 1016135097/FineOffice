using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FineOffice.Common.ListHelper
{
    //对用List<T>作数据源的DataGridView的排序类 //

    public class ObjectPropertyCompare<T>:IComparer<T>
    {
        private string property;
        private string direction;

        // 构造函数
        public ObjectPropertyCompare(string property, string direction)
        {
            this.property = property;
            this.direction = direction;
        }

        #region IComparer<T> 成员

        public int Compare(T x, T y)
        {
            object xValue = x.GetType().GetProperty(property).GetValue(x, null);
            object yValue = y.GetType().GetProperty(property).GetValue(y, null);
            
            //两个null值不能比较,转换为空字符串,时间类型则转为最早时间

            if (xValue == null)
            {
                xValue = string.Empty;
            }
            if (yValue == null)
            {
                yValue = string.Empty;
            }

            int returnValue;
            try
            {
                if (xValue is IComparable)
                {
                    returnValue = ((IComparable)xValue).CompareTo(yValue);
                }
                else if (xValue.Equals(yValue))
                {
                    returnValue = 0;
                }
                else
                {
                    returnValue = xValue.ToString().CompareTo(yValue.ToString());
                }
            }
            catch
            {
                if (xValue.ToString() == "" && yValue != null)
                {
                    returnValue = -1;
                }
                else if (xValue.ToString() == "" && yValue.ToString() == "")
                {
                    returnValue = 0;
                }
                else if (xValue.ToString() != null && yValue.ToString() == "")
                {
                    returnValue = 1;
                }
                else
                    returnValue = 0;
            }

            if (direction == "ASC")
            {
                return returnValue;
            }
            else
            {
                return returnValue * -1;
            }
        }

        #endregion

    }
}
