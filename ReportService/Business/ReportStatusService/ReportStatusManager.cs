using ReportService.DataAccess.Repositories.Abstract;
using ReportService.Entities.Concrete;
using ReportService.Entities.Dto;
using ReportService.Utilities.Constants;
using ReportService.Utilities.Result;
using System.Text.Json;

namespace ReportService.Business.ReportStatusService
{
    public class ReportStatusManager : IReportStatusManager
    {
        private readonly IReportStatusDal _reportStatusDal;

        public ReportStatusManager(IReportStatusDal reportStatusDal)
        {
            this._reportStatusDal = reportStatusDal;
        }

        public async Task<IResultModel> Add(ReportStatus report)
        {
            await _reportStatusDal.AddAsync(report);

            return new ResultModel() { IsSuccess = true, Message = ResultMessages.SuccessMessage };
        }

        public async Task<IResultModel> UpdateAsync(ReportStatus report)
        {
            await _reportStatusDal.UpdateAsync(report.Id, report);

            return new ResultModel() { IsSuccess = true, Message = ResultMessages.SuccessMessage };
        }
        public async Task<IResultModel<ReportDetail>> Get(string id)
        {
            ReportStatus result = await _reportStatusDal.GetByIdAsync(id);
            ReportDetail detail = new ReportDetail
            {
                CreatedAt = result.CreatedAt,
                Details = JsonSerializer.Deserialize<List<ReportDto>>(result.ReportDetail)
            };

            return new ResultModel<ReportDetail>() { IsSuccess = true, Message = ResultMessages.SuccessMessage, Data = detail };
        }

        public async Task<IResultModel> GetAllAsync()
        {
            IQueryable<ReportStatus> result = _reportStatusDal.Get();

            return new ResultModel<IQueryable<ReportStatus>>() { IsSuccess = true, Message = ResultMessages.SuccessMessage, Data = result };
        }


    }
}
