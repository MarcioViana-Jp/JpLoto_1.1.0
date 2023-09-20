using JpLoto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JpLoto.Data.Mappings;

public class SubscriptionMap : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable("Subscriptions");

        builder.Property(p => p.UserId)
            .HasMaxLength(450)
            .IsUnicode(false);

        builder.HasOne(p => p.Plan)
            .WithMany(p => p.Subscriptions)
            .HasForeignKey(p => p.PlanId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}