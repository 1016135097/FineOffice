using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class OA_FlowSort
    {
        FineOffice.IDataAccess.OA_FlowSort dal = new FineOffice.DataAccess.OA_FlowSort();
       
        /// <summary>
        /// 增加流程分类
        /// </summary>
        public FineOffice.Modules.OA_FlowSort Add(FineOffice.Modules.OA_FlowSort model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FlowSort entity = new Entity.OA_FlowSort
            {
                ID = model.ID,
                SortNO = model.SortNO,
                FlowSortName = model.FlowSortName,
                PinyinCode = model.PinyinCode,
                SerialNO = model.SerialNO,
                Stop = model.Stop,
                Remark = model.Remark
            };
            dal.Add(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 修改流程分类
        /// </summary>
        public FineOffice.Modules.OA_FlowSort Update(FineOffice.Modules.OA_FlowSort model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FlowSort entity = new Entity.OA_FlowSort
            {
                ID = model.ID,
                SortNO = model.SortNO,
                FlowSortName = model.FlowSortName,
                PinyinCode = model.PinyinCode,
                SerialNO = model.SerialNO,
                Stop = model.Stop,
                Remark = model.Remark
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 返回所有流程分类
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.OA_FlowSort> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_FlowSort> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.OA_FlowSort
                 {
                     ID = entity.ID,
                     SortNO = entity.SortNO,
                     FlowSortName = entity.FlowSortName,
                     PinyinCode = entity.PinyinCode,
                     SerialNO = entity.SerialNO,
                     Stop = entity.Stop,
                     Remark = entity.Remark
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.OA_FlowSort GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_FlowSort, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.OA_FlowSort model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.OA_FlowSort
                   {
                       ID = entity.ID,
                       SortNO = entity.SortNO,
                       FlowSortName = entity.FlowSortName,
                       PinyinCode = entity.PinyinCode,
                       SerialNO = entity.SerialNO,
                       Stop = entity.Stop,
                       Remark = entity.Remark
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.OA_FlowSort model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FlowSort entity = new Entity.OA_FlowSort
            {
                ID = model.ID,
            };
            dal.Delete(entity);
            dal.Dispose();
        }

        public void Delete(List<int> deleteList)
        {
            dal.Initialization();
            dal.Delete(d => deleteList.Contains(d.ID));
            dal.Dispose();
        }

        /// <summary>
        /// sql方式查询
        /// </summary>
        /// <param name="changeTrackingList"></param>
        /// <returns></returns>
        public List<Modules.OA_FlowSort> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetList(changeTrackingList);
        }

        /// <summary>
        /// 分页sql方式查询
        /// </summary>
        public List<Modules.OA_FlowSort> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }


        public int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetCount(changeTrackingList);
        }
    }
}
