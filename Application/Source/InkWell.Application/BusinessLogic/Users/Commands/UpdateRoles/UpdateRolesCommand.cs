using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.Role;

namespace InkWell.Application.BusinessLogic.Users.Commands.UpdateRoles;
public sealed record UpdateRolesCommand(Guid UserId, RoleDto Roles) : ICommand;