using System;
using API.Business.Builders;
using API.Business.Factory;
using API.Business.Services;
using API.Domain;
using API.Interfaces;
using API.Interfaces.Builders;
using API.Interfaces.Factory;
using API.Interfaces.Services;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTests
{
    public class IntegrationTestsBase
    {
        protected readonly IServiceCollection Services;
        protected readonly IServiceProvider ServiceProvider;

        protected IntegrationTestsBase()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var cache = new MemoryCache(new MemoryCacheOptions());
            Services = new ServiceCollection();
            Services.AddSingleton<IMemoryCache>(cache);
            Services.AddSingleton<IConfiguration>(config);
            Services.AddScoped<IWorker, Worker>();
            Services.AddScoped<ICache, API.Domain.Storage.MemoryCache>();
            Services.AddScoped<IAppConfiguration, AppConfiguration>();
            Services.AddScoped<IApiFacade, ApiFacade>();
            Services.AddScoped<IHttpClientApiBuilder, HttpClientBuilder>();
            Services.AddScoped<IHttpFactory, HttpFactory>();
            Services.AddSingleton<IReportWorker, ReportWorker>();
            Services.AddScoped<IReportBuilder, ReportBuilder>();
            Services.AddScoped<IReportFactory, ReportFactory>();
            ServiceProvider = Services.BuildServiceProvider();
        } 
    }
}
