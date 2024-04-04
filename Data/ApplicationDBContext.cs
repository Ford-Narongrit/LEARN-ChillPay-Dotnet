using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Data;

public class ApplicationDBContext : DbContext
{
    protected readonly IConfiguration Configuration;

    public ApplicationDBContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // OnConfiguring Database
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
    }

    // OnCreate Model
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<PaymentHistory>()
            .HasIndex(u => u.OrderId)
            .IsUnique();
        base.OnModelCreating(builder);
    }

    // Models
    public DbSet<PaymentHistory> PaymentHistories => Set<PaymentHistory>();

}