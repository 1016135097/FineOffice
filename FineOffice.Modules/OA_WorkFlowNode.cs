using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BX.Modules
{
   public partial class OA_WorkFlowNode
    {
       public OA_WorkFlowNode()
       { }
        #region model
       private int _ID;

       private string _NodeNO;

       private string _NodeName;

       private string _PinyinCode;

       private System.Nullable<int> _WorkFlowID;

       private string _NodeXuHao;

       private System.Nullable<int> _NodeAttribute;

       private string _NextNodeXuHao;

       private System.Nullable<int> _VerifyModel;

       private System.Nullable<int> _ValidHours;

       private System.Nullable<int> _VerifierSetting;

       private string _Transactor;

       private string _SetLeft;

       private string _SetTop;

       private string _Remark;

       private string _NodeAttributeName;

       private string _VerifyModelName;       

       private string _VerifierSettingName;



       /// <summary>
       /// GUID
       /// </summary>
       public int ID
       {
           get { return _ID; }
           set { _ID = value; }
       }

       /// <summary>
       /// 节点编码
       /// </summary>
       public string NodeNO
       {
           get { return _NodeNO; }
           set { _NodeNO = value; }
       }

       /// <summary>
       /// 节点名称
       /// </summary>
       public string NodeName
       {
           get { return _NodeName; }
           set { _NodeName = value; }
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
       /// 工作流ID
       /// </summary>
       public System.Nullable<int> WorkFlowID
       {
           get { return _WorkFlowID; }
           set { _WorkFlowID = value; }
       }

       /// <summary>
       /// 节点序号
       /// </summary>
       public string NodeXuHao
       {
           get { return _NodeXuHao; }
           set { _NodeXuHao = value; }
       }

       /// <summary>
       /// 节点属性ID
       /// </summary>
       public System.Nullable<int> NodeAttribute
       {
           get { return _NodeAttribute; }
           set { _NodeAttribute = value; }
       }

       /// <summary>
       /// 下个节点序号
       /// </summary>
       public string NextNodeXuHao
       {
           get { return _NextNodeXuHao; }
           set { _NextNodeXuHao = value; }
       }

       /// <summary>
       /// 评审模式ID
       /// </summary>
       public System.Nullable<int> VerifyModel
       {
           get { return _VerifyModel; }
           set { _VerifyModel = value; }
       }

       /// <summary>
       /// 有效小时
       /// </summary>
       public System.Nullable<int> ValidHours
       {
           get { return _ValidHours; }
           set { _ValidHours = value; }
       }

       /// <summary>
       /// 审批人指定方式ID
       /// </summary>
       public System.Nullable<int> VerifierSetting
       {
           get { return _VerifierSetting; }
           set { _VerifierSetting = value; }
       }

       /// <summary>
       /// 经办人
       /// </summary>
       public string Transactor
       {
           get { return _Transactor; }
           set { _Transactor = value; }
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
       /// 节点属性名
       /// </summary>
       public string NodeAttributeName
       {
           get { return _NodeAttributeName; }
           set { _NodeAttributeName = value; }
       }

       /// <summary>
       /// 评审模式名
       /// </summary>
       public string VerifyModelName
       {
           get { return _VerifyModelName; }
           set { _VerifyModelName = value; }
       }

       /// <summary>
       /// 审批人指定方式
       /// </summary>
       public string VerifierSettingName
       {
           get { return _VerifierSettingName; }
           set { _VerifierSettingName = value; }
       }


       /// <summary>
       /// 节点离左边位置
       /// </summary>
       public string SetLeft
       {
           get { return _SetLeft; }
           set { _SetLeft = value; }
       }

       /// <summary>
       /// 节点离顶边位置
       /// </summary>
       public string SetTop
       {
           get { return _SetTop; }
           set { _SetTop = value; }
       }
        #endregion
    }
}
