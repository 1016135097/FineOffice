using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.IDataAccess.Helper;

namespace FineOffice.IDataAccess
{
   public interface OA_FlowProcess : IBaseDataAccess<FineOffice.Entity.OA_FlowProcess>
    {
        /// <summary>
        /// sql方式查询数据库 
        /// </summary>
        /// <param name="changeTrackingList"></param>
        /// <returns></returns>
       List<Modules.OA_FlowProcess> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList);           

       /// <summary>
       /// 分页sql方式查询数据库
       /// </summary>
       /// <param name="changeTrackingList"></param>
       /// <param name="start"></param>
       /// <param name="records"></param>
       /// <returns></returns>
       List<Modules.OA_FlowProcess> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records);

       /// <summary>
       /// 获取记录数
       /// </summary>
       /// <param name="strSql"></param>
       /// <returns></returns>
       int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList);
       
    }
}
