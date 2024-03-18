namespace Domain.DTOs.TaskManagement.UserManagement;

public class UserDto
{
    public Guid UserId { get; set; }
    
    public string Username { get; set; }
    
    public string Email { get; set; }
    
    public string Role { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public bool UseMultiFactorAuthentication { get; set; }
    
    // user created date
    public DateTime CreatedAt { get; set; }
    
    // user updated date
    public DateTime UpdatedAt { get; set; }
    
    //user deleted date
    public DateTime? DeletedAt { get; set; }
    
    public string EmailVerified { get; set; } = null!;

    public string PhoneNumberVerified { get; set; } = null!;

    public string LastLoginTime { get; set; } = null!;
}

