using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FetchSignal.Domain.Models;
using FetchSignal.Infrastructure.ApplicationDbContext;
using FetchSignal.Infrastructure.Repositories.GenericRepositories;

namespace FetchSignal.Infrastructure.Repositories.FetchedDataRepositories
{
    public class FetchedDataRepository:GenericRepository<FetchedData>, IFetchedDataRepository
    {
        protected readonly AppDbContext _context;
        public FetchedDataRepository( AppDbContext context) :base(context)
        {
            _context = context;
        }
    }
}
