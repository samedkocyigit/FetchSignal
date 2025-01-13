using FetchSignal.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FetchSignal.Infrastructure.ApplicationDbContext
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<RawData> RawDatas { get; set; }
        public DbSet<ProcessedData> ProcessedDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
