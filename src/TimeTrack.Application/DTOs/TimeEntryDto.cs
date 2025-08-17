namespace TimeTrack.Application.DTOs;

public class TimeEntryDto
{
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string Status { get; set; } = string.Empty;
}