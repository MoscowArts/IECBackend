namespace IECBackend.Api.Services.Interfaces;

public interface IMinioService
{
    public Task EnsureBucketExistsAsync();
    public Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType);
    public Task<Stream> DownloadFileAsync(string fileName);
}