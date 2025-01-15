using FetchSignal.Infrastructure.ApplicationDbContext;
using FetchSignal.Infrastructure.Repositories.ApplicationsRepositories;
using FetchSignal.Infrastructure.Repositories.FetchedDataRepositories;
using FetchSignal.Infrastructure.Repositories.ListOfUrlsRepositories;
using FetchSignal.Infrastructure.Repositories.RawDataRepositories;
using FetchSignal.Infrastructure.Repositories.SourceUrlRepositories;
using FetchSignal.Infrastructure.Repositories.GenericRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FetchSignal.Infrastructure.Extension
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql("server=localhost;port=5432; database=FetchSignal; username=postgres; password=postgres;"));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IRawDataRepository,RawDataRepository>();
            services.AddScoped<IListOfUrlsRepository,ListOfUrlsRepository>();
            services.AddScoped<IApplicationsRepository, ApplicationsRepository>();
            services.AddScoped<IFetchedDataRepository, FetchedDataRepository>();
            services.AddScoped<ISourceUrlRepository, SourceUrlRepository>();
            return services;
        }
    }
}
