using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectTracking.API.Common.Models;
using ProjectTracking.Application.Features.Tasks.Queries.GetTasksList;
using ProjectTracking.Application.ViewModels;
using Swashbuckle.AspNetCore.Annotations;

namespace ProjectTracking.API.Endpoints;

public class GetTasksListByProjectId:EndpointBaseAsync
    .WithRequest<GetTasksListQuery>
    .WithActionResult<DefaultResponseObject<List<TaskInfoVm>>>
{
    private readonly IMediator _mediator;

    public GetTasksListByProjectId(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("/Task/GetList")]
    [SwaggerOperation(
        Summary = "Returns tasks to the project",
        Description = "Return tasks list",
        Tags = new[] { "Task" })
    ]
    public override async Task<ActionResult<DefaultResponseObject<List<TaskInfoVm>>>> HandleAsync([FromQuery]GetTasksListQuery request, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(new DefaultResponseObject<List<TaskInfoVm>>(result));
    }
}