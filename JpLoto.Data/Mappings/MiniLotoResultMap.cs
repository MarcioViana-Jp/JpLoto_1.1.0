using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JpLoto.Domain.Entities;

namespace JpLoto.Data.Mappings;

public class MiniLotoResultMap : IEntityTypeConfiguration<MiniLotoResult>
{
    public void Configure(EntityTypeBuilder<MiniLotoResult> builder)
    {
        builder.ToTable("MiniLotoResults");

        builder.Property(r => r.Bonus)
            .HasMaxLength(2)
            .IsUnicode(false);

        builder.Property(p => p.Numbers)
            .HasMaxLength(14)
            .IsUnicode(false);
    }
}