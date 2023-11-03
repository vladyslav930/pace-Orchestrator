using CscGet.Costing.Domain.Dispatcher.Events.Wbs.BaselineMetrics;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.CopyMove
{
    public interface IBaselineMetricContext
    {
        IFlowSagaContextRepository<BaselineMetricCopyModel> BaselineMetricCopyModels { get; set; }
    }
}