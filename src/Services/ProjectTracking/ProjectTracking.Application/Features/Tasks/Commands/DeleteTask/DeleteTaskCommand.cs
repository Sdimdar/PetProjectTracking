using MediatR;

namespace ProjectTracking.Application.Features.Tasks.Commands.DeleteTask;

public class DeleteTaskCommand : IRequest<bool>
{
    public int Id { get; set; }
}