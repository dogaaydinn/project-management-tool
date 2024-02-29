using Core.Constants.Project;

namespace Domain.Entities;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ProjectStatus Status { get; set; } // Could be an enum for different statuses
    public int Priority { get; set; } // Consider using a constant enum for priorities
    public User Manager { get; set; } // Navigation property for User relationship
    public ICollection<TeamProject> Teams { get; set; } // Navigation property for one-to-many relationship with TeamProject
    public ICollection<Task> Tasks { get; set; } // Navigation property for one-to-many relationship with Task
    // Additional properties and methods as needed
}