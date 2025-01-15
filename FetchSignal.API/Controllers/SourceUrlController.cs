using FetchSignal.Application.Services.SourceUrlServices;
using Microsoft.AspNetCore.Mvc;

namespace FetchSignal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 

    public class SourceUrlController:ControllerBase
    {
        protected readonly ISourceUrlService _sourceUrlService;
        public SourceUrlController(ISourceUrlService sourceUrlService)
        {
            _sourceUrlService = sourceUrlService;
        }

        [HttpGet]   
        public async Task<IActionResult> GetSourceUrls()
        {
            var sourceUrls = await _sourceUrlService.GetAllSourceUrls();
            return Ok(sourceUrls);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetSourceUrl(int id)
        {
            var sourceUrl = await _sourceUrlService.GetSourceUrlById(id);
            return Ok(sourceUrl);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSourceUrl(Domain.Models.SourceUrl sourceUrl)
        {
            var newSourceUrl = await _sourceUrlService.AddSourceUrl(sourceUrl);
            return Ok(newSourceUrl);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSourceUrl(Domain.Models.SourceUrl sourceUrl)
        {
            var updatedSourceUrl = await _sourceUrlService.UpdateSourceUrl(sourceUrl);
            return Ok(updatedSourceUrl);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSourceUrl(int id)
        {
            await _sourceUrlService.DeleteSourceUrl(id);
            return Ok();
        }
    }
}
