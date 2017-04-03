using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BX.BLL
{
   public class OA_ProjectType
    {
       IDataAccess.OA_ProjectType dal = new DataAccess.OA_ProjectType();

       /// <summary>
       /// 增加工程类别
       /// </summary>
       public BX.Modules.OA_ProjectType Add(BX.Modules.OA_ProjectType model)
       {
           dal.Initialization();
           BX.Entity.OA_ProjectType entity = new Entity.OA_ProjectType
           {
               ID = model.ID,
               TypeNO = model.TypeNO,
               TypeName = model.TypeName,
               PinyinCode = model.PinyinCode,
               Stop = model.Stop,
               Remark = model.Remark
           };
           dal.Add(entity);
           dal.Dispose();
           return null;
       }

       /// <summary>
       /// 修改工程类别
       /// </summary>
       public BX.Modules.OA_ProjectType Update(BX.Modules.OA_ProjectType model)
       {
           dal.Initialization();
           BX.Entity.OA_ProjectType entity = new Entity.OA_ProjectType
           {
               ID = model.ID,
               TypeNO = model.TypeNO,
               TypeName = model.TypeName,
               PinyinCode = model.PinyinCode,
               Stop = model.Stop,
               Remark = model.Remark
           };
           dal.Update(entity);
           dal.Dispose();
           return null;
       }

       /// <summary>
       /// 返回所有工程类别
       /// </summary>
       /// <returns></returns>
       public List<BX.Modules.OA_ProjectType> GetListAll()
       {
           dal.Initialization();
           List<BX.Modules.OA_ProjectType> list = (from entity in dal.GetListAll()
                                                   select new BX.Modules.OA_ProjectType
                                                       {
                                                           ID = entity.ID,
                                                           TypeNO = entity.TypeNO,
                                                           TypeName = entity.TypeName,
                                                           PinyinCode = entity.PinyinCode,
                                                           Stop = entity.Stop,
                                                           Remark = entity.Remark
                                                       }).ToList();
           dal.Dispose();
           return list;
       }

       /// <summary>
       /// 返回一个model 
       /// </summary>
       public BX.Modules.OA_ProjectType GetModel(System.Linq.Expressions.Expression<Func<BX.Modules.OA_ProjectType,bool>> expression)
       {
           dal.Initialization();
           BX.Modules.OA_ProjectType model = (from entity in dal.GetListAll()
                                              select new BX.Modules.OA_ProjectType
                                                  {
                                                      ID = entity.ID,
                                                      TypeNO = entity.TypeNO,
                                                      TypeName = entity.TypeName,
                                                      PinyinCode = entity.PinyinCode,
                                                      Stop = entity.Stop,
                                                      Remark = entity.Remark

                                                  }).Where(expression).FirstOrDefault();
           dal.Dispose();
           return model;
       }

       /// <summary>
       /// 删除一个工程类别
       /// </summary>
       public BX.Modules.OA_ProjectType Delete(BX.Modules.OA_ProjectType model)
       {
           dal.Initialization();
           BX.Entity.OA_ProjectType entity = new Entity.OA_ProjectType
           {
               ID = model.ID
           };
           dal.Delete(entity);
           dal.Dispose();
           return null;

       }
    }
}
