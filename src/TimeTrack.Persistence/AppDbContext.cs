using Microsoft.EntityFrameworkCore;
using TimeTrack.Domain.Entities;

namespace TimeTrack.Persistence;

public class AppDbContext(DbContextOptions<AppDbContext> options)
        : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<TimeEntry> TimeEntries { get; set; }
    public DbSet<LeaveRequest> LeaveRequests { get; set; }
    public DbSet<OvertimeRequest> OvertimeRequests { get; set; }
    public DbSet<Holiday> Holidays { get; set; }

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

        modelBuilder.Entity<TimeEntry>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.ClockIn).IsRequired();
            entity.Property(t => t.ClockOut).IsRequired(false);

            entity.HasOne<User>()
                  .WithMany()
                  .HasForeignKey(t => t.UserFirebaseUid)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<LeaveRequest>(entity =>
        {
            entity.HasKey(l => l.Id);
            entity.Property(l => l.StartDate).IsRequired();
            entity.Property(l => l.EndDate).IsRequired();
            entity.Property(l => l.Reason).HasMaxLength(500);
            entity.Property(l => l.Status).HasDefaultValue("Pending");

            entity.HasOne<User>()
                  .WithMany()
                  .HasForeignKey(l => l.UserFirebaseUid)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<OvertimeRequest>(entity =>
        {
            entity.HasKey(o => o.Id);
            entity.Property(o => o.Date).IsRequired();
            entity.Property(o => o.Hours).IsRequired();
            entity.Property(o => o.Status).HasDefaultValue("Pending");

            entity.HasOne<User>()
                  .WithMany()
                  .HasForeignKey(o => o.UserFirebaseUid)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Holiday>(entity =>
        {
            entity.HasKey(h => h.Id);
            entity.Property(h => h.Date).IsRequired();
            entity.Property(h => h.Description).HasMaxLength(255).IsRequired();
        });
    }
}
