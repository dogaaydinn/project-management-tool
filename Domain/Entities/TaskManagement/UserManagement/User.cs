using System.ComponentModel.DataAnnotations;
using Core.Constants;
using Core.Models.Entities.Abstract;

namespace Domain.Entities;

public class User : EntityBase
{
    public string Username { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; } = null!;
    public string Role { get; set; } = UserRoles.TeamMember;

    public ICollection<UserTask> UserTasks { get; set; } // Navigation property for many-to-many relationship with Task
    public ICollection<Team> Teams { get; set; } // Navigation property for one-to-many relationship with Team

    // Additional properties and methods as needed
    [StringLength(127)] public string PhoneNumber { get; set; } = null!;

    [StringLength(6)] public string? LoginVerificationCode { get; set; }

    public DateTime? LoginVerificationCodeExpiration { get; set; }

    public byte[] PasswordSalt { get; set; } = null!;

    public bool UseMultiFactorAuthentication { get; set; }

    public bool EmailVerified { get; set; }

    public bool PhoneNumberVerified { get; set; }

    public DateTime LastLoginTime { get; set; }

    
}