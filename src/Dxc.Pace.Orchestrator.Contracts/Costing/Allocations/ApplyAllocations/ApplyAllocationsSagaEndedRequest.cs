namespace Dxc.Pace.Orchestrator.Contracts.Costing.Allocations.ApplyAllocations
{
    public class ApplyAllocationsSagaEndedRequest
    {
        public int CostingVersionId { get; set; }

        public ApplyAllocationsSagaEndedRequest(int costingVersionId)
        {
            CostingVersionId = costingVersionId;
        }
    }
}
