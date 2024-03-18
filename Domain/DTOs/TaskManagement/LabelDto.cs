namespace Domain.DTOs.TaskManagement;

public class LabelDto
{
    public Guid LabelId { get; set; }
    
    public string LabelName { get; set; }
    
    public string Description { get; set; }
    
    public string Color { get; set; }
}
