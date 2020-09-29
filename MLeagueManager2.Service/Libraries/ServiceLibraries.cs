using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using MLeagueManager2.Service.Interfaces;
using MLeagueManager2.Service.Services;

namespace MLeagueManager2.Service.Libraries
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddServiceLibrary(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
