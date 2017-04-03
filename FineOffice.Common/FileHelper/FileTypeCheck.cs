using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace FineOffice.Common.FileHelper
{
    /// <summary>
    /// 文件类型
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// 枚举未定义的文件类型
        /// </summary>
        Undefined = -1,
        /// <summary>
        /// 可执行文件
        /// </summary>
        PEFile = 0,
        /// <summary>
        /// office2003系列文件
        /// </summary>
        Office2003 = 1,
        /// <summary>
        /// office2007和2010系列文件
        /// </summary>
        Office07And10 = 2,
        /// <summary>
        /// PDF文件
        /// </summary>
        PDFFile = 3,
        /// <summary>
        /// dwg文件
        /// </summary>
        DWGFile = 4,
        /// <summary>
        /// rar文件
        /// </summary>
        RARFile = 5,
        /// <summary>
        /// zip文件
        /// </summary>
        ZIPFile = 6,
        /// <summary>
        /// png图片
        /// </summary>
        PNGFile = 7,
        /// <summary>
        /// jpg图片
        /// </summary>
        JPGFile = 8
    }

    public class FileTypeCheck
    {
        /// <summary>
        /// 文件类型检查
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>文件类型枚举对象</returns>
        public FileType TypeCheck(string filePath)
        {
            FileType ft;
            //获取文件头部标识,14个字符串
            string fileHead = GetFileHead(filePath);
            //获取文件的通常头部长度4,一般情况下这个长度足够判断;
            string normalHead = fileHead.Substring(0, 4);
            switch (normalHead)
            {
                case "4D5A":
                    ft = FileType.PEFile;
                    break;
                case "D0CF":
                    ft = FileType.Office2003;
                    break;
                case "504B":
                    //0ffice2007、2010与zip文件的头部
                    //前面几个字节相同,必须更长的才能判断
                    if (fileHead == "504B0304140006")
                    {
                        ft = FileType.Office07And10;
                    }
                    else//zip文件
                    {
                        ft = FileType.ZIPFile;
                    }
                    break;
                case "2550":
                    ft = FileType.PDFFile;
                    break;
                case "5261":
                    ft = FileType.RARFile;
                    break;
                case "8950":
                    ft = FileType.PNGFile;
                    break;
                case "FFD8":
                    ft = FileType.JPGFile;
                    break;
                case "4143":
                    ft = FileType.DWGFile;
                    break;
                default:
                    ft = FileType.Undefined;
                    break;
            }
            return ft;
        }

        /// <summary>
        /// 获取文件头
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <returns>长度7的字节数组换成16进制字符串14个</returns>
        private string GetFileHead(string filePath)
        {
            //存放头部信息
            string strHeadInfo = string.Empty;
            byte[] buff = new byte[7];
            FileStream fs = new FileStream(filePath, FileMode.Open);
            fs.Seek(0, SeekOrigin.Begin);
            fs.Read(buff, 0, buff.Length);
            strHeadInfo = byteToHexStr(buff);
            fs.Close();
            return strHeadInfo;
        }

        ///<summary>        
        /// 字节数组转16进制字符串        
        ///</summary>        
        ///<param name="bytes">读取的字节数组</param>        
        ///<returns></returns>
        private string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < bytes.Length; i++)
                {
                    returnStr += bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }
    }
}
