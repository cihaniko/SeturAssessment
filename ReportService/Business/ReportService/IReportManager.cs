using ReportService.Entities.Concrete;
using ReportService.Entities.Dto;
using ReportService.Utilities.Result;

namespace ReportService.Business.ReportService
{
    public interface IReportManager
    {
        Task<ResultModel<List<Report>>> StatisticReportByAllLocation();
    }
}