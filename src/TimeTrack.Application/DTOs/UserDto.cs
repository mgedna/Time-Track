namespace TimeTrack.Application.DTOs;

public class UserDto
{
    public string FirebaseUid { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = "Employee";
    public bool IsActive { get; set; } = true;
    public DateTime DateCreated { get; set; }
}