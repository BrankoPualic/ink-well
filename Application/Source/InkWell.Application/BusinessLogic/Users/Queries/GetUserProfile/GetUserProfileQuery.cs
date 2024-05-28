using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.User;

namespace InkWell.Application.BusinessLogic.Users.Queries.GetUserProfile;
public sealed record GetUserProfileQuery(Guid UserId) : IQuery<ProfileDto>;