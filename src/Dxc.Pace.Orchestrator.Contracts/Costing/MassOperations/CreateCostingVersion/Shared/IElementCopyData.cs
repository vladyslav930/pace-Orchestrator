using CscGet.Costing.Domain.Dispatcher.Events.Wbs.CostGroups.Models;
using CscGet.Costing.Domain.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.CreateCostingVersion.Shared
{
    public interface IElementCopyData
    {
        Guid UserId { get; set; }
        int BidId { get; set; }
        int SourceCostingVersionId { get; set; }
        int TargetCostingVersionId { get; set; }
        DateRange BidRange { get; set; }
    }
}
