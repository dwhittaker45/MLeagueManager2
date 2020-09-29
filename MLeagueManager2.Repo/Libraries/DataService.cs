using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MLeagueManager2.Repo.magicleague;

namespace MLeagueManager2.Repo.Libraries
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDataService(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<magicleagueContext>(options => options.UseMySQL(config.GetConnectionString("MagicLeagueDB")));

            return services;
        }
    }
}
