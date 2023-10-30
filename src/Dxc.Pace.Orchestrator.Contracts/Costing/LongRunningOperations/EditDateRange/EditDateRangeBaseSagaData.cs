using System;
using Dxc.Captn.Costing.Contracts.Wbs.Levels;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.LongRunningOperations.EditDateRange
{
    public class EditDateRangeBaseSagaData : LroCostingSagaDataBase
    {
        public Guid UserId { set; get; }

        public NodeType NodeType { get; set; }

        public DateTime? LevelStartDate { get; set; }

        public DateTime? LevelEndDate { get; set; }

        public int? Duration { get; set; }

        public DateTime BidStartDate { get; set; }

        public DateTime BidEndDate { get; set; }

        public DateTime BidPreviousStartDate { get; set; }

        public DateTime BidPreviousEndDate { get; set; }

        public DateTime StartDate { set; get; }

        public DateTime EndDate { set; get; }

        public bool CostGroupExists { set; get; }

        public bool ApplyFinFactors { set; get; }
    }
}