using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BX.BLL
{
   public class OA_WorkFlow
    {
        BX.IDataAccess.OA_WorkFlow dal = new BX.DataAccess.OA_WorkFlow();
        /// <summary>
        /// 增加工作流
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BX.Modules.OA_WorkFlow Add(BX.Modules.OA_WorkFlow model)
        {
            dal.Initialization();
            BX.Entity.OA_WorkFlow entity = new Entity.OA_WorkFlow
            {
                ID = model.ID,
                FormID = model.FormID,
                ProjectTypeID = model.ProjectTypeID,
                WorkFlowNO = model.WorkFlowNO,
                WorkFlowName = model.WorkFlowName,
                PinyinCode = model.PinyinCode,
                UserList = model.UserList,
                MakeDate = model.MakeDate,
                Describe = model.Describe,
                Maker = model.Maker,
                Remark = model.Remark
            };
            dal.Add(entity);
            dal.Dispose();
            return null;
        }

        public BX.Modules.OA_WorkFlow Update(BX.Modules.OA_WorkFlow model)
        {
            dal.Initialization();
            BX.Entity.OA_WorkFlow entity = new Entity.OA_WorkFlow
            {
                ID = model.ID,
                FormID = model.FormID,
                ProjectTypeID = model.ProjectTypeID,
                WorkFlowNO = model.WorkFlowNO,
                WorkFlowName = model.WorkFlowName,
                PinyinCode = model.PinyinCode,
                UserList = model.UserList,
                MakeDate = model.MakeDate,
                Maker = model.Maker,
                Describe = model.Describe,
                Remark = model.Remark
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 返回所有工作流
        /// </summary>
        /// <returns></returns>
        public List<BX.Modules.OA_WorkFlow> GetListAll()
        {
            dal.Initialization();
            List<BX.Modules.OA_WorkFlow> list =
                (from entity in dal.GetListAll()
                 select new BX.Modules.OA_WorkFlow
                 {
                     ID = entity.ID,
                     FormID = entity.FormID,
                     //FormName = entity.FormID == null ? string.Empty : entity.OA_Form.FormName,
                     ProjectTypeID = entity.ProjectTypeID,
                     ProjectName = entity.ProjectTypeID == null ? string.Empty : entity.OA_ProjectType.TypeName,
                     WorkFlowNO = entity.WorkFlowNO,
                     WorkFlowName = entity.WorkFlowName,
                     PinyinCode = entity.PinyinCode,
                     UserList = entity.UserList,
                     MakeDate = entity.MakeDate,
                     Maker = entity.Maker,
                     Describe = entity.Describe,
                     Remark = entity.Remark
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public BX.Modules.OA_WorkFlow GetModel(System.Linq.Expressions.Expression<Func<BX.Modules.OA_WorkFlow, bool>> expression)
        {
            dal.Initialization();
            BX.Modules.OA_WorkFlow model =
                  (from entity in dal.GetListAll()
                   select new BX.Modules.OA_WorkFlow
                   {
                       ID = entity.ID,
                       FormID = entity.FormID,
                       //FormName = entity.FormID == null ? string.Empty : entity.OA_Form.FormName,
                       ProjectTypeID = entity.ProjectTypeID,
                       ProjectName = entity.ProjectTypeID == null ? string.Empty : entity.OA_ProjectType.TypeName,
                       WorkFlowNO = entity.WorkFlowNO,
                       WorkFlowName = entity.WorkFlowName,
                       PinyinCode = entity.PinyinCode,
                       UserList = entity.UserList,
                       MakeDate = entity.MakeDate,
                       Maker = entity.Maker,
                       Describe = entity.Describe,
                       Remark = entity.Remark

                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.OA_WorkFlow model)
        {
            dal.Initialization();
            BX.Entity.OA_WorkFlow entity = new Entity.OA_WorkFlow
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
        public List<Modules.OA_WorkFlow> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
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
        public List<Modules.OA_WorkFlow> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }

        /// <summary>
        /// 分页sql方式查询
        /// </summary>
        /// <param name="changeTrackingList"></param>
        /// <param name="start"></param>
        /// <param name="records"></param>
        /// <returns></returns>
        public List<Modules.OA_WorkFlow> GetList(string strSql, int start, int records)
        {
            return dal.GetList(strSql, start, records);
        }

        public int GetCount(string strSql)
        {
            return dal.GetCount(strSql);
        }
    }
}
