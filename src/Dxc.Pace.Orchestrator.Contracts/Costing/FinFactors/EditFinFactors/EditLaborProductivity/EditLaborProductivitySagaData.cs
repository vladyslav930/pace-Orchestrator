using Dxc.Pace.Orchestrator.Contracts.Costing.Common;
using System;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.FinFactors.EditFinFactors.EditLaborProductivity
{

    public class EditLaborProductivitySagaData: CostingSagaDataBase
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public DateTime ChangeDate { get; set; }

        public EditLaborProductivitySagaData()
        {
            this.DisableFinFactors = true;
        }
    }
}
