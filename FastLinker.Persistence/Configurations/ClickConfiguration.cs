using FastLinker.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastLinker.Persistence.Configurations;

public class ClickConfiguration : IEntityTypeConfiguration<Click>
{
    public void Configure(EntityTypeBuilder<Click> builder)
    {
        builder.Property(c => c.Ip)
            .IsRequired()
            .HasMaxLength(15);

        builder.HasIndex(c => new { c.Ip, c.ShortLinkId }).IsUnique();
    }
}