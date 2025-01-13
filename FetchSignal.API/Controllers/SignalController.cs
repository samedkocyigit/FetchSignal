using FetchSignal.Application.Services.SignalServices;
using Microsoft.AspNetCore.Mvc;

namespace FetchSignal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SignalController : ControllerBase
    {
        protected readonly ISignalService _signalService;
        public SignalController(ISignalService signalService)
        {
            _signalService = signalService;
        }

        [HttpPost("with-recurring-job")]
        public async Task<IActionResult> FetchSignalsRecurringJobs()
        {
            var urls = new List<string>()
            {
                "https://www.w3schools.com/xml/plant_catalog.xml",
                "https://www.tcmb.gov.tr/kurlar/today.xml"
            };
            await _signalService.FetchDataFromUrl(urls);
            return Ok("Recurring Fetch Data Job Started");
        }
    }
}
