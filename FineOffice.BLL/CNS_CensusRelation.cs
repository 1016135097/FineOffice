using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class CNS_CensusRelation
    {
        FineOffice.IDataAccess.CNS_CensusRelation dal = new FineOffice.DataAccess.CNS_CensusRelation();

        public FineOffice.Modules.CNS_CensusRelation Add(FineOffice.Modules.CNS_CensusRelation model)
        {
            dal.Initialization();
            FineOffice.Entity.CNS_CensusRelation entity = new Entity.CNS_CensusRelation
            {
                ID = model.ID,
                Remark = model.Remark,
                Relation = model.Relation,
            };
            dal.Add(entity);
            dal.Dispose();
            return this.GetModel(d => d.ID == entity.ID);
        }

        public FineOffice.Modules.CNS_CensusRelation Update(FineOffice.Modules.CNS_CensusRelation model)
        {
            dal.Initialization();
            FineOffice.Entity.CNS_CensusRelation entity = new Entity.CNS_CensusRelation
            {
                ID = model.ID,
                Remark = model.Remark,
                Relation = model.Relation,
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        public List<FineOffice.Modules.CNS_CensusRelation> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.CNS_CensusRelation> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.CNS_CensusRelation
                 {
                     ID = entity.ID,
                     Remark = entity.Remark,
                     Relation = entity.Relation,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        public FineOffice.Modules.CNS_CensusRelation GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CNS_CensusRelation, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.CNS_CensusRelation model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.CNS_CensusRelation
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       Relation = entity.Relation,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        /// <summary>
        /// 返回一个List
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.CNS_CensusRelation> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CNS_CensusRelation, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.CNS_CensusRelation> list =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.CNS_CensusRelation
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       Relation = entity.Relation,
                   }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        public void Delete(Modules.CNS_CensusRelation model)
        {
            dal.Initialization();
            FineOffice.Entity.CNS_CensusRelation entity = new Entity.CNS_CensusRelation
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
