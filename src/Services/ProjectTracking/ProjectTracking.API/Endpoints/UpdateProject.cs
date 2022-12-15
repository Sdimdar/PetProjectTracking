using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectTracking.API.Common.Models;
using ProjectTracking.Application.Features.Projects.Commands.UpdateProject;
using Swashbuckle.AspNetCore.Annotations;

namespace ProjectTracking.API.Endpoints;

public class UpdateProject:EndpointBaseAsync
    .WithRequest<UpdateProjectCommand>
    .WithActionResult<DefaultResponseObject<bool>>
{
    private readonly IMediator _mediator;

    public UpdateProject(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("/Project/Update")]
    [SwaggerOperation(
        Summary = "can be update name, status, priority",
        Description = "Status 1 = NotStarted, Status 2 = Active, Status 3 = Complete",
        Tags = new[] { "Project" })
    ]
    public override async Task<ActionResult<DefaultResponseObject<bool>>> HandleAsync([FromBody]UpdateProjectCommand request, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(new DefaultResponseObject<bool>(result));
    }
}