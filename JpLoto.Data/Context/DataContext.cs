using JpLoto.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection;

namespace JpLoto.Data.Context;
public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    { }

    public DbSet<Loto6Result> Loto6Results { get; set; }
    public DbSet<Loto7Result> Loto7Results { get; set; }
    public DbSet<MiniLotoResult> MiniLotoResults { get; set; }
    public DbSet<Plan> Plans { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(DataContext)
            .Assembly);

        //modelBuilder
        //    .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
