using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.User;
using InkWell.Domain.Utilities.Params;

namespace InkWell.Application.BusinessLogic.Users.Queries.GetAllUsersByAdmin;
public sealed record GetAllUsersByAdminQuery(EntryParams EntryParams) : IQuery<GridDto<PersonalInformationsDto>>;