using Core.Models.Entities.Abstract;

namespace Domain.Entities;

public class TaskAccess: IEntity
{
    public int Id { get; set; }
    public int TaskId { get; set; } // Foreign key referencing Task.Id
    public Task Task { get; set; } // Navigation property
    public int TeamProjectId { get; set; } // Foreign key referencing TeamProject.Id
    public TeamProject TeamProject { get; set; } // Navigation property
    // Additional properties related to access levels or permissions (if needed)
}