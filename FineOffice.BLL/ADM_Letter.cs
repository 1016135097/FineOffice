using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class ADM_Letter
    {
        FineOffice.IDataAccess.ADM_Letter dal = new FineOffice.DataAccess.ADM_Letter();
        /// <summary>
        /// 增加
        /// </summary>
        public FineOffice.Modules.ADM_Letter Add(FineOffice.Modules.ADM_Letter model)
        {
            dal.Initialization();
            FineOffice.Entity.ADM_Letter entity = new Entity.ADM_Letter
            {
                ID = model.ID,
                Address = model.Address,
                Age = model.Age,
                Area = model.Area,
                ChannelID = model.ChannelID,
                Email = model.Email,
                Handler = model.Handler,
                LetterNO = model.LetterNO,
                Matter = model.Matter,
                Mobile = model.Mobile,
                Receiver = model.Receiver,
                NumberOfpeople = model.NumberOfpeople,
                TypeID = model.TypeID,
                Title = model.Title,
                Visitor = model.Visitor,
                VisitTime = model.VisitTime,
                State = model.State,
                IDCard = model.IDCard,
                Sex = model.Sex,
                Tel = model.Tel,
                Occupation = model.Occupation,
                RecordTime = model.RecordTime,
                Recorder = model.Recorder,
                Remark = model.Remark
            };
            dal.Add(entity);
            dal.Dispose();
            return this.GetModel(l=>l.ID==entity.ID);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public FineOffice.Modules.ADM_Letter Update(FineOffice.Modules.ADM_Letter model)
        {
            dal.Initialization();
            FineOffice.Entity.ADM_Letter entity = new Entity.ADM_Letter
            {
                ID = model.ID,
                Address = model.Address,
                Age = model.Age,
                Area = model.Area,
                ChannelID = model.ChannelID,
                Email = model.Email,
                Handler = model.Handler,
                LetterNO = model.LetterNO,
                Matter = model.Matter,
                Mobile = model.Mobile,
                Receiver = model.Receiver,
                NumberOfpeople = model.NumberOfpeople,
                TypeID = model.TypeID,
                Title = model.Title,
                Visitor = model.Visitor,
                VisitTime = model.VisitTime,
                State = model.State,
                Recorder = model.Recorder,
                IDCard = model.IDCard,
                Sex = model.Sex,
                Tel = model.Tel,
                Occupation = model.Occupation,
                RecordTime = model.RecordTime,
                Remark = model.Remark
            };
            dal.Update(entity);
            dal.Dispose();
            return this.GetModel(l=>l.ID==entity.ID);;
        }

        /// <summary>
        /// 返回所有信件
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.ADM_Letter> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.ADM_Letter> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.ADM_Letter
                 {
                     ID = entity.ID,
                     Address = entity.Address,
                     Age = entity.Age,
                     Area = entity.Area,
                     ChannelID = entity.ChannelID,
                     Email = entity.Email,
                     Handler = entity.Handler,
                     LetterNO = entity.LetterNO,
                     Matter = entity.Matter,
                     Mobile = entity.Mobile,
                     Receiver = entity.Receiver,
                     NumberOfpeople = entity.NumberOfpeople,
                     TypeID = entity.TypeID,
                     IDCard = entity.IDCard,
                     Sex = entity.Sex,
                     Tel = entity.Tel,
                     Occupation = entity.Occupation,
                     RecordTime = entity.RecordTime,
                     Title = entity.Title,
                     Visitor = entity.Visitor,
                     VisitTime = entity.VisitTime,
                     State = entity.State,
                     Recorder = entity.Recorder,
                     Remark = entity.Remark
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.ADM_Letter GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.ADM_Letter, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.ADM_Letter model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.ADM_Letter
                   {
                       ID = entity.ID,
                       Address = entity.Address,
                       Age = entity.Age,
                       Area = entity.Area,
                       ChannelID = entity.ChannelID,
                       Email = entity.Email,
                       Handler = entity.Handler,
                       LetterNO = entity.LetterNO,
                       Matter = entity.Matter,
                       Mobile = entity.Mobile,
                       Receiver = entity.Receiver,
                       NumberOfpeople = entity.NumberOfpeople,
                       TypeID = entity.TypeID,
                       Title = entity.Title,
                       IDCard = entity.IDCard,
                       Sex = entity.Sex,
                       Tel = entity.Tel,
                       Occupation = entity.Occupation,
                       RecordTime = entity.RecordTime,
                       Visitor = entity.Visitor,
                       VisitTime = entity.VisitTime,
                       State = entity.State,
                       Recorder = entity.Recorder,
                       Remark = entity.Remark,
                       HandleDepartmentID = entity.HR_Personnel == null ? null : entity.HR_Personnel.DepartmentID,
                       ReceiveDepartmentID = entity.RecorderHR_Personnel == null ? null : entity.RecorderHR_Personnel.DepartmentID,
                       RecorderName=entity.RecorderHR_Personnel.Name
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.ADM_Letter model)
        {
            dal.Initialization();
            FineOffice.Entity.ADM_Letter entity = new Entity.ADM_Letter
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
        public List<Modules.ADM_Letter> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
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
        public List<Modules.ADM_Letter> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }

        /// <summary>
        /// 按表达查找步骤
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<Modules.ADM_Letter> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.ADM_Letter, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.ADM_Letter> list = new List<Modules.ADM_Letter>();
            list = (from entity in dal.GetListAll()
                    select new FineOffice.Modules.ADM_Letter
                    {
                        ID = entity.ID,
                        Address = entity.Address,
                        Age = entity.Age,
                        Area = entity.Area,
                        ChannelID = entity.ChannelID,
                        Email = entity.Email,
                        Handler = entity.Handler,
                        LetterNO = entity.LetterNO,
                        Matter = entity.Matter,
                        Mobile = entity.Mobile,
                        Receiver = entity.Receiver,
                        NumberOfpeople = entity.NumberOfpeople,
                        TypeID = entity.TypeID,
                        Title = entity.Title,
                        IDCard = entity.IDCard,
                        Sex = entity.Sex,
                        Tel = entity.Tel,
                        Occupation = entity.Occupation,
                        RecordTime = entity.RecordTime,
                        Visitor = entity.Visitor,
                        VisitTime = entity.VisitTime,
                        State = entity.State,
                        Recorder = entity.Recorder,
                        Remark = entity.Remark
                    }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        public int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetCount(changeTrackingList);
        }

        public void Delete(List<int> ids)
        {
            dal.Initialization();
            dal.Delete(d => ids.Contains(d.ID));
            dal.Dispose();
        }
    }
}
