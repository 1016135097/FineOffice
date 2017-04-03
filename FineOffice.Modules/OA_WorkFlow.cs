using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BX.Modules
{
   public partial class OA_WorkFlow
    {
       public OA_WorkFlow()
       { }
        #region model
       private int _ID;

       private System.Nullable<int> _FormID;

       private System.Nullable<int> _ProjectTypeID;

       private string _WorkFlowNO;

       private string _WorkFlowName;

       private string _PinyinCode;

       private System.Nullable<int> _Maker;

       private System.Nullable<System.DateTime> _MakeDate;

       private string _UserList;

       private string _Describe;   

       private string _Remark;

       private string _ProjectName;

       private string _FormName;


       /// <summary>
       /// GUID
       /// </summary>
       public int ID
       {
           get { return _ID; }
           set { _ID = value; }
       }

       /// <summary>
       /// 表单ID
       /// </summary>
       public System.Nullable<int> FormID
       {
           get { return _FormID; }
           set { _FormID = value; }
       }

       /// <summary>
       /// 工程类别ID
       /// </summary>
       public System.Nullable<int> ProjectTypeID
       {
           get { return _ProjectTypeID; }
           set { _ProjectTypeID = value; }
       }

       /// <summary>
       /// 编码
       /// </summary>
       public string WorkFlowNO
       {
           get { return _WorkFlowNO; }
           set { _WorkFlowNO = value; }
       }

       /// <summary>
       /// 工作流名称
       /// </summary>
       public string WorkFlowName
       {
           get { return _WorkFlowName; }
           set { _WorkFlowName = value; }
       }

       /// <summary>
       /// 设计人
       /// </summary>
       public System.Nullable<int> Maker
       {
           get { return _Maker; }
           set { _Maker = value; }
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
       /// 设计日期
       /// </summary>
       public System.Nullable<System.DateTime> MakeDate
       {
           get { return _MakeDate; }
           set { _MakeDate = value; }
       }

       /// <summary>
       /// 用户列表
       /// </summary>
       public string UserList
       {
           get { return _UserList; }
           set { _UserList = value; }
       }

       /// <summary>
       /// 描述/简介
       /// </summary>
       public string Describe
       {
           get { return _Describe; }
           set { _Describe = value; }
       }

       /// <summary>
       /// 备注
       /// </summary>
       public string Remark
       {
           get { return _Remark; }
           set { _Remark = value; }
       }

       /// <summary>
       /// 工程名称
       /// </summary>
       public string ProjectName
       {
           get { return _ProjectName; }
           set { _ProjectName = value; }
       }

       /// <summary>
       /// 表单名称
       /// </summary>
       public string FormName
       {
           get { return _FormName; }
           set { _FormName = value; }
       }
        #endregion
    }
}
