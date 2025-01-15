using FetchSignal.Application.Services.BackgroundJobs;
using FetchSignal.Application.Services.RawDataServices;
using FetchSignal.Application.Services.SignalServices;
using Hangfire;
using Microsoft.Extensions.DependencyInjection;
using Hangfire.PostgreSql;
using System.Reflection;
using AutoMapper;
using FetchSignal.Application.Services.ListOfUrlsServices;
using FetchSignal.Application.Services.ApplicationsServices;
using FetchSignal.Application.Services.SourceUrlServices;
using FetchSignal.Application.Services.FetchedDataServices;

namespace FetchSignal.Application.Extensions
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddHttpClient("ApiClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7188/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            services.AddScoped<ISignalService, SignalService>();
            services.AddScoped<IRawDataService, RawDataService>();
            services.AddScoped<IListOfUrlsService, ListOfUrlsService>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<ISourceUrlService, SourceUrlService>();
            services.AddScoped<IFetchedDataService, FetchedDataService>();
            services.AddRecurrgingService();
            
            services.AddSwagger();

            using (var serviceProvider = services.BuildServiceProvider())
            {
                var recurringJobManager = serviceProvider.GetRequiredService<IRecurringJobManager>();
                var recurringJobs = serviceProvider.GetRequiredService<RecurringJobs>();

                recurringJobManager.AddOrUpdate(
                    "ExecuteAsyncJob",
                    () => recurringJobs.ExecuteAsync(),
                    Cron.Daily
                );
            }
            return services;
        }
        public static IServiceCollection AddRecurrgingService(this IServiceCollection services)
        {
            services.AddHangfire(config => config.UsePostgreSqlStorage("host=localhost;port=5432;username=postgres; password=postgres; database=hangfire_db;"));
            services.AddHangfireServer();
            
            services.AddScoped<RecurringJobs>();
            services.AddScoped<RecurringJobService>();

            return services;
        }
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(
                //options =>
                //{
                //    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                //    {
                //        Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                //        In = ParameterLocation.Header,
                //        Name = "Authorization",
                //        Type = SecuritySchemeType.ApiKey
                //    });
                //    options.OperationFilter<SecurityRequirementsOperationFilter>();
                //}
            );

            return services;
        }
    }
}
