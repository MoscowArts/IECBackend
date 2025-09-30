namespace IECBackend.Api.Features.WorkTask.UpdateWorkTask;

public class UpdateWorkTaskRequestDto
{
    public int? ProjectId { get; set; }
    public string? Name { get; set; }
    public DateTime? PlannedStart { get; set; }
    public DateTime? PlannedEnd { get; set; }
    public string? Status { get; set; }
}