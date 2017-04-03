using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class OA_Contract
    {
        FineOffice.IDataAccess.OA_Contract dal = new FineOffice.DataAccess.OA_Contract();
        /// <summary>
        /// 增加
        /// </summary>
        public FineOffice.Modules.OA_Contract Add(FineOffice.Modules.OA_Contract model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_Contract entity = new Entity.OA_Contract
            {
                ID = model.ID,
                Content = model.Content,
                ContractName = model.ContractName,
                ContractNO = model.ContractNO,
                EndDate = model.EndDate,
                Handler = model.Handler,
                Location = model.Location,
                SingnDate = model.SingnDate,
                TraderID = model.TraderID,
                TypeID = model.TypeID,
                Remark = model.Remark
            };
            dal.Add(entity);
            dal.Dispose();
            return this.GetModel(l => l.ID == entity.ID);
        }

        /// <summary>
        /// 修改
        /// </summary>
        public FineOffice.Modules.OA_Contract Update(FineOffice.Modules.OA_Contract model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_Contract entity = new Entity.OA_Contract
            {
                ID = model.ID,
                Content = model.Content,
                ContractName = model.ContractName,
                ContractNO = model.ContractNO,
                EndDate = model.EndDate,
                Handler = model.Handler,
                Location = model.Location,
                SingnDate = model.SingnDate,
                TraderID = model.TraderID,
                TypeID = model.TypeID,
                Remark = model.Remark
            };
            dal.Update(entity);
            dal.Dispose();
            return this.GetModel(l => l.ID == entity.ID);
        }

        /// <summary>
        /// 返回所有信件
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.OA_Contract> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_Contract> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.OA_Contract
                 {
                     ID = entity.ID,
                     Content = entity.Content,
                     ContractName = entity.ContractName,
                     ContractNO = entity.ContractNO,
                     EndDate = entity.EndDate,
                     Handler = entity.Handler,
                     Location = entity.Location,
                     SingnDate = entity.SingnDate,
                     TraderID = entity.TraderID,
                     TypeID = entity.TypeID,
                     Remark = entity.Remark
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.OA_Contract GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_Contract, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.OA_Contract model =
                  (from entity in dal.GetTable()
                   select new FineOffice.Modules.OA_Contract
                   {
                       ID = entity.ID,
                       Content = entity.Content,
                       ContractName = entity.ContractName,
                       ContractNO = entity.ContractNO,
                       EndDate = entity.EndDate,
                       TraderName = entity.CRM_Trader == null ? null : entity.CRM_Trader.TraderName,
                       HandlerName = entity.HR_Personnel == null ? null : entity.HR_Personnel.Name,
                       Handler = entity.Handler,
                       Location = entity.Location,
                       SingnDate = entity.SingnDate,
                       TraderID = entity.TraderID,
                       TypeID = entity.TypeID,
                       Remark = entity.Remark
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.OA_Contract model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_Contract entity = new Entity.OA_Contract
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
        public List<Modules.OA_Contract> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
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
        public List<Modules.OA_Contract> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }

        /// <summary>
        /// 按表达查找步骤
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<Modules.OA_Contract> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_Contract, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_Contract> list = new List<Modules.OA_Contract>();
            list = (from entity in dal.GetListAll()
                    select new FineOffice.Modules.OA_Contract
                    {
                        ID = entity.ID,
                        Content = entity.Content,
                        ContractName = entity.ContractName,
                        ContractNO = entity.ContractNO,
                        EndDate = entity.EndDate,
                        Handler = entity.Handler,
                        Location = entity.Location,
                        SingnDate = entity.SingnDate,
                        TraderID = entity.TraderID,
                        TypeID = entity.TypeID,
                        Remark = entity.Remark
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
            dal.Delete(ids);
        }
    }
}
