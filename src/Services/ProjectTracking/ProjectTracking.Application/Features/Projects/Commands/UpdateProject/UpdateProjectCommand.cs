using MediatR;
using ProjectTracking.Domain.Helpers.Enums;

namespace ProjectTracking.Application.Features.Projects.Commands.UpdateProject;

public class UpdateProjectCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string? ProjectName { get; set; }
    public BaseStatusHelper Status { get; set; }
    public PriorityHelper Priority { get; set; }
}