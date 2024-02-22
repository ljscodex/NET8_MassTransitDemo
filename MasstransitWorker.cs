namespace NET8_MassTransit_Demo.Consumers;

using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;
using NET8_MassTransit_Demo.Contracts;
using static NET8_MassTransit_Demo.Contracts.MasstransitContracts;

public class Worker : BackgroundService
{
    readonly IBus _bus;

    public Worker(IBus bus)
    {
        _bus = bus;
    }

    // If you want to public a meesage every 1 second
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await _bus.Publish( new Person { Name = "Leo", Age = 6 }, stoppingToken);

            await Task.Delay(1000, stoppingToken);
        }
    }
    
}