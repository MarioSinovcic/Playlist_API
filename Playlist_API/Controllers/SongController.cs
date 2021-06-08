using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;
using SpotifyWebApi.Auth;

namespace Playlist_API.Controllers
{
    [ApiController]
    public class SongController : ControllerBase
    {
        private static string clientID = "cc67f1c071694b3eabbf884144c558fe";
        private static string clientSecret = "1330ca78d28844cea66c08c61cbeb1ae";
        
        [HttpGet]
        [Route("songs")]
        public async Task<IActionResult> GetSongs()
        {
            try
            {
                var token = ClientCredentials.GetToken(new AuthParameters
                {
                    ClientId = clientID,
                    ClientSecret = clientSecret,
                });
                var spotify = new SpotifyClient(token.AccessToken);
                var track = await spotify.Browse.GetCategories();
                return Ok(track);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        [HttpGet]
        [Route("songs/{name}")]
        public async Task<IActionResult> GetSongs(string name)
        {
            try
            {
                var token = ClientCredentials.GetToken(new AuthParameters
                {
                    ClientId = clientID,
                    ClientSecret = clientSecret,
                });
                var spotify = new SpotifyClient(token.AccessToken);
                var request = new SearchRequest(SearchRequest.Types.Track, name);
                var track = await spotify.Search.Item(request);
                return Ok(track.Tracks);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
