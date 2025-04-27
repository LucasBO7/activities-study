using ImageProcessorAPI.Entities;
using ImageProcessorAPI.ExternalServices.RabbitMQ.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImageProcessorAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
    [HttpPost("upload-image")]
    public async Task<IActionResult> UploadImage(IFormFile image, IPublishBus bus, CancellationToken cancellationToken = default)
    {
        try
        {
            if (image == null || image.Length == 0 || !image.ContentType.Contains("image"))
                throw new ArgumentNullException("É obrigatório a seleção de uma imagem e que contenha valor!");

            Image newImage = new()
            {
                Name = image.Name,
                CompleteName = image.Name,
                ContentType = image.ContentType,
                Length = image.Length,
                StatusText = ImageStatuses.Pending.ToString()
            };

            FakeDB.Images.Add(newImage);

            UploadedImageEvent uploadedImageEvent = new(newImage.Id);
            await bus.PublishAsync(uploadedImageEvent, cancellationToken);

            return Ok(image);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest($"Erro de inserção de dados: {ex.Message}");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("get-images")]
    public IActionResult GetImages()
    {
        try
        {
            return Ok(FakeDB.Images);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}