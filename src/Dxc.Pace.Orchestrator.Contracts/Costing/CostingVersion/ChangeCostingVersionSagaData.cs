using Dxc.Pace.Orchestrator.Contracts.Costing.Allocations;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.CostingVersion
{
	public class ChangeCostingVersionSagaData : CostingSagaDataBase, IEvaluateAllocationsSagaData
	{
        public bool IsNeedToRecalculateAllocations { get; set; }

        public bool IsBidNameChanged { get; set; }
    }
}
