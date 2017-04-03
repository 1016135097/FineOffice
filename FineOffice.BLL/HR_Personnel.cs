using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FineOffice.BLL
{
    public class HR_Personnel
    {
        FineOffice.IDataAccess.HR_Personnel dal = new FineOffice.DataAccess.HR_Personnel();
        /// <summary>
        /// 增加员工信息
        /// </summary>
        public FineOffice.Modules.HR_Personnel Add(FineOffice.Modules.HR_Personnel model)
        {
            dal.Initialization();
            FineOffice.Entity.HR_Personnel entity = new Entity.HR_Personnel
            {
                ID = model.ID,
                Remark = model.Remark,
                Address = model.Address,
                BankingAccount = model.BankingAccount,
                DateOfBirth = model.DateOfBirth,
                DepartmentID = model.DepartmentID,
                EducationID = model.EducationID,
                Email = model.Email,
                EntryDate = model.EntryDate,
                ExitDate = model.ExitDate,
                HomeTelephone = model.HomeTelephone,
                JobID = model.JobID,
                Linkman = model.Linkman,
                Mobile = model.Mobile,
                Name = model.Name,
                Post = model.Post,
                NativePlace = model.NativePlace,
                PersonnelNO = model.PersonnelNO,
                Sex = model.Sex,
                PinyinCode = model.PinyinCode,
                Stop = model.Stop,
            };
            dal.Add(entity);
            dal.Dispose();
            return null;
        }

        public FineOffice.Modules.HR_Personnel Update(FineOffice.Modules.HR_Personnel model)
        {
            dal.Initialization();
            FineOffice.Entity.HR_Personnel entity = new Entity.HR_Personnel
            {
                ID = model.ID,
                Remark = model.Remark,
                Address = model.Address,
                BankingAccount = model.BankingAccount,
                DateOfBirth = model.DateOfBirth,
                DepartmentID = model.DepartmentID,
                EducationID = model.EducationID,
                Email = model.Email,
                EntryDate = model.EntryDate,
                ExitDate = model.ExitDate,
                HomeTelephone = model.HomeTelephone,
                JobID = model.JobID,
                Linkman = model.Linkman,
                Mobile = model.Mobile,
                Name = model.Name,
                Post = model.Post,
                NativePlace = model.NativePlace,
                PersonnelNO = model.PersonnelNO,
                Sex = model.Sex,
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
        public List<FineOffice.Modules.HR_Personnel> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.HR_Personnel> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.HR_Personnel
                 {
                     ID = entity.ID,
                     Address = entity.Address,
                     Remark = entity.Remark,
                     BankingAccount = entity.BankingAccount,
                     DateOfBirth = entity.DateOfBirth,
                     DepartmentID = entity.DepartmentID,
                     EducationID = entity.EducationID,
                     Email = entity.Email,
                     EntryDate = entity.EntryDate,
                     ExitDate = entity.ExitDate,
                     HomeTelephone = entity.HomeTelephone,
                     JobID = entity.JobID,
                     Linkman = entity.Linkman,
                     Mobile = entity.Mobile,
                     Name = entity.Name,
                     Post = entity.Post,
                     NativePlace = entity.NativePlace,
                     PersonnelNO = entity.PersonnelNO,
                     Sex = entity.Sex,
                     PinyinCode = entity.PinyinCode,
                     Stop = entity.Stop,
                     DepartmentName = entity.HR_Department.DepartmentName,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.HR_Personnel GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.HR_Personnel, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.HR_Personnel model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.HR_Personnel
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       Address = entity.Address,
                       BankingAccount = entity.BankingAccount,
                       DateOfBirth = entity.DateOfBirth,
                       DepartmentID = entity.DepartmentID,
                       EducationID = entity.EducationID,
                       Email = entity.Email,
                       EntryDate = entity.EntryDate,
                       ExitDate = entity.ExitDate,
                       TypeID = entity.EducationID,
                       Education = entity.AM_Kind.Name,
                       HomeTelephone = entity.HomeTelephone,
                       JobID = entity.JobID,
                       Linkman = entity.Linkman,
                       Mobile = entity.Mobile,
                       Name = entity.Name,
                       Post = entity.Post,
                       NativePlace = entity.NativePlace,
                       PersonnelNO = entity.PersonnelNO,
                       Sex = entity.Sex,
                       PinyinCode = entity.PinyinCode,
                       Stop = entity.Stop,
                       DepartmentName = entity.HR_Department.DepartmentName,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.HR_Personnel> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.HR_Personnel, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.HR_Personnel> list =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.HR_Personnel
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       Address = entity.Address,
                       BankingAccount = entity.BankingAccount,
                       DateOfBirth = entity.DateOfBirth,
                       DepartmentID = entity.DepartmentID,
                       EducationID = entity.EducationID,
                       Email = entity.Email,
                       EntryDate = entity.EntryDate,
                       ExitDate = entity.ExitDate,
                       TypeID = entity.EducationID,
                       Education = entity.AM_Kind.Name,
                       HomeTelephone = entity.HomeTelephone,
                       JobID = entity.JobID,
                       Linkman = entity.Linkman,
                       Mobile = entity.Mobile,
                       Name = entity.Name,
                       Post = entity.Post,
                       NativePlace = entity.NativePlace,
                       PersonnelNO = entity.PersonnelNO,
                       Sex = entity.Sex,
                       PinyinCode = entity.PinyinCode,
                       Stop = entity.Stop,
                       DepartmentName = entity.HR_Department.DepartmentName,
                   }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        public void Delete(List<int> deleteList)
        {
            dal.Initialization();
            dal.Delete(d => deleteList.Contains(d.ID));
            dal.Dispose();
        }

        public void Delete(Modules.HR_Personnel model)
        {
            dal.Initialization();
            FineOffice.Entity.HR_Personnel entity = new Entity.HR_Personnel
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
        public List<Modules.HR_Personnel> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
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
        public List<Modules.HR_Personnel> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }


        public int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetCount(changeTrackingList);
        }
    }
}
