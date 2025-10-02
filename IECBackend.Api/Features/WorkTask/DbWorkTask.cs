namespace IECBackend.Api.Features.WorkTask;

public class DbWorkTask
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public DateTime PlannedStart { get; set; }
    public DateTime PlannedEnd { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}