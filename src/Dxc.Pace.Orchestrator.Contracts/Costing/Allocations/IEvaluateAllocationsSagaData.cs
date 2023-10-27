using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.Allocations
{
    public interface IEvaluateAllocationsSagaData : ICostingVersionIdProvider
    {
        bool IsNeedToRecalculateAllocations { get; set; }
    }
}
