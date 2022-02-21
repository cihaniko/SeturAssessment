using ReportService.DataAccess.Repositories.Abstract;
using ReportService.Entities.Concrete;
using ReportService.Utilities.Constants;
using ReportService.Utilities.Result;

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
        public async Task<IResultModel<ReportStatus>> Get(string id)
        {
            ReportStatus result = await _reportStatusDal.GetByIdAsync(id);

            return new ResultModel<ReportStatus>() { IsSuccess = true, Message = ResultMessages.SuccessMessage, Data = result };
        }

        public IResultModel GetAllAsync()
        {
            IQueryable<ReportStatus> result = _reportStatusDal.Get();

            return new ResultModel<IQueryable<ReportStatus>>() { IsSuccess = true, Message = ResultMessages.SuccessMessage, Data = result };
        }


    }
}
