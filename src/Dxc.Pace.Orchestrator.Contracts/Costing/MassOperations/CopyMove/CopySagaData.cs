using System.Collections.Generic;
using CscGet.Costing.Domain.Dispatcher.Events.BidManagement;
using Dxc.Captn.Costing.Contracts.Financial.CurrencyRisks.BidClientCountry;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;
using Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Common;
using Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.Shaping.Models;
using Newtonsoft.Json;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.CopyMove
{
    public class CopySagaData : CostingSagaDataBase, ICopyMoveData, IDeleteNodeDataProvider
    {
        public IReadOnlyCollection<CurrencyRisksClientCountryModel> BidClientCountries { get; set; }
        public BidState SourceBidState { get; set; }
        public BidState TargetBidState { get; set; }
        public CostGroupsFlags CostGroupsFlags { get; set; }
        public int SourceCostingVersionId { get; set; }
        public int TargetCostingVersionId { get; set; }

        [JsonProperty] bool IDeleteNodeDataProvider.IsTemplate { get; set; }

        [JsonProperty] bool IDeleteNodeDataProvider.HasCostGroup { get; set; }

        [JsonProperty] bool IDeleteNodeDataProvider.HasClientCountry { get; set; }

        [JsonProperty] bool IDeleteNodeDataProvider.HasRestrictionsToDelete { get; set; }

        [JsonProperty] bool IDeleteNodeDataProvider.HasNodeToDelete { get; set; }

        [JsonProperty] bool IDeleteNodeDataProvider.HasConvertToCustom { get; set; }

        [JsonProperty] bool IDeleteNodeDataProvider.HasBaselineMetric { get; set; }

        public bool HasService { get; set; }
        public bool HasHardware { get; set; }
        public bool HasSoftware { get; set; }
        public bool HasMiscellaneous { get; set; }
        public bool HasLabor { get; set; }
        public bool HasLaborRate { get; set; }

        public bool IsNotTemplateOperation => !((IDeleteNodeDataProvider)this).IsTemplate;

    }
}