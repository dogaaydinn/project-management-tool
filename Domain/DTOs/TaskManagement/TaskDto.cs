namespace Domain.DTOs.TaskManagement;

public class TaskDto
{
    public Guid TaskId { get; set; }
    
    public string TaskName { get; set; }
    
    public string Description { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public Guid AssignedUserId { get; set; }
    
    public Guid ProjectId { get; set; }
    
    public Guid LabelId { get; set; }
    
}

