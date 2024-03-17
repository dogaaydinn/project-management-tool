using Core.Models.Entities.Abstract;

namespace Domain.DTOs.Membership;

public class UserChangePasswordDto : IDto
{
    public Guid Id { get; set; } = default!;

    public string CurrentPassword { get; set; } = null!;

    public string NewPassword { get; set; } = null!;

    public string ConfirmPassword { get; set; } = null!;
}