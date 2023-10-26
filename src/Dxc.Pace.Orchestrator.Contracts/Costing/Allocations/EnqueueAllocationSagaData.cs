using System;
using Dxc.Pace.Infrastructure.FlowSagaEngine.Services;
using Dxc.Pace.Orchestrator.Contracts.Common;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.Allocations
{
    public class EnqueueAllocationSagaData : FlowSagaDataBase, ICostingVersionIdProvider, ILaunchSettings
    {
        public int CostingVersionId { get; set; }

        public bool ShouldUseDeferredQueue => false;

        public Guid QueueId { get; }
    }
}