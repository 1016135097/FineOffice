using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Zip.Compression;
using System.Web.UI;

namespace FineOffice.Common.SerializeHelper
{
    /// <summary>
    /// 页面State序列化的类
    /// </summary>
    public class VeiwStateSerialize
    {
        /// <summary>
        /// 序列化
        /// </summary>
        public static string Serialize(Object pViewState)
        {
            LosFormatter mFormat = new LosFormatter();
            StringWriter mWriter = new StringWriter();
            mFormat.Serialize(mWriter, pViewState);
            String mViewStateStr = mWriter.ToString();
            byte[] pBytes = System.Convert.FromBase64String(mViewStateStr);
            pBytes = SharpZipLib.Compress(pBytes);
            String vStateStr = System.Convert.ToBase64String(pBytes);
            return vStateStr;
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        public static Object Deserialize(string viewState)
        {
            byte[] pBytes = System.Convert.FromBase64String(viewState);
            pBytes = SharpZipLib.DeCompress(pBytes);
            LosFormatter mFormat = new LosFormatter();
            return mFormat.Deserialize(System.Convert.ToBase64String(pBytes));
        }      
    }
}
