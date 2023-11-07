using Dxc.Captn.Costing.Contracts.Dxc.Captn.Costing.Contracts.Sagas.Requests.Shared;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;
using Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.CreateCostingVersion.Shared;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.CreateCostingVersion
{
    public interface INewCostingVersionSagaRedisContext : IElementCopyContext<NewCostingVersionSagaData>, Quantity.IUpdateSumCostContext, ICostingSagaContextBase
    {
        IFlowSagaContextValue<ContingencyBulkOperationRequestBase> ContingencyCopyDataRequest { get; set; }

        IFlowSagaContextRepository<int> CostingVersionIdList { get; set; }

        IFlowSagaContextValue<string> BidName { get; set; }
    }
}
