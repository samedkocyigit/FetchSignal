using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FetchSignal.Domain.Models;
using FetchSignal.Infrastructure.Repositories.SourceUrlRepositories;

namespace FetchSignal.Application.Services.SourceUrlServices
{
    public class SourceUrlService: ISourceUrlService
    {
        protected readonly ISourceUrlRepository _sourceUrlRepository;
        public SourceUrlService(ISourceUrlRepository sourceUrlRepository)
        {
            _sourceUrlRepository = sourceUrlRepository;
        }
        public async Task<IEnumerable<SourceUrl>> GetAllSourceUrls()
        {
            return await _sourceUrlRepository.GetAll();
        }
        public async Task<SourceUrl> AddSourceUrl(SourceUrl sourceUrl)
        {
           return await _sourceUrlRepository.Add(sourceUrl);
        }
        public async Task<SourceUrl> GetSourceUrlById(int id)
        {
            return await _sourceUrlRepository.GetById(id);
        }
        public async Task<SourceUrl> UpdateSourceUrl(SourceUrl sourceUrl)
        {
            return await _sourceUrlRepository.Update(sourceUrl);
        }
        public async Task DeleteSourceUrl(int id)
        {
            await _sourceUrlRepository.Delete(id);
        }

    }
}
