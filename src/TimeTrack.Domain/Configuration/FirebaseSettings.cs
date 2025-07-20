namespace TimeTrack.Domain.Configuration;

public class FirebaseSettings
{
    public const string Key = nameof(FirebaseSettings);
    public string ServiceAccountPath { get; set; } = string.Empty;
}
