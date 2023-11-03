using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;
using System;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Common
{
    public interface IDeleteNodeIdsSagaContext
    {
        IFlowSagaContextRepository<Guid> NodeIdsToDelete { get; set; }
    }
}
