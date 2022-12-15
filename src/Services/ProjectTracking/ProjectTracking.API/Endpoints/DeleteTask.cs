using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectTracking.API.Common.Models;
using ProjectTracking.Application.Features.Tasks.Commands.DeleteTask;
using Swashbuckle.AspNetCore.Annotations;

namespace ProjectTracking.API.Endpoints;

public class DeleteTask:EndpointBaseAsync
    .WithRequest<DeleteTaskCommand>
    .WithActionResult<DefaultResponseObject<bool>>
{
    private readonly IMediator _mediator;

    public DeleteTask(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("/Task/Delete")]
    [SwaggerOperation(
        Summary = "Delete task",
        Description = "Need to pass the task id",
        Tags = new[] { "Task" })
    ]
    public override async Task<ActionResult<DefaultResponseObject<bool>>> HandleAsync([FromBody]DeleteTaskCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(new DefaultResponseObject<bool>(result));
    }
}