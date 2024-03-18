using Core.Models.Entities.Abstract;

namespace Domain.DTOs.TaskManagement.UserManagement;

public class UserChangePasswordDto : IDto
{
    public Guid Id { get; set; } = default!;

    public string CurrentPassword { get; set; } = null!;

    public string NewPassword { get; set; } = null!;

    public string ConfirmPassword { get; set; } = null!;
}