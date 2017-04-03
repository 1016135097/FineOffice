using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL
{
    public class OA_Attachment
    {
        FineOffice.IDataAccess.OA_Attachment dal = new FineOffice.DataAccess.OA_Attachment();
        /// <summary>
        /// 增加附件
        /// </summary>
        public FineOffice.Modules.OA_Attachment Add(FineOffice.Modules.OA_Attachment model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_Attachment entity = new Entity.OA_Attachment
            {
                ID = model.ID,
                Remark = model.Remark,
                ContractID = model.ContractID,
                AttachmentData = model.AttachmentData,
                FileName = model.FileName,
                LetterFollowID = model.LetterFollowID,
                PersonnelID = model.PersonnelID,
                RunProcessID = model.RunProcessID,
                Size = model.Size,
                CreateTime = model.CreateTime,
                XType = model.XType,
                XTypeName = model.XTypeName,
            };
            dal.Add(entity);
            model.ID = entity.ID;
            dal.Dispose();
            return model;
        }

        public FineOffice.Modules.OA_Attachment Update(FineOffice.Modules.OA_Attachment model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_Attachment entity = new Entity.OA_Attachment
            {
                ID = model.ID,
                Remark = model.Remark,
                ContractID = model.ContractID,
                AttachmentData = model.AttachmentData,
                FileName = model.FileName,
                PersonnelID = model.PersonnelID,
                RunProcessID = model.RunProcessID,
                Size = model.Size,
                LetterFollowID = model.LetterFollowID,
                CreateTime = model.CreateTime,
                XType = model.XType,
                XTypeName = model.XTypeName,
            };
            dal.Update(entity);
            dal.Dispose();
            return null;
        }

        /// <summary>
        /// 返回所有附件
        /// </summary>
        /// <returns></returns>
        public List<FineOffice.Modules.OA_Attachment> GetListAll()
        {
            dal.Initialization();
            List<FineOffice.Modules.OA_Attachment> list =
                (from entity in dal.GetListAll()
                 select new FineOffice.Modules.OA_Attachment
                 {
                     ID = entity.ID,
                     Remark = entity.Remark,
                     ContractID = entity.ContractID,
                     AttachmentData = entity.AttachmentData.ToArray(),
                     PersonnelID = entity.HR_Personnel.ID,
                     FileName = entity.FileName,
                     RunProcessID = entity.RunProcessID,
                     Size = entity.Size,
                     LetterFollowID = entity.LetterFollowID,
                     CreateTime = entity.CreateTime,
                     XType = entity.XType,
                     XTypeName = entity.XTypeName,
                 }).ToList();
            dal.Dispose();
            return list;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.OA_Attachment GetModel(System.Linq.Expressions.Expression<Func<FineOffice.Modules.OA_Attachment, bool>> expression)
        {
            dal.Initialization();
            FineOffice.Modules.OA_Attachment model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.OA_Attachment
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       ContractID = entity.ContractID,
                       AttachmentData = entity.AttachmentData.ToArray(),
                       PersonnelID = entity.HR_Personnel.ID,
                       FileName = entity.FileName,
                       RunProcessID = entity.RunProcessID,
                       Size = entity.Size,
                       LetterFollowID = entity.LetterFollowID,
                       CreateTime = entity.CreateTime,
                       XType = entity.XType,
                       XTypeName = entity.XTypeName,
                   }).Where(expression).FirstOrDefault();
            dal.Dispose();
            return model;
        }

        /// <summary>
        /// 返回一个model
        /// </summary>
        /// <returns></returns>
        public FineOffice.Modules.OA_Attachment GetModel(int id)
        {
            dal.Initialization();
            FineOffice.Modules.OA_Attachment model =
                  (from entity in dal.GetListAll()
                   select new FineOffice.Modules.OA_Attachment
                   {
                       ID = entity.ID,
                       Remark = entity.Remark,
                       ContractID = entity.ContractID,
                       AttachmentData = entity.AttachmentData.ToArray(),
                       PersonnelID = entity.HR_Personnel.ID,
                       FileName = entity.FileName,
                       RunProcessID = entity.RunProcessID,
                       Size = entity.Size,
                       LetterFollowID = entity.LetterFollowID,
                       CreateTime = entity.CreateTime,
                       XType = entity.XType,
                       XTypeName = entity.XTypeName,
                   }).Where(p => p.ID == id).FirstOrDefault();
            dal.Dispose();
            return model;
        }


        public void Delete(Modules.OA_Attachment model)
        {
            dal.Initialization();
            FineOffice.Entity.OA_Attachment entity = new Entity.OA_Attachment
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
        public List<Modules.OA_Attachment> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetList(changeTrackingList);
        }

        /// <summary>
        /// 分页sql方式查询
        /// </summary>
        public List<Modules.OA_Attachment> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            return dal.GetList(changeTrackingList, start, records);
        }

        public int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            return dal.GetCount(changeTrackingList);
        }

        public void TransferToComAttachment(List<int> ids)
        {
            dal.TransferToComAttachment(ids);
        }
    }
}
