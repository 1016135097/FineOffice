using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class CRM_Source
    {
        FineOffice.IDataAccess.CRM_Source dal = new FineOffice.DataAccess.CRM_Source();

        /// <summary>
        /// 增加部门
        /// </summary>
        public FineOffice.Modules.CRM_Source Add(FineOffice.Modules.CRM_Source model)
        {
            dal.Initialization();
            FineOffice.Entity.CRM_Source entity = new Entity.CRM_Source
            {
                ID = model.ID,
                Source = model.Source,
                Ordering = model.Ordering,
                Remark = model.Remark,
            };
            dal.Add(entity);
            dal.Dispose();
            return this.GetModel(d => d.ID == entity.ID);
        }

        public FineOffice.Modules.CRM_Source Update(FineOffice.Modules.CRM_Source model)
        {
            dal.Initialization();
            FineOffice.Entity.CRM_Source entity = new Entity.CRM_Source
            {
                ID = model.ID,
                Source = model.Source,
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
        public List<FineOffice.Modules.CRM_Source> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.CRM_Source> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.CRM_Source
                 {
                     ID = entity.ID,
                     Source = entity.Source,
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
        public List<FineOffice.Modules.CRM_Source> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CRM_Source, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.CRM_Source> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.CRM_Source
                 {
                     ID = entity.ID,
                     Source = entity.Source,
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
        public FineOffice.Modules.CRM_Source GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CRM_Source, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.CRM_Source model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.CRM_Source
                   {
                       ID = entity.ID,
                       Source = entity.Source,
                       Ordering = entity.Ordering,
                       Remark = entity.Remark,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.CRM_Source model)
        {
            dal.Initialization();
            FineOffice.Entity.CRM_Source entity = new Entity.CRM_Source
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
