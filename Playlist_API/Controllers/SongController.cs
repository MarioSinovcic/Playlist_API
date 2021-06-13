using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Playlist_API.Behaviours;
using SpotifyAPI.Web;

namespace Playlist_API.Controllers
{
    [ApiController]
    public class SongController : ControllerBase
    {
        private SpotifyClient _spotifyClient;

        [HttpGet]
        [Route("songs")]
        public async Task<IActionResult> GetSong([FromQuery(Name = "name")] string name) //TODO: multiple params (artist, song)
        {
            try
            {
                _spotifyClient = TokenBehaviour.RetrieveToken();
            }
            catch (Exception)
            {
                return StatusCode(503, "Error obtaining Spotify credentials.");
            }

            try
            {
                if (String.IsNullOrEmpty(name))
                {
                    var track = await _spotifyClient.Browse.GetCategories();
                    return Ok(track);
                }
                else
                {
                    var request = new SearchRequest(SearchRequest.Types.Track, name);
                    var track = await _spotifyClient.Search.Item(request);
                    return Ok(track.Tracks);
                }
            }
            catch (Exception e)
            {
                //ErrorChecker.Check(e)
                return StatusCode(500);
            }
        }
        
        [HttpGet]
        [Route("song/{genre}")]
        public async Task<IActionResult> GetRandomSong(string genre) //TODO: multiple params (artist, song)
        {
            try
            {
                _spotifyClient = TokenBehaviour.RetrieveToken();
            }
            catch (Exception)
            {
                return StatusCode(503, "Error obtaining Spotify credentials.");
            }

            try
            {
                var request = new CategoriesRequest {Locale = "en_NZ"};
                var genres = await _spotifyClient.Browse.GetCategories(request);
                var id = genres.Categories.Items.FirstOrDefault(x => x.Name == genre)?.Id;

                if (id == null)
                {
                    return StatusCode(404, "That genre doesn't exist. >:|");
                }
                
                var playlists = await _spotifyClient.Browse.GetCategoryPlaylists(id);
                var playlistId = playlists.Playlists.Items[0].Id;

                var playlist = await _spotifyClient.Playlists.Get(playlistId);
                var track = playlist.Tracks.Items[0].Track;

                return Ok(track);
            }
            catch (Exception e)
            {
                //ErrorChecker.Check(e)
                return StatusCode(500);
            }
        }
    }
}
