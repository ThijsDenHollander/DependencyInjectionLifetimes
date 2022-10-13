using DependencyInjectionLifetimes;
using DependencyInjectionLifetimes.Interfaces;
using DependencyInjectionLifetimes.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(Startup))]
namespace DependencyInjectionLifetimes
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<ISingletonService, SingletonService>();
            builder.Services.AddScoped<IScopedService, ScopedService>();
            builder.Services.AddTransient<ITransientService, TransientService>();
            builder.Services.AddTransient<IHelperService, HelperService>();
        }
    }
}
