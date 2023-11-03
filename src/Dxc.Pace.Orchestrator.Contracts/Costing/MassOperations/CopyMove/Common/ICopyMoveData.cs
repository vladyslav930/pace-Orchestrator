using Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Shaping.Models;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.CopyMove
{
    public interface ICopyMoveData
    {
        CostGroupsFlags CostGroupsFlags { get; set; }
        int SourceCostingVersionId { get; set; }
        int TargetCostingVersionId { get; set; }
    }
}