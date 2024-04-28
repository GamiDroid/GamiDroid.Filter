using Filter.Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Filter.Demo;
internal class DemoDbContext : DbContext
{
    public DbSet<Project> Projects { get; set; }
    public DbSet<TechnicalTemplate> TechnicalTemplates { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<LookupValue> LookupValues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer("Data Source=localhost;Database=DAM3;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(x =>
        {
            x.ToTable("Project");
        });

        modelBuilder.Entity<TechnicalTemplate>(x =>
        {
            x.ToTable("TechnicalTemplate");

            x.HasOne(d => d.Organization)
                    .WithMany()
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

            x.HasOne(d => d.PrimPackNavigation)
                .WithMany()
                .HasForeignKey(d => d.PrimPack)
                .OnDelete(DeleteBehavior.ClientSetNull);

            x.HasOne(d => d.PrimPackSpecNavigation)
                .WithMany()
                .HasForeignKey(d => d.PrimPackSpec)
                .OnDelete(DeleteBehavior.ClientSetNull);

            x.HasOne(d => d.PrimPackVolNavigation)
                .WithMany()
                .HasForeignKey(d => d.PrimPackVol)
                .OnDelete(DeleteBehavior.ClientSetNull);

            x.HasOne(d => d.ReqNewPackNavigation)
                .WithMany()
                .HasForeignKey(d => d.ReqNewPack)
                .OnDelete(DeleteBehavior.ClientSetNull);

            x.HasOne(d => d.ReqNewPackGrpNavigation)
                .WithMany()
                .HasForeignKey(d => d.ReqNewPackGrp)
                .OnDelete(DeleteBehavior.ClientSetNull);

            x.HasOne(d => d.ReqNewPackPosNavigation)
                .WithMany()
                .HasForeignKey(d => d.ReqNewPackPos)
                .OnDelete(DeleteBehavior.ClientSetNull);

            x.HasOne(d => d.SupplierNavigation)
                .WithMany()
                .HasForeignKey(d => d.Supplier)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Organization>(x =>
        {
            x.ToTable("Organization");

            x.HasKey(p => p.OrganizationId);
        });

        modelBuilder.Entity<LookupValue>(x =>
        {
            x.ToTable("LookupValue");
            x.HasKey(e => e.Id);
        });
    }
}
