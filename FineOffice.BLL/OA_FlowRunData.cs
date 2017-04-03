using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class OA_FlowRunData
    {
        FineOffice.IDataAccess.OA_FlowRunData dal = new FineOffice.DataAccess.OA_FlowRunData();
        /// <summary>
        /// 增加
        /// </summary>
        public FineOffice.Modules.OA_FlowRunData Add(FineOffice.Modules.OA_FlowRunData model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FlowRunData entity = new Entity.OA_FlowRunData
            {
                CreateTime = model.CreateTime,
                FormData = model.FormData,
                FormID = model.FormID,
                ID = model.ID,
                RunProcessID = model.RunProcessID,
                Remark = model.Remark,
                UpdateTime = model.UpdateTime,
                Title = model.Title,
                XType = model.XType,
            };
            dal.Add(entity);
            dal.Dispose();
            return this.GetModel(f => f.ID == entity.ID);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public FineOffice.Modules.OA_FlowRunData Update(FineOffice.Modules.OA_FlowRunData model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FlowRunData entity = new Entity.OA_FlowRunData
            {
                CreateTime = model.CreateTime,
                FormData = model.FormData,
                FormID = model.FormID,
                ID = model.ID,
                RunProcessID = model.RunProcessID,
                Remark = model.Remark,
                UpdateTime = model.UpdateTime,
                Title = model.Title,
                XType = model.XType,
            };
            dal.Update(entity);
            dal.Dispose();
            return this.GetModel(e => e.ID == model.ID);
        }

        /// <summary>
        /// 返回所有
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.OA_FlowRunData> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_FlowRunData> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.OA_FlowRunData
                 {
                     CreateTime = entity.CreateTime,
                     FormData = entity.FormData.ToArray(),
                     FormID = entity.FormID,
                     ID = entity.ID,
                     RunProcessID = entity.RunProcessID,
                     Remark = entity.Remark,
                     UpdateTime = entity.UpdateTime,
                     Title = entity.Title,
                     XType = entity.XType,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.OA_FlowRunData GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_FlowRunData, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.OA_FlowRunData model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.OA_FlowRunData
                   {
                       FormName = entity.OA_Form.FormName,
                       CreateTime = entity.CreateTime,
                       FormData = entity.FormData.ToArray(),
                       FormID = entity.FormID,
                       ID = entity.ID,
                       RunProcessID = entity.RunProcessID,
                       Remark = entity.Remark,
                       UpdateTime = entity.UpdateTime,
                       Title = entity.Title,
                       XType = entity.XType,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.OA_FlowRunData model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FlowRunData entity = new Entity.OA_FlowRunData
            {
                ID = model.ID,
            };
            dal.Delete(entity);
            dal.Dispose();
        }

        /// <summary>
        /// sql方式查询
        /// </summary>
        /// <param name="changeTrackingList"></param>
        /// <returns></returns>
        public List<Modules.OA_FlowRunData> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetList(changeTrackingList);
        }

        /// <summary>
        /// 分页sql方式查询
        /// </summary>
        /// <param name="changeTrackingList"></param>
        /// <param name="start"></param>
        /// <param name="records"></param>
        /// <returns></returns>
        public List<Modules.OA_FlowRunData> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }

        public int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetCount(changeTrackingList);
        }

        public void TransferToComAttachment(List<int> ids)
        {
            dal.TransferToComAttachment(ids);
        }
    }
}
