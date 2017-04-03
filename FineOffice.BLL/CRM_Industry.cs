using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class CRM_Industry
    {
        FineOffice.IDataAccess.CRM_Industry dal = new FineOffice.DataAccess.CRM_Industry();

        /// <summary>
        /// 增加部门
        /// </summary>
        public FineOffice.Modules.CRM_Industry Add(FineOffice.Modules.CRM_Industry model)
        {
            dal.Initialization();
            FineOffice.Entity.CRM_Industry entity = new Entity.CRM_Industry
            {
                ID = model.ID,
                Industry = model.Industry,
                Ordering = model.Ordering,
                Remark = model.Remark,
            };
            dal.Add(entity);
            dal.Dispose();
            return this.GetModel(d => d.ID == entity.ID);
        }

        public FineOffice.Modules.CRM_Industry Update(FineOffice.Modules.CRM_Industry model)
        {
            dal.Initialization();
            FineOffice.Entity.CRM_Industry entity = new Entity.CRM_Industry
            {
                ID = model.ID,
                Industry = model.Industry,
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
        public List<FineOffice.Modules.CRM_Industry> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.CRM_Industry> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.CRM_Industry
                 {
                     ID = entity.ID,
                     Industry = entity.Industry,
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
        public List<FineOffice.Modules.CRM_Industry> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CRM_Industry, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.CRM_Industry> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.CRM_Industry
                 {
                     ID = entity.ID,
                     Industry = entity.Industry,
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
        public FineOffice.Modules.CRM_Industry GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CRM_Industry, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.CRM_Industry model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.CRM_Industry
                   {
                       ID = entity.ID,
                       Industry = entity.Industry,
                       Ordering = entity.Ordering,
                       Remark = entity.Remark,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.CRM_Industry model)
        {
            dal.Initialization();
            FineOffice.Entity.CRM_Industry entity = new Entity.CRM_Industry
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
