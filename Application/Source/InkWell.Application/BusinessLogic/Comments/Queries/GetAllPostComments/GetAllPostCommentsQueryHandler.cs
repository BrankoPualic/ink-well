﻿using AutoMapper;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.Comment;
using InkWell.Application.Helpers;
using InkWell.Application.Mapper;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Comments.Queries.GetAllPostComments;

internal class GetAllPostCommentsQueryHandler : BaseHandler, IQueryHandler<GetAllPostCommentsQuery, GridDto<ResponseCommentDto>>
{
	public GetAllPostCommentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
	{
	}

	public async Task<Result<GridDto<ResponseCommentDto>>> Handle(GetAllPostCommentsQuery request, CancellationToken cancellationToken)
	{
		var comments = await UnitOfWork.CommentRepository.GetAllPostCommentsAsync(request.EntryParams, request.PostId, cancellationToken);

		if (comments.Count < 1)
		{
			return Result.Failure<GridDto<ResponseCommentDto>>(Error<Comment>.NotFound);
		}

		var mappedResults = new List<ResponseCommentDto>();

		foreach (var comment in comments.Results)
		{
			var com = new ResponseCommentDto
			{
				Id = comment.Comment.Id,
				Title = comment.Comment.Title,
				Text = comment.Comment.Text,
				ParentId = comment.Comment.ParentId,
				CreatedAt = comment.Comment.CreatedAt,
				ModifiedAt = comment.Comment.ModifiedAt,
				Upvotes = comment.Upvotes,
				Replies = comment.Replies,
				User = new Dtos.User.ProfileDto
				{
					Id = comment.User.User.Id,
					Username = comment.User.User.Username,
					ProfilePictureUrl = comment.User.User.ProfilePictureUrl,
					FullName = comment.User.User.FullName,
					DateOfBirth = comment.User.User.DateOfBirth,
					Followers = comment.User.Followers,
					Following = comment.User.Following
				},
				ReplyComments = comment.Comment.Replies.Select(QueryHelpers.MapComment).ToList()
			};

			mappedResults.Add(com);
		}

		var result = MakeGridResponse<ResponseCommentDto>.Create(request.EntryParams, mappedResults, comments.Count);

		return Result.Success(result);
	}
}