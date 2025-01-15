using FetchSignal.Domain.Models;
using FetchSignal.Infrastructure.ApplicationDbContext;
using FetchSignal.Infrastructure.Repositories.GenericRepositories;

namespace FetchSignal.Infrastructure.Repositories.SourceUrlRepositories
{
    public class SourceUrlRepository:GenericRepository<SourceUrl>,ISourceUrlRepository
    {
        protected readonly AppDbContext _context;
        public SourceUrlRepository(AppDbContext context) : base(context)
        {
            _context = context;   
        }
    }
}
