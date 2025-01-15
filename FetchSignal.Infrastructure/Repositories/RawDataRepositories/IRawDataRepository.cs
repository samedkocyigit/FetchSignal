using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FetchSignal.Domain.Models;

namespace FetchSignal.Infrastructure.Repositories.RawDataRepositories
{
    public interface IRawDataRepository
    {
        Task<IEnumerable<RawData>> GetAllRawDatas();
        Task<RawData> GetRawDataById(int id);
        Task<RawData> AddRawData(RawData rawData);
        void UpdateRawData(RawData rawData);
        Task DeleteRawData(int id);
    }
}
