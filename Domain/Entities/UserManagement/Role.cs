namespace Domain.Entities;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public User User { get; set; } // Navigation property (optional, for bidirectional access)
    // Additional properties and methods as needed
}