using Core.Models.Entities.Abstract;

namespace Domain.Entities;

public class UserTask : EntityBase
{
    public Guid UserId { get; set; } // Foreign key referencing User.Id
    public User User { get; set; } // Navigation property
    public Guid TaskId { get; set; } // Foreign key referencing Task.Id

    public Task Task { get; set; } // Navigation property
    // Additional properties and methods as needed
}