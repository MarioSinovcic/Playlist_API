using System;
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
        public async Task<IActionResult> GetSong([FromQuery(Name = "name")] string name)
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
    }
}
