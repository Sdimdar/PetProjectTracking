using Ardalis.ApiEndpoints;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjectTracking.API.Common.Models;
using ProjectTracking.Application.Features.Tasks.Queries.GetTaskInfo;
using ProjectTracking.Application.ViewModels;
using Swashbuckle.AspNetCore.Annotations;

namespace ProjectTracking.API.Endpoints;

public class GetTaskInfo :EndpointBaseAsync
    .WithRequest<GetTaskInfoQuery>
    .WithActionResult<DefaultResponseObject<TaskInfoVm>>
{
    private readonly IMediator _mediator;

    public GetTaskInfo(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("/Task/GetInfo")]
    [SwaggerOperation(
        Summary = "Get base info about task",
        Description = "need to pass the task id",
        Tags = new[] { "Task" })
    ]
    public  override async Task<ActionResult<DefaultResponseObject<TaskInfoVm>>> HandleAsync([FromQuery]GetTaskInfoQuery request, CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _mediator.Send(request, cancellationToken);
        return Ok(new DefaultResponseObject<TaskInfoVm>(result));
    }
}