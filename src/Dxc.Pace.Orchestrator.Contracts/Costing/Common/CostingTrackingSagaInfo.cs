using System;
using System.Collections.Generic;
using System.Text;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.Common
{
    public class CostingTrackingSagaInfo : TrackingSagaInfoBase
    {
        public bool IsProgressNotificationRequired { get; set; }
        public Guid? UserId { get; set; }
        public string ChainName { get; set; }
    }
}
