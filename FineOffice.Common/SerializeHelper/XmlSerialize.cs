using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace FineOffice.Common.SerializeHelper
{
    public class XmlSerialize
    {
        /// <summary>
        /// 反序列化XML为类实例
        /// </summary>
        public static T Deserialize<T>(string xmlObj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xmlObj))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        /// <summary>
        /// 序列化类实例为XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string Serialize<T>(T obj)
        {
            using (StringWriter writer = new StringWriter())
            {
                new XmlSerializer(obj.GetType()).Serialize((TextWriter)writer, obj);
                return writer.ToString();
            }
        }

        /// <summary>
        /// 序列化数组
        /// </summary>
        public static string Serialize<T>(List<T> list)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<T>));
            System.IO.MemoryStream mem = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mem, Encoding.Default);
            ser.Serialize(writer, list);
            writer.Close();
            string strtmp = Encoding.Default.GetString(mem.ToArray());
            return strtmp;
        }


        public static List<T> Deserialize2List<T>(string xmlObj)
        {
            XmlSerializer ser = new XmlSerializer(typeof(List<T>));
            Stream stream = new MemoryStream(ASCIIEncoding.Default.GetBytes(xmlObj));
            StreamReader sr = new StreamReader(stream);        
            var listsch = ser.Deserialize(sr);
            List<T> reses = listsch as List<T>;
            return reses;
        }
    }
}
