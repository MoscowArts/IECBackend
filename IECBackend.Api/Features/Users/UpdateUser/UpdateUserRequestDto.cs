namespace IECBackend.Api.Features.Users.UpdateUser;

public class UpdateUserRequestDto
{
    /// <summary>
    /// 
    /// </summary>
    public string OldPassword { get; set; }
    
    public string NewPassword { get; set; }
    
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
}