using System;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.Allocations.ApplyAllocations
{
    public class ApplyAllocationsSagaData : ICostingVersionIdProvider
    {
        public int CostingVersionId { get; set; }
        public CostingTrackingSagaInfo[] CostingTrackingSagaInfos { get; set; }
    }
}
