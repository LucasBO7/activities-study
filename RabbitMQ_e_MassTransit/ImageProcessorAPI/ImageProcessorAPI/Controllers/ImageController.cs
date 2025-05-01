using ImageProcessorAPI.Contracts.Requests;
using ImageProcessorAPI.Entities;
using ImageProcessorAPI.ExternalServices.RabbitMQ.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ImageProcessorAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImageController : ControllerBase
{
    private readonly IPublishBus _bus;

    public ImageController(IPublishBus bus)
    {
        _bus = bus;
    }

    [HttpPost("upload-image")]
    public async Task<IActionResult> UploadImage([FromForm]UploadImageRequest uploadImageRequest, CancellationToken cancellationToken = default)
    {
        try
        {
            if (uploadImageRequest.imageFormFile == null || uploadImageRequest.imageFormFile.Length == 0 || !uploadImageRequest.imageFormFile.ContentType.Contains("image"))
                throw new ArgumentNullException("É obrigatório a seleção de uma imagem e que contenha valor!");

            UploadedImage newImage = await UploadedImage.NewUploadedImageAsync(
                name: uploadImageRequest.imageFormFile.Name,
                completeName: uploadImageRequest.imageFormFile.Name,
                contentType: uploadImageRequest.imageFormFile.ContentType,
                length: uploadImageRequest.imageFormFile.Length,
                statusText: ImageStatuses.Pending.ToString(),
                imageFormFile: uploadImageRequest.imageFormFile
            );

            FakeDB.Images.Add(newImage);

            UploadedImageEventRequest uploadedImageEvent = new(newImage.Id, uploadImageRequest.userSettings);
            await _bus.PublishAsync(uploadedImageEvent, cancellationToken);

            return Ok(uploadImageRequest.imageFormFile);
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