using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Playlist_API.Behaviours.Spotify;

namespace Playlist_API.Controllers
{
    [ApiController]
    public class SongController : ControllerBase
    {
        private readonly ISpotifyService _spotifyService;
        public SongController(ISpotifyService spotifyService)
        {
            _spotifyService = spotifyService;
        }

        [HttpGet]
        [Route("songs")]
        public async Task<IActionResult> GetSongs([FromQuery(Name = "name")] string name) 
        {
            _spotifyService.VerifyToken();
            if (_spotifyService.TokenIsNotValid()) return StatusCode(503, "Error obtaining Spotify credentials.");

            try
            {
                var songs = await _spotifyService.GetSongsByName(name);
                return Ok(songs);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        [HttpGet]
        [Route("song/{genre}")]
        public async Task<IActionResult> GetRandomSong(string genre)
        {
            _spotifyService.VerifyToken();
            if (_spotifyService.TokenIsNotValid()) return StatusCode(503, "Error obtaining Spotify credentials.");

            try
            {
                var id = await _spotifyService.GetGenreId(genre);
                if (id == null) 
                    return StatusCode(404, "That genre doesn't exist.");

                var track = await _spotifyService.GetRandomSongByGenre(id);
                return Ok(track);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
