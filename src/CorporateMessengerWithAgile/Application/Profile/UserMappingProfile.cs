using Application.Dto;
using Domain.Common;
using Domain.Entity;

namespace Application.Profile
{
    public class UserMappingProfile : AutoMapper.Profile
    {
        public static IReadOnlyList<Guid> GetIds(IEnumerable<BaseEntity> entities) => [.. entities.Select(e => e.Id)];
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email.Value))
                .ForMember(d => d.Username, opt => opt.MapFrom(s => s.Username.Value))
                .ForMember(d => d.EmployeeIds, opt => opt.MapFrom(s => GetIds(s.Employees)));
        }
    }
}
