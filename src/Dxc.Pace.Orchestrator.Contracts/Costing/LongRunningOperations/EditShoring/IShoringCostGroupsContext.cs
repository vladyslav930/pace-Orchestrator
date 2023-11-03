using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.LongRunningOperations.EditShoring
{
    public interface IShoringCostGroupsContext
    {
        IFlowSagaContextRepository<ShoringCostGroup> ShoringChangedCostGroups { get; set; }
    }
}