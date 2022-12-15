using ProjectTracking.Domain.Helpers.Enums;

namespace ProjectTracking.Application.ViewModels;

public class TaskInfoVm
{
    public int Id { get; set; }
    public string TaskName { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public PriorityHelper Priority { get; set; }
}