namespace Domain.DTOs.Association;

public class UserTaskDto
{
    public Guid TaskId { get; set; }
    public Guid TeamProjectId { get; set; }
    public Guid UserId { get; set; }
    public bool IsOwner { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsMember { get; set; }
    public bool IsObserver { get; set; }
    public string UserName { get; set; }
    public string TaskName { get; set; }
    public string TeamProjectName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}