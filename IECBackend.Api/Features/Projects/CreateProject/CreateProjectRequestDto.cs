namespace IECBackend.Api.Features.Projects;

public class CreateProjectRequestDto
{
    public string Name { get; set; }
    public string Coordinates { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int ConstractorId { get; set; }
    public int SupervisorId { get; set; }
}