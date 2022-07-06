using System;
using System.Threading;
using System.Threading.Tasks;
using API.Interfaces.Services;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntegrationTests.Services
{
    [TestClass()]
    public class WorkerTests : IntegrationTestsBase
    {
        [TestMethod()]
        public void ProcessTwitterStreamTest()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            var task = Task.Run(() =>
            {
                var worker = ServiceProvider.GetService<IWorker>();
                worker.Should().NotBeNull();
                worker.ProcessStreamAsync();
            }, token);
            Func<Task> f = async () => { task.Wait(10000, token); };
            f.Should().NotThrowAsync("Running as expected");
        }
    }
}