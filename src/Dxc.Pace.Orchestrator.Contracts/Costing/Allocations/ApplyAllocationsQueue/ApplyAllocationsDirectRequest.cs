using System;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.Allocations.ApplyAllocationsQueue
{
    public class ApplyAllocationsDirectRequest
    {
        public Guid CorrelationId { get; set; }
        public int CostingVersionId { get; set; }

        public ApplyAllocationsDirectRequest(Guid correlationId, int costingVersionId)
        {
            CorrelationId = correlationId;
            CostingVersionId = costingVersionId;
        }
    }
}
