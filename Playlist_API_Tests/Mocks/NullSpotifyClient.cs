using System.Threading.Tasks;
using Playlist_API.Behaviours.Spotify;
using SpotifyAPI.Web;

namespace Playlist_API_Tests.Mocks
{
    public class NullSpotifyClient : ISpotifyService
    {
        private readonly bool _tokenIsNotValid;

        public NullSpotifyClient(bool tokenIsNotValid)
        {
            _tokenIsNotValid = tokenIsNotValid;
        }

        public async Task VerifyToken() { }

        public bool TokenIsNotValid()
        {
            return _tokenIsNotValid;
        }

        public Task<string> GetGenreId(string genre)
        {
            return null;
        }

        public Task<object> GetRandomSongByGenre(string genreId)
        {
            return null;
        }

        public Task<object> GetSongsByName(string name)
        {
            return null;
        }
    }
}