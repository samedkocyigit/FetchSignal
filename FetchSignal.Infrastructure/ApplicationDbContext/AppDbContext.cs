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
        public DbSet<SourceUrl> SourceUrls { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<FetchedData> FetchedDatas { get; set; }
        public DbSet<ListOfUrls> ListedUrls { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ListOfUrls>()
                .Property(l => l.IsActive)
                .HasConversion<string>();
            modelBuilder.Entity<RawData>()
                .Property(r => r.IsActive)
                .HasConversion<string>();
            modelBuilder.Entity<SourceUrl>()
                .Property(s => s.IsActive)
                .HasConversion<string>();
            modelBuilder.Entity<Application>()
                .Property(a => a.IsActive)
                .HasConversion<string>();
            modelBuilder.Entity<FetchedData>()
                .Property(f => f.IsActive)
                .HasConversion<string>();

            modelBuilder.Entity<RawData>()
                .HasOne(r => r.SourceUrl)
                .WithMany()
                .HasForeignKey(r => r.UrlId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RawData>()
                .HasOne(r => r.FetchedData)
                .WithMany()
                .HasForeignKey(r => r.FetchedDataId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SourceUrl>()
                .HasOne(s => s.Application)
                .WithMany(s => s.SourceUrls)
                .HasForeignKey(s => s.ApplicationId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

        }
    }
}
