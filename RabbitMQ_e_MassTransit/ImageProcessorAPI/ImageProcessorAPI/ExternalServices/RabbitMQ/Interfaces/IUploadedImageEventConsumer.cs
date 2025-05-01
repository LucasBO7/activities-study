using ImageProcessorAPI.Entities;
using MassTransit;

namespace ImageProcessorAPI.ExternalServices.RabbitMQ.Interfaces;

public interface IUploadedImageEventConsumer
{
    Task Consume(ConsumeContext<UploadedImageEventRequest> context);
}