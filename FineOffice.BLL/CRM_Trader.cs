using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class CRM_Trader
    {
        FineOffice.IDataAccess.CRM_Trader dal = new FineOffice.DataAccess.CRM_Trader();
        /// <summary>
        /// 增加
        /// </summary>
        public FineOffice.Modules.CRM_Trader Add(FineOffice.Modules.CRM_Trader model)
        {
            dal.Initialization();
            FineOffice.Entity.CRM_Trader entity = new Entity.CRM_Trader
            {
                ID = model.ID,
                Address = model.Address,
                AreaID = model.AreaID,
                Email = model.Email,
                Handler = model.Handler,
                Mobile = model.Mobile,
                TypeID = model.TypeID,
                Tel = model.Tel,
                Remark = model.Remark,
                Fax = model.Fax,
                GradeID = model.GradeID,
                Incorporator = model.Incorporator,
                IndustryID = model.IndustryID,
                WebSite = model.WebSite,
                TraderNO = model.TraderNO,
                Stop = model.Stop,
                SourceID = model.SourceID,
                TraderName = model.TraderName,
                ShortName = model.ShortName,
                Post = model.Post,
                PinyinCode = model.PinyinCode,
                NumberOfPeople = model.NumberOfPeople,
                Linkman = model.Linkman,
                IsSupplier = model.IsSupplier,
                IsClient = model.IsClient,
                CreateTime = model.CreateTime,
            };
            dal.Add(entity);
            dal.Dispose();
            return this.GetModel(l => l.ID == entity.ID);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public FineOffice.Modules.CRM_Trader Update(FineOffice.Modules.CRM_Trader model)
        {
            dal.Initialization();
            FineOffice.Entity.CRM_Trader entity = new Entity.CRM_Trader
            {
                ID = model.ID,
                Address = model.Address,
                AreaID = model.AreaID,
                Email = model.Email,
                Handler = model.Handler,
                Mobile = model.Mobile,
                TypeID = model.TypeID,
                Tel = model.Tel,
                Remark = model.Remark,
                Fax = model.Fax,
                GradeID = model.GradeID,
                Incorporator = model.Incorporator,
                IndustryID = model.IndustryID,
                WebSite = model.WebSite,
                TraderNO = model.TraderNO,
                Stop = model.Stop,
                SourceID = model.SourceID,
                TraderName = model.TraderName,
                ShortName = model.ShortName,
                Post = model.Post,
                PinyinCode = model.PinyinCode,
                NumberOfPeople = model.NumberOfPeople,
                Linkman = model.Linkman,
                IsSupplier = model.IsSupplier,
                IsClient = model.IsClient,
                CreateTime = model.CreateTime,
            };
            dal.Update(entity);
            dal.Dispose();
            return this.GetModel(l => l.ID == entity.ID); ;
        }

        /// <summary>
        /// 返回所有信件
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.CRM_Trader> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.CRM_Trader> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.CRM_Trader
                 {
                     ID = entity.ID,
                     Address = entity.Address,
                     AreaID = entity.AreaID,
                     Email = entity.Email,
                     Handler = entity.Handler,
                     Mobile = entity.Mobile,
                     TypeID = entity.TypeID,
                     Tel = entity.Tel,
                     Remark = entity.Remark,
                     Fax = entity.Fax,
                     GradeID = entity.GradeID,
                     Incorporator = entity.Incorporator,
                     IndustryID = entity.IndustryID,
                     WebSite = entity.WebSite,
                     TraderNO = entity.TraderNO,
                     Stop = entity.Stop,
                     SourceID = entity.SourceID,
                     TraderName = entity.TraderName,
                     ShortName = entity.ShortName,
                     Post = entity.Post,
                     PinyinCode = entity.PinyinCode,
                     NumberOfPeople = entity.NumberOfPeople,
                     Linkman = entity.Linkman,
                     IsSupplier = entity.IsSupplier,
                     IsClient = entity.IsClient,
                     CreateTime = entity.CreateTime,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.CRM_Trader GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CRM_Trader, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.CRM_Trader model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.CRM_Trader
                   {
                       ID = entity.ID,
                       Address = entity.Address,
                       AreaID = entity.AreaID,
                       Email = entity.Email,
                       Handler = entity.Handler,
                       Mobile = entity.Mobile,
                       TypeID = entity.TypeID,
                       Tel = entity.Tel,
                       Remark = entity.Remark,
                       Fax = entity.Fax,
                       GradeID = entity.GradeID,
                       Incorporator = entity.Incorporator,
                       IndustryID = entity.IndustryID,
                       WebSite = entity.WebSite,
                       TraderNO = entity.TraderNO,
                       Stop = entity.Stop,
                       SourceID = entity.SourceID,
                       TraderName = entity.TraderName,
                       ShortName = entity.ShortName,
                       Post = entity.Post,
                       HandlerName = entity.HR_Personnel == null ? "" : entity.HR_Personnel.Name,
                       Area = entity.CRM_Area == null ? "" : entity.CRM_Area.Area,
                       PinyinCode = entity.PinyinCode,
                       NumberOfPeople = entity.NumberOfPeople,
                       Linkman = entity.Linkman,
                       IsSupplier = entity.IsSupplier,
                       IsClient = entity.IsClient,
                       CreateTime = entity.CreateTime,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.CRM_Trader model)
        {
            dal.Initialization();
            FineOffice.Entity.CRM_Trader entity = new Entity.CRM_Trader
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
        public List<Modules.CRM_Trader> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
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
        public List<Modules.CRM_Trader> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }

        /// <summary>
        /// 按表达查找步骤
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<Modules.CRM_Trader> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CRM_Trader, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.CRM_Trader> list = new List<Modules.CRM_Trader>();
            list = (from entity in dal.GetListAll()
                    select new FineOffice.Modules.CRM_Trader
                    {
                        ID = entity.ID,
                        Address = entity.Address,
                        AreaID = entity.AreaID,
                        Email = entity.Email,
                        Handler = entity.Handler,
                        Mobile = entity.Mobile,
                        TypeID = entity.TypeID,
                        Tel = entity.Tel,
                        Remark = entity.Remark,
                        Fax = entity.Fax,
                        GradeID = entity.GradeID,
                        Incorporator = entity.Incorporator,
                        IndustryID = entity.IndustryID,
                        WebSite = entity.WebSite,
                        TraderNO = entity.TraderNO,
                        Stop = entity.Stop,
                        SourceID = entity.SourceID,
                        TraderName = entity.TraderName,
                        ShortName = entity.ShortName,
                        Post = entity.Post,
                        PinyinCode = entity.PinyinCode,
                        NumberOfPeople = entity.NumberOfPeople,
                        Linkman = entity.Linkman,
                        IsSupplier = entity.IsSupplier,
                        IsClient = entity.IsClient,
                        CreateTime = entity.CreateTime,
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
