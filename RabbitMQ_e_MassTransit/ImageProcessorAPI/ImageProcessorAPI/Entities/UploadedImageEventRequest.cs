using ImageProcessorAPI.Contracts.Requests;

namespace ImageProcessorAPI.Entities;

public record UploadedImageEventRequest(Guid Id, UploadImageUserSettings userSettings);
