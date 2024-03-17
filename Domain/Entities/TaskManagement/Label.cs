using Core.Models.Entities.Abstract;

namespace Domain.Entities;

public class Label : EntityBase
{
    public string Name { get; set; }
    public string Color { get; set; } // Consider using a valid color format (e.g., hex code, CSS color name)
    public Guid TaskId { get; set; } // Foreign key referencing Task.Id
    public Task Task { get; set; } // Navigation property
    public string Description { get; set; } // Optional
}