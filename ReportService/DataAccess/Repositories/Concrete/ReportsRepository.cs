using ReportService.DataAccess.Core;
using ReportService.DataAccess.Repositories.Abstract;
using ReportService.Entities.Concrete;
using Microsoft.Extensions.Options;

namespace ReportService.DataAccess.Repositories.Concrete
{

    public class ReportsRepository : MongoDbRepositoryBase<Report>, IReportDal
    {
        public ReportsRepository(IOptions<DatabaseSettings> options) : base(options)
        {
        }
    }
}
