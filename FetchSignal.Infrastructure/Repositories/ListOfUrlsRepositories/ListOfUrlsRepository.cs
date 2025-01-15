using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FetchSignal.Domain.Models;
using FetchSignal.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace FetchSignal.Infrastructure.Repositories.ListOfUrlsRepositories
{
    public class ListOfUrlsRepository : IListOfUrlsRepository
    {
        private readonly AppDbContext _context;
        public ListOfUrlsRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ListOfUrls>> GetListOfUrls()
        {
            return await _context.ListedUrls.Where(s=>s.IsActive == 0).ToListAsync();
        }
        public async Task<ListOfUrls> GetListOfUrlById(int id)
        {
            return _context.ListedUrls.FirstOrDefault(x => x.Id == id);
        }

        public async Task<ListOfUrls> AddListOfUrl(ListOfUrls listOfUrls)
        {
            _context.ListedUrls.Add(listOfUrls);
            await _context.SaveChangesAsync();
            return listOfUrls;
        }
        public async Task<ListOfUrls> UpdateListOfUrl(ListOfUrls listOfUrls)
        {
            listOfUrls.UpdatedAt = DateTime.UtcNow;
            _context.ListedUrls.Update(listOfUrls);
            await _context.SaveChangesAsync();
            return listOfUrls;
        }

        public async Task DeleteListOfUrl(int id)
        {
            var listOfUrls = await GetListOfUrlById(id);
            listOfUrls.IsActive = Domain.Enums.Status.Inactive;
            listOfUrls.DeletedAt = DateTime.UtcNow;
            listOfUrls.UpdatedAt = DateTime.UtcNow;
            _context.ListedUrls.Update(listOfUrls);
            await _context.SaveChangesAsync();
        }
    }
}
