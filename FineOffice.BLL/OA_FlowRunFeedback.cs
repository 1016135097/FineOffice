using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
   public class OA_FlowRunFeedback
    {
        FineOffice.IDataAccess.OA_FlowRunFeedback dal = new FineOffice.DataAccess.OA_FlowRunFeedback();
        /// <summary>
        /// 增加意见
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FineOffice.Modules.OA_FlowRunFeedback Add(FineOffice.Modules.OA_FlowRunFeedback model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FlowRunFeedback entity = new Entity.OA_FlowRunFeedback
            {
             
            };
            dal.Add(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 修改意见
        /// </summary>
        public FineOffice.Modules.OA_FlowRunFeedback Update(FineOffice.Modules.OA_FlowRunFeedback model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FlowRunFeedback entity = new Entity.OA_FlowRunFeedback
            {
                
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 返回所有意见
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.OA_FlowRunFeedback> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_FlowRunFeedback> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.OA_FlowRunFeedback
                 {
                   
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.OA_FlowRunFeedback GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_FlowRunFeedback, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.OA_FlowRunFeedback model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.OA_FlowRunFeedback
                   {
                       
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.OA_FlowRunFeedback model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FlowRunFeedback entity = new Entity.OA_FlowRunFeedback
            {
                ID = model.ID,
            };
            dal.Delete(entity);
            dal.Dispose();
        }
    }
}
