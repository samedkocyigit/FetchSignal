using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FetchSignal.Domain.Models;

namespace FetchSignal.Application.Services.SourceUrlServices
{
    public interface ISourceUrlService
    {
        Task<IEnumerable<SourceUrl>> GetAllSourceUrls();
        Task<SourceUrl> GetSourceUrlById(int id);
        Task<SourceUrl> AddSourceUrl(SourceUrl sourceUrl);
        Task<SourceUrl> UpdateSourceUrl(SourceUrl sourceUrl);
        Task DeleteSourceUrl(int id);
    }
}
