using AutoMapper;
using TimeTrack.Application.DTOs;
using TimeTrack.Domain.Entities;

namespace TimeTrack.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<TimeEntry, TimeEntryDto>().ReverseMap();
        CreateMap<CreateTimeEntryDto, TimeEntry>();
    }
}
