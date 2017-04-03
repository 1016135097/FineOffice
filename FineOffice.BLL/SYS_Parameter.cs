using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class SYS_Parameter
    {
        FineOffice.IDataAccess.SYS_Parameter dal = new FineOffice.DataAccess.SYS_Parameter();
        /// <summary>
        /// 增加部门
        /// </summary>
        public FineOffice.Modules.SYS_Parameter Add(FineOffice.Modules.SYS_Parameter model)
        {
            dal.Initialization();
            FineOffice.Entity.SYS_Parameter entity = new Entity.SYS_Parameter
            {
                ID = model.ID,
                ParameterName = model.ParameterName,
                ParameterValue = model.ParameterValue,
                Sign = model.Sign,
                TableName = model.TableName
            };
            dal.Add(entity);
            dal.Dispose();
            return this.GetModel(d => d.ID == entity.ID);
        }

        public FineOffice.Modules.SYS_Parameter Update(FineOffice.Modules.SYS_Parameter model)
        {
            dal.Initialization();
            FineOffice.Entity.SYS_Parameter entity = new Entity.SYS_Parameter
            {
                ID = model.ID,
                ParameterName = model.ParameterName,
                ParameterValue = model.ParameterValue,
                Sign = model.Sign,
                TableName = model.TableName
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 返回所有部门
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.SYS_Parameter> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.SYS_Parameter> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.SYS_Parameter
                 {
                     ID = entity.ID,
                     ParameterName = entity.ParameterName,
                     ParameterValue = entity.ParameterValue,
                     Sign = entity.Sign,
                     TableName = entity.TableName
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回所有部门
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.SYS_Parameter> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.SYS_Parameter, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.SYS_Parameter> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.SYS_Parameter
                 {
                     ID = entity.ID,
                     ParameterName = entity.ParameterName,
                     ParameterValue = entity.ParameterValue,
                     Sign = entity.Sign,
                     TableName = entity.TableName
                 }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.SYS_Parameter GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.SYS_Parameter, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.SYS_Parameter model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.SYS_Parameter
                   {
                       ID = entity.ID,
                       ParameterName = entity.ParameterName,
                       ParameterValue = entity.ParameterValue,
                       Sign = entity.Sign,
                       TableName = entity.TableName
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.SYS_Parameter model)
        {
            dal.Initialization();
            FineOffice.Entity.SYS_Parameter entity = new Entity.SYS_Parameter
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
    }
}
