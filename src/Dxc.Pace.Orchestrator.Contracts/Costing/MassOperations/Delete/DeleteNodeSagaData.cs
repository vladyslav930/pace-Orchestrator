using Dxc.Pace.Orchestrator.Contracts.Costing.Common;
using Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Common;
using BidState = CscGet.Costing.Domain.Dispatcher.Events.BidManagement.BidState;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Delete
{
    public class DeleteNodeSagaData : CostingSagaDataBase, IDeleteNodeDataProvider
    {
        public static DeleteNodeSagaData Create(
            int costingVersionId, bool hasCostGroup, bool hasBaselineMetric, bool hasNodeToDelete, bool hasSumValSumCost, bool hasGlobalTotal, bool hasClientCountry,
            bool hasHardwareCapitalSupport, bool hasMiscellaneous, bool hasServiceGroup, bool hasSoftwareGroup, bool hasLaborGroup, bool hasLaborRatesGroup)
        {
            return new DeleteNodeSagaData
            {
                CostingVersionId = costingVersionId,
                HasCostGroup = hasCostGroup,
                HasBaselineMetric = hasBaselineMetric,
                HasNodeToDelete = hasNodeToDelete,
                HasSumValSumCost = hasSumValSumCost,
                HasGlobalTotal = hasGlobalTotal,
                HasClientCountry = hasClientCountry,
                HasHardware = hasHardwareCapitalSupport,
                HasMiscellaneous = hasMiscellaneous,
                HasService = hasServiceGroup,
                HasSoftware = hasSoftwareGroup,
                HasLabor = hasLaborGroup,
                HasLaborRate = hasLaborRatesGroup
            };
        }

        public bool IsTemplate { get; set; }

        public BidState BidState { get; set; }

        public bool HasCostGroup { get; set; }

        public bool HasClientCountry { get; set; }

        public bool HasRestrictionsToDelete { get; set; }

        public bool HasNodeToDelete { get; set; }

        public bool HasConvertToCustom { get; set; }

        public bool HasBaselineMetric { get; set; }

        public bool HasGlobalTotal { get; set; }

        public bool HasSumValSumCost { get; set; }

        public bool HasService { get; set; }

        public bool HasHardware { get; set; }

        public bool HasSoftware { get; set; }

        public bool HasMiscellaneous { get; set; }

        public bool HasLabor { get; set; }

        public bool HasLaborRate { get; set; }
    }
}