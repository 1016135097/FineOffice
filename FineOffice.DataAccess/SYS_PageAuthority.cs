using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using FineOffice.DataAccess.Helper;
using FineOffice.Modules.Helper;
using System.Data;

namespace FineOffice.DataAccess
{
    public class SYS_PageAuthority : Helper.BaseDataAccess<FineOffice.Entity.SYS_PageAuthority>, IDataAccess.SYS_PageAuthority
    {
        public override Entity.SYS_PageAuthority Add(Entity.SYS_PageAuthority entity)
        {
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                Table<FineOffice.Entity.SYS_PageAuthority> authority = cxt.GetTable<FineOffice.Entity.SYS_PageAuthority>();
                FineOffice.Entity.SYS_PageAuthority temp = authority.OrderByDescending(s => s.ID).FirstOrDefault();
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
        public override Entity.SYS_PageAuthority Update(Entity.SYS_PageAuthority entity)
        {
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                try
                {
                    Table<FineOffice.Entity.SYS_PageAuthority> authority = cxt.GetTable<FineOffice.Entity.SYS_PageAuthority>();
                    authority.Attach(entity, true);                  
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

        public override void Delete(Entity.SYS_PageAuthority entity)
        {
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                Table<FineOffice.Entity.SYS_PageAuthority> authority = cxt.GetTable<FineOffice.Entity.SYS_PageAuthority>();
                try
                {
                    authority.DeleteOnSubmit(authority.Where(a => a.ID == entity.ID).FirstOrDefault());                  
                    cxt.SubmitChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public List<Modules.SYS_PageAuthority> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append("FROM vw_sys_pageauthority WHERE 1=1 ");
            if (changeTrackingList.Count > 0)
            {
                strSql.Append(" AND ");
                strSql.Append(JointSearcher.BuidSQL(changeTrackingList));
            }
            List<Modules.SYS_PageAuthority> list = new List<Modules.SYS_PageAuthority>();
            try
            {
                DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
                list = FineOffice.Common.CollectionHelper.ConvertTo<FineOffice.Modules.SYS_PageAuthority>(dt) as List<FineOffice.Modules.SYS_PageAuthority>;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }
    }
}
