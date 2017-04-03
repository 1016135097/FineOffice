using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.IDataAccess.Helper;

namespace FineOffice.IDataAccess
{
    public interface OA_Flow : IBaseDataAccess<FineOffice.Entity.OA_Flow>
    {
        /// <summary>
        /// sql方式查询数据库 
        /// </summary>
        /// <param name="changeTrackingList"></param>
        /// <returns></returns>
        List<Modules.OA_Flow> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList);

        /// <summary>
        /// 分页sql方式查询数据库
        /// </summary>
        /// <param name="changeTrackingList"></param>
        /// <param name="start"></param>
        /// <param name="records"></param>
        /// <returns></returns>
        List<Modules.OA_Flow> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records);

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList);

        /// <summary>
        /// 更新流程明细
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        FineOffice.Entity.OA_Flow UpdateProcess(FineOffice.Entity.OA_Flow entity);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="ids"></param>
        void Delete(List<int> ids);
    }
}
