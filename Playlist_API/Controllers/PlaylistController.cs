using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Playlist_API.Database;
using Playlist_Service;

namespace Playlist_API.Controllers
{
    [ApiController]
    public class PlaylistController : Controller
    {
        private readonly IDatabase _database;
        public PlaylistController(IDatabase database)
        {
            _database = database;
        }

        [HttpPut]
        [Route("playlists")]
        public IActionResult CreatePlaylist(Playlist playlist)
        {
            try
            {
                _database.CreatePlaylist(playlist);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        [HttpPost]
        [Route("playlists/{id}")]
        public IActionResult UpdatePlaylist([FromRoute]int id, Playlist playlist)
        {
            try
            {
                _database.UpdatePlaylist(id, playlist);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("playlists")]
        public async Task<IActionResult> GetPlaylists()
        {
            try
            {
                var playlists = _database.GetPlaylists();
                if (playlists.Count == 0) return NotFound("No playlists have been made yet.");
                
                return Ok(JsonConvert.SerializeObject(playlists));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
        
        [HttpGet]
        [Route("playlists/{id}")]
        public IActionResult GetPlaylist([FromRoute]int id) //change this later
        {
            try
            {
                var playlist = _database.GetPlaylist(id);
                return Ok(JsonConvert.SerializeObject(playlist));
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("playlists/{id}")]
        public IActionResult DeletePlaylist([FromRoute]int id)
        {
            try
            {
                _database.DeletePlaylist(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
