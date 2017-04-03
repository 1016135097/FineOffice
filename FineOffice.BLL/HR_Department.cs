using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class HR_Department
    {
        FineOffice.IDataAccess.HR_Department dal = new FineOffice.DataAccess.HR_Department();
        /// <summary>
        /// 增加部门
        /// </summary>
        public FineOffice.Modules.HR_Department Add(FineOffice.Modules.HR_Department model)
        {
            dal.Initialization();
            FineOffice.Entity.HR_Department entity = new Entity.HR_Department
            {
                ID = model.ID,
                Remark = model.Remark,
                DepartmentName = model.DepartmentName,
                DepartmentNO = model.DepartmentNO,
                PinyinCode = model.PinyinCode,
                Stop = model.Stop,
            };
            dal.Add(entity);
            dal.Dispose();
            return this.GetModel(d=>d.ID==entity.ID);
        }

        public FineOffice.Modules.HR_Department Update(FineOffice.Modules.HR_Department model)
        {
            dal.Initialization();
            FineOffice.Entity.HR_Department entity = new Entity.HR_Department
            {
                ID = model.ID,
                Remark = model.Remark,
                DepartmentName = model.DepartmentName,
                DepartmentNO = model.DepartmentNO,
                PinyinCode = model.PinyinCode,
                Stop = model.Stop,
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 返回所有部门
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.HR_Department> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.HR_Department> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.HR_Department
                 {
                     ID = entity.ID,
                     Remark = entity.Remark,
                     DepartmentName = entity.DepartmentName,
                     DepartmentNO = entity.DepartmentNO,
                     PinyinCode = entity.PinyinCode,
                     Stop = entity.Stop.Value,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.HR_Department GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.HR_Department, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.HR_Department model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.HR_Department
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       DepartmentName = entity.DepartmentName,
                       DepartmentNO = entity.DepartmentNO,
                       PinyinCode = entity.PinyinCode,
                       Stop = entity.Stop.Value,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        /// <summary>
        /// 返回一个List
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.HR_Department> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.HR_Department, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.HR_Department> list =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.HR_Department
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       DepartmentName = entity.DepartmentName,
                       DepartmentNO = entity.DepartmentNO,
                       PinyinCode = entity.PinyinCode,
                       Stop = entity.Stop.Value,
                   }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        public void Delete(Modules.HR_Department model)
        {
            dal.Initialization();
            FineOffice.Entity.HR_Department entity = new Entity.HR_Department
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
        public List<Modules.HR_Department> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
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
        public List<Modules.HR_Department> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }


        public int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetCount(changeTrackingList);
        }
    }
}
