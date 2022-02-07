using BLL.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BLL
{
    public static class BLLDepandancy
    {
        public static void AllDepandancies(IServiceCollection services,IConfiguration configuration)
        {
            services.AddTransient<IWhoSearchApiService, WhoSearchApiService>();
            AllFluentValidationDepandancy(services);
        }

        private static void AllFluentValidationDepandancy(IServiceCollection services)
        {

        }

    }
}
