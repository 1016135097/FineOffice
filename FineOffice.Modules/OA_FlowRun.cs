using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FineOffice.Modules.Helper;

namespace FineOffice.Modules
{
    public class OA_FlowRun : Modules.Helper.BaseModule
    {
        public OA_FlowRun()
        {
            this._OA_FlowRunProcessList = new ChangeTrackingList<OA_FlowRunProcess>();
        }
        private int _ID;
        private System.Nullable<int> _FlowID;
        private string _WorkName;
        private System.Nullable<int> _Creator;
        private System.Nullable<System.DateTime> _CreateTime;
        private string _Remark;
        private string _CreateName;
        private string _ProcessID;
        private string _ProcessName;
        private string _FlowName;
        private string _FlowNO;
        private string _FlowSortName;
        private System.Nullable<int> _SortID;
        private ChangeTrackingList<FineOffice.Modules.OA_FlowRunProcess> _OA_FlowRunProcessList;
        private System.Nullable<short> _State;
        private string _WorkNO;
        private int _CurrentTransmit;
        private System.Nullable<bool> _IsEnd;
        private System.Nullable<int> _StartID;

        public System.Nullable<int> StartID
        {
            get { return _StartID; }
            set { _StartID = value; }
        }

        public System.Nullable<bool> IsEnd
        {
            get { return _IsEnd; }
            set { _IsEnd = value; }
        }

        public int CurrentTransmit
        {
            get { return _CurrentTransmit; }
            set { _CurrentTransmit = value; }
        }

        public string WorkNO
        {
            get { return _WorkNO; }
            set { _WorkNO = value; }
        }

        public System.Nullable<short> State
        {
            get { return _State; }
            set { _State = value; }
        }

        public ChangeTrackingList<FineOffice.Modules.OA_FlowRunProcess> OA_FlowRunProcessList
        {
            get { return _OA_FlowRunProcessList; }
            set { _OA_FlowRunProcessList = value; }
        }

        public System.Nullable<int> SortID
        {
            get { return _SortID; }
            set { _SortID = value; }
        }

        public string FlowSortName
        {
            get { return _FlowSortName; }
            set { _FlowSortName = value; }
        }

        /// <summary>
        /// 流程编码
        /// </summary>
        public string FlowNO
        {
            get { return _FlowNO; }
            set { _FlowNO = value; }
        }

        /// <summary>
        /// 流程名称
        /// </summary>
        public string FlowName
        {
            get { return _FlowName; }
            set { _FlowName = value; }
        }

        /// <summary>
        /// 当前节点名称
        /// </summary>
        public string ProcessName
        {
            get { return _ProcessName; }
            set { _ProcessName = value; }
        }

        /// <summary>
        /// 当前节点ID
        /// </summary>
        public string ProcessID
        {
            get { return _ProcessID; }
            set { _ProcessID = value; }
        }

        public string CreateName
        {
            get { return _CreateName; }
            set { _CreateName = value; }
        }

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }       

        public System.Nullable<int> FlowID
        {
            get { return _FlowID; }
            set { _FlowID = value; }
        }       

        public string WorkName
        {
            get { return _WorkName; }
            set { _WorkName = value; }
        }       

        public System.Nullable<int> Creator
        {
            get { return _Creator; }
            set { _Creator = value; }
        }      

        public System.Nullable<System.DateTime> CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }      

        public string Remark
        {
            get { return _Remark; }
            set { _Remark = value; }
        }
    }
}
