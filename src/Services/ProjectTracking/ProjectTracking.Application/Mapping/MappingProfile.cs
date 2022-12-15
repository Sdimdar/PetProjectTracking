using AutoMapper;
using ProjectTracking.Application.ViewModels;
using ProjectTracking.Domain.Entities;

namespace ProjectTracking.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        {
            CreateMap<ProjectDbModel, ProjectInfoVm>()
                .ForMember(p => p.StartDate, opt => opt.MapFrom(x => x.StartDate.ToString("dd.MM.yyyy")))
                .ForMember(p => p.EndDate, opt => opt.MapFrom(x => x.EndDate.ToString("dd.MM.yyyy")));
        }
    }
}