using Core.Models.Entities.Abstract;

namespace Domain.Entities;

public class Comment : EntityBase
{
    public DateTime Timestamp { get; set; }
    public Guid TaskId { get; set; } // Foreign key referencing Task.Id
    public Task Task { get; set; } // Navigation property
    public Guid AuthorId { get; set; } // Foreign key referencing User.Id
    public User Author { get; set; } // Navigation property
    public int? ReplyToId { get; set; } // Foreign key for nested comments (optional)
    public string Text { get; set; }

    public ICollection<Comment>
        Comments { get; set; } // Navigation property for one-to-many relationship with nested comments (optional)

    public ICollection<Attachment>
        Attachments { get; set; } // Navigation property for one-to-many relationship with Attachment (optional)
}