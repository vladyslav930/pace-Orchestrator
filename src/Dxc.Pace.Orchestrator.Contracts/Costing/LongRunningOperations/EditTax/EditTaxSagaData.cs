using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.LongRunningOperations.EditTax
{
    public class EditTaxSagaData : LroCostingSagaDataBase
    {
        public int BidState { get; set; }
    }
}