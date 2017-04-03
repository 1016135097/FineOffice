using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace FineOffice.Common.SerializeHelper
{
    /// <summary>
    /// 普通序列化的类
    /// </summary>
    public class CommonSerialize
    {
        public static string Serialize(Object obj)
        {
            string result = string.Empty;
            IFormatter fm = new BinaryFormatter();
            MemoryStream sm = new MemoryStream();
            fm.Serialize(sm, obj);
            sm.Seek(0, SeekOrigin.Begin);
            byte[] bt = sm.GetBuffer();
            result = System.Convert.ToBase64String(bt);
            return result;
        }

        public static Object Deserialize(string str)
        {
            byte[] bt = Convert.FromBase64String(str);
            MemoryStream smNew = new MemoryStream(bt);
            IFormatter fmNew = new BinaryFormatter();
            return fmNew.Deserialize(smNew);
        }
    }
}
