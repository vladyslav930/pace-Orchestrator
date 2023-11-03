using System;
using CscGet.Costing.Domain.Dispatcher.Models.Quantities;
using Dxc.Captn.Costing.Contracts.LongRunningOperations.EditTax.Models;
using Dxc.Pace.Hardware.Contracts.LongRunningOperations.EditTax.Models;
using Dxc.Pace.Infrastructure.FlowSagaEngine.SagaContext;
using Dxc.Pace.Labor.Contracts.LongRunningOperations.EditTax.Models;
using Dxc.Pace.LaborRates.Contracts.LongRunningOperations.EditTax.Models;
using Dxc.Pace.Miscellaneous.Contracts.LongRunningOperations.EditTax.Models;
using Dxc.Pace.Orchestrator.Contracts.Costing.Common;
using Dxc.Pace.Software.Contracts.LongRunningOperations.EditTax.Models;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.LongRunningOperations.EditTax
{
    public interface IEditTaxSagaContext : ICostingSagaContextBase
    {
        IFlowSagaContextRepository<SoftwareCostGroupTax> SoftwareTaxes { get; set; }
        IFlowSagaContextRepository<MiscellaneousCostGroupTax> MiscellaneousTaxes { get; set; }
        IFlowSagaContextRepository<HardwareCostGroupTax> HardwareTaxes { get; set; }
        IFlowSagaContextRepository<LaborCostGroupTax> LaborTaxes { get; set; }
        IFlowSagaContextRepository<ServiceCostGroupTax> ServiceTaxes { get; set; }
        IFlowSagaContextRepository<LaborRatesCostGroupTax> LaborRatesTaxes { get; set; }

        IFlowSagaContextRepository<Guid> LaborRatesCostGroupIdsToRecalculate { get; set; }
        
        IFlowSagaContextRepository<QuantityCalculatedModel> CalculatedLaborRatesModels { get; set; }
    }
}