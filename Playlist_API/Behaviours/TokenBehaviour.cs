using System.Threading.Tasks;
using SpotifyAPI.Web;
using SpotifyWebApi.Auth;
using SpotifyWebApi.Model.Auth;

namespace Playlist_API.Behaviours
{
    public static class TokenBehaviour
    {
        private const string SpotifyClientId = "cc67f1c071694b3eabbf884144c558fe";
        private const string SpotifyClientSecret = "1330ca78d28844cea66c08c61cbeb1ae";

        private static Token _token;

        private static async void GenerateToken()
        {
            _token = ClientCredentials.GetToken(new AuthParameters
                {
                    ClientId = SpotifyClientId,
                    ClientSecret = SpotifyClientSecret,
                });
        }


        public static SpotifyClient RetrieveToken()
        {
            if (_token is null || _token.IsExpired)
            {
                GenerateToken();
            }
            return new SpotifyClient(_token.AccessToken);
        }
    }
}