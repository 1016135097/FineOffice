using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class AM_Kind
    {
        FineOffice.IDataAccess.AM_Kind dal = new FineOffice.DataAccess.AM_Kind();
        /// <summary>
        /// 增加部门
        /// </summary>
        public FineOffice.Modules.AM_Kind Add(FineOffice.Modules.AM_Kind model)
        {
            dal.Initialization();
            FineOffice.Entity.AM_Kind entity = new Entity.AM_Kind
            {
                ID = model.ID,
                KindID = model.KindID,
                KindName = model.KindName,
                Name = model.Name,
                Relation = model.Relation,
                Serial = model.Serial,
                SerialNO = model.SerialNO,
            };
            dal.Add(entity);
            dal.Dispose();
            return this.GetModel(d => d.ID == entity.ID);
        }

        public FineOffice.Modules.AM_Kind Update(FineOffice.Modules.AM_Kind model)
        {
            dal.Initialization();
            FineOffice.Entity.AM_Kind entity = new Entity.AM_Kind
            {
                ID = model.ID,
                KindID = model.KindID,
                KindName = model.KindName,
                Name = model.Name,
                Relation = model.Relation,
                Serial = model.Serial,
                SerialNO = model.SerialNO,
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 返回所有部门
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.AM_Kind> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.AM_Kind> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.AM_Kind
                 {
                     ID = entity.ID,
                     KindID = entity.KindID,
                     KindName = entity.KindName,
                     Name = entity.Name,
                     Relation = entity.Relation,
                     Serial = entity.Serial,
                     SerialNO = entity.SerialNO,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回所有部门
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.AM_Kind> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.AM_Kind, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.AM_Kind> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.AM_Kind
                 {
                     ID = entity.ID,
                     KindID = entity.KindID,
                     KindName = entity.KindName,
                     Name = entity.Name,
                     Relation = entity.Relation,
                     Serial = entity.Serial,
                     SerialNO = entity.SerialNO,
                 }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.AM_Kind GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.AM_Kind, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.AM_Kind model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.AM_Kind
                   {
                       ID = entity.ID,
                       KindID = entity.KindID,
                       KindName = entity.KindName,
                       Name = entity.Name,
                       Relation = entity.Relation,
                       Serial = entity.Serial,
                       SerialNO = entity.SerialNO,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.AM_Kind model)
        {
            dal.Initialization();
            FineOffice.Entity.AM_Kind entity = new Entity.AM_Kind
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
