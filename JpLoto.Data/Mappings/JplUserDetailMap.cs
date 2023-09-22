using JpLoto.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JpLoto.Data.Mappings;

public class JplUserDetailMap : IEntityTypeConfiguration<JplUserDetail>
{
    public void Configure(EntityTypeBuilder<JplUserDetail> builder)
    {
        builder.ToTable("UserDetails");

        builder.Property(d => d.UserId)
            .HasMaxLength(450)
            .IsUnicode(false);

        builder.Property(d => d.FirstName)
            .HasMaxLength(50)
            .IsUnicode(false);
        
        builder.Property(d => d.LastName)
            .HasMaxLength(50)
            .IsUnicode(false);

        builder.Property(d => d.State)
            .HasMaxLength(50)
            .IsUnicode(false);

        builder.Property(d => d.City)
            .HasMaxLength(50)
            .IsUnicode(false);

        builder.Property(d => d.PostalCode)
            .HasMaxLength(8)
            .IsUnicode(false);

        builder.Property(d => d.Phone)
            .HasMaxLength(20)
            .IsUnicode(false);
    }
}
