using RiskManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using System;

namespace RiskManagementAPI.DBContext;

public class RiskDbContext : DbContext
{
    public RiskDbContext(DbContextOptions<RiskDbContext> options) : base(options)
    {

    }

    public DbSet<Risk> Risks { get; set; }
    public DbSet<RiskHistory> RiskHistories { get; set; }
    public DbSet<Control> Controls { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Norm> Norms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Making the relationship between Risk and Control
        modelBuilder.Entity<Risk>()
            .HasMany(r => r.Controls)
            .WithOne(c => c.Risk)
            .HasForeignKey(c => c.RiskId)
            .OnDelete(DeleteBehavior.Cascade);

        // Making the relationship between Category and Risk
/*        modelBuilder.Entity<Category>()
            .HasMany(c => c.Risk)
            .WithOne(r => r.Category)
            .HasForeignKey(r => r.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);*/

        // Making the many to many relationship between Norm and Risk
        modelBuilder.Entity<Norm>()
            .HasMany(n => n.Risks)
            .WithMany(r => r.Norms)
            .UsingEntity<Dictionary<string, object>>("NormRisk",
                nr => nr.HasOne<Risk>().WithMany().HasForeignKey("RiskId"),
                nr => nr.HasOne<Norm>().WithMany().HasForeignKey("NormId"),
                nr =>
                {
                    nr.Property<int>("NormRiskId");
                    nr.HasKey("NormRiskId");
                });
    }
}