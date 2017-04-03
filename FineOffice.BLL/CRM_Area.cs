using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class CRM_Area
    {
        FineOffice.IDataAccess.CRM_Area dal = new FineOffice.DataAccess.CRM_Area();

        /// <summary>
        /// 增加部门
        /// </summary>
        public FineOffice.Modules.CRM_Area Add(FineOffice.Modules.CRM_Area model)
        {
            FineOffice.Entity.CRM_Area entity = new Entity.CRM_Area
            {
                ID = model.ID,
                Area = model.Area,
                Ordering = model.Ordering,
                ParentID = model.ParentID,
                Remark = model.Remark,
            };
            dal.Add(entity);
            return this.GetModel(d => d.ID == entity.ID);
        }

        public FineOffice.Modules.CRM_Area Update(FineOffice.Modules.CRM_Area model)
        {
            FineOffice.Entity.CRM_Area entity = new Entity.CRM_Area
            {
                ID = model.ID,
                Area = model.Area,
                Ordering = model.Ordering,
                ParentID = model.ParentID,
                Remark = model.Remark,
            };
            dal.Update(entity);
            return this.GetModel(d => d.ID == entity.ID);
        }

        /// <summary>
        /// 返回所有部门
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.CRM_Area> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.CRM_Area> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.CRM_Area
                 {
                     ID = entity.ID,
                     Area = entity.Area,
                     Ordering = entity.Ordering,
                     ParentID = entity.ParentID,
                     Remark = entity.Remark,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回所有部门
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.CRM_Area> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CRM_Area, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.CRM_Area> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.CRM_Area
                 {
                     ID = entity.ID,
                     Area = entity.Area,
                     Ordering = entity.Ordering,
                     ParentID = entity.ParentID,
                     Remark = entity.Remark,
                 }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.CRM_Area GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CRM_Area, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.CRM_Area model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.CRM_Area
                   {
                       ID = entity.ID,
                       Area = entity.Area,
                       Ordering = entity.Ordering,
                       ParentID = entity.ParentID,
                       Remark = entity.Remark,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.CRM_Area model)
        {
            FineOffice.Entity.CRM_Area entity = new Entity.CRM_Area
            {
                ID = model.ID,
            };
            dal.Delete(entity);
        }

        public void Delete(List<int> deleteList)
        {
            dal.Initialization();
            dal.Delete(d => deleteList.Contains(d.ID));
            dal.Dispose();
        }

        public List<Modules.CRM_Area> GetSubList(Modules.CRM_Area a)
        {
            List<Entity.CRM_Area> tempList = dal.GetSubList(new Entity.CRM_Area { ID = a.ID });
            List<FineOffice.Modules.CRM_Area> list =
           (from entity in tempList
            select new FineOffice.Modules.CRM_Area
            {
                ID = entity.ID,
                Area = entity.Area,
                Ordering = entity.Ordering,
                ParentID = entity.ParentID,
                Remark = entity.Remark,
            }).ToList();
            return list;
        }
    }
}
