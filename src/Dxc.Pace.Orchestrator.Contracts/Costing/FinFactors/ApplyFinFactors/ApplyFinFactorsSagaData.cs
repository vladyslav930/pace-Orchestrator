using Dxc.Pace.Orchestrator.Contracts.Costing.Common;
using System;
using Dxc.Pace.Orchestrator.Contracts.Costing.Allocations;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.FinFactors.ApplyFinFactors
{
    public class ApplyFinFactorsSagaData: IEvaluateAllocationsSagaData
    {
        public CostingTrackingSagaInfo[] CostingTrackingSagaInfos { get; set; } = Array.Empty<CostingTrackingSagaInfo>();
        public int CostingVersionId { get; set; }
        public bool IsNeedToRecalculateAllocations { get; set; }
    }
}
