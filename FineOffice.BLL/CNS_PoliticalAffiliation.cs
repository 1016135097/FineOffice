using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class CNS_PoliticalAffiliation
    {
        FineOffice.IDataAccess.CNS_PoliticalAffiliation dal = new FineOffice.DataAccess.CNS_PoliticalAffiliation();

        public FineOffice.Modules.CNS_PoliticalAffiliation Add(FineOffice.Modules.CNS_PoliticalAffiliation model)
        {
            dal.Initialization();
            FineOffice.Entity.CNS_PoliticalAffiliation entity = new Entity.CNS_PoliticalAffiliation
            {
                ID = model.ID,
                Remark = model.Remark,
                Political = model.Political,
            };
            dal.Add(entity);
            dal.Dispose();
            return this.GetModel(d => d.ID == entity.ID);
        }

        public FineOffice.Modules.CNS_PoliticalAffiliation Update(FineOffice.Modules.CNS_PoliticalAffiliation model)
        {
            dal.Initialization();
            FineOffice.Entity.CNS_PoliticalAffiliation entity = new Entity.CNS_PoliticalAffiliation
            {
                ID = model.ID,
                Remark = model.Remark,
                Political = model.Political,
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        public List<FineOffice.Modules.CNS_PoliticalAffiliation> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.CNS_PoliticalAffiliation> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.CNS_PoliticalAffiliation
                 {
                     ID = entity.ID,
                     Remark = entity.Remark,
                     Political = entity.Political,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        public FineOffice.Modules.CNS_PoliticalAffiliation GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CNS_PoliticalAffiliation, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.CNS_PoliticalAffiliation model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.CNS_PoliticalAffiliation
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       Political = entity.Political,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        /// <summary>
        /// 返回一个List
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.CNS_PoliticalAffiliation> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CNS_PoliticalAffiliation, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.CNS_PoliticalAffiliation> list =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.CNS_PoliticalAffiliation
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       Political = entity.Political,
                   }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        public void Delete(Modules.CNS_PoliticalAffiliation model)
        {
            dal.Initialization();
            FineOffice.Entity.CNS_PoliticalAffiliation entity = new Entity.CNS_PoliticalAffiliation
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
