using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class CRM_TraderType
    {
        FineOffice.IDataAccess.CRM_TraderType dal = new FineOffice.DataAccess.CRM_TraderType();

        /// <summary>
        /// 增加部门
        /// </summary>
        public FineOffice.Modules.CRM_TraderType Add(FineOffice.Modules.CRM_TraderType model)
        {
            dal.Initialization();
            FineOffice.Entity.CRM_TraderType entity = new Entity.CRM_TraderType
            {
                ID = model.ID,
                TraderType = model.TraderType,
                Ordering = model.Ordering,
                Remark = model.Remark,
            };
            dal.Add(entity);
            dal.Dispose();
            return this.GetModel(d => d.ID == entity.ID);
        }

        public FineOffice.Modules.CRM_TraderType Update(FineOffice.Modules.CRM_TraderType model)
        {
            dal.Initialization();
            FineOffice.Entity.CRM_TraderType entity = new Entity.CRM_TraderType
            {
                ID = model.ID,
                TraderType = model.TraderType,
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
        public List<FineOffice.Modules.CRM_TraderType> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.CRM_TraderType> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.CRM_TraderType
                 {
                     ID = entity.ID,
                     TraderType = entity.TraderType,
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
        public List<FineOffice.Modules.CRM_TraderType> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CRM_TraderType, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.CRM_TraderType> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.CRM_TraderType
                 {
                     ID = entity.ID,
                     TraderType = entity.TraderType,
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
        public FineOffice.Modules.CRM_TraderType GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CRM_TraderType, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.CRM_TraderType model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.CRM_TraderType
                   {
                       ID = entity.ID,
                       TraderType = entity.TraderType,
                       Ordering = entity.Ordering,
                       Remark = entity.Remark,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.CRM_TraderType model)
        {
            dal.Initialization();
            FineOffice.Entity.CRM_TraderType entity = new Entity.CRM_TraderType
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
