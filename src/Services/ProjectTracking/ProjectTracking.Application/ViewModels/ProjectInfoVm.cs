using ProjectTracking.Domain.Helpers.Enums;

namespace ProjectTracking.Application.ViewModels;

public class ProjectInfoVm
{
    public int Id { get; set; }
    public string ProjectName { get; set; }
    public string Status { get; set; }
    public PriorityHelper Priority { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
}