using ReportService.DataAccess.Core;
using ReportService.DataAccess.Repositories.Abstract;
using ReportService.Entities.Concrete;
using Microsoft.Extensions.Options;

namespace ReportService.DataAccess.Repositories.Concrete
{
  
    public class ReportStatusRepository : MongoDbRepositoryBase<ReportStatus>, IReportStatusDal
    {
        public ReportStatusRepository(IOptions<DatabaseSettings> options) : base(options)
        {
        }
    }
}
