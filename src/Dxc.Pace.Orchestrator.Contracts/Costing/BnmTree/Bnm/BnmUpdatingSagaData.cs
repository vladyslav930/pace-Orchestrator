using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.BnmTree.Bnm
{
    /// <summary>
    /// Baseline or metric
    /// </summary>
    public class BnmUpdatingSagaData : CostingSagaDataBase
    {
        public bool UpdateSvSc { get; set; }
    }
}