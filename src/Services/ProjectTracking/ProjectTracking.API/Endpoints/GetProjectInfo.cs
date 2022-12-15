using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectTracking.API.Common.Models;
using ProjectTracking.Application.Features.Projects.Queries.GetProjectInfo;
using ProjectTracking.Application.ViewModels;
using Swashbuckle.AspNetCore.Annotations;

namespace ProjectTracking.API.Endpoints;

public class GetProjectInfo : EndpointBaseAsync
    .WithRequest<GetProjectInfoQuery>
    .WithActionResult<DefaultResponseObject<ProjectInfoVm>>
{
    private readonly IMediator _mediator;

    public GetProjectInfo(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("/Project/GetInfo")]
    [SwaggerOperation(
        Summary = "Get base info about project",
        Description = "need to pass the project id",
        Tags = new[] { "Project" })
    ]
    public override async  Task<ActionResult<DefaultResponseObject<ProjectInfoVm>>> HandleAsync([FromQuery]GetProjectInfoQuery request, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(new DefaultResponseObject<ProjectInfoVm>(result));
    }
}