namespace Dxc.Pace.Orchestrator.Contracts.Costing.LongRunningOperations.EditDeliveryCountry
{
    public class DeliveryCountryFlags
    {
        public bool HasLaborRatesElements { get; set; }
        public bool HasLaborElements { get; set; }
        public bool HasSoftwareElements { get; set; }
        public bool HasServiceElements { get; set; }
        public bool HasHardwareElements { get; set; }
        public bool AreServiceElementsChanged { get; set; }
        public bool AreHardwareElementsChanged { get; set; }
        public bool AreSoftwareElementsChanged { get; set; }
        public bool AreLaborRatesElementsChanged { get; set; }
        public bool AreLaborElementsChanged { get; set; }
    }
}