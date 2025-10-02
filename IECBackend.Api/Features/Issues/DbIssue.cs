namespace IECBackend.Api.Features.Issues;

public class DbIssue 
{
    
    /// <summary>
    /// 
    /// </summary>
    public int Id { get; set; }
    
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
    public DateTime TermOfElimination { get; set; } 
    
    /// <summary>
    /// 
    /// </summary>
    public string Image { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}