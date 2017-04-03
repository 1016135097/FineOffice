using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FineOffice.Common
{
    /// <summary>
    /// 图片操作帮助类
    /// </summary>
    public class ImageHelper
    {
        /// <summary>
        /// 将图片信息转换成二进制信息    
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>    
        public byte[] PhotoToArray(string path)
        {
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read); 
            byte[] bufferPhoto = new byte[stream.Length];
            stream.Read(bufferPhoto, 0, Convert.ToInt32(stream.Length));
            stream.Flush();
            stream.Close();
            return bufferPhoto;
        }

        /// <summary>
        /// 显示图片
        /// </summary>
        /// <param name="bufferPhoto"></param>
        /// <returns></returns>
        public System.Drawing.Image ArrayToPhoto(byte[] bufferPhoto)
        {
            try
            {
                MemoryStream ms = new MemoryStream(bufferPhoto);
                System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
                return image;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 将图片信息转换成二进制信息 
        /// </summary>
        /// <param name="imgPhoto"></param>
        /// <returns></returns>
        public byte[] PhotoToArray(System.Drawing.Image imgPhoto) //将Image转换成流数据，并保存为byte[]
        {
            MemoryStream mstream = new MemoryStream();
            imgPhoto.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] byData = new Byte[mstream.Length]; mstream.Position = 0;
            mstream.Read(byData, 0, byData.Length);
            mstream.Close();
            return byData;
        }
    }
}
