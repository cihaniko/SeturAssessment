using ReportService.Entities.Concrete;
using ReportService.Entities.Dto;
using ReportService.Utilities.Result;

namespace ReportService.Business.ReportStatusService
{
    public interface IReportStatusManager
    {
        Task<IResultModel> Add(ReportStatus report);
        Task<IResultModel<ReportDetail>> Get(string id);
        Task<IResultModel> GetAllAsync();
        Task<IResultModel> UpdateAsync(ReportStatus report);
    }
}