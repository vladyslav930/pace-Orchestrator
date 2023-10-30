using System;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.LongRunningOperations.EditDeliveryCountry
{
    public class EditDeliveryCountryData
    {
        public int CostingVersionId { get; set; }
        public Guid UserId { get; set; }
        public int SourceCountryId { get; set; }
        public int TargetCountryId { get; set; }
        public int BidState { get; set; }
    }
}
