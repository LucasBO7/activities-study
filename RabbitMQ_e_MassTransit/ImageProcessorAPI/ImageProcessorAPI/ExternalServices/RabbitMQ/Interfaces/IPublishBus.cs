namespace ImageProcessorAPI.ExternalServices.RabbitMQ.Interfaces;

public interface IPublishBus
{
    Task PublishAsync<T>(T message, CancellationToken cancellationToken) where T: class;
}
