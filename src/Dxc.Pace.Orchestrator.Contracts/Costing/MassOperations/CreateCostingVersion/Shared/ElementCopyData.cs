using CscGet.Costing.Domain.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.CreateCostingVersion.Shared
{
    public class ElementCopyData : IElementCopyData
    {
        public Guid UserId { get; set; }
        public int BidId { get; set; }
        public int SourceCostingVersionId { get; set; }
        public int TargetCostingVersionId { get; set; }
        public DateRange BidRange { get; set; }
    }
}
