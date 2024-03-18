using Core.Constants.Task;
using Core.Models.Entities.Abstract;

namespace Domain.Entities;

public class Task : EntityBase
{
    public string Title { get; set; }
    public string Description { get; set; }
    public TaskType Type { get; set; } // Could be an enum for different task types
    public int Priority { get; set; } // Consider using a constant enum for priorities
    public Project Project { get; set; } // Navigation property for one-to-many relationship with Project
    public DateTime DueDate { get; set; }
    public Guid ReporterId { get; set; } // Foreign key referencing User.Id
    public User Reporter { get; set; } // Navigation property for foreign key relationship with User
    public ICollection<Comment> Comments { get; set; } // Navigation property for one-to-many relationship with Comment

    
    public ICollection<Attachment>
        Attachments { get; set; } // Navigation property for one-to-many relationship with Attachment

    public ICollection<Label> Labels { get; set; } // Navigation property for many-to-many relationship with Label
    // Additional properties and methods as needed
    public ICollection<UserTask> UserTasks { get; set; } // Navigation property for one-to-many relationship with UserTask
}