using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JpLoto.Domain.Entities;

namespace JpLoto.Data.Mappings;

public class Loto7ResultMap : IEntityTypeConfiguration<Loto7Result>
{
    public void Configure(EntityTypeBuilder<Loto7Result> builder)
    {
        builder.ToTable("Loto7Results");

        builder.Property(r => r.Bonus)
            .HasMaxLength(5)
            .IsUnicode(false);

        builder.Property(p => p.Numbers)
            .HasMaxLength(20)
            .IsUnicode(false);
    }
}