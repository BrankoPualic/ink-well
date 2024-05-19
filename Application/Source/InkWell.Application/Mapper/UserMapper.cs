using InkWell.Application.Dtos.User;
using InkWell.Domain.Entities.Application;

namespace InkWell.Application.Mapper;

public class UserMapper : AutoMapperProfile
{
	public UserMapper()
	{
		CreateMap<User, AuthResponseDto>();

		CreateMap<User, UserDto>();

		CreateMap<User, ProfileDto>()
			.IncludeBase<User, UserDto>();

		CreateMap<User, PersonalInformationsDto>()
			.IncludeBase<User, ProfileDto>()
			.ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.UserRoles.Select(x => x.Role.Name).ToList()));
	}
}