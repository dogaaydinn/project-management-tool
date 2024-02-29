namespace Domain.Entities;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public User Manager { get; set; } // Navigation property for foreign key relationship with User
    public ICollection<TeamProject> Projects { get; set; } // Navigation property for one-to-many relationship with TeamProject
    public ICollection<User> Users { get; set; } // Navigation property for many-to-many relationship with User
    // Additional properties and methods as needed
}