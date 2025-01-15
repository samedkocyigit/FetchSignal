using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FetchSignal.Domain.Models;
using FetchSignal.Infrastructure.Repositories.ApplicationsRepositories;

namespace FetchSignal.Application.Services.ApplicationsServices
{
    public class ApplicationService: IApplicationService
    {
        protected readonly IApplicationsRepository _applicationRepository;
        public ApplicationService(IApplicationsRepository applicationsRepository)
        {
            _applicationRepository = applicationsRepository;
        }

        public async Task<IEnumerable<Domain.Models.Application>> GetAllApplications()
        {
             return await _applicationRepository.GetAll();
        }
        public async Task<Domain.Models.Application> GetApplicationById(int id)
        {
            return await _applicationRepository.GetById(id);
        }
        public async Task<Domain.Models.Application> AddApplication(Domain.Models.Application application)
        {
            return await _applicationRepository.Add(application);
        }
        public async Task<Domain.Models.Application> UpdateApplication(Domain.Models.Application application)
        {
            return await _applicationRepository.Update(application);
        }
        public async Task DeleteApplication(int id)
        {
            await _applicationRepository.Delete(id);
        }

    }
}
