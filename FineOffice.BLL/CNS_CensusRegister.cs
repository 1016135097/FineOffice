using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class CNS_CensusRegister
    {
        FineOffice.IDataAccess.CNS_CensusRegister dal = new FineOffice.DataAccess.CNS_CensusRegister();
        /// <summary>
        /// 增加
        /// </summary>
        public FineOffice.Modules.CNS_CensusRegister Add(FineOffice.Modules.CNS_CensusRegister model)
        {
            dal.Initialization();
            FineOffice.Entity.CNS_CensusRegister entity = new Entity.CNS_CensusRegister
            {
                ID = model.ID,
                CensusTypeID = model.CensusTypeID,
                Habitation = model.Habitation,
                HouseHolder = model.HouseHolder,
                IssuingAuthority = model.IssuingAuthority,
                IssuingDate = model.IssuingDate,
                RegisterNO = model.RegisterNO,
                Remark = model.Remark
            };
            dal.Add(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public FineOffice.Modules.CNS_CensusRegister Update(FineOffice.Modules.CNS_CensusRegister model)
        {
            dal.Initialization();
            FineOffice.Entity.CNS_CensusRegister entity = new Entity.CNS_CensusRegister
            {
                ID = model.ID,
                CensusTypeID = model.CensusTypeID,
                Habitation = model.Habitation,
                HouseHolder = model.HouseHolder,
                IssuingAuthority = model.IssuingAuthority,
                IssuingDate = model.IssuingDate,
                RegisterNO = model.RegisterNO,
                Remark = model.Remark
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 返回所有信件
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.CNS_CensusRegister> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.CNS_CensusRegister> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.CNS_CensusRegister
                 {
                     ID = entity.ID,
                     CensusTypeID = entity.CensusTypeID,
                     Habitation = entity.Habitation,
                     HouseHolder = entity.HouseHolder,
                     IssuingAuthority = entity.IssuingAuthority,
                     IssuingDate = entity.IssuingDate,
                     RegisterNO = entity.RegisterNO,
                     Remark = entity.Remark,
                     CensusTypeName = entity.CNS_CensusType.CensusTypeName,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.CNS_CensusRegister GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CNS_CensusRegister, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.CNS_CensusRegister model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.CNS_CensusRegister
                   {
                       ID = entity.ID,
                       CensusTypeID = entity.CensusTypeID,
                       Habitation = entity.Habitation,
                       HouseHolder = entity.HouseHolder,
                       IssuingAuthority = entity.IssuingAuthority,
                       IssuingDate = entity.IssuingDate,
                       RegisterNO = entity.RegisterNO,
                       Remark = entity.Remark,
                       CensusTypeName = entity.CNS_CensusType.CensusTypeName,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.CNS_CensusRegister model)
        {
            dal.Initialization();
            FineOffice.Entity.CNS_CensusRegister entity = new Entity.CNS_CensusRegister
            {
                ID = model.ID,
            };
            dal.Delete(entity);
            dal.Dispose();
        }

        /// <summary>
        /// sql方式查询
        /// </summary>
        /// <param name="changeTrackingList"></param>
        /// <returns></returns>
        public List<Modules.CNS_CensusRegister> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetList(changeTrackingList);
        }

        /// <summary>
        /// 分页sql方式查询
        /// </summary>
        /// <param name="changeTrackingList"></param>
        /// <param name="start"></param>
        /// <param name="records"></param>
        /// <returns></returns>
        public List<Modules.CNS_CensusRegister> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }

        /// <summary>
        /// 按表达查找步骤
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<Modules.CNS_CensusRegister> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.CNS_CensusRegister, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.CNS_CensusRegister> list = new List<Modules.CNS_CensusRegister>();
            list = (from entity in dal.GetListAll()
                    select new FineOffice.Modules.CNS_CensusRegister
                    {
                        ID = entity.ID,
                        CensusTypeID = entity.CensusTypeID,
                        Habitation = entity.Habitation,
                        HouseHolder = entity.HouseHolder,
                        IssuingAuthority = entity.IssuingAuthority,
                        IssuingDate = entity.IssuingDate,
                        RegisterNO = entity.RegisterNO,
                        Remark = entity.Remark,
                        CensusTypeName = entity.CNS_CensusType.CensusTypeName,
                    }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        public int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetCount(changeTrackingList);
        }

        public void Delete(List<int> ids)
        {
            dal.Initialization();
            dal.Delete(d => ids.Contains(d.ID));
            dal.Dispose();
        }
    }
}
