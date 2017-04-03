using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class OA_ContractType
    {
        FineOffice.IDataAccess.OA_ContractType dal = new FineOffice.DataAccess.OA_ContractType();

        /// <summary>
        /// 增加部门
        /// </summary>
        public FineOffice.Modules.OA_ContractType Add(FineOffice.Modules.OA_ContractType model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_ContractType entity = new Entity.OA_ContractType
            {
                ID = model.ID,
                Ordering = model.Ordering,
                TypeName = model.TypeName,
                Remark = model.Remark,
            };
            dal.Add(entity);
            dal.Dispose();
            return this.GetModel(d => d.ID == entity.ID);
        }

        public FineOffice.Modules.OA_ContractType Update(FineOffice.Modules.OA_ContractType model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_ContractType entity = new Entity.OA_ContractType
            {
                ID = model.ID,
                Ordering = model.Ordering,
                TypeName = model.TypeName,
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
        public List<FineOffice.Modules.OA_ContractType> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_ContractType> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.OA_ContractType
                 {
                     ID = entity.ID,
                     Ordering = entity.Ordering,
                     TypeName = entity.TypeName,
                     Remark = entity.Remark,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回所有部门
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.OA_ContractType> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_ContractType, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_ContractType> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.OA_ContractType
                 {
                     ID = entity.ID,
                     Ordering = entity.Ordering,
                     TypeName = entity.TypeName,
                     Remark = entity.Remark,
                 }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.OA_ContractType GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_ContractType, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.OA_ContractType model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.OA_ContractType
                   {
                       ID = entity.ID,
                       Ordering = entity.Ordering,
                       TypeName = entity.TypeName,
                       Remark = entity.Remark,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.OA_ContractType model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_ContractType entity = new Entity.OA_ContractType
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
