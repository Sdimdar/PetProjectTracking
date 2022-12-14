using ProjectTracking.Domain.Helpers.Enums;

namespace ProjectTracking.Domain.Entities;

public class ProjectDbModel
{
    public int Id { get; set; }
    public string ProjectName { get; set; }
    public string Status { get; set; }
    public PriorityHelper Priority { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    
}