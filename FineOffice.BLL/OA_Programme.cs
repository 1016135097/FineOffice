using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class OA_Programme
    {
        FineOffice.IDataAccess.OA_Programme dal = new FineOffice.DataAccess.OA_Programme();
        /// <summary>
        /// 增加日程
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FineOffice.Modules.OA_Programme Add(FineOffice.Modules.OA_Programme model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_Programme entity = ModelToEntity(model);            
            entity= dal.Add(entity);
            dal.Dispose();
            return EntityToModel(entity);
        }

        /// <summary>
        /// 修改日程
        /// </summary>
        public FineOffice.Modules.OA_Programme Update(FineOffice.Modules.OA_Programme model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_Programme entity = ModelToEntity(model);   
            entity = dal.Update(entity);
            dal.Dispose();
            return EntityToModel(entity);
        }

        /// <summary>
        /// 返回所有日程
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.OA_Programme> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_Programme> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.OA_Programme
                 {
                     ID = entity.ID,
                     Subject = entity.Subject,
                     Location = entity.Location,
                     MasterId = entity.MasterID,
                     Description = entity.Description,
                     CalendarType = entity.CalendarType,
                     StartTime = entity.StartTime,
                     EndTime = entity.EndTime,
                     IsAllDayEvent = entity.IsAllDayEvent,
                     HasAttachment = entity.HasAttachment,
                     Category = entity.Category,
                     InstanceType = entity.InstanceType,
                     Attendees = entity.Attendees,
                     AttendeeNames = entity.AttendeeNames,
                     OtherAttendee = entity.OtherAttendee,
                     UPAccount = entity.UPAccount,
                     UPName = entity.UPName,
                     UPTime = entity.UPTime,
                     RecurringRule = entity.RecurringRule,
                     PersonnelID = entity.PersonnelID,
                     Remark = entity.Remark
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 按条件返回日程
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.OA_Programme> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_Programme, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_Programme> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.OA_Programme
                 {
                     ID = entity.ID,
                     Subject = entity.Subject,
                     Location = entity.Location,
                     MasterId = entity.MasterID,
                     Description = entity.Description,
                     CalendarType = entity.CalendarType,
                     StartTime = entity.StartTime,
                     EndTime = entity.EndTime,
                     IsAllDayEvent = entity.IsAllDayEvent,
                     HasAttachment = entity.HasAttachment,
                     Category = entity.Category,
                     InstanceType = entity.InstanceType,
                     Attendees = entity.Attendees,
                     AttendeeNames = entity.AttendeeNames,
                     OtherAttendee = entity.OtherAttendee,
                     UPAccount = entity.UPAccount,
                     UPName = entity.UPName,
                     UPTime = entity.UPTime,
                     RecurringRule = entity.RecurringRule,
                     PersonnelID = entity.PersonnelID,
                     Remark = entity.Remark
                 }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.OA_Programme GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_Programme, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.OA_Programme model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.OA_Programme
                   {
                       ID = entity.ID,
                       Subject = entity.Subject,
                       Location = entity.Location,
                       MasterId = entity.MasterID,
                       Description = entity.Description,
                       CalendarType = entity.CalendarType,
                       StartTime = entity.StartTime,
                       EndTime = entity.EndTime,
                       IsAllDayEvent = entity.IsAllDayEvent,
                       HasAttachment = entity.HasAttachment,
                       Category = entity.Category,
                       InstanceType = entity.InstanceType,
                       Attendees = entity.Attendees,
                       AttendeeNames = entity.AttendeeNames,
                       OtherAttendee = entity.OtherAttendee,
                       UPAccount = entity.UPAccount,
                       UPName = entity.UPName,
                       UPTime = entity.UPTime,
                       RecurringRule = entity.RecurringRule,
                       PersonnelID = entity.PersonnelID,
                       Remark = entity.Remark
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.OA_Programme model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_Programme entity = new Entity.OA_Programme
            {
                ID = model.ID,
            };
            dal.Delete(entity);
            dal.Dispose();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private FineOffice.Entity.OA_Programme ModelToEntity(FineOffice.Modules.OA_Programme model)
        {
            FineOffice.Entity.OA_Programme entity = new Entity.OA_Programme
            {
                ID = model.ID,
                Subject = model.Subject,
                Location = model.Location,
                MasterID = model.MasterId,
                Description = model.Description,
                CalendarType = model.CalendarType,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                IsAllDayEvent = model.IsAllDayEvent,
                HasAttachment = model.HasAttachment,
                Category = model.Category,
                InstanceType = model.InstanceType,
                Attendees = model.Attendees,
                AttendeeNames = model.AttendeeNames,
                OtherAttendee = model.OtherAttendee,
                UPAccount = model.UPAccount,
                UPName = model.UPName,
                UPTime = model.UPTime,
                RecurringRule = model.RecurringRule,
                PersonnelID = model.PersonnelID,
                Remark = model.Remark
            };
            return entity;
        }

        private FineOffice.Modules.OA_Programme EntityToModel(FineOffice.Entity.OA_Programme entity)
        {
            FineOffice.Modules.OA_Programme model = new Modules.OA_Programme
            {
                ID = entity.ID,
                Subject = entity.Subject,
                Location = entity.Location,
                MasterId = entity.MasterID,
                Description = entity.Description,
                CalendarType = entity.CalendarType,
                StartTime = entity.StartTime,
                EndTime = entity.EndTime,
                IsAllDayEvent = entity.IsAllDayEvent,
                HasAttachment = entity.HasAttachment,
                Category = entity.Category,
                InstanceType = entity.InstanceType,
                Attendees = entity.Attendees,
                AttendeeNames = entity.AttendeeNames,
                OtherAttendee = entity.OtherAttendee,
                UPAccount = entity.UPAccount,
                UPName = entity.UPName,
                UPTime = entity.UPTime,
                RecurringRule = entity.RecurringRule,
                PersonnelID = entity.PersonnelID,
                Remark = entity.Remark
            };
            return model;
        }
    }
}