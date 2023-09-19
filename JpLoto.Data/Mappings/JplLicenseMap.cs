using JpLoto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JpLoto.Data.Mappings;

public class JplLicenseMap : IEntityTypeConfiguration<JplLicense>
{
    public void Configure(EntityTypeBuilder<JplLicense> builder)
    {
        builder.ToTable("Licenses");

        builder.Property(p => p.UserId)
            .HasMaxLength(450)
            .IsUnicode(false);

        builder.HasOne(p => p.Plan)
            .WithMany(p => p.JplLicenses)
            .HasForeignKey(p => p.PlanId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}