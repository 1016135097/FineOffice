using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.DataAccess.Helper;
using System.Data.Linq;

namespace FineOffice.DataAccess
{
    public class CRM_Area : BaseDataAccess<FineOffice.Entity.CRM_Area>, FineOffice.IDataAccess.CRM_Area
    {
        /// <summary>
        /// 其所有子级对象的数组
        /// </summary>
        private List<Entity.CRM_Area> areaList = new List<Entity.CRM_Area>();

        /// <summary>
        /// 返回其所有子对象的数组包括其本身
        /// </summary>
        /// <returns></returns>
        public List<Entity.CRM_Area> GetSubList(Entity.CRM_Area e)
        {
            this.areaList.Add(e);
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                Table<FineOffice.Entity.CRM_Area> area = cxt.GetTable<FineOffice.Entity.CRM_Area>();               
                var tempList = area.Where(a => a.ParentID == e.ID);
                foreach (Entity.CRM_Area a in tempList)
                {
                    this.GetSubList(a);
                }
                return this.areaList;
            }
        }

        /// <summary>
        /// 重写update方法
        /// </summary>
        public override Entity.CRM_Area Update(Entity.CRM_Area entity)
        {
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                Table<FineOffice.Entity.CRM_Area> area = cxt.GetTable<FineOffice.Entity.CRM_Area>();
                try
                {
                    area.Attach(entity, true);
                    if (entity.ParentID != 0)
                    {
                        Entity.CRM_Area temp = area.Where(d => d.ID == entity.ParentID).FirstOrDefault();
                        if (temp == null)
                            throw new Exception("所属地区信息不存在！");
                    }
                    List<Entity.CRM_Area> tempList = this.GetSubList(entity);
                    if (tempList.Where(a => a.ID == entity.ParentID).Count() > 0)
                        throw new Exception("所属地区信息不能是自己或者是其子地区信息！");

                    cxt.SubmitChanges();
                    return entity;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// 重写add方法
        /// </summary>
        public override Entity.CRM_Area Add(Entity.CRM_Area entity)
        {
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                Table<FineOffice.Entity.CRM_Area> area = cxt.GetTable<FineOffice.Entity.CRM_Area>();
                try
                {
                    area.InsertOnSubmit(entity);
                    if (entity.ParentID != 0)
                    {
                        Entity.CRM_Area temp = area.Where(d => d.ID == entity.ParentID).FirstOrDefault();
                        if (temp == null)
                            throw new Exception("所属地区信息不存在！");
                    }
                    cxt.SubmitChanges();
                    return entity;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public override void Delete(Entity.CRM_Area entity)
        {
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                Table<FineOffice.Entity.CRM_Area> area = cxt.GetTable<FineOffice.Entity.CRM_Area>();
                try
                {
                    area.Attach(entity, true);
                    area.DeleteOnSubmit(entity);
                    if (area.Where(d => d.ParentID == entity.ID).Count() > 0)
                        throw new Exception("请先删除其子地区信息！");
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
