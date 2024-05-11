using InkWell.Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkWell.Persistence.Configurations.ApplicationConfigurations;

internal class ErrorLogConfiguration : IEntityTypeConfiguration<ErrorLog>
{
	public void Configure(EntityTypeBuilder<ErrorLog> builder)
	{
		builder.HasKey(x => x.ErrorId);

		builder.Property(x => x.Message)
			.IsRequired();

		builder.Property(x => x.StackTrace)
			.IsRequired();
	}
}