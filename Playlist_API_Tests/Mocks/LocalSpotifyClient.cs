using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Playlist_API.Behaviours.Spotify;
using SpotifyAPI.Web;

namespace Playlist_API_Tests.Mocks
{
    public class LocalSpotifyClient : ISpotifyService
    {
        
        private Dictionary<string, string> _localSpotifyData = new()
        {
            {"1", "Hip Hop"},
            {"2", "Pop"},
            {"3", "Rap"}
        }; 
        
        private readonly bool _tokenValidity;

        public LocalSpotifyClient(bool tokenValidity)
        {
            _tokenValidity = tokenValidity;
        }

        public async Task VerifyToken() { }

        public bool TokenIsNotValid()
        {
            return _tokenValidity;
        }

        public async Task<string> GetGenreId(string genre)
        {
            return (from kvp in _localSpotifyData where kvp.Value == genre select kvp.Key).FirstOrDefault();
        }

        public async Task<object> GetRandomSongByGenre(string genreId)
        {
            return "Example Song";
        }

        public Task<object> GetSongsByName(string name)
        {
            return null;
        }

        public Task<object> GetSongs()
        {
            return null;
        }
    }
}