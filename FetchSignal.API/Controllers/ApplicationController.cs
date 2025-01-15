using FetchSignal.Application.Services.ApplicationsServices;
using Microsoft.AspNetCore.Mvc;

namespace FetchSignal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationController: ControllerBase
    {
        protected readonly IApplicationService _applicationService;
        public ApplicationController(IApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public async  Task<IActionResult> GetApplications()
        {
            var applications = await _applicationService.GetAllApplications();
            return Ok(applications);
        }
        [HttpGet]
        [Route("{id}")]
        public async  Task<IActionResult> GetApplication(int id)
        {
            var application = await _applicationService.GetApplicationById(id);
            return Ok(application);
        }
        [HttpPost]
        public async Task<IActionResult> CreateApplication(Domain.Models.Application application)
        {
            var newApplication = await _applicationService.AddApplication(application);
            return Ok(application);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateApplication(Domain.Models.Application application)
        {
            var updatedApplication = await _applicationService.UpdateApplication(application);
            return Ok(updatedApplication);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteApplication(int id)
        {
            await _applicationService.DeleteApplication(id);
            return Ok();
        }
    }
}
