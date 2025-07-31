using Microsoft.EntityFrameworkCore;
using TimeTrack.Domain.Entities;

namespace TimeTrack.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options)
        : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.FirebaseUid);
            entity.Property(u => u.Email).IsRequired();
            entity.Property(u => u.Role).IsRequired();
            entity.Property(u => u.IsActive).HasDefaultValue(true);
            entity.Property(u => u.DateCreated).HasDefaultValueSql("NOW()");
        });
    }
}

