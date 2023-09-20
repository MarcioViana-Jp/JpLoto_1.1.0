using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JpLoto.Domain.Entities;

namespace JpLoto.Data.Mappings;

public class TrialMap : IEntityTypeConfiguration<Trial>
{
    public void Configure(EntityTypeBuilder<Trial> builder)
    {
        builder.ToTable("Trials");

        builder.Property(p => p.UserId)
            .HasMaxLength(450)
            .IsUnicode(false);
    }
}