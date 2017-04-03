using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class CNS_CensusType
    {
        FineOffice.IDataAccess.CNS_CensusType dal = new FineOffice.DataAccess.CNS_CensusType();
       
        public FineOffice.Modules.CNS_CensusType Add(FineOffice.Modules.CNS_CensusType model)
        {
            dal.Initialization();
            FineOffice.Entity.CNS_CensusType entity = new Entity.CNS_CensusType
            {
                ID = model.ID,
                Remark = model.Remark,
                CensusTypeName=model.CensusTypeName,
            };
            dal.Add(entity);
            dal.Dispose();
            return this.GetModel(d => d.ID == entity.ID);
        }

        public FineOffice.Modules.CNS_CensusType Update(FineOffice.Modules.CNS_CensusType model)
        {
            dal.Initialization();
            FineOffice.Entity.CNS_CensusType entity = new Entity.CNS_CensusType
            {
                ID = model.ID,
                Remark = model.Remark,
                CensusTypeName = model.CensusTypeName,
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }
       
        public List<FineOffice.Modules.CNS_CensusType> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.CNS_CensusType> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.CNS_CensusType
                 {
                     ID = entity.ID,
                     Remark = entity.Remark,
                     CensusTypeName = entity.CensusTypeName,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        public FineOffice.Modules.CNS_CensusType GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CNS_CensusType, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.CNS_CensusType model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.CNS_CensusType
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       CensusTypeName = entity.CensusTypeName,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        /// <summary>
        /// 返回一个List
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.CNS_CensusType> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CNS_CensusType, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.CNS_CensusType> list =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.CNS_CensusType
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       CensusTypeName = entity.CensusTypeName,
                   }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        public void Delete(Modules.CNS_CensusType model)
        {
            dal.Initialization();
            FineOffice.Entity.CNS_CensusType entity = new Entity.CNS_CensusType
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
