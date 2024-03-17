using Core.Models.Entities.Abstract;

namespace Domain.DTOs.Membership;

public class UserGetDto : IDto
{
    public Guid Id { get; set; } = default!;

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string UseMultiFactorAuthentication { get; set; } = null!;

    public string EmailVerified { get; set; } = null!;

    public string PhoneNumberVerified { get; set; } = null!;

    public string LastLoginTime { get; set; } = null!;
}