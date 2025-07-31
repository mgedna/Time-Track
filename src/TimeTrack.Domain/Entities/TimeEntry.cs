namespace TimeTrack.Domain.Entities;

public class TimeEntry
{
    public int Id { get; set; }
    public string UserFirebaseUid { get; set; }
    public DateTime ClockIn { get; set; }
    public DateTime? ClockOut { get; set; }
    public TimeSpan TotalHours => (ClockOut ?? DateTime.UtcNow) - ClockIn;
}
