using System.Threading.Tasks;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using SpotifyAPI.Web;
using SpotifyWebApi.Auth;
using SpotifyWebApi.Model.Auth;

namespace Playlist_API.Behaviours.Spotify
{
    public static class SpotifyClientHelper
    {
        private static string _spotifyClientId;
        private static string _spotifyClientSecret;

        private static Token _token;

        private static async Task GenerateToken()
        {
            var ssmClient = new AmazonSimpleSystemsManagementClient();

            var response = await ssmClient.GetParameterAsync(new GetParameterRequest
            {
                Name = "/mario/spotify-api/spotify-client-id",
                WithDecryption = true
            });
            
            _spotifyClientId = response.Parameter.Value; 

            
            response = await ssmClient.GetParameterAsync(new GetParameterRequest
            {
                Name = "/mario/spotify-api/spotify-client-secret",
                WithDecryption = true
            });
            
            _spotifyClientSecret = response.Parameter.Value;

            _token = ClientCredentials.GetToken(new AuthParameters
                {
                    ClientId = _spotifyClientId,
                    ClientSecret = _spotifyClientSecret,
                });
        }


        public static async Task<SpotifyClient> RetrieveClient()
        {
            if (_token is null || _token.IsExpired)
            {
                await GenerateToken();
            }
            return new SpotifyClient(_token?.AccessToken!);
        }

        public static bool TokenIsValid()
        {
            return _token is null || _token.IsExpired;
        }
    }
}