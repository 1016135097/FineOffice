using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules
{
    [Serializable]
   public partial class OA_Reply
    {
       public OA_Reply()
       { }
        #region model
       private int _ID;

       /// <summary>
       /// GUID
       /// </summary>
       public int ID
       {
           get { return _ID; }
           set { _ID = value; }
       }

       private System.Nullable<int> _LetterID;

       /// <summary>
       /// 信件ID
       /// </summary>
       public System.Nullable<int> LetterID
       {
           get { return _LetterID; }
           set { _LetterID = value; }
       }

       private string _Content;

       /// <summary>
       /// 内容
       /// </summary>
       public string Content
       {
           get { return _Content; }
           set { _Content = value; }
       }

       private System.Nullable<int> _ReplyPeople;

       /// <summary>
       /// 回复人
       /// </summary>
       public System.Nullable<int> ReplyPeople
       {
           get { return _ReplyPeople; }
           set { _ReplyPeople = value; }
       }

       private System.Nullable<System.DateTime> _ReplyDate;

       /// <summary>
       /// 回复日期
       /// </summary>
       public System.Nullable<System.DateTime> ReplyDate
       {
           get { return _ReplyDate; }
           set { _ReplyDate = value; }
       }

       private string _Remark;

       /// <summary>
       /// 备注
       /// </summary>
       public string Remark
       {
           get { return _Remark; }
           set { _Remark = value; }
       }

       private string _LetterNO;

       /// <summary>
       /// 信件编号
       /// </summary>
       public string LetterNO
       {
           get { return _LetterNO; }
           set { _LetterNO = value; }
       }

       private string _LetterTitle;

       /// <summary>
       /// 信件标题
       /// </summary>
       public string LetterTitle
       {
           get { return _LetterTitle; }
           set { _LetterTitle = value; }
       }

       private string _ReplyName;

       /// <summary>
       /// 回复人
       /// </summary>
       public string ReplyName
       {
           get { return _ReplyName; }
           set { _ReplyName = value; }
       }
        #endregion
    }
}
