namespace IECBackend.Api.Features.Users.CreateUser;

public class CreateUserRequestDto
{
    /// <summary>
    /// Логин (уникальный)
    /// </summary>
    public string Username { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string Password { get; set; }
    
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
}