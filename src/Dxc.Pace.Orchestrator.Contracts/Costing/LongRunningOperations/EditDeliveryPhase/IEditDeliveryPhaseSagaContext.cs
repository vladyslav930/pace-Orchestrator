using CscGet.Costing.Domain.Dispatcher.Events.BusinessLog;
using Dxc.Captn.Costing.Contracts.Wbs.CostGroups;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.LongRunningOperations.EditDeliveryPhase
{
    public interface IEditDeliveryPhaseSagaContext : ICostingSagaContextBase
    {
        IFlowSagaContextRepository<CostGroupDeliveryPhaseModel> DeliveryPhaseModels { get; set; }
        IFlowSagaContextRepository<AddBusinessLogs> BusinessLogsToAdd { get; set; }
        IFlowSagaContextRepository<RemoveBusinessLogsOptionalSource> BusinessLogsToRemove { get; set; }
    }
}
