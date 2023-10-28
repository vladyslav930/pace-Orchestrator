using Dxc.Pace.Orchestrator.Contracts.Costing.Common;
using Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Common;
using Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Delete;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.ConvertToCustom
{
    public interface IConvertToCustomContext : INotHiddenRestrictionsToDeleteContext, IConvertedNodesSagaContext, ICostingSagaContextBase
    {
    }
}