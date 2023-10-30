using System;
using Dxc.Captn.Costing.Contracts.LongRunningOperations.EditDateRange;
using Dxc.Captn.Costing.Contracts.Wbs.Levels;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.LongRunningOperations.EditDateRange
{
    public sealed class EditDateRangeSagaData : EditDateRangeBaseSagaData
    {
        public static EditDateRangeSagaData Create(int costingVersionId, Guid userId, NodeType nodeType, Guid nodeId, LevelCostGroupChangeRangeDetails costGroupChangeRangeDetails)
        {
            return new EditDateRangeSagaData
            {
                CostingVersionId = costingVersionId,
                UserId = userId,
                NodeType = nodeType,
                Levels = Level.Create((int)nodeType, nodeId),
                LevelStartDate = costGroupChangeRangeDetails.StartDate,
                LevelEndDate = costGroupChangeRangeDetails.EndDate,
                Duration = costGroupChangeRangeDetails.Duration
            };
        }
    }
}
