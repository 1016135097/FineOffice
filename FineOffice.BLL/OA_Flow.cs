using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.Modules.Helper;

namespace FineOffice.BLL
{
    public class OA_Flow
    {
        FineOffice.IDataAccess.OA_Flow dal = new FineOffice.DataAccess.OA_Flow();

        /// <summary>
        /// 增加流程
        /// </summary>
        public FineOffice.Modules.OA_Flow Add(FineOffice.Modules.OA_Flow model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_Flow entity = new Entity.OA_Flow
            {
                ID = model.ID,
                FlowNO = model.FlowNO,
                FlowName = model.FlowName,
                PinyinCode = model.PinyinCode,
                AllowAttachment = model.AllowAttachment,
                Creator = model.Creator,
                FlowDesc = model.FlowDesc,
                SortID = model.SortID,
                IsFreedom = model.IsFreedom,
                Version = model.Version,
                Stop = model.Stop,
                AllowRecall = model.AllowRecall,
                AllowRevoke = model.AllowRevoke,
                FormID = model.FormID,
                Remark = model.Remark,
                XML = model.XML,
                CreateDate = model.CreateDate,
            };
            entity.OA_FlowAuthority.AddRange(
                from f in model.OA_FlowAuthorityList
                select new FineOffice.Entity.OA_FlowAuthority
                {
                    DepartmentID = f.DepartmentID,
                    FlowID = f.FlowID,
                    ID = f.ID,
                    PersonnelID = f.PersonnelID
                });
            dal.Add(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 修改流程
        /// </summary>
        public FineOffice.Modules.OA_Flow Update(FineOffice.Modules.OA_Flow model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_Flow entity = new Entity.OA_Flow
            {
                ID = model.ID,
                FlowNO = model.FlowNO,
                FlowName = model.FlowName,
                PinyinCode = model.PinyinCode,
                AllowAttachment = model.AllowAttachment,
                Creator = model.Creator,
                FlowDesc = model.FlowDesc,
                SortID = model.SortID,
                IsFreedom = model.IsFreedom,
                Stop = model.Stop,
                AllowRecall = model.AllowRecall,
                AllowRevoke = model.AllowRevoke,
                FormID = model.FormID,
                Version = model.Version,
                Remark = model.Remark,
                XML = model.XML,
                CreateDate = model.CreateDate,
            };
            entity.OA_FlowAuthority.AddRange(from temp in model.OA_FlowAuthorityList
                                             select new FineOffice.Entity.OA_FlowAuthority
                                           {
                                               ID = temp.ID,
                                               PersonnelID = temp.PersonnelID,
                                               DepartmentID = temp.DepartmentID,
                                               FlowID = temp.FlowID,
                                           });
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 更改流程明细列表
        /// </summary>
        public FineOffice.Modules.OA_Flow UpdateProcess(FineOffice.Modules.OA_Flow model)
        {
            FineOffice.Entity.OA_Flow entity = new Entity.OA_Flow
            {
                ID = model.ID,
                FlowNO = model.FlowNO,
                FlowName = model.FlowName,
                PinyinCode = model.PinyinCode,
                AllowAttachment = model.AllowAttachment,
                Creator = model.Creator,
                FlowDesc = model.FlowDesc,
                SortID = model.SortID,
                AllowRecall = model.AllowRecall,
                AllowRevoke = model.AllowRevoke,
                FormID = model.FormID,
                IsFreedom = model.IsFreedom,
                Stop = model.Stop,
                Version = model.Version,
                Remark = model.Remark,
                XML = model.XML,
                CreateDate = model.CreateDate,
            };
            entity.OA_FlowProcess.AddRange(from temp in model.OA_FlowProcessList
                                           select new FineOffice.Entity.OA_FlowProcess
                                           {
                                               AllowGoBack = temp.AllowGoBack,
                                               AllowRefuse = temp.AllowRefuse,
                                               Remind = temp.Remind,
                                               TimeLimit = temp.TimeLimit,
                                               AllowSync = temp.AllowSync,
                                               Feedback = temp.Feedback,
                                               FlowID = temp.FlowID,
                                               ID = temp.ID,
                                               Version = temp.Version,
                                               IsEnd = temp.IsEnd,
                                               IsStart = temp.IsStart,
                                               MailTo = temp.MailTo,
                                               MessageTo = temp.MessageTo,
                                               Next = temp.Next,
                                               ProcessDepartment = temp.ProcessDepartment,
                                               ProcessPersonnel = temp.ProcessPersonnel,
                                               ProcessName = temp.ProcessName,
                                               Remark = temp.Remark,
                                               ProcessRole = temp.ProcessRole,
                                               Serial = temp.Serial,
                                               TopDefault = temp.TopDefault
                                           });
            dal.UpdateProcess(entity);
            return null;
        }

        public FineOffice.Modules.OA_Flow GetModelContains(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_Flow, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.OA_Flow model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.OA_Flow
                   {
                       ID = entity.ID,
                       FlowNO = entity.FlowNO,
                       FlowName = entity.FlowName,
                       PinyinCode = entity.PinyinCode,
                       AllowAttachment = entity.AllowAttachment,
                       Creator = entity.Creator,
                       FlowDesc = entity.FlowDesc,
                       SortID = entity.SortID,
                       AllowRecall = entity.AllowRecall,
                       AllowRevoke = entity.AllowRevoke,
                       FormID = entity.FormID,
                       IsFreedom = entity.IsFreedom,
                       Stop = entity.Stop,
                       XML = entity.XML,
                       Version = entity.Version,
                       Remark = entity.Remark,
                       CreateDate = entity.CreateDate,
                       OA_FlowProcessList = (from temp in entity.OA_FlowProcess
                                             select new FineOffice.Modules.OA_FlowProcess
                                             {
                                                 TimeLimit = temp.TimeLimit,
                                                 AllowRefuse = temp.AllowRefuse,
                                                 AllowGoBack = temp.AllowGoBack,
                                                 Remind = temp.Remind,
                                                 AllowSync = temp.AllowSync,
                                                 Feedback = temp.Feedback,
                                                 FlowID = temp.FlowID,
                                                 ID = temp.ID,
                                                 Version = temp.Version.ToArray(),
                                                 IsEnd = temp.IsEnd,
                                                 IsStart = temp.IsStart,
                                                 MailTo = temp.MailTo,
                                                 MessageTo = temp.MessageTo,
                                                 Next = temp.Next,
                                                 ProcessDepartment = temp.ProcessDepartment,
                                                 ProcessPersonnel = temp.ProcessPersonnel,
                                                 ProcessName = temp.ProcessName,
                                                 Remark = temp.Remark,
                                                 ProcessRole = temp.ProcessRole,
                                                 Serial = temp.Serial,
                                                 TopDefault = temp.TopDefault
                                             }).ToTrackingList(),
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        /// <summary>
        /// 返回所有流程
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.OA_Flow> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_Flow> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.OA_Flow
                 {
                     ID = entity.ID,
                     FlowNO = entity.FlowNO,
                     FlowName = entity.FlowName,
                     PinyinCode = entity.PinyinCode,
                     AllowAttachment = entity.AllowAttachment,
                     Creator = entity.Creator,
                     FlowDesc = entity.FlowDesc,
                     SortID = entity.SortID,
                     IsFreedom = entity.IsFreedom,
                     Version = entity.Version,
                     Stop = entity.Stop,
                     AllowRecall = entity.AllowRecall,
                     AllowRevoke = entity.AllowRevoke,
                     FormID = entity.FormID,
                     XML = entity.XML,
                     Remark = entity.Remark,
                     CreateDate = entity.CreateDate,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        public FineOffice.Modules.OA_Flow GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_Flow, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.OA_Flow model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.OA_Flow
                   {
                       ID = entity.ID,
                       FlowNO = entity.FlowNO,
                       FlowName = entity.FlowName,
                       PinyinCode = entity.PinyinCode,
                       AllowAttachment = entity.AllowAttachment,
                       Creator = entity.Creator,
                       FlowDesc = entity.FlowDesc,
                       SortID = entity.SortID,
                       IsFreedom = entity.IsFreedom,
                       Stop = entity.Stop,
                       XML = entity.XML,
                       AllowRecall = entity.AllowRecall,
                       AllowRevoke = entity.AllowRevoke,
                       FormID = entity.FormID,
                       Version = entity.Version,
                       Remark = entity.Remark,
                       CreateDate = entity.CreateDate,
                       OA_FlowAuthorityList = (from w in entity.OA_FlowAuthority
                                               select new FineOffice.Modules.OA_FlowAuthority
                                               {
                                                   DepartmentID = w.DepartmentID,
                                                   PersonnelID = w.PersonnelID,
                                                   FlowID = w.FlowID,
                                                   ID = w.ID,
                                                   PersonnelName = w.PersonnelID == null ? string.Empty : w.HR_Personnel.Name,
                                                   DepartmentName = w.DepartmentID == null ? string.Empty : w.HR_Department.DepartmentName,
                                               }).ToTrackingList()
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.OA_Flow model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_Flow entity = new Entity.OA_Flow
            {
                ID = model.ID,
            };
            dal.Delete(entity);
            dal.Dispose();
        }

        public void Delete(List<int> ids)
        {
            dal.Delete(ids);
        }

        /// <summary>
        /// 按表达查找流程的数组
        /// </summary>
        public List<Modules.OA_Flow> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_Flow, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_Flow> list = new List<Modules.OA_Flow>();
            list = (from entity in dal.GetListAll()
                    select new FineOffice.Modules.OA_Flow
                    {
                        ID = entity.ID,
                        FlowNO = entity.FlowNO,
                        FlowName = entity.FlowName,
                        PinyinCode = entity.PinyinCode,
                        AllowAttachment = entity.AllowAttachment,
                        Creator = entity.Creator,
                        FlowDesc = entity.FlowDesc,
                        SortID = entity.SortID,
                        IsFreedom = entity.IsFreedom,
                        Stop = entity.Stop,
                        AllowRecall = entity.AllowRecall,
                        AllowRevoke = entity.AllowRevoke,
                        FormID = entity.FormID,
                        XML = entity.XML,
                        Version = entity.Version,
                        Remark = entity.Remark,
                        CreateDate = entity.CreateDate,
                    }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// sql方式查询
        /// </summary>
        /// <param name="changeTrackingList"></param>
        /// <returns></returns>
        public List<Modules.OA_Flow> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetList(changeTrackingList);
        }

        /// <summary>
        /// 分页sql方式查询
        /// </summary>
        public List<Modules.OA_Flow> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }

        public int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetCount(changeTrackingList);
        }
    }
}
