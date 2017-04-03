using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.DataAccess.Helper;
using System.Data;
using FineOffice.Modules.Helper;
using System.Data.Linq;

namespace FineOffice.DataAccess
{
    public class OA_Attachment : BaseDataAccess<FineOffice.Entity.OA_Attachment>, IDataAccess.OA_Attachment
    {
        public List<Modules.OA_Attachment> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM vw_oa_attachment WHERE 1=1 ");

            if (changeTrackingList.Count > 0)
            {
                strSql.Append(" AND ");
                strSql.Append(JointSearcher.BuidSQL(changeTrackingList));
            }

            List<Modules.OA_Attachment> list = new List<Modules.OA_Attachment>();
            try
            {
                DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
                list = FineOffice.Common.CollectionHelper.ConvertTo<FineOffice.Modules.OA_Attachment>(dt) as List<FineOffice.Modules.OA_Attachment>;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public List<Modules.OA_Attachment> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM vw_oa_attachment WHERE 1=1 ");

            if (changeTrackingList.Count > 0)
            {
                strSql.Append(" AND ");
                strSql.Append(JointSearcher.BuidSQL(changeTrackingList));
            }

            List<Modules.OA_Attachment> list = new List<Modules.OA_Attachment>();
            try
            {
                DataTable dt = DbHelperSQL.GetList(strSql.ToString(), start, records).Tables[0];
                list = FineOffice.Common.CollectionHelper.ConvertTo<FineOffice.Modules.OA_Attachment>(dt) as List<FineOffice.Modules.OA_Attachment>;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public int GetCount(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT  records= count(ID) ");
            str.Append("FROM vw_oa_attachment WHERE 1=1 ");
            int count = 0;

            if (changeTrackingList.Count > 0)
            {
                str.Append(" AND ");
                str.Append(JointSearcher.BuidSQL(changeTrackingList));
            }
            try
            {
                DataTable dt = DbHelperSQL.Query(str.ToString()).Tables[0];
                count = int.Parse(dt.Rows[0]["records"].ToString());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return count;
        }

        public override Entity.OA_Attachment Add(Entity.OA_Attachment entity)
        {
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                try
                {
                    Table<FineOffice.Entity.OA_FlowRunProcess> runProcess = cxt.GetTable<FineOffice.Entity.OA_FlowRunProcess>();
                    Table<FineOffice.Entity.OA_Attachment> attachment = cxt.GetTable<FineOffice.Entity.OA_Attachment>();
                    attachment.InsertOnSubmit(entity);
                    if (entity.RunProcessID != null)
                    {
                        FineOffice.Entity.OA_FlowRunProcess temp = runProcess.Where(t => t.ID == entity.RunProcessID).FirstOrDefault();
                        if (temp.State != 0)
                            throw new Exception("该流程已办理，不能操作！");
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

        public override Entity.OA_Attachment Update(Entity.OA_Attachment entity)
        {
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                try
                {
                    Table<FineOffice.Entity.OA_FlowRunProcess> transmit = cxt.GetTable<FineOffice.Entity.OA_FlowRunProcess>();
                    Table<FineOffice.Entity.OA_Attachment> attachment = cxt.GetTable<FineOffice.Entity.OA_Attachment>();
                    attachment.Attach(entity, true);
                    if (entity.RunProcessID != null)
                    {
                        FineOffice.Entity.OA_FlowRunProcess temp = transmit.Where(t => t.ID == entity.RunProcessID).FirstOrDefault();
                        if (temp.State != 0)
                            throw new Exception("该流程已办理，不能操作！");
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

        public void TransferToComAttachment(List<int> ids)
        {
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                try
                {
                    Table<FineOffice.Entity.OA_Attachment> attachment = cxt.GetTable<FineOffice.Entity.OA_Attachment>();
                    Table<FineOffice.Entity.HD_Attachment> comAtt = cxt.GetTable<FineOffice.Entity.HD_Attachment>();
                    List<FineOffice.Entity.HD_Attachment> list = new List<Entity.HD_Attachment>();
                    foreach (int id in ids)
                    {
                        FineOffice.Entity.OA_Attachment entity = attachment.Where(d => d.ID == id).FirstOrDefault();
                        FineOffice.Entity.HD_Attachment att = new Entity.HD_Attachment
                        {
                            AttachmentData = entity.AttachmentData,
                            CreateTime = entity.CreateTime,
                            FileName = entity.FileName,
                            PersonnelID = entity.HR_Personnel.ID,
                            Remark = entity.Remark,
                            XType = entity.XType,
                            XTypeName = entity.XTypeName,
                            Size = entity.Size
                        };
                        list.Add(att);
                    }
                    comAtt.InsertAllOnSubmit(list);
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
