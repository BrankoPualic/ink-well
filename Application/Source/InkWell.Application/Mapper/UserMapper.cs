using InkWell.Application.Dtos.User;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Utilities._DbResponses.Users;

namespace InkWell.Application.Mapper;

public class UserMapper : AutoMapperProfile
{
	public UserMapper()
	{
		CreateMap<User, AuthResponseDto>();

		CreateMap<User, UserDto>()
			.ForMember(dest => dest.Followers, opt => opt.MapFrom(src => src.Followers.Count()))
			.ForMember(dest => dest.Following, opt => opt.MapFrom(src => src.Following.Count()))
			.ForMember(dest => dest.Posts, opt => opt.MapFrom(src => src.Posts.Count()));

		CreateMap<UserDbResponse, UserDto>()
			.ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
			.ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.User.ProfilePictureUrl))
			.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.User.Id))
			.ForMember(dest => dest.Followers, opt => opt.MapFrom(src => src.Followers))
			.ForMember(dest => dest.Following, opt => opt.MapFrom(src => src.Following))
			.ForMember(dest => dest.Posts, opt => opt.MapFrom(src => src.Posts));

		CreateMap<UserDbResponse, ProfileDto>()
			.IncludeBase<UserDbResponse, UserDto>()
			.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FullName))
			.ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.User.DateOfBirth));

		CreateMap<User, ProfileDto>()
			.IncludeBase<User, UserDto>();

		CreateMap<User, PersonalInformationsDto>()
			.IncludeBase<User, ProfileDto>()
			.ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.UserRoles.Select(x => x.Role.Name).ToList()));

		CreateMap<UserDbResponse, PersonalInformationsDto>()
			.ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
			.ForMember(dest => dest.ProfilePictureUrl, opt => opt.MapFrom(src => src.User.ProfilePictureUrl))
			.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.User.Id))
			.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
			.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.User.CreatedAt))
			.ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.User.IsActive))
			.ForMember(dest => dest.ModifiedAt, opt => opt.MapFrom(src => src.User.ModifiedAt))
			.ForMember(dest => dest.ModifiedBy, opt => opt.MapFrom(src => src.User.ModifiedBy))
			.ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.User.DateOfBirth))
			.ForMember(dest => dest.DeletedAt, opt => opt.MapFrom(src => src.User.DeletedAt))
			.ForMember(dest => dest.DeletedBy, opt => opt.MapFrom(src => src.User.DeletedBy))
			.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.User.FullName))
			.ForMember(dest => dest.Roles, opt => opt.MapFrom(src => src.User.UserRoles.Select(x => x.Role.Name).ToList()))
			.ForMember(dest => dest.Followers, opt => opt.MapFrom(src => src.Followers))
			.ForMember(dest => dest.Following, opt => opt.MapFrom(src => src.Following));
	}
}