using System.Threading.Tasks;

namespace Playlist_API.Behaviours.Spotify
{
    public interface ISpotifyService
    {
        public Task VerifyToken(); 
        public bool TokenIsNotValid();
        
        public Task<string> GetGenreId(string genre);
        
        public Task<object> GetRandomSongByGenre(string genreId);

        public Task<object> GetSongsByName(string name);
        public Task<object> GetSongs();
    }
}