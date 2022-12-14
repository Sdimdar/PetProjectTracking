using MediatR;
using ProjectTracking.Domain.Helpers.Enums;

namespace ProjectTracking.Application.Features.Projects.Commands.Create;

public class ProjectCreateCommand : IRequest<bool>
{
    public string ProjectName { get; set; }
    public BaseStatusHelper Status { get; set; }
    public PriorityHelper Priority { get; set; }
    
}