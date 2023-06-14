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

  /*      // Making the relationship between Risk and RiskHistory
        modelBuilder.Entity<Risk>()
            .HasMany(r => r.RiskHistory)
            .WithOne(rh => rh.Risk)
            .HasForeignKey(rh => rh.RiskId)
            .OnDelete(DeleteBehavior.Cascade);

        // Making the relationship between Risk and Control
        modelBuilder.Entity<Risk>()
            .HasMany(r => r.Controls)
            .WithOne(c => c.Risk)
            .HasForeignKey(c => c.RiskId)
            .OnDelete(DeleteBehavior.Cascade);

        // Making the relationship between Risk and Category
        modelBuilder.Entity<Risk>()
            .HasMany(r => r.Categories)
            .WithOne(c => c.Risk)
            .HasForeignKey(c => c.RiskId)
            .OnDelete(DeleteBehavior.Cascade);*/
    }
}