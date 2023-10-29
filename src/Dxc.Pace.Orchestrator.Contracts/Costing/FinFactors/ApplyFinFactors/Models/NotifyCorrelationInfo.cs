using System;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.FinFactors.ApplyFinFactors.Models
{
    public class NotifyCorrelationInfo
    {
        public Guid CorrelationId { get; set; }
        public CostingTrackingSagaInfo[] CostingTrackingSagaInfos { get; set; }
    }
}
