using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FetchSignal.Domain.Dtos;
using FetchSignal.Domain.Models;
using FetchSignal.Infrastructure.Repositories.ListOfUrlsRepositories;
using Microsoft.Extensions.Logging;

namespace FetchSignal.Application.Services.ListOfUrlsServices
{
    public class ListOfUrlsService : IListOfUrlsService
    {
        protected readonly IListOfUrlsRepository _listOfUrlsRepository;
        protected readonly ILogger<ListOfUrlsService> _logger;
        protected readonly IMapper _mapper; 
        public ListOfUrlsService(ILogger<ListOfUrlsService> logger,IListOfUrlsRepository listOfUrlsRepository,IMapper mapper)
        {
            _listOfUrlsRepository = listOfUrlsRepository;
            _logger = logger;
            _mapper = mapper;

        }

        public async Task<List<ListOfUrlsDto>> GetAllListedUrls()
        {
            try
            {
                var urls = await _listOfUrlsRepository.GetListOfUrls();
                var mappedUrls = _mapper.Map<List<ListOfUrlsDto>>(urls);
                return mappedUrls;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ListOfUrlsService.GetAllListedUrls");
                return null;
            }
        }
        public async Task<ListOfUrls> GetListOfUrlById(int id)
        {
            try
            {
                return await _listOfUrlsRepository.GetListOfUrlById(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ListOfUrlsService.GetListOfUrlById");
                return null;
            }
        }
        public async Task<ListOfUrls> AddListOfUrl(ListOfUrls listOfUrls)
        {
            try
            {
                return await _listOfUrlsRepository.AddListOfUrl(listOfUrls);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ListOfUrlsService.AddListOfUrl");
                return null;
            }
        }
        public async Task<ListOfUrls> UpdateListOfUrl(ListOfUrls listOfUrls)
        {
            try
            {
                return await _listOfUrlsRepository.UpdateListOfUrl(listOfUrls);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ListOfUrlsService.UpdateListOfUrl");
                return null;
            }
        }
        public async Task DeleteListOfUrl(int id)
        {
            try
            {
                await _listOfUrlsRepository.DeleteListOfUrl(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in ListOfUrlsService.DeleteListOfUrl");
            }
        }
    }
}
