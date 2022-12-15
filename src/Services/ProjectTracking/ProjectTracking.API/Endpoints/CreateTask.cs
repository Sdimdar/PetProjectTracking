using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectTracking.API.Common.Models;
using ProjectTracking.Application.Features.Tasks.Commands.CreateTask;
using Swashbuckle.AspNetCore.Annotations;

namespace ProjectTracking.API.Endpoints;

public class CreateTask : EndpointBaseAsync
    .WithRequest<CreateTaskCommand>
    .WithActionResult<DefaultResponseObject<bool>>
{
    private readonly IMediator _mediator;

    public CreateTask(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("/Task/Create")]
    [SwaggerOperation(
        Summary = "Create new task",
        Description = "Status 1 = ToDo, Status 2 = InProgress, Status 3 = Done",
        Tags = new[] { "Task" })
    ]
    public  override async Task<ActionResult<DefaultResponseObject<bool>>> HandleAsync([FromBody]CreateTaskCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(new DefaultResponseObject<bool>(result));
    }
}