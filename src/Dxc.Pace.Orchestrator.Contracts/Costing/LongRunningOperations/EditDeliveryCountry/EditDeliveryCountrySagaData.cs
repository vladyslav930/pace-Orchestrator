using System;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.LongRunningOperations.EditDeliveryCountry
{
    public class EditDeliveryCountrySagaData : LroCostingSagaDataBase
    {
        public EditDeliveryCountrySagaData()
        {
            Flags = new DeliveryCountryFlags();
        }

        public int BidId { get; set; }
        public Guid UserId { get; set; }
        public int SourceCountryId { get; set; }
        public int TargetCountryId { get; set; }
        public int BidState { get; set; }

        public DeliveryCountryFlags Flags { get; set; }
    }
}
