using FetchSignal.Domain.Models;
using FetchSignal.Infrastructure.Repositories.FetchedDataRepositories;

namespace FetchSignal.Application.Services.FetchedDataServices
{
    public class FetchedDataService: IFetchedDataService
    {
        protected readonly IFetchedDataRepository _fetchedDataRepository;
        public FetchedDataService(IFetchedDataRepository fetchedDataRepository)
        {
            _fetchedDataRepository = fetchedDataRepository;
        }

        public async Task<IEnumerable<FetchedData>> GetAllFetchedDatas()
        {
            return await _fetchedDataRepository.GetAll();
        }
        public async Task<FetchedData> GetFetchedDataById(int id)
        {
            return await _fetchedDataRepository.GetById(id);
        }
        public async Task<FetchedData> AddFetchedData(FetchedData fetchedData)
        {
            return await _fetchedDataRepository.Add(fetchedData);
        }
        public async Task<FetchedData> UpdateFetchedData(FetchedData fetchedData)
        {
            return await _fetchedDataRepository.Update(fetchedData);
        }
        public async Task DeleteFetchedData(int id)
        {
             await _fetchedDataRepository.Delete(id);
        }
    }
}
