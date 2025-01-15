using FetchSignal.Application.Services.RawDataServices;
using FetchSignal.Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FetchSignal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RawDataController:ControllerBase
    {
        protected readonly IRawDataService _rawDataService;
        public RawDataController(IRawDataService rawDataService)
        {
            _rawDataService = rawDataService;
        }
        //[HttpPost("with-url")]
        //public async Task<IActionResult> FetchRawDataFromUrl(string url)
        //{
        //    await _rawDataService.FetchDataFromUrl(url);
        //    return Ok("Data fetched from url");
        //}
        [HttpPost("without-url")]
        public async Task<IActionResult> FetchRawData()
        {
            await _rawDataService.FetchDataFromUrl();
            return Ok("Data fetched from url");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRawDatas()
        {
            var response = await _rawDataService.GetAllRawDatas();
            if(response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRawDataById(int id)
        {
            var response = await _rawDataService.GetRawDataById(id);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRawData(int id)
        {
            await _rawDataService.DeleteRawData(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> AddRawData(RawData rawData)
        {
            var response = await _rawDataService.AddRawData(rawData);
            if (response != null)
            {
                return Ok(response);
            }
            return BadRequest();
        }
        [HttpPatch]
        public IActionResult UpdateRawData(RawData rawData)
        {
            _rawDataService.UpdateRawData(rawData);
            return Ok();
        }
    }
}
