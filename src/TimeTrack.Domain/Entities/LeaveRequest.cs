namespace TimeTrack.Domain.Entities;

public class LeaveRequest
{
    public int Id { get; set; }
    public string UserFirebaseUid { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Reason { get; set; }
    public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected
}