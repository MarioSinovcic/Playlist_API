using System.Linq;
using System.Threading.Tasks;
using SpotifyAPI.Web;

namespace Playlist_API.Behaviours.Spotify
{
    public class SpotifyService : ISpotifyService
    {
        private SpotifyClient _spotifyClient;

        public SpotifyService()
        {
            VerifyToken();
        }
        
        public async Task VerifyToken()
        {
            _spotifyClient = await SpotifyClientHelper.RetrieveClient();
        }

        public bool TokenIsNotValid()
        {
            return SpotifyClientHelper.TokenIsValid();
        }

        public async Task<string> GetGenreId(string genre)
        {
            var request = new CategoriesRequest {Locale = "en_NZ"};
            var genres = await _spotifyClient.Browse.GetCategories(request);
            
            return genres.Categories.Items!.FirstOrDefault(x => NormalisationHelper.Genre(x.Name) == NormalisationHelper.Genre(genre))?.Id;
        }

        public async Task<object> GetRandomSongByGenre(string genreId)
        {
            var playlists = await _spotifyClient.Browse.GetCategoryPlaylists(genreId);
            var playlistId = playlists.Playlists.Items[0].Id;

            var playlist = await _spotifyClient.Playlists.Get(playlistId);
            var track = playlist.Tracks.Items[0].Track;

            return track;
        }

        public async Task<object> GetSongsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return await _spotifyClient.Browse.GetCategories();
            }

            var request = new SearchRequest(SearchRequest.Types.Track, name);
            var track = await _spotifyClient.Search.Item(request);
            return track.Tracks;
        }

        public async Task<object> GetSongs()
        {
            return await _spotifyClient.Browse.GetCategories();
        }
    }
}