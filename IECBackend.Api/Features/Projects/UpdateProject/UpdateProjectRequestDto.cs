namespace IECBackend.Api.Features.Projects;

public class UpdateProjectRequestDto
{
    public string? Name { get; set; }
    public string? Coordinates { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? AssignedContractorId { get; set; }
    public int? AssignedSupervisorId { get; set; }
}