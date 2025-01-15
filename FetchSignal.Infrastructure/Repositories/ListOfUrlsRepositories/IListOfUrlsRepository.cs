using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FetchSignal.Domain.Models;

namespace FetchSignal.Infrastructure.Repositories.ListOfUrlsRepositories
{
    public interface IListOfUrlsRepository
    {
        Task<List<ListOfUrls>> GetListOfUrls();
        Task<ListOfUrls> GetListOfUrlById(int id);
        Task<ListOfUrls> UpdateListOfUrl(ListOfUrls listOfUrls);
        Task<ListOfUrls> AddListOfUrl(ListOfUrls listOfUrls);
        Task DeleteListOfUrl(int id);
        
    }
}
