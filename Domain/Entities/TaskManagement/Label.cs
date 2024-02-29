namespace Domain.Entities;

public class Label
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Color { get; set; } // Consider using a valid color format (e.g., hex code, CSS color name)
    public int TaskId { get; set; } // Foreign key referencing Task.Id
    public Task Task { get; set; } // Navigation property
    public string Description { get; set; } // Optional
}