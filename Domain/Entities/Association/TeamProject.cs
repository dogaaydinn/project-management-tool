namespace Domain.Entities;

public class TeamProject
{
    public int Id { get; set; }
    public int TeamId { get; set; } // Foreign key referencing Team.Id
    public Team Team { get; set; } // Navigation property
    public int ProjectId { get; set; } // Foreign key referencing Project.Id
    public Project Project { get; set; } // Navigation property
    public ICollection<TaskAccess> TaskAccesses { get; set; } // Navigation property for one-to-many relationship with TaskAccess
    // Additional properties and methods as needed (e.g., permissions level)
}