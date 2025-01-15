using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FetchSignal.Domain.Models;
using FetchSignal.Infrastructure.ApplicationDbContext;
using FetchSignal.Infrastructure.Repositories.GenericRepositories;

namespace FetchSignal.Infrastructure.Repositories.ApplicationsRepositories
{
    public class ApplicationsRepository:GenericRepository<Application>, IApplicationsRepository
    {
        protected readonly AppDbContext _context;
        public ApplicationsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
