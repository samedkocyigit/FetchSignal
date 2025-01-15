using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchSignal.Application.Services.ApplicationsServices
{
    public interface IApplicationService
    {
        Task<IEnumerable<Domain.Models.Application>> GetAllApplications();
        Task<Domain.Models.Application> GetApplicationById(int id);
        Task<Domain.Models.Application> AddApplication(Domain.Models.Application application);
        Task<Domain.Models.Application> UpdateApplication(Domain.Models.Application application);
        Task DeleteApplication(int id);
    }
}
