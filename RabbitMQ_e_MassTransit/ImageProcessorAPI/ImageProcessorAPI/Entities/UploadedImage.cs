namespace ImageProcessorAPI.Entities;

public class UploadedImage
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string? Name { get; private set; }
    public string? CompleteName { get; private set; }
    public string? ContentType { get; private set; }
    public long Length { get; private set; }

    private ImageStatuses _status;
    public string? StatusText
    {
        get => _status.ToString();
        set
        {
            if (Enum.TryParse(value, out ImageStatuses status))
                _status = status;
            else
                throw new ArgumentException("Status inválido");
        }
    }
    public byte[] Data { get; private set; } = [];

    private UploadedImage() { }
    private UploadedImage(string? name, string? completeName, string? contentType, long length, string? statusText, byte[] data)
    {
        Name = name;
        CompleteName = completeName;
        ContentType = contentType;
        Length = length;
        StatusText = statusText;
        Data = data;
    }

    public static async Task<UploadedImage> NewUploadedImageAsync(string? name, string? completeName, string? contentType, long length, string? statusText, IFormFile imageFormFile)
    {
        var imageData = await ExtractFileDataAsync(imageFormFile);

        return new UploadedImage(name, completeName, contentType, length, statusText, imageData);

        async Task<byte[]> ExtractFileDataAsync(IFormFile imageFormFile)
        {
            using MemoryStream memoryStream = new();
            await imageFormFile.CopyToAsync(memoryStream);

            return memoryStream.ToArray();
        }
    }
}

public enum ImageStatuses
{
    Pending,
    Canceled,
    Completed
}
