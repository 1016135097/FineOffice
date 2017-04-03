using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.DataAccess.Helper;
using FineOffice.Modules.Helper;
using System.Data;
using System.Data.SqlClient;

namespace FineOffice.DataAccess
{
    public class HD_Attachment : BaseDataAccess<FineOffice.Entity.HD_Attachment>, IDataAccess.HD_Attachment
    {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="changeTrackingList"></param>
        /// <returns></returns>
        public List<Modules.HD_Attachment> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM vw_hd_attachment WHERE 1=1 ");

            if (changeTrackingList.Count > 0)
            {
                strSql.Append(" AND ");
                strSql.Append(JointSearcher.BuidSQL(changeTrackingList));
            }

            List<Modules.HD_Attachment> list = new List<Modules.HD_Attachment>();
            try
            {
                DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
                list = FineOffice.Common.CollectionHelper.ConvertTo<FineOffice.Modules.HD_Attachment>(dt) as List<FineOffice.Modules.HD_Attachment>;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return list;
        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="changeTrackingList"></param>
        /// <param name="start"></param>
        /// <param name="records"></param>
        /// <returns></returns>
        public List<Modules.HD_Attachment> GetList(Modules.Helper.ChangeTrackingList<Modules.Helper.EntitySearcher> changeTrackingList, int start, int records)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM vw_hd_attachment WHERE 1=1 ");

            if (changeTrackingList.Count > 0)
            {
                strSql.Append(" AND ");
                strSql.Append(JointSearcher.BuidSQL(changeTrackingList));
            }

            List<Modules.HD_Attachment> list = new List<Modules.HD_Attachment>();
            try
            {
                DataTable dt = DbHelperSQL.GetList(strSql.ToString(), start, records).Tables[0];
                list = FineOffice.Common.CollectionHelper.ConvertTo<FineOffice.Modules.HD_Attachment>(dt) as List<FineOffice.Modules.HD_Attachment>;
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
            str.Append("FROM vw_hd_attachment WHERE 1=1 ");
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

        /// <summary>
        /// 批量更新，用于移动文件
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public override List<Entity.HD_Attachment> Update(List<Entity.HD_Attachment> list)
        {
            List<CommandInfo> transation = new List<CommandInfo>();
            for (int i = 0; i < list.Count; i++)
            {
                SqlParameter[] parameter = { 
                                               new SqlParameter("@ID", SqlDbType.Int, 4), 
                                               new SqlParameter("@FolderID", SqlDbType.Int, 4)
                                           };
                parameter[0].Value = list[i].ID;
                parameter[1].Value = list[i].FolderID;

                CommandInfo command = new CommandInfo("update HD_Attachment set FolderID=@FolderID  where ID=@ID", parameter);
                transation.Add(command);
            }
            DbHelperSQL.ExecuteSqlTran(transation);
            return list;
        }

        public override void Add(List<Entity.HD_Attachment> list)
        {
            List<CommandInfo> transation = new List<CommandInfo>();
            for (int i = 0; i < list.Count; i++)
            {
                SqlParameter[] parameter = { 
                                               new SqlParameter("@FolderID", SqlDbType.Int, 4), 
                                               new SqlParameter("@Owner", SqlDbType.Int, 4),
                                               new SqlParameter("@SendID", SqlDbType.Int, 4),
                                               new SqlParameter("@SendTime", SqlDbType.DateTime),
                                               new SqlParameter("@IsPublic", SqlDbType.Bit),
                                               new SqlParameter("@ID", SqlDbType.Int, 4)
                                           };
                parameter[0].Value = list[i].FolderID;
                parameter[1].Value = list[i].Owner;
                parameter[2].Value = list[i].SendID;
                parameter[3].Value = list[i].SendTime;
                parameter[4].Value = list[i].IsPublic;
                parameter[5].Value = list[i].ID;

                StringBuilder strSql = new StringBuilder();
                strSql.Append("Insert into HD_Attachment(FileName,XType,XTypeName,AttachmentData,Size,FolderID,CreateTime,PersonnelID,Owner,SendID,SendTime,IsPublic,Remark)");
                strSql.Append("Select FileName,XType,XTypeName,AttachmentData,Size,@FolderID,CreateTime,PersonnelID,@Owner,@SendID,@SendTime,@IsPublic,Remark  from HD_Attachment where ID=@ID");

                CommandInfo command = new CommandInfo(strSql.ToString(), parameter);
                transation.Add(command);
            }
            DbHelperSQL.ExecuteSqlTran(transation);
        }
    }
}
