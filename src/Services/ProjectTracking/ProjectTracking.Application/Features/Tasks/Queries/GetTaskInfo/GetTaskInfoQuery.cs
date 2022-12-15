using MediatR;
using ProjectTracking.Application.ViewModels;

namespace ProjectTracking.Application.Features.Tasks.Queries.GetTaskInfo;

public class GetTaskInfoQuery :IRequest<TaskInfoVm>
{
    public int TaskId { get; set; }
}