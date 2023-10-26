using System;
using Dxc.Pace.CostingReports.Contracts.Reporting;

namespace Dxc.Pace.Orchestrator.Contracts.Common.Reporting
{
    public class ReportExportResult
    {
        public Guid ReportId { get; set; }

        public int CostingVersionId { get; set; }

        public Guid UserId { get; set; }

        public Guid FileId { get; set; }

        public CostingReportType ExportType { get; set; }

        public CostType CostType { get; set; }

        public string FileName { get; }
    }
}