using MediatR;
using ProjectTracking.Application.ViewModels;

namespace ProjectTracking.Application.Features.Projects.Queries.GetProjectInfo;

public class GetProjectInfoQuery : IRequest<ProjectInfoVm>
{
    public int ProjectId { get; set; }
}