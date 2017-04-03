using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BX.IDataAccess.Helper;

namespace BX.IDataAccess
{
   public interface OA_WorkFlow : IRepository<BX.Entity.OA_WorkFlow>
    {
        /// <summary>
        /// sql方式查询数据库 
        /// </summary>
        /// <param name="changeTrackingList"></param>
        /// <returns></returns>
        List<Modules.OA_WorkFlow> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList);

        /// <summary>
        /// 分页sql方式查询数据库
        /// </summary>
        /// <param name="changeTrackingList"></param>
        /// <param name="start"></param>
        /// <param name="records"></param>
        /// <returns></returns>
        List<Modules.OA_WorkFlow> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records);

        /// <summary>
        /// 分页sql方式查询数据库
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="start"></param>
        /// <param name="records"></param>
        /// <returns></returns>
        List<Modules.OA_WorkFlow> GetList(string strSql, int start, int records);

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        int GetCount(string strSql);
    }
}
