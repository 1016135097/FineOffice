using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Configuration;
using System.IO;

namespace FineOffice.DataAccess.Helper
{
    public class ContextFactory
    {
        //读取数据库连接字符串
        public static string ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["FineOffice"].ConnectionString;

        /// <summary>
        /// 返回一个LinqContext
        /// </summary> 
        /// <returns></returns> 
        public static DataContext CreateContext() 
        {
            try
            {
                DataContext cxt = new DataContext(ConnectionString);
                return cxt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
