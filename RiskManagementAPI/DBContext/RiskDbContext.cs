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
    public DbSet<Control> Controls { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Norm> Norms { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}