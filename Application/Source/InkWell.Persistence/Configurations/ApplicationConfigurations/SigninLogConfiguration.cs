using InkWell.Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkWell.Persistence.Configurations.ApplicationConfigurations;

internal class SigninLogConfiguration : IEntityTypeConfiguration<SigninLog>
{
	public void Configure(EntityTypeBuilder<SigninLog> builder)
	{
		builder.HasKey(x => x.SessionId);

		builder.HasOne(x => x.User)
			.WithMany(u => u.Signins)
			.HasForeignKey(x => x.UserId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}