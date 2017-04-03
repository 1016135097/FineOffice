using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BX.Modules
{
   public partial class Sys_FixedData
    {
       public Sys_FixedData()
       { }
        #region model
       private int _ID;

       private string _DataContent;

       private string _Sign;

       private string _Remark;

       /// <summary>
       /// GUID
       /// </summary>
       public int ID
       {
           get { return _ID; }
           set { _ID = value; }
       }

       /// <summary>
       /// 标记
       /// </summary>
       public string Sign
       {
           get { return _Sign; }
           set { _Sign = value; }
       }

       /// <summary>
       /// 内容
       /// </summary>
       public string DataContent
       {
           get { return _DataContent; }
           set { _DataContent = value; }
       }

       /// <summary>
       /// 备注
       /// </summary>
       public string Remark
       {
           get { return _Remark; }
           set { _Remark = value; }
       }
        #endregion
    }
}
