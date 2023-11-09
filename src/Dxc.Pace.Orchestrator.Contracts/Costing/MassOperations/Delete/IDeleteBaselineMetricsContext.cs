using System;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Delete
{
    public interface IDeleteBaselineMetricsContext
    {
        IFlowSagaContextRepository<Guid> BaselineMetricsToDelete { get; set; }
    }
}