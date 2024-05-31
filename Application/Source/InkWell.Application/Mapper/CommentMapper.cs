using AutoMapper;
using InkWell.Application.Dtos.Comment;
using InkWell.Application.Dtos.User;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Utilities._DbResponses.Comments;

namespace InkWell.Application.Mapper;

public class CommentMapper : AutoMapperProfile
{
	public CommentMapper()
	{
		CreateMap<Comment, ResponseCommentDto>()
			.ForMember(dest => dest.Upvotes, opt => opt.MapFrom(src => src.Upvotes.Count()))
			.ForMember(dest => dest.Replies, opt => opt.MapFrom(src => src.Replies.Count()))
			.ForMember(dest => dest.ReplyComments, opt => opt.MapFrom(src => src.Replies))
			.ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User));

		CreateMap<ICollection<Comment>, IEnumerable<ResponseCommentDto>>()
		   .ConvertUsing((src, dest, context) => src.Select(c => context.Mapper.Map<ResponseCommentDto>(c)));

		CreateMap<CommentDbResponse, ResponseCommentDto>()
			.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Comment.Id))
			.ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Comment.Title))
			.ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Comment.Text))
			.ForMember(dest => dest.ParentId, opt => opt.MapFrom(src => src.Comment.ParentId))
			.ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.Comment.CreatedAt))
			.ForMember(dest => dest.ModifiedAt, opt => opt.MapFrom(src => src.Comment.ModifiedAt))
			.ForMember(dest => dest.Upvotes, opt => opt.MapFrom(src => src.Upvotes))
			.ForMember(dest => dest.Replies, opt => opt.MapFrom(src => src.Replies))
			.ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
			.ForMember(dest => dest.ReplyComments, opt => opt.MapFrom(src => src.Comment.Replies));
	}
}