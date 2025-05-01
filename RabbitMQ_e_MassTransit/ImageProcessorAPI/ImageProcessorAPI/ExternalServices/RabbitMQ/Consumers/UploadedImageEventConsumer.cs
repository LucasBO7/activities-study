using ImageProcessorAPI.DTOs;
using ImageProcessorAPI.Entities;
using ImageProcessorAPI.ExternalServices.RabbitMQ.Interfaces;
using ImageProcessorAPI.Service;
using MassTransit;
using System.Diagnostics;

namespace ImageProcessorAPI.ExternalServices.RabbitMQ.Consumers;

public class UploadedImageEventConsumer : IConsumer<UploadedImageEventRequest>, IUploadedImageEventConsumer
{
    private readonly ILogger<UploadedImageEventRequest> _logger;
    private readonly ImageProcessorService _imageProcessorService;

    public UploadedImageEventConsumer(ILogger<UploadedImageEventRequest> logger)
    {
        _logger = logger;
        _imageProcessorService = new();
    }

    public async Task Consume(ConsumeContext<UploadedImageEventRequest> context)
    {
        try
        {
            var message = context.Message;

            _logger.LogInformation("Processando imagem enviada..." + message.Id);

            UploadedImage? uploadedImage = FakeDB.Images.FirstOrDefault(image => image.Id == message.Id);

            if (uploadedImage == null)
            {
                _logger.LogError("A imagem inserida não foi encontrada no banco de dados. Verifique se o processo de Upload foi bem sucedido.");
                return;
            }

            ProcessImageDTO processImageDTO = new(uploadedImage.Data,
                width: message.userSettings.width,
                height: message.userSettings.height
            );

            await _imageProcessorService.ProcessImage(processImageDTO);

            if (uploadedImage != null)
                uploadedImage.StatusText = ImageStatuses.Completed.ToString();

            _logger.LogInformation("Imagem processada com sucesso!");

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
