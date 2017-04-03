using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules
{
    [Serializable]
    public partial class OA_Work
    {
        public OA_Work()
        { }
        #region Model
        private int _ID;

        /// <summary>
        /// GUID
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _WorkName;

        /// <summary>
        /// 工作名称
        /// </summary>
        public string WorkName
        {
            get { return _WorkName; }
            set { _WorkName = value; }
        }

        private System.Nullable<int> _WorkFlowID;

        /// <summary>
        /// 工作流程ID
        /// </summary>
        public System.Nullable<int> WorkFlowID
        {
            get { return _WorkFlowID; }
            set { _WorkFlowID = value; }
        }

        private System.Nullable<int> _Maker;

        /// <summary>
        /// 制作人
        /// </summary>
        public System.Nullable<int> Maker
        {
            get { return _Maker; }
            set { _Maker = value; }
        }

        private System.Nullable<System.DateTime> _MakeDate;

        /// <summary>
        /// 制作日期
        /// </summary>
        public System.Nullable<System.DateTime> MakeDate
        {
            get { return _MakeDate; }
            set { _MakeDate = value; }
        }

        private string _FromContent;

        /// <summary>
        /// 表单内容
        /// </summary>
        public string FromContent
        {
            get { return _FromContent; }
            set { _FromContent = value; }
        }

        private string _VerifyList;

        /// <summary>
        /// 审批人
        /// </summary>
        public string VerifyList
        {
            get { return _VerifyList; }
            set { _VerifyList = value; }
        }

        private System.Nullable<int> _WorkState;

        /// <summary>
        /// 工作状态
        /// </summary>
        public System.Nullable<int> WorkState
        {
            get { return _WorkState; }
            set { _WorkState = value; }
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
        private string _WorkFlowName;

        /// <summary>
        /// 工作流程名称
        /// </summary>
        public string WorkFlowName
        {
            get { return _WorkFlowName; }
            set { _WorkFlowName = value; }
        }

        private string _FormName;

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
