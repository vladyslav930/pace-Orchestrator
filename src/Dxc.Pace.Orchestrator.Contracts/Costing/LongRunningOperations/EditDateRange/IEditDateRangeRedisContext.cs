using Dxc.Captn.Costing.Contracts.LongRunningOperations.EditDateRange;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;
using Dxc.Pace.Orchestrator.Contracts.BusinessLog;
using Dxc.Pace.Orchestrator.Contracts.Costing.Quantity;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.LongRunningOperations.EditDateRange
{
    public interface IEditDateRangeRedisContext : IChangeBusinessLogsContext, ICalculatedQuantitySagaContext
    {
        IFlowSagaContextRepository<CostGroupChangeDetails> CostGroups { get; set; }
    }
}
