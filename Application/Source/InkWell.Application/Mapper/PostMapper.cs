using InkWell.Application.Dtos.Post;
using InkWell.Application.Dtos.User;
using InkWell.Domain.Utilities._DbResponses.Posts;

namespace InkWell.Application.Mapper;

public class PostMapper : AutoMapperProfile
{
	public PostMapper()
	{
		CreateMap<PostDbResponse, ResponsePostDto>()
			.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Post.Id))
			.ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Post.Title))
			.ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Post.Text))
			.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Post.Description))
			.ForMember(dest => dest.ViewCount, opt => opt.MapFrom(src => src.Post.ViewCount))
			.ForMember(dest => dest.PostImageUrl, opt => opt.MapFrom(src => src.Post.PostImageUrl))
			.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.Post.CreatedAt))
			.ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Post.Category.Name))
			.ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.Comments))
			.ForMember(dest => dest.Likes, opt => opt.MapFrom(src => src.Likes))
			.ForMember(dest => dest.Author, opt => opt.MapFrom(src => new ProfileDto
			{
				Id = src.Author.User.Id,
				Username = src.Author.User.Username,
				ProfilePictureUrl = src.Author.User.ProfilePictureUrl,
				FullName = src.Author.User.FullName,
				DateOfBirth = src.Author.User.DateOfBirth,
				Followers = src.Author.Followers,
				Following = src.Author.Following,
				Posts = src.Author.Posts,
			}));
	}
}