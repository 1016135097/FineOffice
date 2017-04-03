using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.BLL.Bussness
{
    /// <summary>
    /// 工作流处理类
    /// </summary>
    public class FlowRunHandler
    {
        FineOffice.IDataAccess.Business.IFlowRunHandler dal = new FineOffice.DataAccess.Business.FlowRunHandler();

        /// <summary>
        /// 处理并创建新节点
        /// </summary>
        public void HandleCreateRunProcess(Modules.OA_FlowRunProcess handleProcess, Modules.OA_FlowRunProcess create)
        {
            dal.HandleCreateRunProcess(handleProcess, create);
        }

        /// <summary>
        /// 流程节点退回
        /// </summary>
        public void SendBackRunProcess(Modules.OA_FlowRunProcess handleProcess, Modules.OA_FlowRunProcess backProcess)
        {
            dal.SendBackRunProcess(handleProcess, backProcess);
        }

        /// <summary>
        /// 流程节点列表
        /// </summary>
        public List<FineOffice.Modules.OA_FlowRunProcess> FlowRunProcessList(Modules.OA_FlowRun flowRun)
        {
            return dal.FlowRunProcessList(flowRun);
        }
    }
}
