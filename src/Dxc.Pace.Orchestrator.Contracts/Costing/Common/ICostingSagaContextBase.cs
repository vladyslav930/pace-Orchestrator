using System;
using Dxc.Captn.Costing.Contracts.Reports;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;
using Dxc.Pace.Infrastructure.FlowSagaEngine.Utils;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.Common
{
    public interface ICostingSagaContextBase
    {
        /// <summary>
        /// CostGroups for which will be applied FinFactors calculation
        /// </summary>
        [IgnoreOnSagaFinalization]
        IFlowSagaContextRepository<Guid> CostGroupIds { get; set; }

        /// <summary>
        /// ReportTypes for which will be send ReportRecalculationNotification
        /// </summary>
        [IgnoreOnSagaFinalization]        
        IFlowSagaContextRepository<ReportType> ReportTypes { get; set; }
    }
}
