using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BX.Modules
{
   public partial class OA_ProjectType
    {
       public OA_ProjectType()
       {}
        #region Model
       private int _ID;

       private string _TypeNO;

       private string _TypeName;

       private string _PinyinCode;

       private System.Nullable<short> _Stop;

       private string _Remark;



       public int ID
       {
           get { return _ID; }
           set { _ID = value; }
       }
       /// <summary>
       /// 编码
       /// </summary>
       public string TypeNO
       {
           get { return _TypeNO; }
           set { _TypeNO = value; }
       }

       /// <summary>
       /// 工程
       /// </summary>
       public string TypeName
       {
           get { return _TypeName; }
           set { _TypeName = value; }
       }

       /// <summary>
       /// 拼音码
       /// </summary>
       public string PinyinCode
       {
           get { return _PinyinCode; }
           set { _PinyinCode = value; }
       }

       /// <summary>
       /// 停用标志
       /// </summary>
       public System.Nullable<short> Stop
       {
           get { return _Stop; }
           set { _Stop = value; }
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
