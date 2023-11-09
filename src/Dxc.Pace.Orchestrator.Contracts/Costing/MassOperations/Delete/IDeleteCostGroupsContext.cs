using Dxc.Captn.Costing.Contracts.Costing.MassOperations.Delete;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Delete
{
    public interface IDeleteCostGroupsContext
    {
        IFlowSagaContextRepository<CostGroup> CostGroupsToDelete { get; set; }
    }
}