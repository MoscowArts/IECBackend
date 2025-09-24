namespace IECBackend.Api.Features.Issues.UpdateIssue;

public class IssueRequestDto
{
    /// <summary>
    /// 
    /// </summary>
    public string Description { get; set; } 
    
    /// <summary>
    /// 
    /// </summary>
    public string Coordinates { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public DateTime? TermOfElimination { get; set; } 
    
    /// <summary>
    /// 
    /// </summary>
    public string Image { get; set; }
}