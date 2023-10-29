namespace Dxc.Pace.Orchestrator.Contracts.Costing.FinFactors.ApplyFinFactors
{
    public class ApplyFinFactorsSagaEndedRequest
    {
        public int CostingVersionId { get; set; }

        public ApplyFinFactorsSagaEndedRequest(int costingVersionId)
        {
            CostingVersionId = costingVersionId;
        }
    }
}
