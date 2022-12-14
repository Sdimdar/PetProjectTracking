using ProjectTracking.Domain.Helpers.Enums;

namespace ProjectTracking.Domain.Entities;

public class TaskDbModel
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string TaskName { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public PriorityHelper Priority { get; set; }
    
}