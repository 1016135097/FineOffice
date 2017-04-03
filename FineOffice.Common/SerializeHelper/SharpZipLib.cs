using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ICSharpCode.SharpZipLib.Zip.Compression;

namespace FineOffice.Common.SerializeHelper
{
    /// <summary>
    /// 压缩通用类
    /// </summary>
    public class SharpZipLib
    {
        /// <summary>
        /// 压缩二进制流
        /// </summary>
        /// <param name="pBytes"></param>
        /// <returns></returns>
        public static byte[] Compress(byte[] pBytes)
        {
            MemoryStream mMemory = new MemoryStream();

            Deflater mDeflater = new Deflater(ICSharpCode.SharpZipLib.Zip.Compression.Deflater.BEST_COMPRESSION);
            ICSharpCode.SharpZipLib.Zip.Compression.Streams.DeflaterOutputStream mStream = new ICSharpCode.SharpZipLib.Zip.Compression.Streams.DeflaterOutputStream(mMemory, mDeflater, 131072);

            mStream.Write(pBytes, 0, pBytes.Length);
            mStream.Close();

            return mMemory.ToArray();
        }

        /// <summary>
        /// 解压二进制流
        /// </summary>
        /// <param name="pBytes"></param>
        /// <returns></returns>
        public static byte[] DeCompress(byte[] pBytes)
        {
            ICSharpCode.SharpZipLib.Zip.Compression.Streams.InflaterInputStream mStream = new ICSharpCode.SharpZipLib.Zip.Compression.Streams.InflaterInputStream(new MemoryStream(pBytes));

            MemoryStream mMemory = new MemoryStream();
            Int32 mSize;
            byte[] mWriteData = new byte[4096];
            while (true)
            {
                mSize = mStream.Read(mWriteData, 0, mWriteData.Length);
                if (mSize > 0)
                {
                    mMemory.Write(mWriteData, 0, mSize);
                }
                else
                {
                    break;
                }
            }
            mStream.Close();
            return mMemory.ToArray();
        }
    }
}
