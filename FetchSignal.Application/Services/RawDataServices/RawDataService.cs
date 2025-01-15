using AutoMapper;
using FetchSignal.Application.Services.ListOfUrlsServices;
using FetchSignal.Domain.Dtos;
using FetchSignal.Domain.Models;
using FetchSignal.Domain.Wrapper;
using FetchSignal.Infrastructure.Repositories.RawDataRepositories;
using Microsoft.Extensions.Logging;

namespace FetchSignal.Application.Services.RawDataServices
{
    public class RawDataService : IRawDataService
    {
        protected readonly IRawDataRepository _rawDataRepository;
        protected readonly ILogger<RawDataService> _logger;
        protected readonly IListOfUrlsService _listOfUrlsService;
        protected readonly IMapper _mapper;
        public RawDataService(IRawDataRepository rawDataRepository,ILogger<RawDataService> logger,IMapper mapper,IListOfUrlsService  listOfUrlsService)
        {
            _rawDataRepository = rawDataRepository;
            _listOfUrlsService = listOfUrlsService;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task FetchDataFromUrl()
        {
            try
            {
                var urls = await _listOfUrlsService.GetAllListedUrls();
                if (urls.Count < 1)
                {
                    throw new Exception("No URLs found");
                }
                else
                {
                    foreach (var item in urls)
                    {

                        if (item.Extension=="XML")
                        {
                            var client = new HttpClient();
                            var response = await client.GetStringAsync(item.Url);
                    

                            var application = new Domain.Models.Application
                            {
                                Name = item.ApplicationName,
                            };
                            var sourceUrl = new SourceUrl
                            {
                                Url = item.Url,
                                Application = application
                            };
                            var fetchedData = new FetchedData
                            {
                                FetchDataString = response
                            };
                            var rawData = new RawData
                            {
                                SourceUrl = sourceUrl,
                                FetchedData = fetchedData,
                                ProcessedStartDate = DateTime.UtcNow
                            };

                            await _rawDataRepository.AddRawData(rawData);
                        }
                        else
                        {
                            throw new Exception("Invalid URL");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        } 
        public async Task<ApiResult<List<RawDataDto>>> GetAllRawDatas()
        {
            try
            {
                _logger.LogInformation("Fetching all RawDatas {Time}",DateTime.UtcNow);
                var rawDatas = await _rawDataRepository.GetAllRawDatas();
                if (rawDatas == null)
                {
                    _logger.LogInformation("RawDatas fetching failed {Time}", DateTime.UtcNow);
                    throw new Exception("No RawDatas found");
                }
                var mappedRawDatas = _mapper.Map<List<RawDataDto>>(rawDatas);
                return ApiResult<List<RawDataDto>>.Success(mappedRawDatas.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);
                throw;
            }
        }
        public async Task<ApiResult<RawDataDto>> GetRawDataById(int id)
        {
            try
            {
                var rawData = await _rawDataRepository.GetRawDataById(id);
                if (rawData == null)
                {
                    _logger.LogError("RawData not found with that ID: {Id}",id);
                    throw new Exception("RawData not found");
                }
                var rawDataDto = _mapper.Map<RawDataDto>(rawData);

                return ApiResult<RawDataDto>.Success(rawDataDto);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public async Task<ApiResult<RawDataDto>> AddRawData(RawData rawData)
        {
            try
            {
                var addedRawData = await _rawDataRepository.AddRawData(rawData);
                if (addedRawData == null)
                {
                    _logger.LogError("RawData not added");
                    throw new Exception("RawData not added");
                }
                var mappedRawData = _mapper.Map<RawDataDto>(addedRawData);
                return ApiResult<RawDataDto>.Success(mappedRawData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public void UpdateRawData(RawData rawData)
        {
            try
            {
                _logger.LogInformation("Updating RawData {Time}", DateTime.UtcNow);
                rawData.UpdatedDate = DateTime.UtcNow;
                _rawDataRepository.UpdateRawData(rawData);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
        public async Task DeleteRawData(int id)
        {
            try
            {
                _logger.LogInformation("Deleting RawData {Time}", DateTime.UtcNow);
                var result = _rawDataRepository.GetRawDataById(id);
                if(result == null)
                {
                    _logger.LogError("RawData not found with that ID: {Id}", id);
                    throw new Exception("RawData not found");
                }
                await _rawDataRepository.DeleteRawData(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }
    }
}
