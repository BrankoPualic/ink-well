using InkWell.Application.Dtos.User;
using InkWell.Domain.Entities.Application;

namespace InkWell.Application.Mapper;

public class UserMapper : AutoMapperProfile
{
	public UserMapper()
	{
		CreateMap<User, AuthResponseDto>();
	}
}