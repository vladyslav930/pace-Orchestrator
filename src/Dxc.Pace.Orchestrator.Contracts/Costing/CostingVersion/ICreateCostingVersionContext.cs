using System;
using CscGet.Costing.Domain.Dispatcher.Events.BidManagement;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.CostingVersion
{
	public interface ICreateCostingVersionContext: ICostingSagaContextBase
	{
		IFlowSagaContextValue<string> Name { get; set; }
		IFlowSagaContextValue<DateTime> StartDate { get; set; }
		IFlowSagaContextValue<DateTime> EndDate { get; set; }
		IFlowSagaContextValue<BidState> State { get; set; }
	}
}
