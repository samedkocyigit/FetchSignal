using FetchSignal.Domain.Models;
using FetchSignal.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace FetchSignal.Infrastructure.Repositories.RawDataRepositories
{
    public class RawDataRepository: IRawDataRepository
    {
        protected readonly AppDbContext _context;
        public RawDataRepository(AppDbContext context ) 
        {
            _context = context;
        }

        public async Task<IEnumerable<RawData>> GetAllRawDatas()
        {
            return await _context.RawDatas.Include(s => s.SourceUrl).ThenInclude(s => s.Application).Include(s => s.FetchedData).ToListAsync();
        }
        public async Task<RawData> GetRawDataById(int id)
        {
            return await _context.RawDatas.Include(s=> s.SourceUrl).ThenInclude(s=> s.Application).Include(s=> s.FetchedData).FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<RawData> AddRawData(RawData rawData)
        {
            rawData.ProcessedEndDate = DateTime.UtcNow;
            await _context.RawDatas.AddAsync(rawData);
            await _context.SaveChangesAsync();
            return rawData;
        }
        public void UpdateRawData(RawData rawData) 
        { 
            _context.RawDatas.Update(rawData);
            _context.SaveChanges();
           
        }
        public async Task DeleteRawData(int id)
        {
            var rawData = await GetRawDataById(id);

            rawData.IsActive = Domain.Enums.Status.Inactive;
           _context.RawDatas.Update(rawData);
           _context.SaveChanges();
        }
    }
}
