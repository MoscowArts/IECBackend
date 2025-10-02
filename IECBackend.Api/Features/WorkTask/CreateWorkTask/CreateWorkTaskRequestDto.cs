namespace IECBackend.Api.Features.WorkTask.CreateWorkTask;

public class CreateWorkTaskRequestDto
{
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public DateTime PlannedStart { get; set; }
    public DateTime PlannedEnd { get; set; }
    public string Status { get; set; }
}