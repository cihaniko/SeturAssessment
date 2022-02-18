using Microsoft.AspNetCore.Mvc;

namespace ContactService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactsController : ControllerBase
    {
  
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(ILogger<ContactsController> logger)
        {
            _logger = logger;
        }

        //[HttpGet(Name = "Get")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}