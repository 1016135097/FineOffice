using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class HD_Folder
    {
        FineOffice.IDataAccess.HD_Folder dal = new FineOffice.DataAccess.HD_Folder();
        /// <summary>
        /// 增加部门
        /// </summary>
        public FineOffice.Modules.HD_Folder Add(FineOffice.Modules.HD_Folder model)
        {
            dal.Initialization();
            FineOffice.Entity.HD_Folder entity = new Entity.HD_Folder
            {
                ID = model.ID,
                FolderName = model.FolderName,
                ParentID = model.ParentID,
                IsPublic = model.IsPublic,
                PersonnelID = model.PersonnelID,
                Remark = model.Remark,
            };
            dal.Add(entity);
            dal.Dispose();
            return this.GetModel(d => d.ID == entity.ID);
        }

        public FineOffice.Modules.HD_Folder Update(FineOffice.Modules.HD_Folder model)
        {
            dal.Initialization();
            FineOffice.Entity.HD_Folder entity = new Entity.HD_Folder
            {
                ID = model.ID,
                FolderName = model.FolderName,
                ParentID = model.ParentID,
                IsPublic = model.IsPublic,
                PersonnelID = model.PersonnelID,
                Remark = model.Remark,
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 返回所有部门
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.HD_Folder> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.HD_Folder> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.HD_Folder
                 {
                     ID = entity.ID,
                     FolderName = entity.FolderName,
                     ParentID = entity.ParentID,
                     IsPublic = entity.IsPublic,
                     PersonnelID = entity.PersonnelID,
                     Remark = entity.Remark,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回所有
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.HD_Folder> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.HD_Folder, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.HD_Folder> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.HD_Folder
                 {
                     ID = entity.ID,
                     FolderName = entity.FolderName,
                     ParentID = entity.ParentID,
                     Remark = entity.Remark,
                     PersonnelID = entity.PersonnelID,
                     IsPublic = entity.IsPublic,
                 }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.HD_Folder GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.HD_Folder, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.HD_Folder model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.HD_Folder
                   {
                       ID = entity.ID,
                       FolderName = entity.FolderName,
                       ParentID = entity.ParentID,
                       Remark = entity.Remark,
                       PersonnelID = entity.PersonnelID,
                       IsPublic = entity.IsPublic,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        /// <summary>
        /// 删除Model
        /// </summary>
        /// <param name="model"></param>
        public void Delete(Modules.HD_Folder model)
        {
            dal.Initialization();
            FineOffice.Entity.HD_Folder entity = new Entity.HD_Folder
            {
                ID = model.ID,
            };
            dal.Delete(entity);
            dal.Dispose();
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="deleteList"></param>
        public void Delete(List<int> deleteList)
        {
            dal.Initialization();
            dal.Delete(d => deleteList.Contains(d.ID));
            dal.Dispose();
        }

        /// <summary>
        /// 返回所有子对象的数组(包括本身)
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public List<Modules.HD_Folder> GetSubList(Modules.HD_Folder a)
        {
            List<Entity.HD_Folder> tempList = dal.GetSubList(new Entity.HD_Folder { ID = a.ID });
            List<FineOffice.Modules.HD_Folder> list =
           (from entity in tempList
            select new FineOffice.Modules.HD_Folder
            {
                ID = entity.ID,
                FolderName = entity.FolderName,
                ParentID = entity.ParentID,
                PersonnelID = entity.PersonnelID,
                IsPublic = entity.IsPublic,
                Remark = entity.Remark,
            }).ToList();
            return list;
        }
    }
}