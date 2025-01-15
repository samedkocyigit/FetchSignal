using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FetchSignal.Domain.Models;

namespace FetchSignal.Application.Services.FetchedDataServices
{
    public interface IFetchedDataService
    {
        Task<IEnumerable<FetchedData>> GetAllFetchedDatas();
        Task<FetchedData> GetFetchedDataById(int id);
        Task<FetchedData> AddFetchedData(FetchedData fetchedData);
        Task<FetchedData> UpdateFetchedData(FetchedData fetchedData);
        Task DeleteFetchedData(int id);

    }
}
