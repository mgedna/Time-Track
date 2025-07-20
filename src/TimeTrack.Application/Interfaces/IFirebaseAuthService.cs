namespace TimeTrack.Application.Interfaces;

public interface IFirebaseAuthService
{
    Task<string?> ValidateTokenAsync(string idToken);
}
