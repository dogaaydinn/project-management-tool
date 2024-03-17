using Core.Models.Entities.Abstract;

namespace Domain.DTOs.Membership;

public class UserUpdateDto : IDto
{
    public Guid Id { get; set; } = default!;

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? UseMultiFactorAuthentication { get; set; }
}