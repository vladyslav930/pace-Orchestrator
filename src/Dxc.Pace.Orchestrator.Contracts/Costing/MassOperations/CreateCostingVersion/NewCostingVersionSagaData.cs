using CscGet.Costing.Domain.Types;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;
using Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.CreateCostingVersion.Shared;
using System;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.MassOperations.CreateCostingVersion
{
    public class NewCostingVersionSagaData : CostingSagaDataBase, IElementCopyData
    {
        #region properties from IElementCopyData
        public Guid UserId { get; set; }
        public int BidId { get; set; }
        public int SourceCostingVersionId { get; set; }
        public int TargetCostingVersionId { get; set; }
        public DateRange BidRange { get; set; }
        #endregion

        public int VersionNumber { get; set; }

        public bool BidNameChanged { get; set; }
    }
}
