using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MLeagueManager2.Repo.Interfaces;
using MLeagueManager2.Repo.Repositories;
using MLeagueManager2.Repo.magicleague;
using Org.BouncyCastle.Crypto.Agreement.Kdf;

namespace MLeagueManager2.Repo.Libraries
{
    public static class IServiceCollectionExtension
    { 
        public static IServiceCollection AddRepoLibrary(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository,UsersRepository>();
            return services;
        }
    }
}
