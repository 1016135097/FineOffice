﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.DataAccess.Helper;
using FineOffice.Modules.Helper;
using System.Data;

namespace FineOffice.DataAccess
{
    public class OA_FormType : BaseDataAccess<FineOffice.Entity.OA_FormType>, FineOffice.IDataAccess.OA_FormType
    {
        public List<Modules.OA_FormType> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append("FROM OA_FormType WHERE 1=1 ");

            if (changeTrackingList.Count > 0)
            {
                strSql.Append(" AND ");
                strSql.Append(JointSearcher.BuidSQL(changeTrackingList));
            }

            List<Modules.OA_FormType> list = new List<Modules.OA_FormType>();
            try
            {
                DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
                list = FineOffice.Common.CollectionHelper.ConvertTo<FineOffice.Entity.OA_FormType>(dt) as List<FineOffice.Modules.OA_FormType>;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        public List<Modules.OA_FormType> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append("FROM OA_FormType WHERE 1=1 ");

            if (changeTrackingList.Count > 0)
            {
                strSql.Append(" AND ");
                strSql.Append(JointSearcher.BuidSQL(changeTrackingList));
            }
            List<Modules.OA_FormType> list = new List<Modules.OA_FormType>();
            try
            {
                DataTable dt = DbHelperSQL.GetList(strSql.ToString(), start, records).Tables[0];
                list = FineOffice.Common.CollectionHelper.ConvertTo<FineOffice.Modules.OA_FormType>(dt) as List<FineOffice.Modules.OA_FormType>;
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
            str.Append("FROM OA_FormType WHERE 1=1 ");
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
    }
}
