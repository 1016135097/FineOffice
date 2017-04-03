using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.DataAccess.Helper;
using FineOffice.Modules.Helper;
using System.Data;
using System.Data.Linq;

namespace FineOffice.DataAccess
{
    public class OA_FlowRunData : BaseDataAccess<FineOffice.Entity.OA_FlowRunData>, FineOffice.IDataAccess.OA_FlowRunData
    {
        #region OA_FlowRunData 成员

        public List<Modules.OA_FlowRunData> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append("FROM vw_oa_flowrundata WHERE 1=1 ");

            if (changeTrackingList.Count > 0)
            {
                strSql.Append(" AND ");
                strSql.Append(JointSearcher.BuidSQL(changeTrackingList));
            }

            List<Modules.OA_FlowRunData> list = new List<Modules.OA_FlowRunData>();
            try
            {
                DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
                list = FineOffice.Common.CollectionHelper.ConvertTo<FineOffice.Modules.OA_FlowRunData>(dt) as List<FineOffice.Modules.OA_FlowRunData>;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public List<Modules.OA_FlowRunData> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append("FROM vw_oa_flowrundata WHERE 1=1 ");

            if (changeTrackingList.Count > 0)
            {
                strSql.Append(" AND ");
                strSql.Append(JointSearcher.BuidSQL(changeTrackingList));
            }
            List<Modules.OA_FlowRunData> list = new List<Modules.OA_FlowRunData>();
            try
            {
                DataTable dt = DbHelperSQL.GetList(strSql.ToString(), start, records).Tables[0];
                list = FineOffice.Common.CollectionHelper.ConvertTo<FineOffice.Modules.OA_FlowRunData>(dt) as List<FineOffice.Modules.OA_FlowRunData>;
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
            str.Append("FROM vw_oa_flowrundata WHERE 1=1 ");
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

        public override Entity.OA_FlowRunData Add(Entity.OA_FlowRunData entity)
        {
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                try
                {
                    Table<FineOffice.Entity.OA_FlowRunProcess> transmit = cxt.GetTable<FineOffice.Entity.OA_FlowRunProcess>();
                    Table<FineOffice.Entity.OA_FlowRunData> runData = cxt.GetTable<FineOffice.Entity.OA_FlowRunData>();
                    runData.InsertOnSubmit(entity);
                    FineOffice.Entity.OA_FlowRunProcess temp = transmit.Where(t => t.ID == entity.RunProcessID).FirstOrDefault();
                    if (temp.State != 0)
                        throw new Exception("该流程已办理，不能操作！");
                    cxt.SubmitChanges();
                    return entity;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public override Entity.OA_FlowRunData Update(Entity.OA_FlowRunData entity)
        {
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                try
                {
                    Table<FineOffice.Entity.OA_FlowRunProcess> transmit = cxt.GetTable<FineOffice.Entity.OA_FlowRunProcess>();
                    Table<FineOffice.Entity.OA_FlowRunData> runData = cxt.GetTable<FineOffice.Entity.OA_FlowRunData>();
                    runData.Attach(entity, true);
                    FineOffice.Entity.OA_FlowRunProcess temp = transmit.Where(t => t.ID == entity.RunProcessID).FirstOrDefault();
                    if (temp.State != 0)
                        throw new Exception("该流程已办理，不能操作！");
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
                    Table<FineOffice.Entity.OA_FlowRunData> runData = cxt.GetTable<FineOffice.Entity.OA_FlowRunData>();
                    Table<FineOffice.Entity.HD_Attachment> attachment = cxt.GetTable<FineOffice.Entity.HD_Attachment>();
                    List<FineOffice.Entity.HD_Attachment> list = new List<Entity.HD_Attachment>();
                    foreach (int id in ids)
                    {
                        FineOffice.Entity.OA_FlowRunData entity = runData.Where(d => d.ID == id).FirstOrDefault();
                        FineOffice.Entity.HD_Attachment att = new Entity.HD_Attachment
                        {
                            AttachmentData = entity.FormData,
                            CreateTime = entity.CreateTime,
                            FileName = entity.Title,
                            PersonnelID = entity.OA_FlowRunProcess.HR_Personnel.ID,
                            Remark = entity.Remark,
                            XType = entity.XType
                        };
                        list.Add(att);
                    }
                    attachment.InsertAllOnSubmit(list);
                    cxt.SubmitChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        #endregion
    }
}
