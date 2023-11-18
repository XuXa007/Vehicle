using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data;

public class DBContext : DbContext
{
    public DBContext(DbContextOptions<DBContext> options) : base(options)
    {
    }
    
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<MaintenanceTask> MaintenanceTasks { get; set; }
    public DbSet<Report> Reports { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaintenanceTask>().ToTable("maintenance_task");
        modelBuilder.Entity<Vehicle>().ToTable("vehicle");
        modelBuilder.Entity<Report>().ToTable("report");
        modelBuilder.Entity<User>().ToTable("user");

    }

}