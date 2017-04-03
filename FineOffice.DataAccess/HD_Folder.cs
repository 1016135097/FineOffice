using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.DataAccess.Helper;
using System.Data.Linq;

namespace FineOffice.DataAccess
{
    public class HD_Folder : BaseDataAccess<FineOffice.Entity.HD_Folder>, FineOffice.IDataAccess.HD_Folder
    {
        /// <summary>
        /// 其所有子级对象的数组
        /// </summary>
        private List<Entity.HD_Folder> folderList = new List<Entity.HD_Folder>();

        /// <summary>
        /// 返回其所有子对象的数组包括其本身
        /// </summary>
        public List<Entity.HD_Folder> GetSubList(Entity.HD_Folder e)
        {
            this.folderList.Add(e);
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                Table<FineOffice.Entity.HD_Folder> folder = cxt.GetTable<FineOffice.Entity.HD_Folder>();
                var tempList = folder.Where(a => a.ParentID == e.ID);
                foreach (Entity.HD_Folder a in tempList)
                {
                    this.GetSubList(a);
                }
                return this.folderList;
            }
        }

        public override void Delete(Entity.HD_Folder entity)
        {
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                Table<FineOffice.Entity.HD_Folder> folder = cxt.GetTable<FineOffice.Entity.HD_Folder>();
                try
                {
                    folder.Attach(entity, true);
                    folder.DeleteOnSubmit(entity);
                    if (folder.Where(d => d.ParentID == entity.ID).Count() > 0)
                        throw new Exception("请先删除其子目录！");
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
