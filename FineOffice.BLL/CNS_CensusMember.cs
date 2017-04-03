using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class CNS_CensusMember
    {
        FineOffice.IDataAccess.CNS_CensusMember dal = new FineOffice.DataAccess.CNS_CensusMember();
        /// <summary>
        /// 增加
        /// </summary>
        public FineOffice.Modules.CNS_CensusMember Add(FineOffice.Modules.CNS_CensusMember model)
        {
            dal.Initialization();
            FineOffice.Entity.CNS_CensusMember entity = new Entity.CNS_CensusMember
            {
                ID = model.ID,
                Address = model.Address,
                Brithday = model.Brithday,
                CancelDate = model.CancelDate,
                CancelReason = model.CancelReason,
                Company = model.Company,
                EducationID = model.EducationID,
                Height = model.Height,
                IDCard = model.IDCard,
                IngoingDate = model.IngoingDate,
                IngoingReason = model.IngoingReason,
                IsCanceled = model.IsCanceled,
                Marriage = model.Marriage,
                MilitaryService = model.MilitaryService,
                MoveOutDate = model.MoveOutDate,
                MoveToAddress = model.MoveToAddress,
                Name = model.Name,
                Nationalilty = model.Nationalilty,
                Occupation = model.Occupation,
                PoliticalID = model.PoliticalID,
                TypeOfBlood = model.TypeOfBlood,
                Tel = model.Tel,
                Sex = model.Sex,
                Religion = model.Relation,
                OtherName = model.OtherName,
                Relation = model.Relation,
                PreviousAddress = model.PreviousAddress,
                PlaceOfAncestral = model.PlaceOfAncestral,
                PlaceOfBirth = model.PlaceOfBirth,
                RegisterNO = model.RegisterNO,
                Remark = model.Remark
            };
            dal.Add(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public FineOffice.Modules.CNS_CensusMember Update(FineOffice.Modules.CNS_CensusMember model)
        {
            dal.Initialization();
            FineOffice.Entity.CNS_CensusMember entity = new Entity.CNS_CensusMember
            {
                ID = model.ID,
                Address = model.Address,
                Brithday = model.Brithday,
                CancelDate = model.CancelDate,
                CancelReason = model.CancelReason,
                Company = model.Company,
                EducationID = model.EducationID,
                Height = model.Height,
                IDCard = model.IDCard,
                IngoingDate = model.IngoingDate,
                IngoingReason = model.IngoingReason,
                IsCanceled = model.IsCanceled,
                Marriage = model.Marriage,
                MilitaryService = model.MilitaryService,
                MoveOutDate = model.MoveOutDate,
                MoveToAddress = model.MoveToAddress,
                Name = model.Name,
                Nationalilty = model.Nationalilty,
                Occupation = model.Occupation,
                PoliticalID = model.PoliticalID,
                TypeOfBlood = model.TypeOfBlood,
                Tel = model.Tel,
                Sex = model.Sex,
                Religion = model.Relation,
                OtherName = model.OtherName,
                Relation = model.Relation,
                PreviousAddress = model.PreviousAddress,
                PlaceOfAncestral = model.PlaceOfAncestral,
                PlaceOfBirth = model.PlaceOfBirth,
                RegisterNO = model.RegisterNO,
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
        public List<FineOffice.Modules.CNS_CensusMember> GetListAll()
        {
            dal.Initialization(); 
            List<FineOffice.Modules.CNS_CensusMember> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.CNS_CensusMember
                 {
                     ID = entity.ID,
                     Address = entity.Address,
                     Brithday = entity.Brithday,
                     CancelDate = entity.CancelDate,
                     CancelReason = entity.CancelReason,
                     Company = entity.Company,
                     EducationID = entity.EducationID,
                     Height = entity.Height,
                     IDCard = entity.IDCard,
                     IngoingDate = entity.IngoingDate,
                     IngoingReason = entity.IngoingReason,
                     IsCanceled = entity.IsCanceled,
                     Marriage = entity.Marriage,
                     MilitaryService = entity.MilitaryService,
                     MoveOutDate = entity.MoveOutDate,
                     MoveToAddress = entity.MoveToAddress,
                     Name = entity.Name,
                     Nationalilty = entity.Nationalilty,
                     Occupation = entity.Occupation,
                     PoliticalID = entity.PoliticalID,
                     TypeOfBlood = entity.TypeOfBlood,
                     Tel = entity.Tel,
                     Sex = entity.Sex,
                     Religion = entity.Relation,
                     OtherName = entity.OtherName,
                     Relation = entity.Relation,
                     PreviousAddress = entity.PreviousAddress,
                     PlaceOfAncestral = entity.PlaceOfAncestral,
                     PlaceOfBirth = entity.PlaceOfBirth,
                     RegisterNO = entity.RegisterNO,
                     Remark = entity.Remark
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.CNS_CensusMember GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CNS_CensusMember, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.CNS_CensusMember model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.CNS_CensusMember
                   {
                       ID = entity.ID,
                       Address = entity.Address,
                       Brithday = entity.Brithday,
                       CancelDate = entity.CancelDate,
                       CancelReason = entity.CancelReason,
                       Company = entity.Company,
                       EducationID = entity.EducationID,
                       Height = entity.Height,
                       IDCard = entity.IDCard,
                       IngoingDate = entity.IngoingDate,
                       IngoingReason = entity.IngoingReason,
                       IsCanceled = entity.IsCanceled,
                       Marriage = entity.Marriage,
                       MilitaryService = entity.MilitaryService,
                       MoveOutDate = entity.MoveOutDate,
                       MoveToAddress = entity.MoveToAddress,
                       Name = entity.Name,
                       Nationalilty = entity.Nationalilty,
                       Occupation = entity.Occupation,
                       PoliticalID = entity.PoliticalID,
                       TypeOfBlood = entity.TypeOfBlood,
                       Tel = entity.Tel,
                       Sex = entity.Sex,
                       Religion = entity.Relation,
                       OtherName = entity.OtherName,
                       Relation = entity.Relation,
                       PreviousAddress = entity.PreviousAddress,
                       PlaceOfAncestral = entity.PlaceOfAncestral,
                       PlaceOfBirth = entity.PlaceOfBirth,
                       RegisterNO = entity.RegisterNO,
                       Remark = entity.Remark
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.CNS_CensusMember model)
        {
            dal.Initialization();
            FineOffice.Entity.CNS_CensusMember entity = new Entity.CNS_CensusMember
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
        public List<Modules.CNS_CensusMember> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
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
        public List<Modules.CNS_CensusMember> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }

        /// <summary>
        /// 按表达查找步骤
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<Modules.CNS_CensusMember> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CNS_CensusMember, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.CNS_CensusMember> list = new List<Modules.CNS_CensusMember>();
            list = (from entity in dal.GetListAll()
                    select new FineOffice.Modules.CNS_CensusMember
                    {
                        ID = entity.ID,
                        Address = entity.Address,
                        Brithday = entity.Brithday,
                        CancelDate = entity.CancelDate,
                        CancelReason = entity.CancelReason,
                        Company = entity.Company,
                        EducationID = entity.EducationID,
                        Height = entity.Height,
                        IDCard = entity.IDCard,
                        IngoingDate = entity.IngoingDate,
                        IngoingReason = entity.IngoingReason,
                        IsCanceled = entity.IsCanceled,
                        Marriage = entity.Marriage,
                        MilitaryService = entity.MilitaryService,
                        MoveOutDate = entity.MoveOutDate,
                        MoveToAddress = entity.MoveToAddress,
                        Name = entity.Name,
                        Nationalilty = entity.Nationalilty,
                        Occupation = entity.Occupation,
                        PoliticalID = entity.PoliticalID,
                        TypeOfBlood = entity.TypeOfBlood,
                        Tel = entity.Tel,
                        Sex = entity.Sex,
                        Religion = entity.Relation,
                        OtherName = entity.OtherName,
                        Relation = entity.Relation,
                        PreviousAddress = entity.PreviousAddress,
                        PlaceOfAncestral = entity.PlaceOfAncestral,
                        PlaceOfBirth = entity.PlaceOfBirth,
                        RegisterNO = entity.RegisterNO,
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
