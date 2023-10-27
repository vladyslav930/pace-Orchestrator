using Dxc.Captn.Costing.Contracts.Svsc;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;
using Dxc.Pace.Orchestrator.Contracts.BusinessLog;
using Dxc.Pace.Orchestrator.Contracts.Costing.Quantity;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.BnmTree.SumValSumCost
{
    public interface ISvscRefreshReferencesSagaContext: ICalculatedQuantitySagaContext, IUpdateSumCostContext, IChangeBusinessLogsContext
    {
        IFlowSagaContextValue<SvscRefreshReferencesCommand> SvscRefreshReferencesCommand { get; set; }
    }
}