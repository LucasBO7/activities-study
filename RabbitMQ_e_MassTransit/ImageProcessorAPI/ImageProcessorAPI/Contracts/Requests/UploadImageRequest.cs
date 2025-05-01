namespace ImageProcessorAPI.Contracts.Requests;

public record UploadImageRequest(
    IFormFile imageFormFile,
    UploadImageUserSettings userSettings
);