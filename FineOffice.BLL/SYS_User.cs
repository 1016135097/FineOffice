using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class SYS_User
    {
        FineOffice.IDataAccess.SYS_User dal = new FineOffice.DataAccess.SYS_User();

        /// <summary>
        /// 增加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public FineOffice.Modules.SYS_User Add(FineOffice.Modules.SYS_User model)
        {
            dal.Initialization();
            FineOffice.Entity.SYS_User entity = new Entity.SYS_User
            {
                ID = model.ID,
                Remark = model.Remark,
                IsModify = model.IsModify,
                CreateDate = model.CreateDate,
                Password = FineOffice.Common.DEncrypt.DESEncrypt.Encrypt(model.Password),
                PersonnelID = model.PersonnelID,
                UserName = model.UserName,
                Stop = model.Stop,
                RoleList = model.RoleList,
                CheckAuthority = model.CheckAuthority
            };
            dal.Add(entity);
            model.ID = entity.ID;
            dal.Dispose();
            return model;
        }

        public FineOffice.Modules.SYS_User Update(FineOffice.Modules.SYS_User model)
        {
            dal.Initialization();
            FineOffice.Entity.SYS_User entity = new Entity.SYS_User
            {
                ID = model.ID,
                Remark = model.Remark,
                IsModify = model.IsModify,
                CreateDate = model.CreateDate,
                Password = FineOffice.Common.DEncrypt.DESEncrypt.Encrypt(model.Password),
                PersonnelID = model.PersonnelID,
                UserName = model.UserName,
                Stop = model.Stop,
                CheckAuthority = model.CheckAuthority,
                RoleList = model.RoleList
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 返回所有用户
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.SYS_User> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.SYS_User> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.SYS_User
                 {
                     ID = entity.ID,
                     Remark = entity.Remark,
                     IsModify = entity.IsModify,
                     CreateDate = entity.CreateDate,
                     Password = entity.Password,
                     PersonnelID = entity.PersonnelID,
                     UserName = entity.UserName,
                     Stop = entity.Stop,
                     PersonnelNO = entity.HR_Personnel.PersonnelNO,
                     PersonnelName = entity.HR_Personnel.Name,
                     RoleList = entity.RoleList,
                     CheckAuthority = entity.CheckAuthority
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.SYS_User GetModel(Func<FineOffice.Modules.SYS_User, bool> expression)
        {
            dal.Initialization();
            FineOffice.Modules.SYS_User model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.SYS_User
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       IsModify = entity.IsModify,
                       CreateDate = entity.CreateDate,
                       Password = entity.Password,
                       PersonnelID = entity.PersonnelID,
                       UserName = entity.UserName,
                       Stop = entity.Stop,
                       PersonnelNO = entity.HR_Personnel.PersonnelNO,
                       PersonnelName = entity.HR_Personnel.Name,
                       RoleList = entity.RoleList,
                       CheckAuthority = entity.CheckAuthority
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.SYS_User GetModel(int id)
        {
            FineOffice.Modules.SYS_User model = GetModel(u => u.ID == id);
            return model;
        }

        public void Delete(Modules.SYS_User model)
        {
            dal.Initialization();
            FineOffice.Entity.SYS_User entity = new Entity.SYS_User
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
        public List<Modules.SYS_User> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetList(changeTrackingList);
        }

        /// <summary>
        /// 分页sql方式查询
        /// </summary>
        public List<Modules.SYS_User> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }

        public int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetCount(changeTrackingList);
        }
    }
}
