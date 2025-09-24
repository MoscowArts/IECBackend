using IECBackend.Api.Services.Interfaces;
using Minio;
using Minio.DataModel.Args;

namespace IECBackend.Api.Services;

public class MinioService(IMinioClient minioClient, IConfiguration config) : IMinioService
{
    private readonly string _bucketName = config["Minio:BucketName"];
    public async Task EnsureBucketExistsAsync()
    {
        var found = await minioClient.BucketExistsAsync(
            new BucketExistsArgs().WithBucket(_bucketName));

        if (!found)
        {
            await minioClient.MakeBucketAsync(
                new MakeBucketArgs().WithBucket(_bucketName));
        }
    }

    public async Task<string> UploadFileAsync(Stream fileStream, string fileName, string contentType)
    {
        await EnsureBucketExistsAsync();

        await minioClient.PutObjectAsync(new PutObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(fileName)
            .WithStreamData(fileStream)
            .WithObjectSize(fileStream.Length)
            .WithContentType(contentType));
        
        return fileName;
    }

    public async Task<Stream> DownloadFileAsync(string fileName)
    {
        var ms = new MemoryStream();
        await minioClient.GetObjectAsync(new GetObjectArgs()
            .WithBucket(_bucketName)
            .WithObject(fileName)
            .WithCallbackStream(stream => stream.CopyTo(ms)));
        ms.Position = 0;
        return ms;
    }
}