using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.DataAccess.Helper;
using System.Data;
using FineOffice.Modules.Helper;
using System.Data.Linq;
using System.Reflection;
using System.Data.SqlClient;

namespace FineOffice.DataAccess
{
    public class OA_Flow : BaseDataAccess<FineOffice.Entity.OA_Flow>, IDataAccess.OA_Flow
    {
        /// <summary>
        /// 更改流程明细列表
        /// </summary>
        public FineOffice.Entity.OA_Flow UpdateProcess(FineOffice.Entity.OA_Flow entity)
        {
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                Table<FineOffice.Entity.OA_Flow> flow = cxt.GetTable<FineOffice.Entity.OA_Flow>();
                Table<FineOffice.Entity.OA_FlowProcess> flowProcess = cxt.GetTable<FineOffice.Entity.OA_FlowProcess>();

                try
                {
                    flow.Attach(entity, true);
                    flowProcess.AttachAll(entity.OA_FlowProcess, true);//以当前实体更新数据                    
                    flowProcess.DeleteAllOnSubmit(flowProcess.Where(f => f.FlowID == entity.ID && !(from e in entity.OA_FlowProcess select e.ID).Contains(f.ID)));//删除数据                   
                    cxt.SubmitChanges(ConflictMode.ContinueOnConflict); //乐观并发
                }
                catch (ChangeConflictException)
                {
                    foreach (ObjectChangeConflict occ in cxt.ChangeConflicts)
                    {
                        FineOffice.Entity.OA_FlowProcess newDetail = occ.Object as FineOffice.Entity.OA_FlowProcess;
                        if (occ.IsDeleted)
                        {
                            if (newDetail != null)
                                flowProcess.InsertOnSubmit(Changes(newDetail));
                        }
                        else
                        {
                            foreach (MemberChangeConflict mc in occ.MemberConflicts)
                            {
                                MemberInfo mi = mc.Member;
                                string memberName = mi.Name;
                                if (memberName == "ProcessName"
                                    || memberName == "Remark" || memberName == "Next")
                                    mc.Resolve(RefreshMode.KeepCurrentValues);
                                else
                                    mc.Resolve(RefreshMode.OverwriteCurrentValues);
                            }
                        }
                        occ.Resolve();
                    }
                    cxt.SubmitChanges(ConflictMode.FailOnFirstConflict);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return flow.Where(f => f.ID == entity.ID).FirstOrDefault();
            }
        }

        private FineOffice.Entity.OA_FlowProcess Changes(FineOffice.Entity.OA_FlowProcess temp)
        {
            return new FineOffice.Entity.OA_FlowProcess
                   {
                       TimeLimit = temp.TimeLimit,
                       Remind = temp.Remind,
                       AllowGoBack = temp.AllowGoBack,
                       AllowRefuse = temp.AllowRefuse,
                       AllowSync = temp.AllowSync,
                       Feedback = temp.Feedback,
                       FlowID = temp.FlowID,
                       ID = temp.ID,
                       IsEnd = temp.IsEnd,
                       IsStart = temp.IsStart,
                       MailTo = temp.MailTo,
                       MessageTo = temp.MessageTo,
                       Next = temp.Next,
                       Version = temp.Version,
                       ProcessDepartment = temp.ProcessDepartment,
                       ProcessPersonnel = temp.ProcessPersonnel,
                       ProcessName = temp.ProcessName,
                       Remark = temp.Remark,
                       ProcessRole = temp.ProcessRole,
                       Serial = temp.Serial,
                       TopDefault = temp.TopDefault
                   };
        }

        public List<Modules.OA_Flow> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append("FROM Vw_OA_Flow WHERE 1=1 ");
            if (changeTrackingList.Count > 0)
            {
                strSql.Append(" AND ");
                strSql.Append(JointSearcher.BuidSQL(changeTrackingList));
            }
            List<Modules.OA_Flow> list = new List<Modules.OA_Flow>();
            try
            {
                DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
                list = FineOffice.Common.CollectionHelper.ConvertTo<FineOffice.Entity.OA_Flow>(dt) as List<FineOffice.Modules.OA_Flow>;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public List<Modules.OA_Flow> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append("FROM Vw_OA_Flow WHERE 1=1 ");

            if (changeTrackingList.Count > 0)
            {
                strSql.Append(" AND ");
                strSql.Append(JointSearcher.BuidSQL(changeTrackingList));
            }

            List<Modules.OA_Flow> list = new List<Modules.OA_Flow>();
            try
            {
                DataTable dt = DbHelperSQL.GetList(strSql.ToString(), start, records).Tables[0];
                list = FineOffice.Common.CollectionHelper.ConvertTo<FineOffice.Modules.OA_Flow>(dt) as List<FineOffice.Modules.OA_Flow>;
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
            str.Append("FROM Vw_OA_Flow WHERE 1=1 ");
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

        public override void Delete(Entity.OA_Flow entity)
        {
            List<CommandInfo> transation = new List<CommandInfo>();
            SqlParameter[] flowAuthority = { new SqlParameter("@FlowID", SqlDbType.Int, 4) };
            flowAuthority[0].Value = entity.ID;

            CommandInfo flowAuthorityInfo = new CommandInfo("delete from OA_FlowAuthority where FlowID=@FlowID", flowAuthority);
            transation.Add(flowAuthorityInfo);

            SqlParameter[] deleteParam = { new SqlParameter("@ID", SqlDbType.Int, 4) };
            deleteParam[0].Value = entity.ID;
            CommandInfo deleteInfo = new CommandInfo("delete from OA_Flow where ID=@ID", deleteParam);
            transation.Add(deleteInfo);
            DbHelperSQL.ExecuteSqlTran(transation);
        }

        public void Delete(List<int> ids)
        {
            List<CommandInfo> transation = new List<CommandInfo>();
            for (int i = 0; i < ids.Count; i++)
            {               
                SqlParameter[] flowAuthority = { new SqlParameter("@FlowID", SqlDbType.Int, 4) };
                flowAuthority[0].Value = ids[i];

                CommandInfo flowAuthorityInfo = new CommandInfo("delete from OA_FlowAuthority where FlowID=@FlowID", flowAuthority);
                transation.Add(flowAuthorityInfo);

                SqlParameter[] deleteParam = { new SqlParameter("@ID", SqlDbType.Int, 4) };
                deleteParam[0].Value = ids[i];
                CommandInfo deleteInfo = new CommandInfo("delete from OA_Flow where ID=@ID", deleteParam);
                transation.Add(deleteInfo);                
            }
            DbHelperSQL.ExecuteSqlTran(transation);
        }

        public override Entity.OA_Flow Update(Entity.OA_Flow entity)
        {
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                Table<FineOffice.Entity.OA_Flow> flow = cxt.GetTable<FineOffice.Entity.OA_Flow>();
                Table<FineOffice.Entity.OA_FlowAuthority> flowAuthority = cxt.GetTable<FineOffice.Entity.OA_FlowAuthority>();

                try
                {
                    flow.Attach(entity, true);
                    flowAuthority.DeleteAllOnSubmit(flowAuthority.Where(f => f.FlowID == entity.ID));
                    flowAuthority.InsertAllOnSubmit(entity.OA_FlowAuthority);
                    cxt.SubmitChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return flow.Where(f => f.ID == entity.ID).FirstOrDefault();
            }
        }
    }
}
