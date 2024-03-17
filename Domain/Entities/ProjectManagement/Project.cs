using Core.Constants.Project;
using Core.Models.Entities.Abstract;

namespace Domain.Entities;

public class Project : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ProjectStatus Status { get; set; } // Could be an enum for different statuses
    public int Priority { get; set; } // Consider using a constant enum for priorities
    public Guid ManagerId { get; set; } // Foreign key referencing User.Id
    public User Manager { get; set; } // Navigation property for User relationship
    public ICollection<Team> Teams { get; set; } // Navigation property for one-to-many relationship with TeamProject

    public ICollection<Task> Tasks { get; set; } // Navigation property for one-to-many relationship with Task
    // Additional properties and methods as needed
}