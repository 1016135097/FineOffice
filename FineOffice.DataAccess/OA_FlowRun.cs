using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.DataAccess.Helper;
using System.Data;
using FineOffice.Modules.Helper;
using System.Data.SqlClient;
using System.Data.Linq;

namespace FineOffice.DataAccess
{
    public class OA_FlowRun : BaseDataAccess<FineOffice.Entity.OA_FlowRun>, IDataAccess.OA_FlowRun
    {
        public List<Modules.OA_FlowRun> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append("FROM vw_oa_flowrun WHERE 1=1 ");

            if (changeTrackingList.Count > 0)
            {
                strSql.Append(" AND ");
                strSql.Append(JointSearcher.BuidSQL(changeTrackingList));
            }

            List<Modules.OA_FlowRun> list = new List<Modules.OA_FlowRun>();
            try
            {
                DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
                list = FineOffice.Common.CollectionHelper.ConvertTo<FineOffice.Modules.OA_FlowRun>(dt) as List<FineOffice.Modules.OA_FlowRun>;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public List<Modules.OA_FlowRun> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append("FROM vw_oa_flowrun WHERE 1=1 ");

            if (changeTrackingList.Count > 0)
            {
                strSql.Append(" AND ");
                strSql.Append(JointSearcher.BuidSQL(changeTrackingList));
            }
            List<Modules.OA_FlowRun> list = new List<Modules.OA_FlowRun>();
            try
            {
                DataTable dt = DbHelperSQL.GetList(strSql.ToString(), start, records).Tables[0];
                list = FineOffice.Common.CollectionHelper.ConvertTo<FineOffice.Modules.OA_FlowRun>(dt) as List<FineOffice.Modules.OA_FlowRun>;
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
            str.Append("FROM vw_oa_flowrun WHERE 1=1 ");
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

        public override void Delete(Entity.OA_FlowRun entity)
        {
            this.Initialization();
            Entity.OA_FlowRun flowRun = this.Get(f => f.ID == entity.ID);
            List<Entity.OA_FlowRunProcess> runList = flowRun.OA_FlowRunProcess.ToList();

            List<CommandInfo> transation = new List<CommandInfo>();
            foreach (Entity.OA_FlowRunProcess p in runList)
            {
                SqlParameter[] transmit = { new SqlParameter("@RunProcessID", SqlDbType.Int, 4) };
                transmit[0].Value = p.ID;
                CommandInfo transmitInfo = new CommandInfo("delete from OA_FlowRunTransmit where RunProcessID=@RunProcessID", transmit);
                transation.Add(transmitInfo);

                SqlParameter[] attachment = { new SqlParameter("@RunProcessID", SqlDbType.Int, 4) };
                attachment[0].Value = p.ID;
                CommandInfo attachmentInfo = new CommandInfo("delete from OA_Attachment where RunProcessID=@RunProcessID", attachment);
                transation.Add(attachmentInfo);

                SqlParameter[] flowRunData = { new SqlParameter("@RunProcessID", SqlDbType.Int, 4) };
                flowRunData[0].Value = p.ID;
                CommandInfo flowRunDataInfo = new CommandInfo("delete from OA_FlowRunData where RunProcessID=@RunProcessID", flowRunData);
                transation.Add(flowRunDataInfo);
            }
            this.Dispose();

            SqlParameter[] runProcess = { new SqlParameter("@RunID", SqlDbType.Int, 4) };
            runProcess[0].Value = flowRun.ID;
            CommandInfo runProcessInfo = new CommandInfo("delete from OA_FlowRunProcess where RunID=@RunID", runProcess);
            transation.Add(runProcessInfo);

            SqlParameter[] flowRunParmeter = { new SqlParameter("@ID", SqlDbType.Int, 4) };
            flowRunParmeter[0].Value = entity.ID;
            CommandInfo flowRunInfo = new CommandInfo("delete from OA_FlowRun where ID=@ID", flowRunParmeter);
            transation.Add(flowRunInfo);          

            DbHelperSQL.ExecuteSqlTran(transation);
        }
    }
}
