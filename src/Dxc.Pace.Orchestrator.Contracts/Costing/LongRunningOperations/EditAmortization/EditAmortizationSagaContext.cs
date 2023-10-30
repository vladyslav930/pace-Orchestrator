using Dxc.Captn.Costing.Contracts.Wbs.CostGroups;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.LongRunningOperations.EditAmortization
{
    public interface IEditAmortizationSagaContext : ICostingSagaContextBase
    {
        IFlowSagaContextRepository<CostGroupAmortizationModel> AmortizationModels { get; set; }
    }
}