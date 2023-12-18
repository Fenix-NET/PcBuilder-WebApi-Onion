using Core.Interfaces;
using Core.Interfaces.Repository;
using Core.Services;
using Infrastructure.LoggerService;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Web.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigurationCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });

        public static void ConfigureNpgsqlContext(this IServiceCollection services,
            IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(opts =>
                opts.UseNpgsql(configuration.GetConnectionString("BuilderContext")));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();

        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(new ConfigurationBuilder()
                    .AddJsonFile("serilog.config.json")
                    .Build())
                .Enrich.FromLogContext()
                .CreateLogger();

            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

    }
}
