using Dxc.Pace.Orchestrator.Contracts.BusinessLog;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Delete
{
    public interface IDeleteBusinessLogContext : IDeleteCostGroupsAndBaselineMetricsContext, IBusinessLogCountByLevelContext
    {
    }
}