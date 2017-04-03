using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BX.DataAccess.Helper;
using System.Data;

namespace BX.DataAccess
{
   public class OA_WorkFlow : Repository<BX.Entity.OA_WorkFlow>,IDataAccess.OA_WorkFlow
    {
        public List<Modules.OA_WorkFlow> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append("FROM Vw_WorkFlow WHERE 1=1 ");

            if (changeTrackingList.Count > 0)
            {
                foreach (Modules.Helper.EntitySearcher searcher in changeTrackingList)
                {
                    strSql.Append("AND ");
                    if (searcher.Operator.Equals("LIKE") || searcher.Operator.Equals("NOT LIKE"))
                        strSql.Append(searcher.Field + " " + searcher.Operator + " '%" + searcher.Content + "%' ");
                    else
                        strSql.Append(searcher.Field + " " + searcher.Operator + " '" + searcher.Content + "' ");
                }
            }
            List<Modules.OA_WorkFlow> list = new List<Modules.OA_WorkFlow>();
            try
            {
                DataTable dt = SqlHelper.Query(strSql.ToString()).Tables[0];
                list = BX.Common.CollectionHelper.ConvertTo<BX.Entity.OA_WorkFlow>(dt) as List<BX.Modules.OA_WorkFlow>;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public List<Modules.OA_WorkFlow> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append("FROM Vw_WorkFlow WHERE 1=1 ");

            if (changeTrackingList.Count > 0)
            {
                foreach (Modules.Helper.EntitySearcher searcher in changeTrackingList)
                {
                    strSql.Append("AND ");
                    if (searcher.Operator.Equals("LIKE") || searcher.Operator.Equals("NOT LIKE"))
                        strSql.Append(searcher.Field + " " + searcher.Operator + " '%" + searcher.Content + "%' ");
                    else
                        strSql.Append(searcher.Field + " " + searcher.Operator + " '" + searcher.Content + "' ");
                }
            }
            List<Modules.OA_WorkFlow> list = new List<Modules.OA_WorkFlow>();
            try
            {
                DataTable dt = SqlHelper.GetList(strSql.ToString(), start, records).Tables[0];
                list = BX.Common.CollectionHelper.ConvertTo<BX.Entity.OA_WorkFlow>(dt) as List<BX.Modules.OA_WorkFlow>;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public List<Modules.OA_WorkFlow> GetList(string strSql, int start, int records)
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT * ");
            str.Append("FROM Vw_WorkFlow WHERE 1=1 ");

            if (strSql.Length > 0)
            {
                str.Append(" AND  ");
                str.Append(strSql);
            }
            List<Modules.OA_WorkFlow> list = new List<Modules.OA_WorkFlow>();
            try
            {
                DataTable dt = SqlHelper.GetList(str.ToString(), start, records).Tables[0];
                list = BX.Common.CollectionHelper.ConvertTo<BX.Modules.OA_WorkFlow>(dt) as List<BX.Modules.OA_WorkFlow>;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public int GetCount(string strSql)
        {
            StringBuilder str = new StringBuilder();
            str.Append("SELECT  records= count(ID) ");
            str.Append("FROM Vw_WorkFlow WHERE 1=1 ");
            int count = 0;

            if (strSql.Length > 0)
            {
                str.Append(" AND  ");
                str.Append(strSql);
            }
            try
            {
                DataTable dt = SqlHelper.Query(str.ToString()).Tables[0];
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
