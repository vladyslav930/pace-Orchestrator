using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.LongRunningOperations.EditShoring
{
    public class EditShoringSagaData: CostingSagaDataBase
    {
        public EditShoringSagaData()
        {
            this.DisableFinFactors = true;
            this.DisableCalculatingFlagManipulation = true;
        }
    }
}