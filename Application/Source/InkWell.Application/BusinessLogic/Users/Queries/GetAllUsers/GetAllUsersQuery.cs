using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.User;
using InkWell.Domain.Utilities.Params;
using MediatR;

namespace InkWell.Application.BusinessLogic.Users.Queries.GetAllUsers;
public sealed record GetAllUsersQuery(EntryParams EntryParams) : IQuery<GridDto<UserDto>>;