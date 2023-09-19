using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using JpLoto.Domain.Entities;

namespace JpLoto.Data.Mappings;

public class Loto6ResultMap : IEntityTypeConfiguration<Loto6Result>
{
    public void Configure(EntityTypeBuilder<Loto6Result> builder)
    {
        builder.ToTable("Loto6Results");

        //builder.Property(p => p.Id)
        //    .ValueGeneratedNever();

        builder.Property(r => r.Bonus)
            .HasMaxLength(2)
            .IsUnicode(false);

        builder.Property(p => p.Numbers)
            .HasMaxLength(17)
            .IsUnicode(false);

        //builder.HasData(new[]
        //{
        //    new Categoria(1, "Eletrodomésticos"),
        //    new Categoria(2, "Informática"),
        //    new Categoria(3, "Vestuário"),
        //    new Categoria(4, "Livros")
        //});
    }
}