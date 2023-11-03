using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;
using System;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Common
{
    public interface IDeleteNotHiddenNodeIdsSagaContext
    {
        IFlowSagaContextRepository<Guid> NotHiddenNodeIdsToDelete { get; set; }
    }
}
