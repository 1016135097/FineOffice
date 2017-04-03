using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BX.BLL
{
   public class OA_Work
    {
        BX.IDataAccess.OA_Work dal = new BX.DataAccess.OA_Work();
        /// <summary>
        /// 增加工作
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BX.Modules.OA_Work Add(BX.Modules.OA_Work model)
        {
            dal.Initialization();
            BX.Entity.OA_Work entity = new Entity.OA_Work
            {
                ID = model.ID,
                WorkName = model.WorkName,
                WorkFlowID = model.WorkFlowID,
                Maker = model.Maker,
                MakeDate = model.MakeDate,
                FromContent = model.FromContent,
                VerifyList = model.VerifyList,
                WorkState = model.WorkState,
                Remark = model.Remark
            };
            dal.Add(entity);
            dal.Dispose();
            return null;
        }

        public BX.Modules.OA_Work Update(BX.Modules.OA_Work model)
        {
            dal.Initialization();
            BX.Entity.OA_Work entity = new Entity.OA_Work
            {
                ID = model.ID,
                WorkName = model.WorkName,
                WorkFlowID = model.WorkFlowID,
                Maker = model.Maker,
                MakeDate = model.MakeDate,
                FromContent = model.FromContent,
                VerifyList = model.VerifyList,
                WorkState = model.WorkState,
                Remark = model.Remark
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 返回所有工作
        /// </summary>
        /// <returns></returns>
        public List<BX.Modules.OA_Work> GetListAll()
        {
            dal.Initialization();
            List<BX.Modules.OA_Work> list =
                (from entity in dal.GetListAll()
                 select new BX.Modules.OA_Work
                 {
                     ID = entity.ID,
                     WorkName = entity.WorkName,
                     WorkFlowID = entity.WorkFlowID,
                     WorkFlowName = entity.WorkFlowID == null ? string.Empty : entity.OA_WorkFlow.WorkFlowName,
                     FormName = entity.OA_WorkFlow.OA_Form == null ? null : entity.OA_WorkFlow.OA_Form.FormName,
                     Maker = entity.Maker,
                     MakeDate = entity.MakeDate,
                     FromContent = entity.FromContent,
                     VerifyList = entity.VerifyList,
                     WorkState = entity.WorkState,
                     Remark = entity.Remark
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public BX.Modules.OA_Work GetModel(System.Linq.Expressions.Expression<Func<BX.Modules.OA_Work, bool>> expression)
        {
            dal.Initialization();
            BX.Modules.OA_Work model =
                  (from entity in dal.GetListAll()
                   select new BX.Modules.OA_Work
                   {
                       ID = entity.ID,
                       WorkName = entity.WorkName,
                       WorkFlowID = entity.WorkFlowID,
                       WorkFlowName = entity.WorkFlowID == null ? string.Empty : entity.OA_WorkFlow.WorkFlowName,
                       FormName = entity.OA_WorkFlow.OA_Form == null ? null : entity.OA_WorkFlow.OA_Form.FormName,
                       Maker = entity.Maker,
                       MakeDate = entity.MakeDate,
                       FromContent = entity.FromContent,
                       VerifyList = entity.VerifyList,
                       WorkState = entity.WorkState,
                       Remark = entity.Remark

                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.OA_Work model)
        {
            dal.Initialization();
            BX.Entity.OA_Work entity = new Entity.OA_Work
            {
                ID = model.ID,
            };
            dal.Delete(entity);
            dal.Dispose();
        }
    }
}
