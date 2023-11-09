using System;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Delete
{
    public interface IDeleteClientCountryIdsContext
    {
        IFlowSagaContextRepository<Guid> ClientCountriesToDelete { get; set; }
    }
}