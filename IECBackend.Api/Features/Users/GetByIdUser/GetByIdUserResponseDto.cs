namespace IECBackend.Api.Features.Users.GetByIdUser;

public class GetByIdUserResponseDto
{
    /// <summary>
    /// 
    /// </summary>
    public string Fullname { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string Email { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string Phone { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public UserRole Role { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string Organization { get; set; }
    
    /// <summary>
    /// можно временно отключить пользователя
    /// </summary>
    public bool IsActive { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public DateTime CreatedAt { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}