using Filter.Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Filter.Demo;
internal class DemoDbContext : DbContext
{
    public DbSet<Project> Projects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Data Source=localhost;Database=DAM3;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(x =>
        {
            x.ToTable("Project");
        });
    }
}
