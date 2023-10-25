using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.BusinessLog
{
    public class ChangeBusinessLogsSagaData: CostingSagaDataBase
    {
        public ChangeBusinessLogsSagaData()
        {
            base.DisableFinFactors = true;
        }
    }
}
