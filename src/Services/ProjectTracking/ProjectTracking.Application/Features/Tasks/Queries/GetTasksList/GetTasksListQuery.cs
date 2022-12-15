using MediatR;
using ProjectTracking.Application.ViewModels;

namespace ProjectTracking.Application.Features.Tasks.Queries.GetTasksList;

public class GetTasksListQuery : IRequest<List<TaskInfoVm>>
{
    public int ProjectId { get; set; }
    
}