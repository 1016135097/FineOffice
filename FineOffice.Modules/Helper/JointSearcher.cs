using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules.Helper
{
    /// <summary>
    /// 拼接条件
    /// </summary>
    public class JointSearcher
    {
        /// <summary>
        /// 拼接sql条件语句
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string BuidSQL(ChangeTrackingList<EntitySearcher> list)
        {
            StringBuilder strSql = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                EntitySearcher searcher = list[i];
                strSql.Append(" " + searcher.LeftParentheses + " ");
                if (searcher.Operator.ToLower().Equals("is"))
                {
                    strSql.Append(searcher.Field + " " + searcher.Operator + " " + searcher.Content + " ");
                }
                else if (searcher.Operator.ToUpper().Equals("LIKE") || searcher.Operator.ToUpper().Equals("NOT LIKE"))
                {
                    strSql.Append(searcher.Field + " " + searcher.Operator + " '%" + searcher.Content + "%' ");
                }
                else if (searcher.Operator.ToUpper().Equals("IN"))
                {
                    strSql.Append(searcher.Field + " IN " + searcher.Content + " ");
                }
                else
                    strSql.Append(searcher.Field + " " + searcher.Operator + " '" + searcher.Content + "' ");
                strSql.Append(" " + searcher.RightParentheses + " ");
                if (i < list.Count - 1)
                    strSql.Append(" " + searcher.Relation + " ");
            }
            return strSql.ToString();
        }
    }
}
