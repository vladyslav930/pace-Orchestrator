using System;
using Dxc.Captn.Costing.Contracts.LongRunningOperations.EditDateRange;
using Dxc.Captn.Costing.Contracts.Wbs.Levels;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.LongRunningOperations.EditDateRange
{
    public sealed class EditBidDateRangeSagaData : EditDateRangeBaseSagaData
    {
        public static EditBidDateRangeSagaData Create(int costingVersionId, Guid userId, NodeType nodeType, Guid nodeId, BidCostGroupChangeRangeDetails costGroupChangeRangeDetails)
        {
            return new EditBidDateRangeSagaData
            {
                CostingVersionId = costingVersionId,
                UserId = userId,
                NodeType = nodeType,
                Levels = Level.Create((int)nodeType, nodeId),
                BidStartDate = costGroupChangeRangeDetails.StartDate,
                BidEndDate = costGroupChangeRangeDetails.EndDate,
                BidPreviousStartDate = costGroupChangeRangeDetails.PreviousStartDate,
                BidPreviousEndDate = costGroupChangeRangeDetails.PreviousEndDate
            };
        }
    }
}