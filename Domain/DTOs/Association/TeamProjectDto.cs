namespace Domain.DTOs.Association;

public class TeamProjectDto
{
    public Guid TeamId { get; set; }
    public Guid ProjectId { get; set; }
    public string TeamName { get; set; }
    public string ProjectName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}