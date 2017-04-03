using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class SYS_Role
    {
        FineOffice.IDataAccess.SYS_Role dal = new FineOffice.DataAccess.SYS_Role();

        /// <summary>
        /// 增加角色
        /// </summary>
        public FineOffice.Modules.SYS_Role Add(FineOffice.Modules.SYS_Role model)
        {
            dal.Initialization();
            FineOffice.Entity.SYS_Role entity = new Entity.SYS_Role
            {
                ID = model.ID,
                Remark = model.Remark,
                AuthorityList = model.AuthorityList,
                RoleName = model.RoleName,
                MenuList = model.MenuList,
                Ordering = model.Ordering,
                Stop = model.Stop,
                IsModify = model.IsModify,
            };
            dal.Add(entity);
            dal.Dispose();
            return null;
        }

        public FineOffice.Modules.SYS_Role Update(FineOffice.Modules.SYS_Role model)
        {
            dal.Initialization();
            FineOffice.Entity.SYS_Role entity = new Entity.SYS_Role
            {
                ID = model.ID,
                Remark = model.Remark,
                AuthorityList = model.AuthorityList,
                RoleName = model.RoleName,
                Stop = model.Stop,
                Ordering = model.Ordering,
                MenuList = model.MenuList,
                IsModify = model.IsModify,
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 返回所有角色
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.SYS_Role> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.SYS_Role> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.SYS_Role
                 {
                     ID = entity.ID,
                     Remark = entity.Remark,
                     AuthorityList = entity.AuthorityList,
                     RoleName = entity.RoleName,
                     Stop = entity.Stop,
                     Ordering = entity.Ordering,
                     MenuList = entity.MenuList,
                     IsModify = entity.IsModify,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.SYS_Role GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.SYS_Role, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.SYS_Role model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.SYS_Role
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       AuthorityList = entity.AuthorityList,
                       RoleName = entity.RoleName,
                       Stop = entity.Stop,
                       Ordering = entity.Ordering,
                       MenuList = entity.MenuList,
                       IsModify = entity.IsModify,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        /// <summary>
        /// 返回List
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.SYS_Role> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.SYS_Role, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.SYS_Role> list =
                  (from entity in dal.GetTable()
                   select new FineOffice.Modules.SYS_Role
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       AuthorityList = entity.AuthorityList,
                       RoleName = entity.RoleName,
                       Stop = entity.Stop,
                       Ordering = entity.Ordering,
                       MenuList = entity.MenuList,
                       IsModify = entity.IsModify,
                   }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        public void Delete(Modules.SYS_Role model)
        {
            dal.Initialization();
            FineOffice.Entity.SYS_Role entity = new Entity.SYS_Role
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
        public List<Modules.SYS_Role> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetList(changeTrackingList);
        }

        /// <summary>
        /// 分页sql方式查询
        /// </summary>
        public List<Modules.SYS_Role> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }

        public int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetCount(changeTrackingList);
        }
    }
}
