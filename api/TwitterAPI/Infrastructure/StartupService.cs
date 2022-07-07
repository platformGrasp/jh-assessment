using System;
using System.Threading;
using System.Threading.Tasks;
using API.Interfaces.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TwitterAPI_Assessment.HubConfig;

namespace TwitterAPI_Assessment.Infrastructure
{
    public class StartupService : IHostedService
    {
        private readonly IServiceProvider _services;
        private static ILogger _logger;
        public StartupService(IServiceProvider services, ILogger<StartupService> logger)
        {
            _services = services;
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _services.CreateScope();
            var twitterUnitOfWork = scope.ServiceProvider.GetService<IWorker>();
            IHubContext<ChartHub> hub = scope.ServiceProvider.GetService<IHubContext<ChartHub>>();
            HubEngine.Init(hub, twitterUnitOfWork, _logger);
            Thread thread = new Thread(() =>
            {
                HubEngine.DoWork();
            });
            thread.Start();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
