using ReportService.Entities.Concrete;
using ReportService.Utilities.Result;

namespace ReportService.Business.ReportStatusService
{
    public interface IReportStatusManager
    {
        Task<IResultModel> Add(ReportStatus report);
        Task<IResultModel<ReportStatus>> Get(string id);
        IResultModel GetAllAsync();
        Task<IResultModel> UpdateAsync(ReportStatus report);
    }
}