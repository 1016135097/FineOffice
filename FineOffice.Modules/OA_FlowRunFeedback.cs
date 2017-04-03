using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.Modules
{
    [Serializable]
    public partial class OA_FlowRunFeedback
    {
        public OA_FlowRunFeedback()
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

        private System.Nullable<int> _RunID;

        /// <summary>
        /// 办理流程的ID
        /// </summary>
        public System.Nullable<int> RunID
        {
            get { return _RunID; }
            set { _RunID = value; }
        }

        private System.Nullable<int> _PrcsID;

        /// <summary>
        /// 步骤ID
        /// </summary>
        public System.Nullable<int> PrcsID
        {
            get { return _PrcsID; }
            set { _PrcsID = value; }
        }

        private System.Nullable<int> _UserID;

        /// <summary>
        /// 填写意见的用户ID
        /// </summary>
        public System.Nullable<int> UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        private string _Content;

        /// <summary>
        /// 意见
        /// </summary>
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        private System.Nullable<System.DateTime> _EditTime;

        /// <summary>
        /// 编写时间
        /// </summary>
        public System.Nullable<System.DateTime> EditTime
        {
            get { return _EditTime; }
            set { _EditTime = value; }
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
        #endregion
    }
}
