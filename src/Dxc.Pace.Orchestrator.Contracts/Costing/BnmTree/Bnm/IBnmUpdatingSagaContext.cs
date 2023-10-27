using System;
using CscGet.Costing.Domain.Dispatcher.Events.BaselineMetric;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;
using Dxc.Pace.Orchestrator.Contracts.BusinessLog;
using Dxc.Pace.Orchestrator.Contracts.Costing.BnmTree.SumValSumCost;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;
using Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.BnmTree.Bnm
{
    public interface IBnmUpdatingSagaContext : ICostingSagaContextBase,
                                               ISvscRefreshReferencesSagaContext,
                                               IChangeBusinessLogsContext,
                                               IGlobalTotalUpdatedContext,
                                               IGlobalTotalDeletedContext,
                                               IDeleteNodeIdsSagaContext
    {
        IFlowSagaContextRepository<Guid> BnmIds { get; set; }

        IFlowSagaContextValue<BaselineMetricUpdated> BnmUpdatedEvent { get; set; }
    }
}