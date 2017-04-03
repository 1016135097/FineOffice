using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class CRM_Grade
    {
        FineOffice.IDataAccess.CRM_Grade dal = new FineOffice.DataAccess.CRM_Grade();

        /// <summary>
        /// 增加部门
        /// </summary>
        public FineOffice.Modules.CRM_Grade Add(FineOffice.Modules.CRM_Grade model)
        {
            dal.Initialization();
            FineOffice.Entity.CRM_Grade entity = new Entity.CRM_Grade
            {
                ID = model.ID,
                Grade = model.Grade,
                Ordering = model.Ordering,
                Remark = model.Remark,
            };
            dal.Add(entity);
            dal.Dispose();
            return this.GetModel(d => d.ID == entity.ID);
        }

        public FineOffice.Modules.CRM_Grade Update(FineOffice.Modules.CRM_Grade model)
        {
            dal.Initialization();
            FineOffice.Entity.CRM_Grade entity = new Entity.CRM_Grade
            {
                ID = model.ID,
                Grade = model.Grade,
                Ordering = model.Ordering,
                Remark = model.Remark,
            };
            dal.Update(entity);
            dal.Dispose();
            return this.GetModel(d => d.ID == entity.ID);
        }

        /// <summary>
        /// 返回所有部门
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.CRM_Grade> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.CRM_Grade> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.CRM_Grade
                 {
                     ID = entity.ID,
                     Grade = entity.Grade,
                     Ordering = entity.Ordering,
                     Remark = entity.Remark,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回所有部门
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.CRM_Grade> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CRM_Grade, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.CRM_Grade> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.CRM_Grade
                 {
                     ID = entity.ID,
                     Grade = entity.Grade,
                     Ordering = entity.Ordering,
                     Remark = entity.Remark,
                 }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.CRM_Grade GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CRM_Grade, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.CRM_Grade model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.CRM_Grade
                   {
                       ID = entity.ID,
                       Grade = entity.Grade,
                       Ordering = entity.Ordering,
                       Remark = entity.Remark,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.CRM_Grade model)
        {
            dal.Initialization();
            FineOffice.Entity.CRM_Grade entity = new Entity.CRM_Grade
            {
                ID = model.ID,
            };
            dal.Delete(entity);
            dal.Dispose();
        }

        public void Delete(List<int> deleteList)
        {
            dal.Initialization();
            dal.Delete(d => deleteList.Contains(d.ID));
            dal.Dispose();
        }
    }
}
