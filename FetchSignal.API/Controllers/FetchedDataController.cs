using FetchSignal.Application.Services.FetchedDataServices;
using FetchSignal.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace FetchSignal.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]

    public class FetchedDataController : ControllerBase
    {
        protected readonly IFetchedDataService _fetchedDataService;
        public FetchedDataController(IFetchedDataService fetchedDataService)
        {
            _fetchedDataService = fetchedDataService;
        }
        [HttpGet]
        public async Task<IEnumerable<FetchedData>> GetAllFetchedDatas()
        {
            return await _fetchedDataService.GetAllFetchedDatas();
        }
        [HttpGet("{id}")]
        public async Task<FetchedData> GetFetchedDataById(int id)
        {
            return await _fetchedDataService.GetFetchedDataById(id);
        }
        [HttpPost]
        public async Task<FetchedData> AddFetchedData(FetchedData fetchedData)
        {
            return await _fetchedDataService.AddFetchedData(fetchedData);
        }
        [HttpPut]
        public async Task<FetchedData> UpdateFetchedData(FetchedData fetchedData)
        {
            return await _fetchedDataService.UpdateFetchedData(fetchedData);
        }
        [HttpDelete("{id}")]
        public async Task DeleteFetchedData(int id)
        {
            await _fetchedDataService.DeleteFetchedData(id);
        }

    }
}
