using Google.Apis.Auth;
using Microsoft.Extensions.Options;

namespace LoansAnalyzerAPI.OAuthProvider
{
    public class OAuthService
    {
        private readonly OAuthProviderSettings _oAuthSettings;
        public OAuthService(IOptions<OAuthProviderSettings> settings)
        {
            _oAuthSettings = settings.Value;
        }

        public async Task<GoogleJsonWebSignature.Payload> GetPayloadAsync(string credential)
        {
            var settings = PrepareValidationSettings();
            return await GoogleJsonWebSignature.ValidateAsync(credential, settings);
        }

        public GoogleJsonWebSignature.ValidationSettings PrepareValidationSettings()
        {
            return new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { _oAuthSettings.GoogleClientId }
            };
        }
    }
}
