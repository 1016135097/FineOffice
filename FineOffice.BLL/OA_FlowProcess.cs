using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class OA_FlowProcess
    {
        FineOffice.IDataAccess.OA_FlowProcess dal = new FineOffice.DataAccess.OA_FlowProcess();
        /// <summary>
        /// 增加
        /// </summary>
        public FineOffice.Modules.OA_FlowProcess Add(FineOffice.Modules.OA_FlowProcess model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FlowProcess entity = new Entity.OA_FlowProcess
            {
                ID = model.ID,
                FlowID = model.FlowID,
                Feedback = model.Feedback,
                Remind = model.Remind,
                AllowGoBack = model.AllowGoBack,
                TimeLimit = model.TimeLimit,
                AllowRefuse = model.AllowRefuse,
                AllowSync = model.AllowSync,
                IsEnd = model.IsEnd,
                IsStart = model.IsStart,
                MessageTo = model.MessageTo,
                Next = model.Next,
                Version = model.Version,
                ProcessName = model.ProcessName,
                ProcessPersonnel = model.ProcessPersonnel,
                Serial = model.Serial,
                ProcessDepartment = model.ProcessDepartment,
                ProcessRole = model.ProcessRole,
                TopDefault = model.TopDefault,
                MailTo = model.MailTo,
                Remark = model.Remark
            };
            dal.Add(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public FineOffice.Modules.OA_FlowProcess Update(FineOffice.Modules.OA_FlowProcess model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FlowProcess entity = new Entity.OA_FlowProcess
            {
                ID = model.ID,
                ProcessDepartment = model.ProcessDepartment,
                ProcessRole = model.ProcessRole,
                FlowID = model.FlowID,
                Feedback = model.Feedback,
                Remind = model.Remind,
                AllowGoBack = model.AllowGoBack,
                TimeLimit = model.TimeLimit,
                AllowRefuse = model.AllowRefuse,
                AllowSync = model.AllowSync,
                IsEnd = model.IsEnd,
                IsStart = model.IsStart,
                MessageTo = model.MessageTo,
                Next = model.Next,
                Version = model.Version,
                ProcessName = model.ProcessName,
                ProcessPersonnel = model.ProcessPersonnel,
                Serial = model.Serial,
                TopDefault = model.TopDefault,
                MailTo = model.MailTo,
                Remark = model.Remark
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 返回所有信件
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.OA_FlowProcess> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_FlowProcess> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.OA_FlowProcess
                 {
                     ID = entity.ID,
                     ProcessDepartment = entity.ProcessDepartment,
                     ProcessRole = entity.ProcessRole,
                     FlowID = entity.FlowID,
                     Feedback = entity.Feedback,
                     Remind = entity.Remind,
                     AllowGoBack = entity.AllowGoBack,
                     TimeLimit = entity.TimeLimit,
                     AllowRefuse = entity.AllowRefuse,
                     AllowSync = entity.AllowSync,
                     IsEnd = entity.IsEnd,
                     Version = entity.Version.ToArray(),
                     IsStart = entity.IsStart,
                     MessageTo = entity.MessageTo,
                     Next = entity.Next,
                     ProcessName = entity.ProcessName,
                     ProcessPersonnel = entity.ProcessPersonnel,
                     Serial = entity.Serial,
                     TopDefault = entity.TopDefault,
                     MailTo = entity.MailTo,
                     Remark = entity.Remark
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.OA_FlowProcess GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_FlowProcess, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.OA_FlowProcess model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.OA_FlowProcess
                   {
                       ID = entity.ID,
                       ProcessDepartment = entity.ProcessDepartment,
                       ProcessRole = entity.ProcessRole,
                       FlowID = entity.FlowID,
                       Feedback = entity.Feedback,
                       Remind = entity.Remind,
                       AllowGoBack = entity.AllowGoBack,
                       TimeLimit = entity.TimeLimit,
                       AllowRefuse = entity.AllowRefuse,
                       AllowSync = entity.AllowSync,
                       IsEnd = entity.IsEnd,
                       Version = entity.Version.ToArray(),
                       IsStart = entity.IsStart,
                       MessageTo = entity.MessageTo,
                       Next = entity.Next,
                       ProcessName = entity.ProcessName,
                       ProcessPersonnel = entity.ProcessPersonnel,
                       Serial = entity.Serial,
                       TopDefault = entity.TopDefault,
                       MailTo = entity.MailTo,
                       Remark = entity.Remark
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.OA_FlowProcess model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FlowProcess entity = new Entity.OA_FlowProcess
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
        public List<Modules.OA_FlowProcess> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
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
        public List<Modules.OA_FlowProcess> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }

        /// <summary>
        /// 按表达查找步骤
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<Modules.OA_FlowProcess> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_FlowProcess, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_FlowProcess> list = new List<Modules.OA_FlowProcess>();
            list = (from entity in dal.GetListAll()
                    select new FineOffice.Modules.OA_FlowProcess
                    {
                        ID = entity.ID,
                        ProcessDepartment = entity.ProcessDepartment,
                        ProcessRole = entity.ProcessRole,
                        FlowID = entity.FlowID,
                        Feedback = entity.Feedback,
                        Remind = entity.Remind,
                        AllowGoBack = entity.AllowGoBack,
                        TimeLimit = entity.TimeLimit,
                        AllowRefuse = entity.AllowRefuse,
                        AllowSync = entity.AllowSync,
                        IsEnd = entity.IsEnd,
                        Version = entity.Version.ToArray(),
                        IsStart = entity.IsStart,
                        MessageTo = entity.MessageTo,
                        Next = entity.Next,
                        ProcessName = entity.ProcessName,
                        ProcessPersonnel = entity.ProcessPersonnel,
                        Serial = entity.Serial,
                        TopDefault = entity.TopDefault,
                        MailTo = entity.MailTo,
                        Remark = entity.Remark
                    }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        public int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetCount(changeTrackingList);
        }
    }
}
