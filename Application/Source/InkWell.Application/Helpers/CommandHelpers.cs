using InkWell.Application.Identity.Extensions;
using InkWell.Common.Enums;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.Helpers;

public static class CommandHelpers
{
    public static void DeactivateCategoryChildren(IEnumerable<Category> children, IUnitOfWork unitOfWork)
    {
        foreach (var child in children)
        {
            child.IsActive = false;
            child.DeletedBy = UserContext.CurrentUserId;
            child.DeletedAt = DateTime.UtcNow;

            Audit log = new()
            {
                Id = Guid.NewGuid(),
                EntityId = child.Id,
                EntityTypeId = (int)eEntityType.Category,
                ActionTypeId = (int)eActionType.Delete,
                IsSuccess = true,
                Time = DateTime.UtcNow,
                ExecutedBy = UserContext.CurrentUserId,
            };

            unitOfWork.AuditRepository.Add(log);

            if (child.Children.Count != 0)
            {
                DeactivateCategoryChildren(child.Children, unitOfWork);
            }
        }
    }
}