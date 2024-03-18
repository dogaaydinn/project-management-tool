namespace Domain.DTOs.ProjectManagement;

public class TeamDto
{
    public string TeamName { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid TeamLeaderId { get; set; }
    public string TeamLeaderName { get; set; }
    public Guid TeamId { get; set; }
    public string Description { get; set; }
}


