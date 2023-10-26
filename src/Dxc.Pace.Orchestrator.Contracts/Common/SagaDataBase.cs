using System;

namespace Dxc.Pace.Orchestrator.Contracts.Common
{
    public class FlowSagaDataBase
    {
        public DateTime InitTime { get; set; }

        public FlowSagaDataBase()
        {
            InitTime = DateTime.UtcNow;
        }
    }
}
