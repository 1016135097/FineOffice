using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BX.BLL
{
   public partial class Sys_FixedData
    {
       BX.IDataAccess.Sys_FixedData dal = new BX.DataAccess.Sys_FixedData();
       /// <summary>
       /// 增加表单
       /// </summary>
       /// <param name="model"></param>
       /// <returns></returns>
       public BX.Modules.Sys_FixedData Add(BX.Modules.Sys_FixedData model)
       {
           dal.Initialization();
           BX.Entity.Sys_FixedData entity = new Entity.Sys_FixedData
           {
               ID = model.ID,
               DataContent = model.DataContent,
               Sign = model.Sign,
               Remark = model.Remark
           };
           dal.Add(entity);
           dal.Dispose();
           return null;
       }

       public BX.Modules.Sys_FixedData Update(BX.Modules.Sys_FixedData model)
       {
           dal.Initialization();
           BX.Entity.Sys_FixedData entity = new Entity.Sys_FixedData
           {
               ID = model.ID,
               DataContent = model.DataContent,
               Sign = model.Sign,
               Remark = model.Remark
           };
           dal.Update(entity);
           dal.Dispose();
           return null;
       }

       /// <summary>
       /// 返回所有表单
       /// </summary>
       /// <returns></returns>
       public List<BX.Modules.Sys_FixedData> GetListAll()
       {
           dal.Initialization();
           List<BX.Modules.Sys_FixedData> list =
               (from entity in dal.GetListAll()
                select new BX.Modules.Sys_FixedData
                {
                    ID = entity.ID,
                    DataContent = entity.DataContent,
                    Sign = entity.Sign,
                    Remark = entity.Remark
                }).ToList();
           dal.Dispose();
           return list;
       }

       /// <summary>
       /// 返回一个model
       /// </summary>
       /// <returns></returns>
       public BX.Modules.Sys_FixedData GetModel(System.Linq.Expressions.Expression<Func<BX.Modules.Sys_FixedData, bool>> expression)
       {
           dal.Initialization();
           BX.Modules.Sys_FixedData model =
                 (from entity in dal.GetListAll()
                  select new BX.Modules.Sys_FixedData
                  {
                      ID = entity.ID,
                      DataContent = entity.DataContent,
                      Sign = entity.Sign,
                      Remark = entity.Remark
                  }).Where(expression).FirstOrDefault();
           dal.Dispose();
           return model;
       }

       public void Delete(Modules.Sys_FixedData model)
       {
           dal.Initialization();
           BX.Entity.Sys_FixedData entity = new Entity.Sys_FixedData
           {
               ID = model.ID,
           };
           dal.Delete(entity);
           dal.Dispose();
       }
    }
}
