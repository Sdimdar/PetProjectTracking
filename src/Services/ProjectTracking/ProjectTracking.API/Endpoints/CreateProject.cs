using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectTracking.API.Common.Models;
using ProjectTracking.Application.Features.Projects.Commands.Create;
using Swashbuckle.AspNetCore.Annotations;

namespace ProjectTracking.API.Endpoints;

public class CreateProject:EndpointBaseAsync
    .WithRequest<ProjectCreateCommand>
    .WithActionResult<DefaultResponseObject<bool>>
{
    private readonly IMediator _mediator;

    public CreateProject(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("/Project/Create")]
    [SwaggerOperation(
        Summary = "Create new project",
        Description = "Status 1 = NotStarted, Status 2 = Active, Status 3 = Complete",
        Tags = new[] { "Project" })
    ]
    public override async Task<ActionResult<DefaultResponseObject<bool>>> HandleAsync([FromBody]ProjectCreateCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(new DefaultResponseObject<bool>(result));
    }
}