using Dxc.Captn.Costing.Contracts.BulkOperations.Quantity;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;
using System;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.BnmTree.Bnm
{
    public interface IBnmCreatingSagaContext: ICostingSagaContextBase
    {
        IFlowSagaContextRepository<Guid> BnmIds { get; set; }
        IFlowSagaContextValue<ChangeQuantitiesCommand> ChangeQuantities { get; set; }
    }   
}