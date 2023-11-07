using System;
using CscGet.Costing.Domain.Dispatcher.Models.Element;
using Dxc.Captn.Costing.Contracts.Costing.MassOperations;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;
using Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Common;
using Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.CopyMove.Common;
using Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Delete;
using Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Shaping.Models;
using Dxc.Pace.Orchestrator.Contracts.Costing.Quantity;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.CopyMove
{
    public interface IMoveSagaContext : 
        IDeleteNodeSagaContext, 
        IDeleteNodeIdsSagaContext, 
        IDeleteNotHiddenNodeIdsSagaContext, 
        IConvertedNodesSagaContext,
        IChangeQuantitiesContext,
        ICostingSagaContextBase,
        IBaselineMetricContext,
        ICopyMoveCommonContext,
        IDeleteBusinessLogContext
    {
        IFlowSagaContextRepository<NodeToUpdate> NodesToUpdate { get; set; }
        
        IFlowSagaContextRepository<Guid> SourceAllocationCostGroupIds { get; set; }
        IFlowSagaContextRepository<SourceTargetMap> AllocationIdsMap { get; set; }

        IFlowSagaContextRepository<ElementModel> HardwareCostGroupsElementsToCopy { get; set; }
        IFlowSagaContextRepository<ElementModel> SoftwareCostGroupsElementsToCopy { get; set; }
        IFlowSagaContextRepository<ElementModel> LaborCostGroupsElementsToCopy { get; set; }
        IFlowSagaContextRepository<ElementModel> LaborRatesCostGroupsElementsToCopy { get; set; }
        IFlowSagaContextRepository<ElementModel> ServicesCostGroupsElementsToCopy { get; set; }
        IFlowSagaContextRepository<ElementModel> MiscellaneousCostGroupsElementsToCopy { get; set; }
    }
}