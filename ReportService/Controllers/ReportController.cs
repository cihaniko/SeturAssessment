using Microsoft.AspNetCore.Mvc;
using ReportService.Business.ReportService;
using ReportService.Entities.RabbitMqModels;
using ReportService.Utilities.Constants;
using ReportService.Utilities.RabbitMq;
using ReportService.Utilities.Result;

namespace ReportService.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ReportController : ControllerBase
    {


        private readonly ILogger<ReportController> _logger;
        private readonly IReportManager _reportManager;
        private readonly IRabbitMqProducerHelper _rabbitMqProducer;

        public ReportController(ILogger<ReportController> logger, IReportManager reportManager, IRabbitMqProducerHelper rabbitMqProducer)
        {
            _logger = logger;
            this._reportManager = reportManager;
            this._rabbitMqProducer = rabbitMqProducer;
        }

        [HttpGet]
        public async Task<IActionResult> GetStatisticsReportByAllLocationAsync()
        {
            _rabbitMqProducer.SendMessageQueue(new MessagesModel() { ReportName = "LocationReport" });

            return Ok(new ResultModel() { IsSuccess=true,Message=ResultMessages.SuccessMessage});
        }
    }
}