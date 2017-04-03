using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using FineOffice.Common;
using FineOffice.Common.ListHelper;

namespace FineOffice.Modules.Helper
{
    [Serializable]
    public static class ChangeTrackingConvert
    {
        /// <summary>
        /// ListToTrackingList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Modules.Helper.ChangeTrackingList<T> ConvertToChangeTrackingList<T>(IList<T> list) where T : ITrackable, INotifyPropertyChanged
        {
            Modules.Helper.ChangeTrackingList<T> trackingList = new Modules.Helper.ChangeTrackingList<T>();

            foreach (T item in list)
            {
                trackingList.Add(item);
            }

            return trackingList;
        }


        /// <summary>
        /// 转为排序的BindingCollection;
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static ExtBindingList<TSource> ToBindingList<TSource>(this IEnumerable<TSource> source)
        {
            ExtBindingList<TSource> tResult = new ExtBindingList<TSource>();
            foreach (var temp in source)
            {
                tResult.Add(temp);
            }
            return tResult;
        }


        /// <summary>
        /// 转成ChangeTrackingList
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Modules.Helper.ChangeTrackingList<TSource> ToTrackingList<TSource>(this IEnumerable<TSource> source) where TSource : ITrackable, INotifyPropertyChanged
        {
            Modules.Helper.ChangeTrackingList<TSource> tResult = new ChangeTrackingList<TSource>();
            foreach (var temp in source)
            {
                tResult.Add(temp);
            }
            return tResult;
        }
    }
}
