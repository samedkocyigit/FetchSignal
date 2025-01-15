using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FetchSignal.Domain.Models;
using FetchSignal.Infrastructure.Repositories.GenericRepositories;

namespace FetchSignal.Infrastructure.Repositories.ApplicationsRepositories
{
    public interface IApplicationsRepository:IGenericRepository<Application>
    {
    }
}
