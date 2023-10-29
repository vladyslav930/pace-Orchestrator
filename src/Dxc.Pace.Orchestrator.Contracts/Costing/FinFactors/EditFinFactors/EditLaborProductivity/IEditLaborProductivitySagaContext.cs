using CscGet.Costing.Domain.Dispatcher.Events.BusinessLog;
using CscGet.Costing.Domain.Dispatcher.Models.Quantities;
using Dxc.Captn.Costing.Contracts.Dxc.Captn.Costing.Contracts.Quantity;
using Dxc.Captn.Costing.Contracts.Quantity;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;
using Dxc.Pace.Orchestrator.Contracts.BusinessLog;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.FinFactors.EditFinFactors.EditLaborProductivity
{
    public interface IEditLaborProductivitySagaContext : ICostingSagaContextBase, IChangeBusinessLogsContext
    {
        IFlowSagaContextRepository<CostGroupProductivityRequestModel> CostGroupProductivityRequestModels { get; set; }
        IFlowSagaContextRepository<QuantityContainerModel> QuantityContainerModel { get; set; }
        IFlowSagaContextRepository<QuantityCalculatedModel> CalculatedQuantityGroups { get; set; }

    }
}
