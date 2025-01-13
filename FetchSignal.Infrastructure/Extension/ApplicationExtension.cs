using FetchSignal.Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FetchSignal.Infrastructure.Extension
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql("server=localhost;port=5432; database=FetchSignalDb; username=postgres; password=postgres;"));
            return services;
        }
    }
}
