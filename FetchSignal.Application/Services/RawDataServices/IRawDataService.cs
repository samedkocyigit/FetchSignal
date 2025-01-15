using FetchSignal.Domain.Dtos;
using FetchSignal.Domain.Models;
using FetchSignal.Domain.Wrapper;

namespace FetchSignal.Application.Services.RawDataServices
{
    public interface IRawDataService
    {
        Task<ApiResult<List<RawDataDto>>> GetAllRawDatas();
        Task<ApiResult<RawDataDto>> GetRawDataById(int id);
        Task<ApiResult<RawDataDto>> AddRawData(RawData rawData);
        void UpdateRawData(RawData rawData);
        Task DeleteRawData(int id);
        Task FetchDataFromUrl();
    }
}
