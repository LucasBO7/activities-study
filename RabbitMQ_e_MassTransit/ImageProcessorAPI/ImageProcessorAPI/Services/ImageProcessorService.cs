using ImageProcessorAPI.DTOs;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;

namespace ImageProcessorAPI.Service;

public class ImageProcessorService
{
    public async Task SaveImage(Image uploadedImage, string path, IImageEncoder? format = null)
    {
        string downloadsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        path = Path.Combine(downloadsFolder, $"imagem-processada.{uploadedImage.Metadata.DecodedImageFormat!.FileExtensions.FirstOrDefault()}");

        await uploadedImage.SaveAsync(path);
    }

    public async Task ProcessImage(ProcessImageDTO processImageDTO)
    {
        var stream = new MemoryStream(processImageDTO.Data);

        using var imageProcess = Image.Load(stream);

        if (processImageDTO.Width != 0 && processImageDTO.Height != 0)
        {
            ResizeImage(imageProcess, processImageDTO.Width, processImageDTO.Height);
            await SaveImage(imageProcess, "imagem-processada.jpg");
        }
    }

    private void ResizeImage(Image imageProcess, int width, int height)
    {
        imageProcess.Mutate(i => i.Resize(width, height));
    }
}
