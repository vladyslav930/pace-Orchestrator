using System;
using CscGet.Costing.Domain.Dispatcher.Events.Wbs.CostGroups.Models;
using CscGet.Costing.Domain.Dispatcher.Models.Element;
using Dxc.Captn.Costing.Contracts.BulkOperations.Contingency.Models;
using Dxc.Captn.Costing.Contracts.Financial.CurrencyRisks.BidClientCountry;
using Dxc.Captn.Costing.Contracts.Financial.Inflation.BidClientCountry;
using Dxc.Captn.Costing.Contracts.Sagas.Messages.Models;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;
using Dxc.Pace.Orchestrator.Contracts.Costing.BnmTree.SumValSumCost;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;
using Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Common;
using Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.CopyMove.Common;
using Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Delete;
using Dxc.Pace.Orchestrator.Contracts.Costing.Quantity;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.CopyMove
{
    public interface ICopySagaContext: 
        IChangeQuantitiesContext,
        ICostingSagaContextBase,
        IDeleteNodeSagaContext,
        IDeleteNodeIdsSagaContext,
        IDeleteNotHiddenNodeIdsSagaContext,
        IBaselineMetricContext,
        ISvscRefreshReferencesSagaContext,
        ICopyMoveCommonContext
    {
        IFlowSagaContextRepository<Guid> SourceAllocationCostGroupIds { get; set; }
        IFlowSagaContextRepository<ContingencyBusinessModel> Businesses { get; set; }
        IFlowSagaContextRepository<CurrencyRisksClientCountryModel> BidClientCountries { get; set; }
        IFlowSagaContextRepository<InflationClientCountryModel> ClientCountries { get; set; }
        IFlowSagaContextRepository<ElementModel> Elements { get; set; }
        IFlowSagaContextRepository<NodeCopiedModel> CopiedNodes { get; set; }
    }
}