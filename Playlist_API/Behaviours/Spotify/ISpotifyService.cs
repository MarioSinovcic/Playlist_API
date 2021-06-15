using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace Playlist_API.Behaviours.Spotify
{
    public interface ISpotifyService
    {
        public void VerifyToken(); 
        public bool TokenIsValid();
        
        public Task<string> GetGenreId(string genre);
        
        public Task<IPlayableItem> GetRandomSongByGenre(string genre);

        public Task<object> GetSongsByName(string name);
    }
}