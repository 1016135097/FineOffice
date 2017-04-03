using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class ADM_LetterFollow
    {
        FineOffice.IDataAccess.ADM_LetterFollow dal = new FineOffice.DataAccess.ADM_LetterFollow();
        /// <summary>
        /// 增加表单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FineOffice.Modules.ADM_LetterFollow Add(FineOffice.Modules.ADM_LetterFollow model)
        {
            dal.Initialization();
            FineOffice.Entity.ADM_LetterFollow entity = new Entity.ADM_LetterFollow
            {
                ID = model.ID,
                Handler = model.Handler,
                HandleTime = model.HandleTime,
                LetterID = model.LetterID,
                Linkman = model.Linkman,
                Matter = model.Matter,
                Mobile = model.Mobile,
                Result = model.Result,
            };
            dal.Add(entity);
            dal.Dispose();
            return GetModel(d => d.ID == entity.ID);
        }

        public FineOffice.Modules.ADM_LetterFollow Update(FineOffice.Modules.ADM_LetterFollow model)
        {
            dal.Initialization();
            FineOffice.Entity.ADM_LetterFollow entity = new Entity.ADM_LetterFollow
            {
                ID = model.ID,
                Handler = model.Handler,
                HandleTime = model.HandleTime,
                LetterID = model.LetterID,
                Linkman = model.Linkman,
                Matter = model.Matter,
                Mobile = model.Mobile,
                Result = model.Result,
            };
            dal.Update(entity);
            dal.Dispose();
            return GetModel(d => d.ID == model.ID);
        }

        /// <summary>
        /// 返回所有表单
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.ADM_LetterFollow> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.ADM_LetterFollow> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.ADM_LetterFollow
                 {
                     ID = entity.ID,
                     Handler = entity.Handler,
                     HandleTime = entity.HandleTime,
                     LetterID = entity.LetterID,
                     Linkman = entity.Linkman,
                     Matter = entity.Matter,
                     Mobile = entity.Mobile,
                     Result = entity.Result,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.ADM_LetterFollow GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.ADM_LetterFollow, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.ADM_LetterFollow model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.ADM_LetterFollow
                   {
                       ID = entity.ID,
                       Handler = entity.Handler,
                       HandleTime = entity.HandleTime,
                       LetterID = entity.LetterID,
                       Linkman = entity.Linkman,
                       HandleDepartmentID = entity.HR_Personnel != null ? entity.HR_Personnel.DepartmentID : null,
                       Matter = entity.Matter,
                       Mobile = entity.Mobile,
                       Result = entity.Result,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.ADM_LetterFollow model)
        {
            dal.Initialization();
            FineOffice.Entity.ADM_LetterFollow entity = new Entity.ADM_LetterFollow
            {
                ID = model.ID,
            };
            dal.Delete(entity);
            dal.Dispose();
        }

        /// <summary>
        /// 按表达查找表单的数组
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<Modules.ADM_LetterFollow> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.ADM_LetterFollow, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.ADM_LetterFollow> list = new List<Modules.ADM_LetterFollow>();
            list = (from entity in dal.GetListAll()
                    select new FineOffice.Modules.ADM_LetterFollow
                    {
                        ID = entity.ID,
                        Handler = entity.Handler,
                        HandleTime = entity.HandleTime,
                        LetterID = entity.LetterID,
                        Linkman = entity.Linkman,
                        Matter = entity.Matter,
                        Mobile = entity.Mobile,
                        Result = entity.Result,
                        Remark = entity.Remark
                    }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// sql方式查询
        /// </summary>
        /// <param name="changeTrackingList"></param>
        /// <returns></returns>
        public List<Modules.ADM_LetterFollow> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
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
        public List<Modules.ADM_LetterFollow> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
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
