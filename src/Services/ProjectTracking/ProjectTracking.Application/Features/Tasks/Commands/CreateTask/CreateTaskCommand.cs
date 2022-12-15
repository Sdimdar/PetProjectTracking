using MediatR;
using ProjectTracking.Domain.Helpers.Enums;

namespace ProjectTracking.Application.Features.Tasks.Commands.CreateTask;

public class CreateTaskCommand : IRequest<bool>
{
    public int ProjectId { get; set; }
    public string TaskName { get; set; }
    public string Description { get; set; }
    public BaseStatusHelper Status { get; set; }
    public PriorityHelper Priority { get; set; }
}