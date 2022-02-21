using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportService.Business.ReportStatusService;

namespace ReportService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReportStatusController : ControllerBase
    {
        private readonly IReportStatusManager _reportStatusManager;

        public ReportStatusController(IReportStatusManager reportStatusManager)
        {
            this._reportStatusManager = reportStatusManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailsReport(string id)
        {
            var result = await _reportStatusManager.Get(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _reportStatusManager.GetAllAsync();
            return Ok(result);
        }
    }
}
