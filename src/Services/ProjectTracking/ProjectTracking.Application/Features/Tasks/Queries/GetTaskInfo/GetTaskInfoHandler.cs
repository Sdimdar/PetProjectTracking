using AutoMapper;
using MediatR;
using ProjectTracking.Application.Contracts;
using ProjectTracking.Application.Exceptions;
using ProjectTracking.Application.ViewModels;

namespace ProjectTracking.Application.Features.Tasks.Queries.GetTaskInfo;

public class GetTaskInfoHandler : IRequestHandler<GetTaskInfoQuery,TaskInfoVm>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;

    public GetTaskInfoHandler(ITaskRepository taskRepository, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
    }

    
    public async Task<TaskInfoVm> Handle(GetTaskInfoQuery request, CancellationToken cancellationToken)
    {
        var result = await _taskRepository.GetByIdAsync(request.TaskId);
        if (result is null) throw new DatabaseException($"Task with id {request.TaskId} not found");
        return _mapper.Map<TaskInfoVm>(result);
    }
}