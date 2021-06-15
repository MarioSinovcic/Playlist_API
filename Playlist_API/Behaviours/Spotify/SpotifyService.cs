using System;
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
        
        public void VerifyToken()
        {
            _spotifyClient = SpotifyClientHelper.RetrieveClient();
        }

        public bool TokenIsValid()
        {
            return SpotifyClientHelper.TokenIsValid();
        }

        public async Task<string> GetGenreId(string genre)
        {
            var request = new CategoriesRequest {Locale = "en_NZ"};
            var genres = await _spotifyClient.Browse.GetCategories(request);
            
            return genres.Categories.Items!.FirstOrDefault(x => NormalisationHelper.Genre(x.Name) == NormalisationHelper.Genre(genre))?.Id;
        }

        public async Task<IPlayableItem> GetRandomSongByGenre(string id)
        {
            var playlists = await _spotifyClient.Browse.GetCategoryPlaylists(id);
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
    }
}