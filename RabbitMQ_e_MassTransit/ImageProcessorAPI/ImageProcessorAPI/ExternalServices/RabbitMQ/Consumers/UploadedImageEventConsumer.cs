using ImageProcessorAPI.Entities;
using MassTransit;

namespace ImageProcessorAPI.ExternalServices.RabbitMQ.Consumers;

public class UploadedImageEventConsumer : IConsumer<UploadedImageEvent>
{
    private readonly ILogger<UploadedImageEvent> _logger;

    public UploadedImageEventConsumer(ILogger<UploadedImageEvent> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<UploadedImageEvent> context)
    {
        var message = context.Message;

        _logger.LogInformation("Processando imagem enviada..." + message.Id);

        await Task.Delay(1000);

        var uploadedImage = FakeDB.Images.FirstOrDefault(image => image.Id == message.Id);

        if (uploadedImage != null)
            uploadedImage.StatusText = ImageStatuses.Completed.ToString();

        _logger.LogInformation("Imagem processada com sucesso!");
    }
}
