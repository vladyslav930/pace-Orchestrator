using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.ConvertToCustom
{
    public class ConvertToCustomSagaData : CostingSagaDataBase
    {
        public bool HasConvertToCustom { get; set; }

        public bool HasRestrictionsToDelete { get; set; }

        public ConvertToCustomSagaData()
        {
            this.DisableFinFactors = true;
            this.DisableCalculatingFlagManipulation = true;
        }
    }
}