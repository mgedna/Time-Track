using TimeTrack.Domain.Enums;

namespace TimeTrack.Domain.Entities;

public class OvertimeRequest
{
    public int Id { get; set; }
    public string UserFirebaseUid { get; set; }
    public DateTime Date { get; set; }
    public double Hours { get; set; }
    public LeaveStatus Status { get; set; } = LeaveStatus.Pending;
}
