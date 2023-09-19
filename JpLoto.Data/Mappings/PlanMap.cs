using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JpLoto.Domain.Entities;

namespace JpLoto.Data.Mappings;

public class PlanMap : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.ToTable("Plans");

        builder.Property(p => p.PlanCode)
            .HasMaxLength(20)
            .IsUnicode(false);
        
        builder.Property(p => p.Description)
            .HasMaxLength(100)
            .IsUnicode(false);
    }
}