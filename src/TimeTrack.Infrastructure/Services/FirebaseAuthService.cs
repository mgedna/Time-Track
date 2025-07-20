using FirebaseAdmin;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Options;
using TimeTrack.Application.Interfaces;
using TimeTrack.Domain.Configuration;

namespace TimeTrack.Infrastructure.Services;

public class FirebaseAuthService : IFirebaseAuthService
{
    private readonly FirebaseSettings _firebaseSettings;

    public FirebaseAuthService(IOptions<FirebaseSettings> firebaseOptions)
    {
        _firebaseSettings = firebaseOptions.Value;

        if (FirebaseApp.DefaultInstance == null)
        {
            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile(_firebaseSettings.ServiceAccountPath)
            });
        }
    }

    public async Task<string?> ValidateTokenAsync(string idToken)
    {
        try
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken);
            return payload.Subject;
        }
        catch
        {
            return null;
        }
    }
}
