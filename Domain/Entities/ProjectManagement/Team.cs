using Core.Models.Entities.Abstract;

namespace Domain.Entities;

public class Team : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid ManagerId { get; set; } // Foreign key referencing User.Id
    public User Manager { get; set; } // Navigation property for foreign key relationship with User

    public Guid TeamLeadId { get; set; }
    public User TeamLead { get; set; }
    public ICollection<Project>
        Projects { get; set; } // Navigation property for one-to-many relationship with TeamProject

    public ICollection<User> Users { get; set; } // Navigation property for many-to-many relationship with User
    // Additional properties and methods as needed
}