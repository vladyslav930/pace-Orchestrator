using CscGet.Costing.Domain.Dispatcher.Events.GlobalTotals;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;
using Dxc.Pace.Orchestrator.Contracts.BusinessLog;
using Dxc.Pace.Orchestrator.Contracts.Costing.Quantity;

namespace Dxc.Pace.Orchestrator.Contracts.Costing
{
    public interface IGlobalTotalUpdatedContext : IChangeBusinessLogsContext, ICalculatedQuantityGroupsContext
    {
        IFlowSagaContextRepository<GlobalTotalUpdated> GlobalTotalUpdated { get; set; }
    }
}