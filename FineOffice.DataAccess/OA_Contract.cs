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
   public class OA_Contract : BaseDataAccess<FineOffice.Entity.OA_Contract>,IDataAccess.OA_Contract
    {
        public List<Modules.OA_Contract> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append("FROM vw_oa_contract WHERE 1=1 ");
            if (changeTrackingList.Count > 0)
            {
                strSql.Append(" AND ");
                strSql.Append(JointSearcher.BuidSQL(changeTrackingList));
            }
            List<Modules.OA_Contract> list = new List<Modules.OA_Contract>();
            try
            {
                DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
                list = FineOffice.Common.CollectionHelper.ConvertTo<FineOffice.Modules.OA_Contract>(dt) as List<FineOffice.Modules.OA_Contract>;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public List<Modules.OA_Contract> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append("FROM vw_oa_contract WHERE 1=1 ");
            if (changeTrackingList.Count > 0)
            {
                strSql.Append(" AND ");
                strSql.Append(JointSearcher.BuidSQL(changeTrackingList));
            }
            List<Modules.OA_Contract> list = new List<Modules.OA_Contract>();
            try
            {
                DataTable dt = DbHelperSQL.GetList(strSql.ToString(), start, records).Tables[0];
                list = FineOffice.Common.CollectionHelper.ConvertTo<FineOffice.Modules.OA_Contract>(dt) as List<FineOffice.Modules.OA_Contract>;
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
            str.Append("FROM vw_oa_contract WHERE 1=1 ");
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

        public override void Delete(Entity.OA_Contract entity)
        {
            List<CommandInfo> transation = new List<CommandInfo>();
            SqlParameter[] attachmentParameter = { new SqlParameter("@ContractID", SqlDbType.Int, 4) };
            attachmentParameter[0].Value = entity.ID;

            CommandInfo attachmentInfo = new CommandInfo("delete from OA_Attachment where ContractID=@ContractID", attachmentParameter);
            transation.Add(attachmentInfo);

            SqlParameter[] deleteParam = { new SqlParameter("@ID", SqlDbType.Int, 4) };
            deleteParam[0].Value = entity.ID;
            CommandInfo deleteInfo = new CommandInfo("delete from OA_Contract where ID=@ID", deleteParam);
            transation.Add(deleteInfo);
            DbHelperSQL.ExecuteSqlTran(transation);
        }

        public void Delete(List<int> ids)
        {
            List<CommandInfo> transation = new List<CommandInfo>();
            for (int i = 0; i < ids.Count; i++)
            {
              
                SqlParameter[] attachmentParameter = { new SqlParameter("@ContractID", SqlDbType.Int, 4) };
                attachmentParameter[0].Value = ids[i];

                CommandInfo attachmentInfo = new CommandInfo("delete from OA_Attachment where ContractID=@ContractID", attachmentParameter);
                transation.Add(attachmentInfo);

                SqlParameter[] deleteParam = { new SqlParameter("@ID", SqlDbType.Int, 4) };
                deleteParam[0].Value = ids[i];
                CommandInfo deleteInfo = new CommandInfo("delete from OA_Contract where ID=@ID", deleteParam);
                transation.Add(deleteInfo);
            }
            DbHelperSQL.ExecuteSqlTran(transation);
        }       
    }
}
