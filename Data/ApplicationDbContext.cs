using Microsoft.EntityFrameworkCore;
using StudentRegistrationSystem.Models;

namespace StudentRegistrationSystem.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students => Set<Student>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Students");

            // One email address can only be registered once.
            // This unique index is the final guard: even if two requests with the
            // same email arrive at the same moment, the database rejects the second one.
            entity.HasIndex(s => s.Email).IsUnique();

            entity.Property(s => s.FirstName).HasMaxLength(50).IsRequired();
            entity.Property(s => s.LastName).HasMaxLength(50).IsRequired();
            entity.Property(s => s.Email).HasMaxLength(100).IsRequired();
            entity.Property(s => s.Course).HasMaxLength(100).IsRequired();
        });
    }
}
