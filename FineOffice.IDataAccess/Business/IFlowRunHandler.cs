using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FineOffice.IDataAccess.Business
{
    public interface IFlowRunHandler
    {
        /// <summary>
        /// 处理并创建新步骤
        /// </summary>
        /// <param name="handleProcess">要处理的步骤</param>
        /// <param name="create">创建的步骤</param>
        void HandleCreateRunProcess(FineOffice.Modules.OA_FlowRunProcess handleProcess, FineOffice.Modules.OA_FlowRunProcess create);

       /// <summary>
       /// 退回流程
       /// </summary>
       /// <param name="handleProcess">要处理的步骤</param>
       /// <param name="backProcess">退回到的步骤</param>
        void SendBackRunProcess(FineOffice.Modules.OA_FlowRunProcess handleProcess, FineOffice.Modules.OA_FlowRunProcess backProcess);

        /// <summary>
        ///  返回已处理的步聚
        /// </summary>
        /// <param name="flowRun">工作流程</param>
        List<FineOffice.Modules.OA_FlowRunProcess> FlowRunProcessList(FineOffice.Modules.OA_FlowRun flowRun); 
    }
}
