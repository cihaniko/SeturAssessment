using Microsoft.AspNetCore.Mvc;
using ReportService.Business.ReportService;

namespace ReportService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReportController : ControllerBase
    {


        private readonly ILogger<ReportController> _logger;
        private readonly IReportManager _reportManager;

        public ReportController(ILogger<ReportController> logger, IReportManager reportManager)
        {
            _logger = logger;
            this._reportManager = reportManager;
        }

        [HttpGet]
        public async Task<bool> GetStatisticsReportByAllLocationAsync()
        {
            await _reportManager.StatisticReportByAllLocation();
            return true;
        }
    }
}