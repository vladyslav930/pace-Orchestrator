using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.GlobalTotal
{
    public sealed class CreateGlobalTotalSagaData : CostingSagaDataBase
    {
        public CreateGlobalTotalSagaData()
        {
            base.DisableFinFactors = true;
        }
    }
}
