using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.DataAccess.Helper;
using System.Data;
using FineOffice.Modules.Helper;

namespace FineOffice.DataAccess
{
    public class OA_FlowAuthority : BaseDataAccess<FineOffice.Entity.OA_FlowAuthority>, IDataAccess.OA_FlowAuthority
    {
        public List<Modules.OA_Flow> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from vw_oa_flow where ID in ( select distinct FlowID from vw_oa_flowauthority where 1=1 ");
            if (changeTrackingList.Count > 0)
            {
                strSql.Append(" AND ");
                strSql.Append(JointSearcher.BuidSQL(changeTrackingList));
            }
            strSql.Append(" ) ");

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
            strSql.Append("select * from vw_oa_flow where ID in ( select distinct FlowID from vw_oa_flowauthority where 1=1 "); 
            if (changeTrackingList.Count > 0)
            {
                strSql.Append(" AND ");
                strSql.Append(JointSearcher.BuidSQL(changeTrackingList));
            }
            strSql.Append(" ) ");

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
            str.Append("SELECT  records= count(*)  ");
            str.Append("FROM ");
            str.Append("(select distinct FlowID  FROM vw_oa_flowauthority WHERE 1=1 ");

            if (changeTrackingList.Count > 0)
            {
                str.Append(" AND ");
                str.Append(JointSearcher.BuidSQL(changeTrackingList));
            }

            str.Append(" ) as t");
            int count = 0;           
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
    }
}
