namespace Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; }
    public int TaskId { get; set; } // Foreign key referencing Task.Id
    public Task Task { get; set; } // Navigation property
    public int AuthorId { get; set; } // Foreign key referencing User.Id
    public User Author { get; set; } // Navigation property
    public int? ReplyToId { get; set; } // Foreign key for nested comments (optional)
    public Comment ParentComment { get; set; } // Navigation property for nested comments (optional)
    public string Text { get; set; }
    public ICollection<Comment> Comments { get; set; } // Navigation property for one-to-many relationship with nested comments (optional)
    public ICollection<Attachment> Attachments { get; set; } // Navigation property for one-to-many relationship with Attachment (optional)
}
