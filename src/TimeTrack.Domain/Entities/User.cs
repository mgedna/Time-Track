using TimeTrack.Domain.Enums;

namespace TimeTrack.Domain.Entities;

public class User
{
    public string FirebaseUid { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public Role Role { get; set; } = Role.Employee;
    public string? ManagerFirebaseUid { get; set; }

    public string Department { get; set; } = string.Empty;
    public string Team { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    public DateTime? LastLoginDate { get; set; }
}
