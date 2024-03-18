namespace Domain.DTOs.Association;

public class TaskAccessDto
{
    public Guid UserId { get; set; }
    public Guid TaskId { get; set; }
    public bool IsOwner { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsMember { get; set; }
    public bool IsObserver { get; set; }
    public string UserName { get; set; }
    public string TaskName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}