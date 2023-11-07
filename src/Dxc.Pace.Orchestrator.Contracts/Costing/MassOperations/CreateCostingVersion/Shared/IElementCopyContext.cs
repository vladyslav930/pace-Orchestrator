using CscGet.Costing.Domain.Dispatcher.Events.Element.Copy;
using CscGet.Costing.Domain.Dispatcher.Events.Wbs.CostGroups.Models;
using Dxc.Captn.Costing.Contracts.Sagas.Messages.Models;
using Dxc.Captn.Costing.Contracts.Services.BidManagement.Operations.Shaping;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;
using Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Shaping.Models;
using System;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.CreateCostingVersion.Shared
{
    public interface IElementCopyContext<T> where T: IElementCopyData
    {
        IFlowSagaContextValue<T> SagaData { get; set; }

        IFlowSagaContextRepository<ElementCopiedModel> CopiedElements { get; set; }

        IFlowSagaContextRepository<CostGroupCopiedModel> AllCopiedNodes { get; set; }
        IFlowSagaContextRepository<CostGroupCopiedModel> HardwareCopiedCostGroups { get; set; }
        IFlowSagaContextRepository<CostGroupCopiedModel> SoftwareCopiedCostGroups { get; set; }
        IFlowSagaContextRepository<CostGroupCopiedModel> ServicesCopiedCostGroups { get; set; }
        IFlowSagaContextRepository<CostGroupCopiedModel> LaborCopiedCostGroups { get; set; }
        IFlowSagaContextRepository<CostGroupCopiedModel> LaborRatesCopiedCostGroups { get; set; }
        IFlowSagaContextRepository<CostGroupCopiedModel> MiscellaneousCopiedCostGroups { get; set; }

        IFlowSagaContextRepository<CostGroupCopiedModel> InflationsCostGroups { get; set; }

        IFlowSagaContextRepository<NodeCopiedModel> CopiedNodes { get; set; }
        IFlowSagaContextRepository<NodeCopiedModel> QuantityCopiedNodes { get; set; }
        IFlowSagaContextRepository<FormulaReplacementModel> FormulaReplacements { get; set; }

        IFlowSagaContextRepository<ClientCountryCopiedModel> CopiedClientCountries { get; set; }

        IFlowSagaContextRepository<Guid> SourceAllocationCostGroupIds { get; set; }
        IFlowSagaContextRepository<SourceTargetMap> AllocationIdsMap { get; set; }
    }
}
