using System.ComponentModel.DataAnnotations;
using Core.Models.Entities.Abstract;

namespace Domain.Entities;

public class User: EntityBase
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; } // Consider using a secure hashing algorithm for password storage
    public Role Role { get; set; } // Navigation property for one-to-one relationship with Role
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