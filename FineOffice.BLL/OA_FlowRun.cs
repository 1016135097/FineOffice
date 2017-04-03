using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.Modules.Helper;

namespace FineOffice.BLL
{
    public class OA_FlowRun
    {
        FineOffice.IDataAccess.OA_FlowRun dal = new FineOffice.DataAccess.OA_FlowRun();
        /// <summary>
        /// 增加
        /// </summary>
        public FineOffice.Modules.OA_FlowRun Add(FineOffice.Modules.OA_FlowRun model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FlowRun entity = new Entity.OA_FlowRun
            {
                CreateTime = model.CreateTime,
                Creator = model.Creator,
                FlowID = model.FlowID,
                ID = model.ID,
                WorkNO = model.WorkNO,
                State = model.State,
                Remark = model.Remark,
                WorkName = model.WorkName
            };

            for (int i = 0; i < model.OA_FlowRunProcessList.Count; i++)
            {
                FineOffice.Modules.OA_FlowRunProcess f = model.OA_FlowRunProcessList[i];
                FineOffice.Entity.OA_FlowRunProcess runProcess = new Entity.OA_FlowRunProcess
                {
                    ID = f.ID,
                    ProcessID = f.ProcessID,
                    Remark = f.Remark,
                    AcceptID = f.AcceptID,
                    AcceptTime = f.AcceptTime,
                    HandleTime = f.HandleTime,
                    Pattern = f.Pattern,
                    IsEntrance = f.IsEntrance,
                    PreviousID = f.PreviousID,
                    SendID = f.SendID,
                    Version = f.Version,
                    TransmitAdvice = f.TransmitAdvice,
                    RunID = f.RunID,
                    State = f.State
                };
                entity.OA_FlowRunProcess.Add(runProcess);
            }
            dal.Add(entity);
            dal.Dispose();
            return this.GetModel(f => f.ID == entity.ID);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public FineOffice.Modules.OA_FlowRun Update(FineOffice.Modules.OA_FlowRun model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FlowRun entity = new Entity.OA_FlowRun
            {
                CreateTime = model.CreateTime,
                Creator = model.Creator,
                FlowID = model.FlowID,
                ID = model.ID,
                WorkNO = model.WorkNO,
                State = model.State,
                Remark = model.Remark,
                WorkName = model.WorkName,
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 返回所有
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.OA_FlowRun> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_FlowRun> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.OA_FlowRun
                 {
                     CreateTime = entity.CreateTime,
                     Creator = entity.Creator,
                     FlowID = entity.FlowID,
                     ID = entity.ID,
                     WorkNO = entity.WorkNO,
                     Remark = entity.Remark,
                     WorkName = entity.WorkName
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.OA_FlowRun GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_FlowRun, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.OA_FlowRun model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.OA_FlowRun
                   {
                       CreateTime = entity.CreateTime,
                       Creator = entity.Creator,
                       FlowID = entity.FlowID,
                       ID = entity.ID,
                       WorkNO = entity.WorkNO,
                       State = entity.State,
                       Remark = entity.Remark,
                       WorkName = entity.WorkName,
                       OA_FlowRunProcessList = (from s in entity.OA_FlowRunProcess
                                                select new FineOffice.Modules.OA_FlowRunProcess
                                                {
                                                    ID = s.ID,
                                                    ProcessID = s.ProcessID,
                                                    Remark = s.Remark,
                                                    AcceptID = s.AcceptID,
                                                    AcceptTime = s.AcceptTime,
                                                    HandleTime = s.HandleTime,
                                                    Pattern = s.Pattern,
                                                    PreviousID = s.PreviousID,
                                                    SendID = s.SendID,
                                                    IsEntrance = s.IsEntrance,
                                                    Version = s.Version.ToArray(),
                                                    TransmitAdvice = s.TransmitAdvice,
                                                    RunID = s.RunID,
                                                    State = s.State
                                                }).ToTrackingList(),
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        /// <summary>
        /// 删除工作
        /// </summary>
        /// <param name="model"></param>
        public void Delete(Modules.OA_FlowRun model)
        {
            FineOffice.Entity.OA_FlowRun entity = new Entity.OA_FlowRun
            {
                ID = model.ID,
            };
            dal.Delete(entity);
        }

        /// <summary>
        /// sql方式查询
        /// </summary>
        /// <param name="changeTrackingList"></param>
        /// <returns></returns>
        public List<Modules.OA_FlowRun> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
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
        public List<Modules.OA_FlowRun> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }

        public int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetCount(changeTrackingList);
        }
    }
}
