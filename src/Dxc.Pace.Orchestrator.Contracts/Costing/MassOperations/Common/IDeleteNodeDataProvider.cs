using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Common
{
    public interface IDeleteNodeDataProvider : ICostingVersionIdProvider
    {
        bool IsTemplate { get; set; }
        bool HasCostGroup { get; set; }

        bool HasClientCountry { get; set; }

        bool HasRestrictionsToDelete { get; set; }

        bool HasNodeToDelete { get; set; }

        bool HasConvertToCustom { get; set; }

        bool HasBaselineMetric { get; set; }

        bool HasService { get; set; }

        bool HasHardware { get; set; }

        bool HasSoftware { get; set; }

        bool HasMiscellaneous { get; set; }

        bool HasLabor { get; set; }
        
        bool HasLaborRate { get; set; }
    }
}
