using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class SYS_PageAuthority
    {
        FineOffice.IDataAccess.SYS_PageAuthority dal = new FineOffice.DataAccess.SYS_PageAuthority();

        /// <summary>
        /// 增加菜单
        /// </summary>
        public FineOffice.Modules.SYS_PageAuthority Add(FineOffice.Modules.SYS_PageAuthority model)
        {
            FineOffice.Entity.SYS_PageAuthority entity = new Entity.SYS_PageAuthority
            {
                ID = model.ID,
                Remark = model.Remark,
                MenuID = model.MenuID,
                AuthorityName = model.AuthorityName,
                ControlID = model.ControlID,
                Ordering = model.Ordering,
                Version = model.Version
            };
            dal.Add(entity);
            return this.GetModel(d => d.ID == entity.ID);
        }

        public FineOffice.Modules.SYS_PageAuthority Update(FineOffice.Modules.SYS_PageAuthority model)
        {
            FineOffice.Entity.SYS_PageAuthority entity = new Entity.SYS_PageAuthority
            {
                ID = model.ID,
                Remark = model.Remark,
                MenuID = model.MenuID,
                AuthorityName = model.AuthorityName,
                ControlID = model.ControlID,
                Ordering = model.Ordering,
                Version = model.Version
            };
            dal.Update(entity);
            return this.GetModel(a => a.ID == model.ID);
        }

        /// <summary>
        /// 返回所有菜单
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.SYS_PageAuthority> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.SYS_PageAuthority> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.SYS_PageAuthority
                 {
                     ID = entity.ID,
                     Remark = entity.Remark,
                     MenuID = entity.MenuID,
                     AuthorityName = entity.AuthorityName,
                     ControlID = entity.ControlID,
                     Ordering = entity.Ordering,
                     Version = entity.Version.ToArray(),
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.SYS_PageAuthority GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.SYS_PageAuthority, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.SYS_PageAuthority model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.SYS_PageAuthority
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       MenuID = entity.MenuID,
                       AuthorityName = entity.AuthorityName,
                       ControlID = entity.ControlID,
                       Ordering = entity.Ordering,
                       Text = entity.SYS_MenuList.Text,
                       Version = entity.Version.ToArray(),
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        /// <summary>
        /// 返回一个List
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.SYS_PageAuthority> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.SYS_PageAuthority, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.SYS_PageAuthority> list =
                  (from entity in dal.GetTable()
                   select new FineOffice.Modules.SYS_PageAuthority
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       MenuID = entity.MenuID,
                       AuthorityName = entity.AuthorityName,
                       ControlID = entity.ControlID,
                       Ordering = entity.Ordering,
                       Version = entity.Version.ToArray(),
                   }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        public void Delete(Modules.SYS_PageAuthority model)
        {
            FineOffice.Entity.SYS_PageAuthority entity = new Entity.SYS_PageAuthority
            {
                ID = model.ID,
            };
            dal.Delete(entity);
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
        public List<Modules.SYS_PageAuthority> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetList(changeTrackingList);
        }
    }
}
