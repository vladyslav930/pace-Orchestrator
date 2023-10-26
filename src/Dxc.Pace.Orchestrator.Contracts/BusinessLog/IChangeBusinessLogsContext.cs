using CscGet.Costing.Domain.Dispatcher.Events.BusinessLog;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.BusinessLog
{
    public interface IChangeBusinessLogsContext: IBusinessLogCountByLevelContext, ICostingSagaContextBase
    {
        IFlowSagaContextRepository<ChangeBusinessLogs> ChangeBusinessLogs { get; set; }

        IFlowSagaContextRepository<AddBusinessLogs> BusinessLogsToAdd { get; set; }

        IFlowSagaContextRepository<RemoveBusinessLogsOptionalSource> BusinessLogsToRemove { get; set; }
    }
}
