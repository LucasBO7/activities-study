using MassTransit;
using ReportProcessor.Bus.Interfaces;

namespace ReportProcessor.Bus;

public class PublisBus : IPublishBus
{
    private readonly IBus _busEndpoint;

    public PublisBus(IBus busEndpoint) => _busEndpoint = busEndpoint;

    public Task PublishAsync<T>(T message, CancellationToken cancellationToken = default) where T : class
    {
        return _busEndpoint.Publish(message, cancellationToken);
    }
}
