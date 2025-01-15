using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FetchSignal.Domain.Dtos;
using FetchSignal.Domain.Models;

namespace FetchSignal.Application.Services.ListOfUrlsServices
{
    public interface IListOfUrlsService
    {
        Task<List<ListOfUrlsDto>> GetAllListedUrls();
        Task<ListOfUrls> GetListOfUrlById(int id);
        Task<ListOfUrls> AddListOfUrl(ListOfUrls listOfUrls);
        Task<ListOfUrls> UpdateListOfUrl(ListOfUrls listOfUrls);
        Task DeleteListOfUrl(int id);
    }
}
