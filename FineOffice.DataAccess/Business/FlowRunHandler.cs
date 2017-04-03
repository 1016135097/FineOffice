using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using FineOffice.DataAccess.Helper;
using System.Data.Common;

namespace FineOffice.DataAccess.Business
{
    public class FlowRunHandler : FineOffice.IDataAccess.Business.IFlowRunHandler
    {
        /// <summary>
        /// 下一流程
        /// </summary>
        /// <param name="handleProcess"></param>
        /// <param name="create"></param>
        public void HandleCreateRunProcess(Modules.OA_FlowRunProcess handleProcess, Modules.OA_FlowRunProcess create)
        {
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                cxt.Connection.Open();
                using (DbTransaction tran = cxt.Connection.BeginTransaction())
                {
                    cxt.Transaction = tran;
                    Table<FineOffice.Entity.OA_FlowRunProcess> runProcess = cxt.GetTable<FineOffice.Entity.OA_FlowRunProcess>();
                    Table<FineOffice.Entity.OA_FlowRunTransmit> transmit = cxt.GetTable<FineOffice.Entity.OA_FlowRunTransmit>();

                    try
                    {
                        FineOffice.Entity.OA_FlowRunProcess createProcess = new Entity.OA_FlowRunProcess
                        {
                            ID = create.ID,
                            ProcessID = create.ProcessID,
                            Remark = create.Remark,
                            AcceptID = create.AcceptID,
                            AcceptTime = create.AcceptTime,
                            HandleTime = create.HandleTime,
                            Pattern = create.Pattern,
                            IsEntrance = create.IsEntrance,
                            PreviousID = create.PreviousID,
                            SendID = create.SendID,
                            Version = create.Version,
                            TransmitAdvice = create.TransmitAdvice,
                            RunID = create.RunID,
                            State = create.State,
                            TransmitFrom = handleProcess.TransmitFrom,
                        };
                        runProcess.InsertOnSubmit(createProcess);
                        cxt.SubmitChanges();

                        runProcess.Attach(new Entity.OA_FlowRunProcess
                        {
                            ID = handleProcess.ID,
                            ProcessID = handleProcess.ProcessID,
                            Remark = handleProcess.Remark,
                            AcceptID = handleProcess.AcceptID,
                            AcceptTime = handleProcess.AcceptTime,
                            HandleTime = handleProcess.HandleTime,
                            Pattern = handleProcess.Pattern,
                            PreviousID = handleProcess.PreviousID,
                            SendID = handleProcess.SendID,
                            Version = handleProcess.Version,
                            IsEntrance = handleProcess.IsEntrance,
                            TransmitAdvice = handleProcess.TransmitAdvice,
                            RunID = handleProcess.RunID,
                            State = handleProcess.State,
                            TransmitFrom = handleProcess.TransmitFrom,
                        }, true);

                        transmit.InsertOnSubmit(new Entity.OA_FlowRunTransmit
                        {
                            Pattern = 1,
                            RunProcessID = handleProcess.ID,
                            TransmitTo = createProcess.ID
                        });

                        transmit.InsertOnSubmit(new Entity.OA_FlowRunTransmit
                        {
                            Pattern = 2,
                            RunProcessID = handleProcess.ID,
                            TransmitTo = createProcess.ID
                        });
                        cxt.SubmitChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 退回流程
        /// </summary>
        /// <param name="handleProcess"></param>
        /// <param name="backProcess"></param>
        public void SendBackRunProcess(Modules.OA_FlowRunProcess handleProcess, Modules.OA_FlowRunProcess backProcess)
        {
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                cxt.Connection.Open();
                using (DbTransaction tran = cxt.Connection.BeginTransaction())
                {
                    cxt.Transaction = tran;
                    Table<FineOffice.Entity.OA_FlowRunProcess> runProcess = cxt.GetTable<FineOffice.Entity.OA_FlowRunProcess>();
                    Table<FineOffice.Entity.OA_FlowRunTransmit> transmit = cxt.GetTable<FineOffice.Entity.OA_FlowRunTransmit>();

                    try
                    {
                        FineOffice.Entity.OA_FlowRunProcess createProcess = new Entity.OA_FlowRunProcess
                        {
                            ID = backProcess.ID,
                            ProcessID = backProcess.ProcessID,
                            Remark = backProcess.Remark,
                            AcceptID = backProcess.AcceptID,
                            AcceptTime = backProcess.AcceptTime,
                            HandleTime = backProcess.HandleTime,
                            Pattern = backProcess.Pattern,
                            PreviousID = backProcess.PreviousID,
                            SendID = backProcess.SendID,
                            IsEntrance = backProcess.IsEntrance,
                            Version = backProcess.Version,
                            TransmitFrom = handleProcess.ID,
                            TransmitAdvice = backProcess.TransmitAdvice,
                            RunID = backProcess.RunID,
                            State = backProcess.State,
                        };
                        runProcess.InsertOnSubmit(createProcess);
                        cxt.SubmitChanges();

                        bool isEntrance = false;
                        if (handleProcess.IsEntrance != null && handleProcess.IsEntrance.Value)
                        {
                            isEntrance = true;
                            handleProcess.IsEntrance = false;
                        }

                        if (backProcess.IsEntrance == null || !backProcess.IsEntrance.Value)
                        {
                            FineOffice.Entity.OA_FlowRunTransmit previous = transmit.Where(p => p.RunProcessID == createProcess.PreviousID &&
                                p.TransmitTo == handleProcess.PreviousID && p.Pattern == 1).FirstOrDefault();
                        }
                        else if (!isEntrance)
                        {
                            FineOffice.Entity.OA_FlowRunProcess tempProcess = runProcess.Where(p => p.RunID == backProcess.RunID && p.IsEntrance == true).FirstOrDefault();
                            tempProcess.IsEntrance = null;
                        }

                        runProcess.Attach(new Entity.OA_FlowRunProcess
                        {
                            ID = handleProcess.ID,
                            ProcessID = handleProcess.ProcessID,
                            Remark = handleProcess.Remark,
                            AcceptID = handleProcess.AcceptID,
                            AcceptTime = handleProcess.AcceptTime,
                            HandleTime = handleProcess.HandleTime,
                            Pattern = handleProcess.Pattern,
                            PreviousID = handleProcess.PreviousID,
                            SendID = handleProcess.SendID,
                            IsEntrance = handleProcess.IsEntrance,
                            Version = handleProcess.Version,
                            TransmitAdvice = handleProcess.TransmitAdvice,
                            RunID = handleProcess.RunID,
                            State = handleProcess.State
                        }, true);

                        transmit.InsertOnSubmit(new Entity.OA_FlowRunTransmit
                        {
                            Pattern = 2,
                            RunProcessID = handleProcess.ID,
                            TransmitTo = createProcess.ID
                        });

                        cxt.SubmitChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        throw new Exception(ex.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 返回已解决的步骤
        /// </summary>
        /// <param name="flowRun"></param>
        /// <returns></returns>
        public List<FineOffice.Modules.OA_FlowRunProcess> FlowRunProcessList(Modules.OA_FlowRun flowRun)
        {
            using (DataContext cxt = ContextFactory.CreateContext())
            {
                Table<FineOffice.Entity.OA_FlowRunProcess> runProcess = cxt.GetTable<FineOffice.Entity.OA_FlowRunProcess>();
                Table<FineOffice.Entity.OA_FlowRunTransmit> transmit = cxt.GetTable<FineOffice.Entity.OA_FlowRunTransmit>();

                FineOffice.Entity.OA_FlowRunProcess tempProcess = runProcess.Where(p => p.RunID == flowRun.ID && p.IsEntrance == true).FirstOrDefault();
                List<FineOffice.Entity.OA_FlowRunTransmit> transmitList = transmit.Where(p => p.RunProcessID == tempProcess.ID && p.Pattern == 1).ToList();

                List<FineOffice.Entity.OA_FlowRunProcess> list = new List<Entity.OA_FlowRunProcess>();
                list.Add(tempProcess);

                foreach (FineOffice.Entity.OA_FlowRunTransmit temp in transmitList)
                {
                    FineOffice.Entity.OA_FlowRunProcess runp = runProcess.Where(p => p.ID == temp.TransmitTo).FirstOrDefault();
                    list.Add(runp);
                    this.AddRunProcess(cxt, runp, list);
                }

                List<FineOffice.Modules.OA_FlowRunProcess> result = (from p in list
                                                                     select new FineOffice.Modules.OA_FlowRunProcess
                                                                         {
                                                                             ID = p.ID,
                                                                             AcceptTime = p.AcceptTime,
                                                                             HandleTime = p.HandleTime,
                                                                             IsEnd = p.OA_FlowProcess.IsEnd,
                                                                             IsStart = p.OA_FlowProcess.IsStart,
                                                                             ProcessName = p.OA_FlowProcess.ProcessName,
                                                                             State = p.State,
                                                                         }).ToList();

                return result;
            }
        }

        /// <summary>
        /// 递归中的主函数
        /// </summary>
        /// <param name="cxt"></param>
        /// <param name="tempProcess"></param>
        /// <param name="list"></param>
        public void AddRunProcess(DataContext cxt, Entity.OA_FlowRunProcess tempProcess, List<Entity.OA_FlowRunProcess> list)
        {
            Table<FineOffice.Entity.OA_FlowRunProcess> runProcess = cxt.GetTable<FineOffice.Entity.OA_FlowRunProcess>();
            Table<FineOffice.Entity.OA_FlowRunTransmit> transmit = cxt.GetTable<FineOffice.Entity.OA_FlowRunTransmit>();

            List<FineOffice.Entity.OA_FlowRunTransmit> transmitList = transmit.Where(p => p.RunProcessID == tempProcess.ID && p.Pattern == 1).ToList();

            foreach (FineOffice.Entity.OA_FlowRunTransmit temp in transmitList)
            {
                FineOffice.Entity.OA_FlowRunProcess runp = runProcess.Where(p => p.ID == temp.TransmitTo).FirstOrDefault();
                list.Add(runp);
                this.AddRunProcess(cxt, runp, list);
            }
        }
    }
}
