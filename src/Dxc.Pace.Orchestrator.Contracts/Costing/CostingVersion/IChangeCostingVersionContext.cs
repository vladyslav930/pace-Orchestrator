using System;
using CscGet.Costing.Domain.Core;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;
using Dxc.Pace.Orchestrator.Contracts.Costing.LongRunningOperations.EditDateRange;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.CostingVersion
{
	public interface IChangeCostingVersionContext: IEditDateRangeRedisContext
	{
		IFlowSagaContextValue<string> Name { get; set; }
		IFlowSagaContextValue<Guid> CostingVersionNodeId { get; set; }
		IFlowSagaContextValue<DateRangeModel> OldDateRange { get; set; }
		IFlowSagaContextValue<DateRangeModel> NewDateRange { get; set; }
	}
}
