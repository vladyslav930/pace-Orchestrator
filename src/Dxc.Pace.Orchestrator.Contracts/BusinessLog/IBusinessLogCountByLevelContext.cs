using Dxc.Pace.BusinessLog.Contracts;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;

namespace Dxc.Pace.Orchestrator.Contracts.BusinessLog
{
    public interface IBusinessLogCountByLevelContext
    {
        IFlowSagaContextValue<BusinessLogCountByLevel> BusinessLogCountByLevel { get; set; }
    }
}