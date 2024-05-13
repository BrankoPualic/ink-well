using InkWell.Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkWell.Persistence.Configurations.ApplicationConfigurations;

internal class AuditConfiguration : IEntityTypeConfiguration<Audit>
{
	public void Configure(EntityTypeBuilder<Audit> builder)
	{
		builder.HasKey(x => x.Id);

		builder.HasOne(x => x.User)
			.WithMany(u => u.Audits)
			.HasForeignKey(x => x.ExecutedBy)
			.OnDelete(DeleteBehavior.Restrict);
	}
}