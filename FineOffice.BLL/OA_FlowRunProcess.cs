using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.Modules.Helper;

namespace FineOffice.BLL
{
    public class OA_FlowRunProcess
    {
        FineOffice.IDataAccess.OA_FlowRunProcess dal = new FineOffice.DataAccess.OA_FlowRunProcess();

        /// <summary>
        /// 增加
        /// </summary>
        public FineOffice.Modules.OA_FlowRunProcess Add(FineOffice.Modules.OA_FlowRunProcess model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FlowRunProcess entity = new Entity.OA_FlowRunProcess
            {
                AcceptID = model.AcceptID,
                AcceptTime = model.AcceptTime,
                HandleTime = model.HandleTime,
                ID = model.ID,
                Pattern = model.Pattern,
                PreviousID = model.PreviousID,
                ProcessID = model.ProcessID,
                Remark = model.Remark,
                RunID = model.RunID,
                SendID = model.SendID,
                IsEntrance = model.IsEntrance,
                State = model.State,
                TransmitAdvice = model.TransmitAdvice,
                Version = model.Version,                 
            };
            dal.Add(entity);
            dal.Dispose();
            return this.GetModel(temp => temp.ID == entity.ID);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public FineOffice.Modules.OA_FlowRunProcess Update(FineOffice.Modules.OA_FlowRunProcess model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FlowRunProcess entity = new Entity.OA_FlowRunProcess
            {
                AcceptID = model.AcceptID,
                AcceptTime = model.AcceptTime,
                HandleTime = model.HandleTime,
                ID = model.ID,
                Pattern = model.Pattern,
                PreviousID = model.PreviousID,
                ProcessID = model.ProcessID,
                Remark = model.Remark,
                RunID = model.RunID,
                IsEntrance = model.IsEntrance,
                SendID = model.SendID,
                State = model.State,
                TransmitAdvice = model.TransmitAdvice,
                Version = model.Version,
            };
            dal.Update(entity);
            dal.Dispose();
            return this.GetModel(p=>p.ID==model.ID);
        }

        /// <summary>
        /// 返回所有
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.OA_FlowRunProcess> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_FlowRunProcess> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.OA_FlowRunProcess
                 {
                     AcceptID = entity.AcceptID,
                     AcceptTime = entity.AcceptTime,
                     HandleTime = entity.HandleTime,
                     ID = entity.ID,
                     Pattern = entity.Pattern,
                     PreviousID = entity.PreviousID,
                     ProcessID = entity.ProcessID,
                     Remark = entity.Remark,
                     IsEntrance = entity.IsEntrance,
                     RunID = entity.RunID,
                     SendID = entity.SendID,
                     State = entity.State,
                     TransmitAdvice = entity.TransmitAdvice,
                     Version = entity.Version.ToArray(),
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.OA_FlowRunProcess GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_FlowRunProcess, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.OA_FlowRunProcess model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.OA_FlowRunProcess
                   {
                       AcceptID = entity.AcceptID,
                       AcceptTime = entity.AcceptTime,
                       HandleTime = entity.HandleTime,
                       ID = entity.ID,
                       Pattern = entity.Pattern,
                       PreviousID = entity.PreviousID,
                       ProcessID = entity.ProcessID,
                       Remark = entity.Remark,
                       RunID = entity.RunID,
                       SendID = entity.SendID,
                       IsEntrance = entity.IsEntrance,
                       State = entity.State,
                       Next = entity.OA_FlowProcess.Next,
                       IsStart = entity.OA_FlowProcess.IsStart,
                       TransmitAdvice = entity.TransmitAdvice,
                       Version = entity.Version.ToArray(),
                       ProcessName = entity.OA_FlowProcess.ProcessName,
                       WorkName = entity.OA_FlowRun.WorkName,
                       WorkNO = entity.OA_FlowRun.WorkNO,
                       CreateName = entity.OA_FlowRun.HR_Personnel.Name,
                       WorkCreateTime = entity.OA_FlowRun.CreateTime,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.OA_FlowRunProcess model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FlowRunProcess entity = new Entity.OA_FlowRunProcess
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
        public List<Modules.OA_FlowRunProcess> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetList(changeTrackingList);
        }

        /// <summary>
        /// 分页sql方式查询
        /// </summary>
        public List<Modules.OA_FlowRunProcess> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }

        /// <summary>
        /// 取记录数
        /// </summary>
        public int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetCount(changeTrackingList);
        }

        public void Update(ChangeTrackingList<FineOffice.Modules.OA_FlowRunProcess> list)
        {
            dal.Initialization();
            ChangeTrackingList<FineOffice.Modules.OA_FlowRunProcess> temp = list.GetChanges();
            dal.Update(this.Changes(temp, TrackingInfo.Updated));
            dal.Add(this.Changes(temp, TrackingInfo.Created));
            dal.Dispose();
        }

        private List<FineOffice.Entity.OA_FlowRunProcess> Changes(ChangeTrackingList<FineOffice.Modules.OA_FlowRunProcess> list, TrackingInfo trackingState)
        {
            return (from t in list
                    where t.TrackingState == trackingState
                    select new FineOffice.Entity.OA_FlowRunProcess
                    {
                        AcceptID = t.AcceptID,
                        AcceptTime = t.AcceptTime,
                        HandleTime = t.HandleTime,
                        ID = t.ID,
                        Pattern = t.Pattern,
                        PreviousID = t.PreviousID,
                        ProcessID = t.ProcessID,
                        Remark = t.Remark,
                        RunID = t.RunID,
                        IsEntrance = t.IsEntrance,
                        SendID = t.SendID,
                        State = t.State,
                        TransmitAdvice = t.TransmitAdvice,
                        Version = t.Version,
                    }).ToList();
        }
    }
}
