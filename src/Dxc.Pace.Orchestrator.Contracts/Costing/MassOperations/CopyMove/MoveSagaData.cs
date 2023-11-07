using CscGet.Costing.Domain.Dispatcher.Events.BidManagement;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;
using Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Common;
using Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Shaping.Models;
using Newtonsoft.Json;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.CopyMove
{
    public class MoveSagaData : CostingSagaDataBase, ICopyMoveData, IDeleteNodeDataProvider
    {
        public int SourceCostingVersionId { get; set; }
        public BidState SourceBidState { get; set; }


        public int TargetCostingVersionId { get; set; }
        public BidState TargetBidState { get; set; }

        public CostGroupsFlags CostGroupsFlags { get; set; }
        
        public bool NeedMoveInflations { get; set; }
        
        
        [JsonProperty]
        bool IDeleteNodeDataProvider.IsTemplate { get; set; }

        [JsonProperty]
        bool IDeleteNodeDataProvider.HasCostGroup { get; set; }
        
        [JsonProperty]
        bool IDeleteNodeDataProvider.HasClientCountry { get; set; }

        [JsonProperty]
        bool IDeleteNodeDataProvider.HasRestrictionsToDelete { get; set; }

        [JsonProperty]
        bool IDeleteNodeDataProvider.HasNodeToDelete { get; set; }

        [JsonProperty]
        bool IDeleteNodeDataProvider.HasConvertToCustom { get; set; }

        [JsonProperty]
        bool IDeleteNodeDataProvider.HasBaselineMetric { get; set; }

        bool IDeleteNodeDataProvider.HasService { get => CostGroupsFlags.HasServiceCostGroupsToDelete; set => CostGroupsFlags.HasServiceCostGroupsToDelete = value; }

        bool IDeleteNodeDataProvider.HasHardware { get => CostGroupsFlags.HasHardwareCostGroupsToDelete; set => CostGroupsFlags.HasHardwareCostGroupsToDelete = value; }

        bool IDeleteNodeDataProvider.HasSoftware { get => CostGroupsFlags.HasSoftwareCostGroupsToDelete; set => CostGroupsFlags.HasSoftwareCostGroupsToDelete = value; }

        bool IDeleteNodeDataProvider.HasMiscellaneous { get => CostGroupsFlags.HasMiscellaneousCostGroupsToDelete; set => CostGroupsFlags.HasMiscellaneousCostGroupsToDelete = value; }

        bool IDeleteNodeDataProvider.HasLabor { get => CostGroupsFlags.HasLaborCostGroupsToDelete; set => CostGroupsFlags.HasLaborCostGroupsToDelete = value; }

        bool IDeleteNodeDataProvider.HasLaborRate { get => CostGroupsFlags.HasLaborRatesCostGroupsToDelete; set => CostGroupsFlags.HasLaborRatesCostGroupsToDelete = value; }

        public bool IsNotTemplateOperation => !((IDeleteNodeDataProvider) this).IsTemplate;

    }
}