using Dxc.Pace.Orchestrator.Contracts.Costing.Common;
using System;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.LongRunningOperations.EditDeliveryPhase
{
    public class EditDeliveryPhaseSagaData : LroCostingSagaDataBase
    {
        public Guid UserId { get; set; }
        public int CurrentDeliveryPhaseId { get; set; }
        public int NewDeliveryPhaseId { get; set; }
        public bool HasCostGroupIds { get; set; }
    }
}
