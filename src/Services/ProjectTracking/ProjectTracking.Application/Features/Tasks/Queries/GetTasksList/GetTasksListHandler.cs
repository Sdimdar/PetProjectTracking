using AutoMapper;
using MediatR;
using ProjectTracking.Application.Contracts;
using ProjectTracking.Application.Exceptions;
using ProjectTracking.Application.ViewModels;

namespace ProjectTracking.Application.Features.Tasks.Queries.GetTasksList;

public class GetTasksListHandler : IRequestHandler<GetTasksListQuery,List<TaskInfoVm>>
{
    private readonly ITaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public GetTasksListHandler(ITaskRepository taskRepository, IMapper mapper, IProjectRepository projectRepository)
    {
        _taskRepository = taskRepository;
        _mapper = mapper;
        _projectRepository = projectRepository;
    }

    public async Task<List<TaskInfoVm>> Handle(GetTasksListQuery request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.ProjectId);
        if (project is null) throw new DatabaseException($"Project with id {request.ProjectId} not found");
        var result = await _taskRepository.GetTasksByProjectId(request.ProjectId);
        if (result is null || !result.Any()) throw new DatabaseException("This project havent tasks");
        return _mapper.Map<List<TaskInfoVm>>(result);
    }
}