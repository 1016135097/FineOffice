using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class HR_Job
    {
        FineOffice.IDataAccess.HR_Job dal = new FineOffice.DataAccess.HR_Job(); 
        /// <summary>
        /// 增加分支机构
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FineOffice.Modules.HR_Job Add(FineOffice.Modules.HR_Job model)
        {
            dal.Initialization();
            FineOffice.Entity.HR_Job entity = new Entity.HR_Job
            {
                ID = model.ID,
                Remark = model.Remark,
                Job = model.Job,
                JobNO = model.JobNO,
                PinyinCode = model.PinyinCode,
                Stop = model.Stop,
            };
            dal.Add(entity);
            dal.Dispose();
            return this.GetModel(d=>d.ID==entity.ID);
        }

        public FineOffice.Modules.HR_Job Update(FineOffice.Modules.HR_Job model)
        {
            dal.Initialization();
            FineOffice.Entity.HR_Job entity = new Entity.HR_Job
            {
                ID = model.ID,
                Remark = model.Remark,
                Job = model.Job,
                JobNO = model.JobNO,
                PinyinCode = model.PinyinCode,
                Stop = model.Stop,
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 返回所有分支机构
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.HR_Job> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.HR_Job> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.HR_Job
                 {
                     ID = entity.ID,
                     Remark = entity.Remark,
                     Job = entity.Job,
                     JobNO = entity.JobNO,
                     PinyinCode = entity.PinyinCode,
                     Stop = entity.Stop,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.HR_Job GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.HR_Job, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.HR_Job model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.HR_Job
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       Job = entity.Job,
                       JobNO = entity.JobNO,
                       PinyinCode = entity.PinyinCode,
                       Stop = entity.Stop,

                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        public void Delete(Modules.HR_Job model)
        {
            dal.Initialization();
            FineOffice.Entity.HR_Job entity = new Entity.HR_Job
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
        public List<Modules.HR_Job> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetList(changeTrackingList);
        }

        /// <summary>
        /// 分页sql方式查询
        /// </summary>
        public List<Modules.HR_Job> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }


        public int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetCount(changeTrackingList);
        }
    }
}
