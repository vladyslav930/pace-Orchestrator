using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.BusinessLog
{
    public class AddBusinessLogsSagaData : CostingSagaDataBase
    {
        public AddBusinessLogsSagaData()
        {
            DisableFinFactors = true;
        }
    }
}