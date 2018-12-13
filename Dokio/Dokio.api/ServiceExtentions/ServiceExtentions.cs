using Dokio.Contracts.ILoggerService;
using Dokio.Contracts.IRepositoryWrapper;
using Dokio.Entities.Context;
using Dokio.LoggerService;
using Dokio.Repository.RepositoryWrapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dokio.api.ServiceExtentions
{
    public static class ServiceExtentions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod()
                               .AllowCredentials());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }

        public static void  ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        public static void ConfigureMySqlContext (this IServiceCollection services, IConfiguration config)
        {
           string connectionString="";
           connectionString = connectionString.IsDevelopment(true, config);
           services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
        public static string IsDevelopment(this string connectionString, bool check,  IConfiguration config)
        {
             
            if (check == true)
                connectionString = config["mysqlconnection:connectionString-Dev"];
            else
                connectionString = config["mysqlconnection:connectionString-Prod"];

            return connectionString;
        }
    }

  
}
