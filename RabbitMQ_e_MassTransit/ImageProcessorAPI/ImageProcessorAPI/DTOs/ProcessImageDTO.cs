using SixLabors.ImageSharp.Formats;

namespace ImageProcessorAPI.DTOs;

public class ProcessImageDTO
{
    public int Width { get; private set; }
    public int Height { get; private set; }
    public string? Path { get; private set; }
    public IImageDecoder? Format { get; private set; }
    public byte[] Data { get; private set; } = [];

    public ProcessImageDTO(byte[] data, int? width = 0, int? height = 0, string? path = null, IImageDecoder? format = null)
    {
        Width = (int)width!;
        Height = (int)height!;
        Path = path;
        Format = format;
        Data = data;
    }
}