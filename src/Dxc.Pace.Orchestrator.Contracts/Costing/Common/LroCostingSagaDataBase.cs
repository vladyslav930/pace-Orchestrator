using System;

namespace Dxc.Pace.Orchestrator.Contracts.Costing.Common
{
    public abstract class LroCostingSagaDataBase: CostingSagaDataBase
    {
        public Level[] Levels { get; set; }
    }
}
