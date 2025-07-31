namespace TimeTrack.Domain.Entities;

public class OvertimeRequest
{
    public int Id { get; set; }
    public string UserFirebaseUid { get; set; }
    public DateTime Date { get; set; }
    public double Hours { get; set; }
    public string Status { get; set; } = "Pending";
}
