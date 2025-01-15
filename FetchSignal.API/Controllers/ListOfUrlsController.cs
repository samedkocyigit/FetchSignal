using FetchSignal.Application.Services.ListOfUrlsServices;
using FetchSignal.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FetchSignal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListOfUrlsController:ControllerBase
    {
        protected readonly IListOfUrlsService _listOfUrlsService;
        public ListOfUrlsController(IListOfUrlsService listOfUrlsService)
        {
            _listOfUrlsService = listOfUrlsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllListedUrls()
        {
            var result = await _listOfUrlsService.GetAllListedUrls();
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetListOfUrlById(int id)
        {
            var result = await _listOfUrlsService.GetListOfUrlById(id);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddListOfUrl(ListOfUrls listOfUrls)
        {
            var result = await _listOfUrlsService.AddListOfUrl(listOfUrls);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateListOfUrl(ListOfUrls listOfUrls)
        {
            var result = await _listOfUrlsService.UpdateListOfUrl(listOfUrls);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListOfUrl(int id)
        {
            await _listOfUrlsService.DeleteListOfUrl(id);
            return Ok();
        }
    }
}
