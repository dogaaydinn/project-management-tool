namespace Domain.DTOs.ProjectManagement;

public class ProjectDto
{
    public string ProjectName { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid ProjectManagerId { get; set; }
    public string ProjectManagerName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

