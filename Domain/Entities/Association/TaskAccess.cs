using Core.Models.Entities.Abstract;

namespace Domain.Entities;

public class TaskAccess : EntityBase
{
    public Guid TaskId { get; set; } // Foreign key referencing Task.Id
    public Task Task { get; set; } // Navigation property
    public Guid TeamProjectId { get; set; } // Foreign key referencing TeamProject.Id

    public TeamProject TeamProject { get; set; } // Navigation property
    // Additional properties related to access levels or permissions (if needed)
}