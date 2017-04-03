using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class HD_Attachment
    {
        FineOffice.IDataAccess.HD_Attachment dal = new FineOffice.DataAccess.HD_Attachment();

        /// <summary>
        /// 增加附件
        /// </summary>
        public FineOffice.Modules.HD_Attachment Add(FineOffice.Modules.HD_Attachment model)
        {
            dal.Initialization();
            FineOffice.Entity.HD_Attachment entity = new Entity.HD_Attachment
            {
                ID = model.ID,
                Remark = model.Remark,
                FolderID = model.FolderID,
                AttachmentData = model.AttachmentData,
                FileName = model.FileName,
                PersonnelID = model.PersonnelID,
                Size = model.Size,
                IsPublic = model.IsPublic,
                Owner = model.Owner,
                CreateTime = model.CreateTime,
                XType = model.XType,
                XTypeName = model.XTypeName,
                SendID = model.SendID,
                SendTime = model.SendTime,
            };
            dal.Add(entity);
            model.ID = entity.ID;
            dal.Dispose();
            return model;
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        public void Add(List<FineOffice.Modules.HD_Attachment> list)
        {
            List<FineOffice.Entity.HD_Attachment> tempList = (from model in list
                                                              select new FineOffice.Entity.HD_Attachment
                                                              {
                                                                  ID = model.ID,                                                                
                                                                  FolderID = model.FolderID, 
                                                                  IsPublic = model.IsPublic,
                                                                  Owner = model.Owner,
                                                                  SendID = model.SendID,
                                                                  SendTime = model.SendTime,
                                                              }).ToList();
            dal.Add(tempList);           
        }

        public FineOffice.Modules.HD_Attachment Update(FineOffice.Modules.HD_Attachment model)
        {
            dal.Initialization();
            FineOffice.Entity.HD_Attachment entity = new Entity.HD_Attachment
            {
                ID = model.ID,
                Remark = model.Remark,
                FolderID = model.FolderID,
                AttachmentData = model.AttachmentData,
                FileName = model.FileName,
                PersonnelID = model.PersonnelID,
                Size = model.Size,
                CreateTime = model.CreateTime,
                XType = model.XType,
                XTypeName = model.XTypeName,
                IsPublic = model.IsPublic,
                Owner = model.Owner,
                SendID = model.SendID,
                SendTime = model.SendTime,
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 返回所有附件
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.HD_Attachment> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.HD_Attachment> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.HD_Attachment
                 {
                     ID = entity.ID,
                     Remark = entity.Remark,
                     FolderID = entity.FolderID,
                     AttachmentData = entity.AttachmentData.ToArray(),
                     FileName = entity.FileName,
                     PersonnelID = entity.PersonnelID,
                     Size = entity.Size,
                     CreateTime = entity.CreateTime,
                     XType = entity.XType,
                     XTypeName = entity.XTypeName,
                     IsPublic = entity.IsPublic,
                     Owner = entity.Owner,
                     SendID = entity.SendID,
                     SendTime = entity.SendTime,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.HD_Attachment GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.HD_Attachment, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.HD_Attachment model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.HD_Attachment
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       FolderID = entity.FolderID,
                       AttachmentData = entity.AttachmentData.ToArray(),
                       FileName = entity.FileName,
                       PersonnelID = entity.PersonnelID,
                       Size = entity.Size,
                       CreateTime = entity.CreateTime,
                       XType = entity.XType,
                       XTypeName = entity.XTypeName,
                       IsPublic = entity.IsPublic,
                       Owner = entity.Owner,
                       SendID = entity.SendID,
                       SendTime = entity.SendTime,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        /// <summary>
        /// 返回一个数组
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.HD_Attachment> GetList(System.Linq.Expressions.Expression<Func<FineOffice.Modules.HD_Attachment, bool>> expression)
        {
            dal.Initialization();
            List<FineOffice.Modules.HD_Attachment> list =
                  (from entity in dal.GetTable()
                   select new FineOffice.Modules.HD_Attachment
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       FolderID = entity.FolderID,
                       FileName = entity.FileName,
                       PersonnelID = entity.PersonnelID,
                       Size = entity.Size,
                       CreateTime = entity.CreateTime,
                       XType = entity.XType,
                       XTypeName = entity.XTypeName,
                       IsPublic = entity.IsPublic,
                       Owner = entity.Owner,
                       SendID = entity.SendID,
                       SendTime = entity.SendTime,
                   }).Where(expression).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.HD_Attachment GetModel(int id)
        {
            dal.Initialization();
            FineOffice.Modules.HD_Attachment model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.HD_Attachment
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       FolderID = entity.FolderID,
                       AttachmentData = entity.AttachmentData.ToArray(),
                       FileName = entity.FileName,
                       PersonnelID = entity.PersonnelID,
                       Size = entity.Size,
                       CreateTime = entity.CreateTime,
                       XType = entity.XType,
                       XTypeName = entity.XTypeName,
                       IsPublic = entity.IsPublic,
                       Owner = entity.Owner,
                       SendID = entity.SendID,
                       SendTime = entity.SendTime,
                   }).Where(p => p.ID == id).FirstOrDefault();
            dal.Dispose();
            return model;
        }


        public void Delete(Modules.HD_Attachment model)
        {
            dal.Initialization();
            FineOffice.Entity.HD_Attachment entity = new Entity.HD_Attachment
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
        /// <param name="changeTrackingList"></param>
        /// <returns></returns>
        public List<Modules.HD_Attachment> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetList(changeTrackingList);
        }

        /// <summary>
        /// 分页sql方式查询
        /// </summary>
        public List<Modules.HD_Attachment> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }

        public int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetCount(changeTrackingList);
        }

        public void Update(List<Modules.HD_Attachment> list)
        {
            List<FineOffice.Entity.HD_Attachment> tempList = (from model in list
                                                              select new FineOffice.Entity.HD_Attachment
                                                              {
                                                                  ID = model.ID,
                                                                  FolderID = model.FolderID,
                                                              }).ToList();

            dal.Update(tempList);
        }
    }
}
