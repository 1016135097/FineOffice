using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class OA_FormType
    {
        IDataAccess.OA_FormType dal = new DataAccess.OA_FormType();

        /// <summary>
        /// 增加
        /// </summary>
        public FineOffice.Modules.OA_FormType Add(FineOffice.Modules.OA_FormType model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FormType entity = new Entity.OA_FormType
            {
                ID = model.ID,
                TypeNO = model.TypeNO,
                FormTypeName = model.FormTypeName,
                PinyinCode = model.PinyinCode,
                Stop = model.Stop,
                Creator = model.Creator,
                Remark = model.Remark
            };
            dal.Add(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 修改
        /// </summary>
        public FineOffice.Modules.OA_FormType Update(FineOffice.Modules.OA_FormType model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FormType entity = new Entity.OA_FormType
            {
                ID = model.ID,
                TypeNO = model.TypeNO,
                FormTypeName = model.FormTypeName,
                PinyinCode = model.PinyinCode,
                Creator = model.Creator,
                Stop = model.Stop,
                Remark = model.Remark
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 返回所有
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.OA_FormType> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_FormType> list = (from entity in dal.GetListAll()
                                                         select new FineOffice.Modules.OA_FormType
                                                         {
                                                             ID = entity.ID,
                                                             TypeNO = entity.TypeNO,
                                                             FormTypeName = entity.FormTypeName,
                                                             PinyinCode = entity.PinyinCode,
                                                             Creator = entity.Creator,
                                                             Stop = entity.Stop,
                                                             Remark = entity.Remark
                                                         }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model 
        /// </summary>
        public FineOffice.Modules.OA_FormType GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_FormType, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.OA_FormType model = (from entity in dal.GetListAll()
                                                    select new FineOffice.Modules.OA_FormType
                                                    {
                                                        ID = entity.ID,
                                                        TypeNO = entity.TypeNO,
                                                        FormTypeName = entity.FormTypeName,
                                                        PinyinCode = entity.PinyinCode,
                                                        Creator = entity.Creator,
                                                        Stop = entity.Stop,
                                                        Remark = entity.Remark

                                                    }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        /// <summary>
        /// 删除
        /// </summary>
        public FineOffice.Modules.OA_FormType Delete(FineOffice.Modules.OA_FormType model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_FormType entity = new Entity.OA_FormType
            {
                ID = model.ID
            };
            dal.Delete(entity);
            dal.Dispose();
            return null;

        }

        /// <summary>
        /// 批量删除
        /// </summary>
        public void Delete(List<int> deleteList)
        {
            dal.Initialization();
            dal.Delete(d => deleteList.Contains(d.ID));
            dal.Dispose();
        }

        /// <summary>
        /// sql方式查询
        /// </summary>
        public List<Modules.OA_FormType> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetList(changeTrackingList);
        }

        /// <summary>
        /// 分页sql方式查询
        /// </summary>
        public List<Modules.OA_FormType> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }


        public int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetCount(changeTrackingList);
        }
    }
}
