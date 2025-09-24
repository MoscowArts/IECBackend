using IECBackend.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace IECBackend.Api;

[Route("api/[controller]")]
[ApiController]
public class TestFilesController(IMinioService minioService) : ControllerBase
{
    [HttpPost("upload")]
    public async Task<IActionResult> UploadFileAsync(IFormFile? file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Файл пустой");

        var fileName = $"{Guid.NewGuid()}_{file.FileName}";

        await using var stream = file.OpenReadStream();
        
        await minioService.UploadFileAsync(stream, fileName, file.ContentType);
        
        return Ok(new { FileName = fileName });
    }

    [HttpGet("download/{fileName}")]
    public async Task<IActionResult> DownloadFile(string fileName)
    {
        var stream = await minioService.DownloadFileAsync(fileName);
        return File(stream, "application/octet-stream", fileName);
    }
}