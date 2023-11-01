using CscGet.Costing.Domain.Dispatcher.Events.DeliveryCountryChange;
using CscGet.Costing.Domain.Dispatcher.Events.Element.Change;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;
using Dxc.Pace.Orchestrator.Contracts.Costing.LongRunningOperations.EditShoring;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.LongRunningOperations.EditDeliveryCountry
{
    public interface IEditDeliveryCountryRedisContext : ICostingSagaContextBase, IShoringCostGroupsContext
    {
        IFlowSagaContextValue<EditDeliveryCountryData> EditDeliveryCountryData { get; set; }

        IFlowSagaContextRepository<ElementChangedModel> LaborRatesChangedElements { get; set; }
        IFlowSagaContextRepository<ElementChangedModel> LaborChangedElements { get; set; }
        IFlowSagaContextRepository<ElementChangedModel> SoftwareChangedElements { get; set; }
        IFlowSagaContextRepository<ElementChangedModel> ServiceChangedElements { get; set; }
        IFlowSagaContextRepository<ElementChangedModel> HardwareChangedElements { get; set; }

        IFlowSagaContextRepository<DeliveryCountryChangedCostGroupModel> DeliveryCountryCostGroups { get; set; }
    }
}
