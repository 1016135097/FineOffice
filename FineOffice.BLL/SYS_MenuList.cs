using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class SYS_MenuList
    {
        FineOffice.IDataAccess.SYS_MenuList dal = new FineOffice.DataAccess.SYS_MenuList();

        /// <summary>
        /// 增加菜单
        /// </summary>
        public FineOffice.Modules.SYS_MenuList Add(FineOffice.Modules.SYS_MenuList model)
        {
            FineOffice.Entity.SYS_MenuList entity = new Entity.SYS_MenuList
            {
                ID = model.ID,
                Remark = model.Remark,
                 TabID = model.TabID,
                Icon = model.Icon,
                IsModule = model.IsModule,
                IsFuntion = model.IsFuntion,
                Ordering = model.Ordering,
                ParentID = model.ParentID,
                Stop = model.Stop,
                Text = model.Text,
                Version = model.Version,
                SingleClickExpand = model.SingleClickExpand,
                NavigateUrl = model.NavigateUrl,
            };
            dal.Add(entity);
            return this.GetModel(d => d.ID == entity.ID);
        }

        public FineOffice.Modules.SYS_MenuList Update(FineOffice.Modules.SYS_MenuList model)
        {
            FineOffice.Entity.SYS_MenuList entity = new Entity.SYS_MenuList
            {
                ID = model.ID,
                Remark = model.Remark,
                TabID = model.TabID,
                Icon = model.Icon,
                IsModule = model.IsModule,
                IsFuntion = model.IsFuntion,
                Ordering = model.Ordering,
                ParentID = model.ParentID,
                Text = model.Text,
                Stop = model.Stop,
                Version = model.Version,
                SingleClickExpand = model.SingleClickExpand,
                NavigateUrl = model.NavigateUrl,
            };
            dal.Update(entity);
            return this.GetModel(a=>a.ID==model.ID);
        }

        /// <summary>
        /// 返回所有菜单
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.SYS_MenuList> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.SYS_MenuList> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.SYS_MenuList
                 {
                     ID = entity.ID,
                     Remark = entity.Remark,
                     TabID = entity.TabID,
                     Icon = entity.Icon,
                     IsModule = entity.IsModule,
                     IsFuntion = entity.IsFuntion,
                     Ordering = entity.Ordering,
                     ParentID = entity.ParentID,
                     Text = entity.Text,
                     Stop = entity.Stop,
                     Version = entity.Version.ToArray(),
                     SingleClickExpand = entity.SingleClickExpand,
                     NavigateUrl = entity.NavigateUrl,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.SYS_MenuList GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.SYS_MenuList, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.SYS_MenuList model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.SYS_MenuList
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       TabID = entity.TabID,
                       Icon = entity.Icon,
                       IsModule = entity.IsModule,
                       IsFuntion = entity.IsFuntion,
                       Ordering = entity.Ordering,
                       ParentID = entity.ParentID,
                       Text = entity.Text,
                       Stop = entity.Stop,
                       Version = entity.Version.ToArray(),
                       SingleClickExpand = entity.SingleClickExpand,
                       NavigateUrl = entity.NavigateUrl,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        /// <summary>
        /// 返回一个List
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.SYS_MenuList> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.SYS_MenuList, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.SYS_MenuList> list =
                  (from entity in dal.GetTable()
                   select new FineOffice.Modules.SYS_MenuList
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       TabID = entity.TabID,
                       Icon = entity.Icon,
                       IsModule = entity.IsModule,
                       IsFuntion = entity.IsFuntion,
                       Ordering = entity.Ordering,
                       ParentID = entity.ParentID,
                       Text = entity.Text,
                       Stop = entity.Stop,
                       Version = entity.Version.ToArray(),
                       SingleClickExpand = entity.SingleClickExpand,
                       NavigateUrl = entity.NavigateUrl
                   }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        public void Delete(Modules.SYS_MenuList model)
        {
            FineOffice.Entity.SYS_MenuList entity = new Entity.SYS_MenuList
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
    }
}
