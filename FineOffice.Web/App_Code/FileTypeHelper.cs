using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Text;

namespace FineOffice.Web
{
    public class FileTypeHelper
    {
        private string _path;
        public FileTypeHelper() { }
        public FileTypeHelper(string path)
        {
            this._path = path;
        }
        public string GetFileType(string key)
        {
            string fileType = "";
            XmlTextReader reader = new XmlTextReader(System.Web.HttpContext.Current.Server.MapPath(_path));
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);

            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                if (node.Attributes["key"].Value == key)
                {
                    fileType = node.Attributes["type"].Value;
                    break;
                }
            }
            return fileType;
        }

        /// <summary>
        /// Get File Size
        /// </summary>
        public string ReturnFileSize(int size)
        {
            string FileSize = ""; if (size != 0)
            {
                if (size >= 1073741824)
                {
                    FileSize = System.Math.Round(Convert.ToDouble((double)size / (double)1073741824), 2).ToString() + "GB";  //GB           
                }
                else if (size >= 1048576)
                {
                    FileSize = System.Math.Round(Convert.ToDouble((double)size / (double)1048576), 2).ToString() + "MB";
                }
                else if (size >= 1024)
                {
                    FileSize = System.Math.Round(Convert.ToDouble((double)size / (double)1024), 2).ToString() + "KB"; int a = size / 1024 * 100; int b = size / 1024;
                }
                else
                {
                    FileSize = size.ToString() + "bytes";
                }
            }
            else { FileSize = size.ToString() + "bytes"; } return FileSize;
        }

        /// <summary>
        /// Get FileHeader
        /// </summary>
        public string GetFileType(byte[] file)
        {
            string returnStr = "";
            if (file != null)
            {
                for (int i = 0; i < 7; i++)
                {
                    returnStr += file[i].ToString("X2");
                }
            }
            return CheckType(returnStr);
        }

        /// <summary>
        /// Check File Type
        /// </summary>
        private string CheckType(string fileHead)
        {
            string fileType = "";
            string normalHead = fileHead.Substring(0, 4);
            switch (normalHead)
            {
                case "D0CF":
                    fileType = "doc";
                    break;
                case "504B":
                    fileType = "docx";
                    break;
                case "2550":
                    fileType = "pdf";
                    break;
                case "5261":
                    fileType = "rar";
                    break;
                case "8950":
                    fileType = "png";
                    break;
                case "FFD8":
                    fileType = "jgp";
                    break;
            }
            return fileType;
        }

        /// <summary>
        /// Encodes non-US-ASCII characters in a string.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string ToHexString(string s)
        {
            char[] chars = s.ToCharArray();
            StringBuilder builder = new StringBuilder();
            for (int index = 0; index < chars.Length; index++)
            {
                bool needToEncode = NeedToEncode(chars[index]);
                if (needToEncode)
                {
                    string encodedString = ToHexString(chars[index]);
                    builder.Append(encodedString);
                }
                else
                {
                    builder.Append(chars[index]);
                }
            }
            return builder.ToString();
        }

        /// <summary>
        /// Determines if the character needs to be encoded.
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
        private bool NeedToEncode(char chr)
        {
            string reservedChars = "$-_.+!*'(),@=&";

            if (chr > 127)
                return true;
            if (char.IsLetterOrDigit(chr) || reservedChars.IndexOf(chr) >= 0)
                return false;

            return true;
        }

        /// <summary>
        /// Encodes a non-US-ASCII character.
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
        private string ToHexString(char chr)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] encodedBytes = utf8.GetBytes(chr.ToString());
            StringBuilder builder = new StringBuilder();
            for (int index = 0; index < encodedBytes.Length; index++)
            {
                builder.AppendFormat("%{0}", Convert.ToString(encodedBytes[index], 16));
            }
            return builder.ToString();
        }
    }
}