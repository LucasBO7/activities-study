namespace ImageProcessorAPI.Entities;

public class Image
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    public string? CompleteName { get; set; }
    public string? ContentType { get; set; }
    public long Length { get; set; }

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
}

public enum ImageStatuses
{
    Pending,
    Canceled,
    Completed
}
