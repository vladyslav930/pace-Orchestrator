using CscGet.Costing.Domain.Dispatcher.Events.GlobalTotals;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;

namespace Dxc.Pace.Orchestrator.Contracts.Costing
{
    public interface IGlobalTotalDeletedContext
    {
        IFlowSagaContextRepository<GlobalTotalDeleted> GlobalTotalDeleted { get; set; }
    }
}