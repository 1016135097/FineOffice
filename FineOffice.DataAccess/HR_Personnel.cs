﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.DataAccess.Helper;
using System.Data;
using FineOffice.Modules.Helper;

namespace FineOffice.DataAccess
{
    public class HR_Personnel : BaseDataAccess<FineOffice.Entity.HR_Personnel>, FineOffice.IDataAccess.HR_Personnel
    {
        public List<Modules.HR_Personnel> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            StringBuilder strSql = new StringBuilder(); 
            strSql.Append("SELECT * FROM vw_hr_personnel WHERE 1=1 ");

            if (changeTrackingList.Count > 0)
            {
                strSql.Append(" AND ");
                strSql.Append(JointSearcher.BuidSQL(changeTrackingList));
            }

            List<Modules.HR_Personnel> list = new List<Modules.HR_Personnel>();
            try
            {
                DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
                list = FineOffice.Common.CollectionHelper.ConvertTo<FineOffice.Modules.HR_Personnel>(dt) as List<FineOffice.Modules.HR_Personnel>;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }


        public List<Modules.HR_Personnel> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM vw_hr_personnel WHERE 1=1 ");

            if (changeTrackingList.Count > 0)
            {
                strSql.Append(" AND ");
                strSql.Append(JointSearcher.BuidSQL(changeTrackingList));
            }
            List<Modules.HR_Personnel> list = new List<Modules.HR_Personnel>();
            try
            {
                DataTable dt = DbHelperSQL.GetList(strSql.ToString(), start, records).Tables[0];
                list = FineOffice.Common.CollectionHelper.ConvertTo<FineOffice.Modules.HR_Personnel>(dt) as List<FineOffice.Modules.HR_Personnel>;
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
            str.Append("FROM vw_hr_personnel WHERE 1=1 ");
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