using System;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.Common
{
    public abstract class TrackingSagaInfoBase
    {
        public Guid CorrelationId { get; set; }
        public DateTime StartTime { get; set; }
    }
}
