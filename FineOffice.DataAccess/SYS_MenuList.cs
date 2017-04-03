using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using FineOffice.DataAccess.Helper;

namespace FineOffice.DataAccess
{
    public class SYS_MenuList : Helper.BaseDataAccess<FineOffice.Entity.SYS_MenuList>, IDataAccess.SYS_MenuList
    {
        public override Entity.SYS_MenuList Add(Entity.SYS_MenuList entity)
        {
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                Table<FineOffice.Entity.SYS_MenuList> authority = cxt.GetTable<FineOffice.Entity.SYS_MenuList>();
                FineOffice.Entity.SYS_MenuList temp = authority.OrderByDescending(s => s.ID).FirstOrDefault();
                entity.ID = 1;
                if (temp != null)
                    entity.ID = temp.ID + 1;

                authority.InsertOnSubmit(entity);
                cxt.SubmitChanges();
                return entity;
            }
        }

        /// <summary>
        /// 重写Update方法
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public override Entity.SYS_MenuList Update(Entity.SYS_MenuList entity)
        {
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                try
                {
                    Table<FineOffice.Entity.SYS_MenuList> authority = cxt.GetTable<FineOffice.Entity.SYS_MenuList>();
                    authority.Attach(entity, true);
                    if (entity.ParentID != 0)
                    {
                        Entity.SYS_MenuList temp = authority.Where(d => d.ID == entity.ParentID).FirstOrDefault();
                        if (temp == null)
                            throw new Exception("父级菜单不存在！");
                    }
                    cxt.SubmitChanges(ConflictMode.ContinueOnConflict);
                }
                catch (ChangeConflictException)
                {
                    cxt.Refresh(RefreshMode.KeepChanges, entity);
                    cxt.SubmitChanges(ConflictMode.FailOnFirstConflict);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return entity;
            }
        }

        public override void Delete(Entity.SYS_MenuList entity)
        {
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                Table<FineOffice.Entity.SYS_MenuList> authority = cxt.GetTable<FineOffice.Entity.SYS_MenuList>();
                try
                {
                    authority.DeleteOnSubmit(authority.Where(a=>a.ID==entity.ID).FirstOrDefault());
                    if (authority.Where(d => d.ParentID == entity.ID).Count() > 0)
                        throw new Exception("请先删除其子菜单！");
                    cxt.SubmitChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
