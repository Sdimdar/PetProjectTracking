using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectTracking.API.Common.Models;
using ProjectTracking.Application.Features.Tasks.Commands.UpdateTask;
using Swashbuckle.AspNetCore.Annotations;

namespace ProjectTracking.API.Endpoints;

public class UpdateTask : EndpointBaseAsync
    .WithRequest<UpdateTaskCommand>
    .WithActionResult<DefaultResponseObject<bool>>
{
    private readonly IMediator _mediator;

    public UpdateTask(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("/Task/Update")]
    [SwaggerOperation(
        Summary = "can be update name, status, priority, description",
        Description = "Status 1 = ToDo, Status 2 = InProgress, Status 3 = Done",
        Tags = new[] { "Task" })
    ]
    public override async Task<ActionResult<DefaultResponseObject<bool>>> HandleAsync([FromBody]UpdateTaskCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(new DefaultResponseObject<bool>(result));
    }
}