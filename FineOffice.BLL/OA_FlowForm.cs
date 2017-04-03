using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class OA_FlowForm
    {
        FineOffice.IDataAccess.OA_FlowForm dal = new FineOffice.DataAccess.OA_FlowForm();
        /// <summary>
        /// 增加
        /// </summary>
        public FineOffice.Modules.OA_FlowForm Add(FineOffice.Modules.OA_FlowForm model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FlowForm entity = new Entity.OA_FlowForm
            {
                ID = model.ID,
                FlowID = model.FlowID,
                FormID = model.FormID,
                ProcessID = model.ProcessID,
            };
            dal.Add(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public FineOffice.Modules.OA_FlowForm Update(FineOffice.Modules.OA_FlowForm model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FlowForm entity = new Entity.OA_FlowForm
            {
                ID = model.ID,
                FlowID = model.FlowID,
                FormID = model.FormID,
                ProcessID = model.ProcessID,
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 返回所有信件
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.OA_FlowForm> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_FlowForm> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.OA_FlowForm
                 {
                     ID = entity.ID,
                     FlowID = entity.FlowID,
                     FormID = entity.FormID,
                     FormName = entity.OA_Form.FormName,
                     FormNO = entity.OA_Form.FormNO,
                     Remark = entity.OA_Form.Remark,
                     ProcessName = entity.OA_FlowProcess.ProcessName,
                     ProcessID = entity.ProcessID,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.OA_FlowForm GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_FlowForm, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.OA_FlowForm model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.OA_FlowForm
                   {
                       ID = entity.ID,
                       FlowID = entity.FlowID,
                       FormID = entity.FormID,
                       FormName = entity.OA_Form.FormName,
                       FormNO = entity.OA_Form.FormNO,
                       Remark = entity.OA_Form.Remark,
                       ProcessName = entity.OA_FlowProcess.ProcessName,
                       ProcessID = entity.ProcessID,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.OA_FlowForm model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FlowForm entity = new Entity.OA_FlowForm
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

        /// <summary>
        /// sql方式查询
        /// </summary>
        /// <param name="changeTrackingList"></param>
        /// <returns></returns>
        public List<Modules.OA_FlowForm> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
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
        public List<Modules.OA_FlowForm> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }

        /// <summary>
        /// 按表达查找步骤
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<Modules.OA_FlowForm> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_FlowForm, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_FlowForm> list = new List<Modules.OA_FlowForm>();
            list = (from entity in dal.GetListAll()
                    select new FineOffice.Modules.OA_FlowForm
                    {
                        ID = entity.ID,
                        FlowID = entity.FlowID,
                        FormID = entity.FormID,
                        FormName = entity.OA_Form.FormName,
                        FormNO = entity.OA_Form.FormNO,
                        Remark = entity.OA_Form.Remark,
                        ProcessName = entity.OA_FlowProcess.ProcessName,
                        ProcessID = entity.ProcessID,
                    }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        public int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetCount(changeTrackingList);
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="list"></param>
        public void AddAll(Modules.Helper.ChangeTrackingList<Modules.OA_FlowForm> list)
        {
            dal.Initialization();
            List<Entity.OA_FlowForm> entityList = (from temp in list
                                                   select new FineOffice.Entity.OA_FlowForm
                                                   {
                                                       FlowID = temp.FlowID,
                                                       ID = temp.ID,
                                                       FormID = temp.FormID,
                                                       ProcessID = temp.ProcessID,
                                                   }).ToList();
            dal.Add(entityList);
            dal.Dispose();
        }
    }
}
