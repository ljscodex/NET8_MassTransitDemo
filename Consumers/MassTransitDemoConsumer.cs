namespace NET8_MassTransit_Demo.Consumers;

using System.Threading.Tasks;
using NET8_MassTransit_Demo.Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;
using static NET8_MassTransit_Demo.Contracts.MasstransitContracts;

public class GettingStartedConsumer :
    IConsumer<Person>
{
    readonly ILogger<GettingStartedConsumer> _logger;

    public GettingStartedConsumer(ILogger<GettingStartedConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<Person> context)
    {
        _logger.LogInformation($"Received Person: {context.Message.ToString()}");
        return Task.CompletedTask;
    }
}