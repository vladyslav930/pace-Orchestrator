using Dxc.Captn.Costing.Contracts.Operations.ConvertToCustom;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Common
{
    public interface IConvertedNodesSagaContext
    {
        IFlowSagaContextRepository<ConvertedNodes> ConvertedNodes { get; set; }
    }
}
