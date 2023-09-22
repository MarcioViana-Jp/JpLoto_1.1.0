using JpLoto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JpLoto.Data.Context;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    { }

    public DbSet<Loto6Result> Loto6Results { get; set; }
    public DbSet<Loto7Result> Loto7Results { get; set; }
    public DbSet<MiniLotoResult> MiniLotoResults { get; set; }
    public DbSet<JplUserDetail> UserDetails { get; set; }
    public DbSet<Trial> Trials { get; set; }
    public DbSet<Plan> Plans { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(DataContext)
            .Assembly);

        //modelBuilder
        //    .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
