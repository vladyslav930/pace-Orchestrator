using System;
using System.Collections.Generic;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.LongRunningOperations.EditAmortization
{
    public class EditAmortizationSagaData : LroCostingSagaDataBase
    {
        public Guid UserId { get; set; }
        public DateTime? GoLiveDate { get; set; }
        public bool? ApplyAmortization { get; set; }
        public int? AmortizationsMonths { get; set; }
        public bool HasCostGroupIds { get; set; }
        public IEnumerable<string> GroupCodes { get; set; }

    }
}