using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BX.BLL
{
   public class OA_WorkFlowNode
    {
        BX.IDataAccess.OA_WorkFlowNode dal = new BX.DataAccess.OA_WorkFlowNode();
        /// <summary>
        /// 增加工作流
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BX.Modules.OA_WorkFlowNode Add(BX.Modules.OA_WorkFlowNode model)
        {
            dal.Initialization();
            BX.Entity.OA_WorkFlowNode entity = new Entity.OA_WorkFlowNode
            {
                ID = model.ID,
                NodeNO = model.NodeNO,
                NodeName = model.NodeName,
                PinyinCode = model.PinyinCode,
                WorkFlowID = model.WorkFlowID,
                NodeXuHao = model.NodeXuHao,
                NodeAttribute = model.NodeAttribute,
                NextNodeXuHao = model.NextNodeXuHao,
                VerifyModel = model.VerifyModel,
                ValidHours = model.ValidHours,
                VerifierSetting = model.VerifierSetting,
                Transactor = model.Transactor,
                SetLeft = model.SetLeft,
                SetTop = model.SetTop,
                Remark = model.Remark
            };
            dal.Add(entity);
            dal.Dispose();
            return null;
        }

        public BX.Modules.OA_WorkFlowNode Update(BX.Modules.OA_WorkFlowNode model)
        {
            dal.Initialization();
            BX.Entity.OA_WorkFlowNode entity = new Entity.OA_WorkFlowNode
            {
                ID = model.ID,
                NodeNO = model.NodeNO,
                NodeName = model.NodeName,
                PinyinCode = model.PinyinCode,
                WorkFlowID = model.WorkFlowID,
                NodeXuHao = model.NodeXuHao,
                NodeAttribute = model.NodeAttribute,
                NextNodeXuHao = model.NextNodeXuHao,
                VerifyModel = model.VerifyModel,
                ValidHours = model.ValidHours,
                VerifierSetting = model.VerifierSetting,
                Transactor = model.Transactor,
                SetLeft = model.SetLeft,
                SetTop = model.SetTop,
                Remark = model.Remark
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

       /// <summary>
       ///  保存布局的更新
       /// </summary>
        public BX.Modules.OA_WorkFlowNode Update(List<BX.Modules.OA_WorkFlowNode> list)
        {
            dal.Initialization();
            List<BX.Entity.OA_WorkFlowNode> resultList = (from entity in list
                                                          select new BX.Entity.OA_WorkFlowNode
                                                              {
                                                                  ID = entity.ID,
                                                                  NodeNO = entity.NodeNO,
                                                                  NodeName = entity.NodeName,
                                                                  PinyinCode = entity.PinyinCode,
                                                                  WorkFlowID = entity.WorkFlowID,
                                                                  NodeXuHao = entity.NodeXuHao,
                                                                  NodeAttribute = entity.NodeAttribute,
                                                                  NextNodeXuHao = entity.NextNodeXuHao,
                                                                  VerifyModel = entity.VerifyModel,
                                                                  ValidHours = entity.ValidHours,
                                                                  VerifierSetting = entity.VerifierSetting,
                                                                  Transactor = entity.Transactor,
                                                                  SetLeft = entity.SetLeft,
                                                                  SetTop = entity.SetTop,
                                                                  Remark = entity.Remark
                                                              }).ToList();
            foreach (BX.Entity.OA_WorkFlowNode model in resultList)
            {
                dal.Update(model);
            }
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 返回所有工作流
        /// </summary>
        /// <returns></returns>
        public List<BX.Modules.OA_WorkFlowNode> GetListAll()
        {
            dal.Initialization();
            List<BX.Modules.OA_WorkFlowNode> list =
                (from entity in dal.GetListAll()
                 select new BX.Modules.OA_WorkFlowNode
                 {
                     ID = entity.ID,
                     NodeNO = entity.NodeNO,
                     NodeName = entity.NodeName,
                     PinyinCode = entity.PinyinCode,
                     WorkFlowID = entity.WorkFlowID,
                     NodeXuHao = entity.NodeXuHao,
                     NodeAttribute = entity.NodeAttribute,
                     NodeAttributeName = entity.NodeAttribute == null ? string.Empty : entity.Sys_FixedData.DataContent,
                     NextNodeXuHao = entity.NextNodeXuHao,
                     VerifyModel = entity.VerifyModel,
                     VerifyModelName = entity.VerifyModel == null ? string.Empty : entity.VerifyModelSys_FixedData.DataContent,
                     ValidHours = entity.ValidHours,
                     VerifierSetting = entity.VerifierSetting,
                     VerifierSettingName = entity.VerifierSetting == null ? string.Empty : entity.VerifierSettingSys_FixedData.DataContent,
                     Transactor = entity.Transactor,
                     SetLeft = entity.SetLeft,
                     SetTop = entity.SetTop,
                     Remark = entity.Remark
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public BX.Modules.OA_WorkFlowNode GetModel(System.Linq.Expressions.Expression<Func<BX.Modules.OA_WorkFlowNode, bool>> expression)
        {
            dal.Initialization();
            BX.Modules.OA_WorkFlowNode model =
                  (from entity in dal.GetListAll()
                   select new BX.Modules.OA_WorkFlowNode
                   {
                       ID = entity.ID,
                       NodeNO = entity.NodeNO,
                       NodeName = entity.NodeName,
                       PinyinCode = entity.PinyinCode,
                       WorkFlowID = entity.WorkFlowID,
                       NodeXuHao = entity.NodeXuHao,
                       NodeAttribute = entity.NodeAttribute,
                       NodeAttributeName = entity.NodeAttribute == null ? string.Empty : entity.Sys_FixedData.DataContent,
                       NextNodeXuHao = entity.NextNodeXuHao,
                       VerifyModel = entity.VerifyModel,
                       VerifyModelName = entity.VerifyModel == null ? string.Empty : entity.VerifyModelSys_FixedData.DataContent,
                       ValidHours = entity.ValidHours,
                       VerifierSetting = entity.VerifierSetting,
                       VerifierSettingName = entity.VerifierSetting == null ? string.Empty : entity.VerifierSettingSys_FixedData.DataContent,
                       Transactor = entity.Transactor,
                       SetLeft = entity.SetLeft,
                       SetTop = entity.SetTop,
                       Remark = entity.Remark
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.OA_WorkFlowNode model)
        {
            dal.Initialization();
            BX.Entity.OA_WorkFlowNode entity = new Entity.OA_WorkFlowNode
            {
                ID = model.ID,
            };
            dal.Delete(entity);
            dal.Dispose();
        }
    }
}
