using AutoMapper;
using MediatR;
using ProjectTracking.Application.Contracts;
using ProjectTracking.Application.Exceptions;
using ProjectTracking.Application.ViewModels;

namespace ProjectTracking.Application.Features.Projects.Queries.GetProjectInfo;

public class GetProjectInfoHandler:IRequestHandler<GetProjectInfoQuery,ProjectInfoVm>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public GetProjectInfoHandler(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<ProjectInfoVm> Handle(GetProjectInfoQuery request, CancellationToken cancellationToken)
    {
        var result = await _projectRepository.GetByIdAsync(request.ProjectId);
        if (result is null) throw new DatabaseException($"Project with id {request.ProjectId} not found");
        return _mapper.Map<ProjectInfoVm>(result);
    }
}