using BLL.Request;
using BLL.Services;
using FluentValidation;
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
            services.AddTransient<IPatientService, PatientService>();
            AllFluentValidationDepandancy(services);
        }

        private static void AllFluentValidationDepandancy(IServiceCollection services)
        {
        

            services.AddTransient<IValidator<PatientInsertRequestViewModel>, PatientInsertRequestViewModelValidator>();
        }

    }
}
