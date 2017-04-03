using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace FineOffice.BLL
{
    public class OA_Form
    {
        FineOffice.IDataAccess.OA_Form dal = new FineOffice.DataAccess.OA_Form();
        /// <summary>
        /// 增加表单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FineOffice.Modules.OA_Form Add(FineOffice.Modules.OA_Form model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_Form entity = new Entity.OA_Form
            {
                ID = model.ID,
                TypeID = model.TypeID,
                FormNO = model.FormNO,
                FormName = model.FormName,
                Creator = model.Creator,
                Stop = model.Stop,
                PinyinCode = model.PinyinCode,
                FormData = model.FormData == null ? null : model.FormData.ToArray(),
                XType = model.XType,
                Remark = model.Remark
            };
            dal.Add(entity);
            dal.Dispose();
            return GetModel(d => d.ID == entity.ID);
        }

        public FineOffice.Modules.OA_Form Update(FineOffice.Modules.OA_Form model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_Form entity = new Entity.OA_Form
            {
                ID = model.ID,
                TypeID = model.TypeID,
                FormNO = model.FormNO,
                Creator = model.Creator,
                Stop = model.Stop,
                FormName = model.FormName,
                PinyinCode = model.PinyinCode,
                FormData = model.FormData == null ? null : model.FormData.ToArray(),
                XType = model.XType,
                Remark = model.Remark
            };
            dal.Update(entity);
            dal.Dispose();
            return GetModel(d => d.ID == model.ID);
        }

        /// <summary>
        /// 返回所有表单
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.OA_Form> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_Form> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.OA_Form
                 {
                     ID = entity.ID,
                     TypeID = entity.TypeID,
                     FormNO = entity.FormNO,
                     Creator = entity.Creator,
                     Stop = entity.Stop,
                     FormName = entity.FormName,
                     PinyinCode = entity.PinyinCode,
                     FormData = entity.FormData.ToArray(),
                     XType = entity.XType,
                     Remark = entity.Remark
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.OA_Form GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_Form, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.OA_Form model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.OA_Form
                   {
                       ID = entity.ID,
                       TypeID = entity.TypeID,
                       FormNO = entity.FormNO,
                       Creator = entity.Creator,
                       Stop = entity.Stop,
                       FormName = entity.FormName,
                       PinyinCode = entity.PinyinCode,
                       Remark = entity.Remark,
                       FormData = entity.FormData == null ? null : entity.FormData.ToArray(),
                       XType = entity.XType,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.OA_Form model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_Form entity = new Entity.OA_Form
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
        public List<Modules.OA_Form> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetList(changeTrackingList);
        }

        /// <summary>
        /// 分页sql方式查询
        /// </summary>
        public List<Modules.OA_Form> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }

        /// <summary>
        /// 按表达查找表单的数组
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public List<Modules.OA_Form> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_Form, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_Form> list = new List<Modules.OA_Form>();
            list = (from entity in dal.GetListAll()
                    select new FineOffice.Modules.OA_Form
                    {
                        FormData = entity.FormData.ToArray(),
                        FormName = entity.FormName,
                        FormNO = entity.FormNO,
                        ID = entity.ID,
                        Creator = entity.Creator,
                        Stop = entity.Stop,
                        PinyinCode = entity.PinyinCode,
                        Remark = entity.Remark,
                        TypeID = entity.TypeID,
                        XType = entity.XType,
                        FormTypeName = entity.OA_FormType.FormTypeName
                    }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        public int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetCount(changeTrackingList);
        }
    }
}
