using CscGet.Costing.Domain.Dispatcher.Events.Element.Copy;
using Dxc.Captn.Costing.Contracts.Costing.MassOperations.Shaping;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.CopyMove.Common
{
    public interface ICopyMoveCommonContext
    {
        IFlowSagaContextRepository<NodeToCopy> NodesToCopy { get; set; }
        IFlowSagaContextRepository<ElementCopiedModel> CopiedElements { get; set; }
    }
}