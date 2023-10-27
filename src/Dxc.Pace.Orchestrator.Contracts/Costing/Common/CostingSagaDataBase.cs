using Dxc.Pace.Infrastructure.Core.Utils;
using Dxc.Pace.Infrastructure.FlowSagaEngine.Services;
using Dxc.Pace.Orchestrator.Contracts.Common;
using System;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.Common
{
    public abstract class CostingSagaDataBase: FlowSagaDataBase, ICostingVersionIdProvider, ILaunchSettings
    {
        public int CostingVersionId { get; set; }
        public bool DisableFinFactors { get; set; }
        public bool DisableCalculatingFlagManipulation { get; set; }
        public virtual bool ShouldUseDeferredQueue => true;
        public Guid QueueId => IntToGuidConverter.IntToGuid(CostingVersionId);       
    }
}
